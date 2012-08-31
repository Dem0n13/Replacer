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
                if (!_initialized) Debug.WriteLine("!_initialized");
                return _initialized && _microTasks.Any(task => task.Updated);
            }
        }

        public ProgressChangedEventArgs GetStatistics()
        {
            // обновляем статистику для каждого файла
            for (var i = 0; i < _microTasks.Length; i++)
                if (_microTasks[i].Updated)
                    _statisticsVector[i] = _microTasks[i].GetStatistics();

            // обнуляем предыдущий вектор статистики
            foreach (var state in MicroTaskStatesHelper.StatesArray) _stateVector[state] = 0;

            // считаем общий процент и заполняем вектор
            var sPercentage = 0.0;
            foreach (var microTaskStat in _statisticsVector)
            {
                sPercentage += microTaskStat.Percentage;
                foreach (var state in MicroTaskStatesHelper.StatesArray) 
                    if (microTaskStat.State.HasFlag(state))
                        _stateVector[state]++;
                    else break;
            }
            sPercentage /= _microTasks.Length;

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
            Debug.WriteLine("Time initialization: {0}", sw.Elapsed);
            Parallel.ForEach(_microTasks, options, task => task.Run(cancellationToken));

            Debug.WriteLine("Time All: {0}", sw.Elapsed);
        }

        public void Cancel()
        {
            var i = 0;
            foreach (var microTask in _microTasks)
            {
                Debug.WriteLine("Cancel " + i + ": ");
                microTask.Cancel();
                i++;
            }
        }
    }
}
