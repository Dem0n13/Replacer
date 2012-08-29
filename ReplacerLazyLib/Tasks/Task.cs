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
    public class Task
    {
        private bool _initialized;
        private readonly TextFile[] _files;
        private readonly RegexProcessor _regexProcessor;
        private readonly Replacement _replacement;
        private readonly MicroTask[] _microTasks;
        private readonly MicroTaskStatistics[] _statisticsVector;
        private readonly Dictionary<MicroTaskStates, int> _stateVector =
            Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>().ToDictionary(o => o, o => 0);

        #region Statistics

        public bool Updated
        {
            get
            {
                return _initialized && _microTasks.Any(task => task.Updated);
            }
        }

        public ProgressChangedEventArgs GetStatistics()
        {
            for (var i = 0; i < _microTasks.Length; i++)
            {
                if (_microTasks[i].Updated)
                {
                    _statisticsVector[i] = _microTasks[i].GetStatistics();
                }
            }

            var sPercentage = _statisticsVector.Average(statistics => statistics.Percentage);
            foreach (var state in Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>())
            {
                _stateVector[state] = 0; // reset old vector
                foreach (var microTask in _statisticsVector)
                    if (microTask.State.HasFlag(state))
                        _stateVector[state]++; // fill new values
            }
            
            Debug.WriteLine("{0}%, {1}", sPercentage, String.Join(",", _stateVector));
            return new ProgressChangedEventArgs((int) Math.Round(sPercentage), _stateVector);
        }

        #endregion

        public Task(IEnumerable<TextFile> files, string regularExpression,
                            string replacementExpression, object options = null)
        {
            _regexProcessor = new RegexProcessor(regularExpression);
            _replacement = new Replacement(replacementExpression);
            _files = files.ToArray();
            _microTasks = new MicroTask[_files.Length];
            _statisticsVector = new MicroTaskStatistics[_files.Length];
        }

        public void Run(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();

            var options = new ParallelOptions {MaxDegreeOfParallelism = Environment.ProcessorCount};

            if (!_initialized)
            {
                Parallel.For(0, _files.Length,
                             options, i =>
                                 {
                                     _microTasks[i] = new MicroTask(_files[i], _regexProcessor, _replacement);
                                     _statisticsVector[i] = _microTasks[i].GetStatistics();
                                 });
                _initialized = true;
            }

            Parallel.ForEach(_microTasks, options, task => task.Run(cancellationToken));

            Debug.WriteLine("Time: {0}", sw.Elapsed);
        }

        public void Cancel()
        {
            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
            Parallel.ForEach(_microTasks, options, task => task.Cancel());
        }
    }
}
