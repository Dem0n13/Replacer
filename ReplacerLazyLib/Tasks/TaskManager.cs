using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Dem0n13.Replacer.Library.Tasks
{
    public sealed class TaskManager
    {
        public static Logger Log = LogManager.GetCurrentClassLogger();

        public List<Task> Tasks = new List<Task>();

        private readonly IProgress<ManagerProgressChangedEventArgs> _progress;
        private CancellationToken _cancellation;
        private CancellationTokenSource _cancellationSource;
        //
        private readonly ActionRepeater _statRefresher;
        //
        private int _currentTaskIndex;
        private readonly TaskFactory _taskFactory = new TaskFactory();

        public bool Busy { get; private set; }

        public TaskManager(IProgress<ManagerProgressChangedEventArgs> progress)
        {
            _progress = progress ?? new Progress();
            _statRefresher = new ActionRepeater(RefreshStatistics);
        }

        private void RefreshStatisticsForced()
        {
            var args = new ManagerProgressChangedEventArgs(_currentTaskIndex, Tasks[_currentTaskIndex].GetStatistics());
            _progress.Report(Tasks[_currentTaskIndex], args);
        }

        private void RefreshStatistics()
        {
            if (Tasks[_currentTaskIndex].Updated)
            {
                RefreshStatisticsForced();
                _statRefresher.DecPeriod();
            }
            else
            {
                _statRefresher.IncPeriod();
            }
        }

        private void Complete()
        {
            Log.Debug("Complete()");
            Busy = false;
            _statRefresher.Stop(true);
            _progress.Complete();
        }

        public void RunAllAsync()
        {
            // cancellation
            _cancellationSource = new CancellationTokenSource();
            _cancellation = _cancellationSource.Token;

            Busy = true;
            Log.Debug("Busy = true");

            // progress
            _statRefresher.Start(false);

            _taskFactory.StartNew(() =>
                {
                    for (var i = 0; i < Tasks.Count; i++)
                    {
                        _currentTaskIndex = i;
                        Tasks[_currentTaskIndex].Run(_cancellation);
                        RefreshStatisticsForced();
                    }
                })
                .ContinueWith(_ =>
                    {
                        if (!_cancellation.IsCancellationRequested) Complete();
                    });
        }

        public void StopAsync()
        {
            _cancellationSource.Cancel();
        }

        public void CancelAsync()
        {
            Log.Debug("CancelAsync(), Busy={0}", Busy);
            Busy = true;
            _cancellationSource.Cancel();
            _statRefresher.Start(true);
            _taskFactory.StartNew(() =>
                {
                    for (var i = 0; i < Tasks.Count; i++)
                    {
                        _currentTaskIndex = i;
                        Tasks[_currentTaskIndex].Cancel();
                        RefreshStatisticsForced();
                    }
                })
                .ContinueWith(_ => Complete());
        }
    }
}