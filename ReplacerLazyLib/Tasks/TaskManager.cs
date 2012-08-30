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

        private readonly IProgress<ManagerProgressChangedEventArgs> _progress;
        private CancellationToken _cancellation;
        private CancellationTokenSource _cancellationSource;
        //
        private readonly ActionRepeater _actionRepeater;
        // TODO old
        private Timer _refresher;
        private const int DefaultRefresherPeriod = 250;
        private const int MaxRefresherPeriod = 2000;
        private int _refresherPeriod = DefaultRefresherPeriod;
        //
        private int _currentTaskIndex;
        private readonly TaskFactory _taskFactory = new TaskFactory();

        public bool Busy { get; private set; }

        private int RefresherPeriod // TODO old
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

        public TaskManager(IProgress<ManagerProgressChangedEventArgs> progress)
        {
            _progress = progress ?? new Progress();
            _actionRepeater = new ActionRepeater(RefreshStatistics);
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
                RefresherPeriod /= 2; // TODO old
                _actionRepeater.TimeDecrement();
            }
            else
            {
                RefresherPeriod *= 2; // TODO old
                _actionRepeater.TimeIncrement();
            }
        }

        private void Complete()
        {          
            //RefreshStatisticsForced();
            Busy = false;
            //RefreshStatisticsForced();
            _actionRepeater.Stop(true);
        }

        public void RunAllAsync()
        {
            // cancellation
            _cancellationSource = new CancellationTokenSource();
            _cancellation = _cancellationSource.Token;

            Busy = true;

            // progress
            //_refresher = new Timer(state => RefreshStatistics(), null, 0, DefaultRefresherPeriod);// TODO old
            _actionRepeater.Start(true);
            
            _taskFactory.StartNew(() =>
                {
                    for (var i = 0; i < Tasks.Count; i++)
                    {
                        _currentTaskIndex = i;
                        Debug.WriteLine("rTask" + _currentTaskIndex); //TODO DEBUG
                        Tasks[_currentTaskIndex].Run(_cancellation);
                        RefreshStatisticsForced();
                    }
                })
                .ContinueWith(_ =>
                    {
                        //_refresher.Dispose();// TODO old
                        //_refresher = null;// TODO old
                        //_actionRepeater.Stop(true);
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
            _actionRepeater.Start(true);
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