using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Dem0n13.Replacer.Library.Tasks
{
    public sealed class TaskManager
    {
        public List<Task> Tasks = new List<Task>();
        private Timer _refresher;
        private readonly IProgress _progress;
        private CancellationToken _cancellation;
        private CancellationTokenSource _cancellationSource;
        private const int DefaultRefresherPeriod = 250;
        private const int MaxRefresherPeriod = 2000;
        private int _refresherPeriod = DefaultRefresherPeriod;
        private int _currentTaskIndex;
        private TaskFactory _taskFactory = new TaskFactory();

        public bool Busy { get; private set; }

        private int RefresherPeriod
        {
            get { return _refresherPeriod; }
            set
            {
                if (value > MaxRefresherPeriod ||
                    value < DefaultRefresherPeriod) return;
                _refresherPeriod = value;
                if (_refresher != null) _refresher.Change(value, value);
            }
        }

        public TaskManager(IProgress progress)
        {
            _progress = progress ?? new Progress();
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
                RefresherPeriod /= 2;
            }
            else
            {
                RefresherPeriod *= 2;
            }
        }

        private void Complete()
        {          
            RefreshStatisticsForced();
            Busy = false;
            RefreshStatisticsForced();
        }

        public void RunAllAsync()
        {
            // cancellation
            _cancellationSource = new CancellationTokenSource();
            _cancellation = _cancellationSource.Token;

            Busy = true;

            // progress
            _refresher = new Timer(state => RefreshStatistics(), null, 0, DefaultRefresherPeriod);

            _taskFactory.StartNew(() =>
                {
                    for (var i = 0; i < Tasks.Count; i++)
                    {
                        _currentTaskIndex = i;
                        Debug.WriteLine("rTask" + _currentTaskIndex); //TODO DEBUG
                        Tasks[_currentTaskIndex].Run(_cancellation);
                        RefreshStatistics();
                    }
                })
                .ContinueWith(_ =>
                    {
                        _refresher.Dispose();
                        _refresher = null;
                        if (!_cancellation.IsCancellationRequested) Complete();
                    });
        }

        public void StopAsync()
        {
            Debug.WriteLine("StopAsync"); //TODO DEBUG
            _cancellationSource.Cancel();
        }

        public void CancelAsync()
        {
            Busy = true;
            Debug.WriteLine("CancelAsync"); //TODO DEBUG
            _cancellationSource.Cancel();
            _taskFactory.StartNew(() =>
                {
                    Tasks.ForEach(task => task.Cancel());
                    RefreshStatisticsForced();
                })
                .ContinueWith(_ => Complete());
        }
    }
}