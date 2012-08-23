using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library
{
    public class ReplacementTask
    {
        private readonly TextFile[] _files;
        private readonly RegexProcessor _regexProcessor;
        private readonly Replacement _replacement;
        private readonly Dictionary<MicroTaskStates, int> _stateVector;
        private readonly double _percentagePerFilePerStage;
        private double _percentage;
        private Timer _timer;

        public int RefreshPeriod
        {
            get { return _refreshPeriod; }
            private set
            {
                if (Equals(value, _refreshPeriod)) return;
                //_timer.Change(_refreshPeriod, _refreshPeriod);
                _refreshPeriod = value;
            }
        }

        public event ProgressChangedEventHandler ProgressChanged;

        private void OnProgressChanged(object notUsed)
        {
            var sw = Stopwatch.StartNew();

            double percentage;
            lock (_stateVector)
            {
                foreach (var state in MicroTask.StatesArray)
                {
                    _stateVector[state] = 0; // reset old vector
                    foreach (var microTask in _microTasks)
                        if (microTask.State.HasFlag(state))
                            _stateVector[state]++; // fill new values
                }

                percentage = MicroTask.StatesArray.Sum(state => _stateVector[state]*_percentagePerFilePerStage);
            }
            
            if (Math.Abs(percentage - _percentage) < double.Epsilon)
            {
                RefreshPeriod += 100;
                Debug.WriteLine("_refreshPeriod =" + RefreshPeriod);
                return;
            }

            RefreshPeriod -= 100;
            _percentage = percentage;

            var e = new ProgressChangedEventArgs((int) Math.Round(percentage), _stateVector);

            Debug.WriteLine("Time: {0}, {1}%, {2}", sw.Elapsed, percentage, String.Join(",", _stateVector));
            sw.Stop();

            var handler = ProgressChanged;
            if (handler != null) handler(this, e);
        }

        private MicroTask[] _microTasks;
        private int _refreshPeriod = 500;

        public ReplacementTask(IEnumerable<TextFile> files, string regularExpression,
                    string replacementExpression, object options = null)
        {
            _regexProcessor = new RegexProcessor(regularExpression);
            _replacement = new Replacement(replacementExpression);
            _files = files.ToArray();

            _stateVector = Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>().ToDictionary(o => o, o => 0);
            _percentagePerFilePerStage = 100.0/_files.Length/(_stateVector.Count);
        }

        public void Run()
        {
            var sw = Stopwatch.StartNew();
            
            var options = new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount};

            if (_microTasks == null)
            {
                _microTasks = new MicroTask[_files.Length];
                Parallel.For(0, _files.Length,
                             options, i => _microTasks[i] = new MicroTask(_files[i], _regexProcessor, _replacement));
            }

            _timer = new Timer(OnProgressChanged, null, 0, RefreshPeriod);

            Parallel.ForEach(_microTasks, options, task => task.Run());

            OnProgressChanged(null);
            _timer.Dispose();

            Debug.WriteLine(Environment.NewLine + sw.Elapsed);
        }
    }
}
