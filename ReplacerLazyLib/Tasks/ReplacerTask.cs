using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class ReplacerTask
    {
        public const int InitialRefreshPeriod = 250;
        private readonly TextFile[] _files;
        private readonly RegexProcessor _regexProcessor;
        private readonly Replacement _replacement;
        private ReplacerMicroTask[] _replacerMicroTasks;

        private readonly Dictionary<MicroTaskStates, int> _stateVector =
            Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>().ToDictionary(o => o, o => 0);

        #region Statistics

        private Timer _refresher;
        private int _currentRefreshPeriod = InitialRefreshPeriod;
        private double _percentage;

        private int CurrentRefreshPeriod
        {
            get { return _currentRefreshPeriod; }
            set
            {
                if ((_refresher == null) || (value == _currentRefreshPeriod)) return;
                _currentRefreshPeriod = value;
                _refresher.Change(value, value);
            }
        }

        private double Percentage
        {
            get { return _percentage; }
            set
            {
                if (Math.Abs(value - Percentage) < 1.0)
                {
                    CurrentRefreshPeriod += 100;
                }
                else
                {
                    CurrentRefreshPeriod = InitialRefreshPeriod;
                    _percentage = value;
                    OnProgressChanged();
                }
            }
        }

        private void RefreshStatistics(object notUsed = null)
        {
            double percentage;
            lock (_stateVector)
            {
                percentage = _replacerMicroTasks.Average(task => task.Percentage);

                foreach (var state in ReplacerMicroTask.StatesArray)
                {
                    _stateVector[state] = 0; // reset old vector
                    foreach (var microTask in _replacerMicroTasks)
                        if (microTask.State.HasFlag(state))
                            _stateVector[state]++; // fill new values
                }
            }

            Percentage = percentage;
        }

        private void OnProgressChanged()
        {
            var e = new ProgressChangedEventArgs((int) Math.Round(Percentage), _stateVector);

            Debug.WriteLine("{0}%, {1}", e.ProgressPercentage, String.Join(",", _stateVector));

            var handler = ProgressChanged;
            if (handler != null) handler(this, e);
        }

        #endregion

        public event ProgressChangedEventHandler ProgressChanged;

        public ReplacerTask(IEnumerable<TextFile> files, string regularExpression,
                            string replacementExpression, object options = null)
        {
            _regexProcessor = new RegexProcessor(regularExpression);
            _replacement = new Replacement(replacementExpression);
            _files = files.ToArray();
        }

        public void Run(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();

            var options = new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount};

            if (_replacerMicroTasks == null)
            {
                _replacerMicroTasks = new ReplacerMicroTask[_files.Length];
                Parallel.For(0, _files.Length,
                             options, i => _replacerMicroTasks[i] = new ReplacerMicroTask(_files[i], _regexProcessor, _replacement));
            }
            
            _refresher = new Timer(RefreshStatistics, null, 0, CurrentRefreshPeriod);
            
            Parallel.ForEach(_replacerMicroTasks, options, task => task.Run(cancellationToken));

            RefreshStatistics();
            _refresher.Dispose();

            Debug.WriteLine("Time: {0}", sw.Elapsed);
            /*Debug.WriteLine("Regex all: {0}, delta: {1}", new TimeSpan(RegexProcessor.PerfomanceCounter),
                            new TimeSpan(ReplacerMicroTask.PerfomanceVector[MicroTaskStates.Searching] -
                                         RegexProcessor.PerfomanceCounter));*/
        }
    }
}
