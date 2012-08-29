using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Dem0n13.Replacer.Library.Tasks
{
    public sealed class ReplacerTaskManager
    {
        public List<Task> Tasks = new List<Task>();
        private Timer _refresher;
        private readonly IProgress _progress;
        private  CancellationToken _cancellation;
        private CancellationTokenSource _cancellationSource;
        private const int DefaultRefresherPeriod = 250;
        private int _refresherPeriod = DefaultRefresherPeriod;
        private int _currentTaskIndex;

        public bool Busy { get; private set; }

        private int RefresherPeriod
        {
            get { return _refresherPeriod; }
            set
            {
                if (_refresher == null) return;
                _refresherPeriod = value;
                _refresher.Change(value, value);
                Debug.WriteLine("RefresherPeriod=" + value); //TODO DEBUG
            }
        }

        public ReplacerTaskManager(IProgress progress)
        {
            _progress = progress;
        }

        private void RefreshStatistics()
        {
            if (_progress == null) return;

            if (Tasks[_currentTaskIndex].Updated)
            {
                _progress.Report(Tasks[_currentTaskIndex],
                                 new ManagerProgressChangedEventArgs(_currentTaskIndex, Tasks[_currentTaskIndex].GetStatistics()));
                RefresherPeriod = DefaultRefresherPeriod;
            }
            else
            {
                RefresherPeriod += 100;
            }
        }

        private void Complete()
        {
            Busy = false;
            if (_progress == null) return;
            _refresher = null;
            _progress.Report(Tasks[_currentTaskIndex],
                                 new ManagerProgressChangedEventArgs(_currentTaskIndex, Tasks[_currentTaskIndex].GetStatistics()));
        }

        public void RunAllAsync()
        {
            // cancellation
            _cancellationSource = new CancellationTokenSource();
            _cancellation = _cancellationSource.Token;

            // progress
            if (_progress != null)
                _refresher = new Timer(state => RefreshStatistics(), null, 0, DefaultRefresherPeriod);

            System.Threading.Tasks.Task.Factory.StartNew(() => Busy = true)
                .ContinueWith(_ =>
                    {
                        for (var i = 0; i < Tasks.Count; i++)
                        {
                            _currentTaskIndex = i;
                            Debug.WriteLine("rTask" + _currentTaskIndex); //TODO DEBUG
                            Tasks[_currentTaskIndex].Run(_cancellation);
                            RefreshStatistics();
                        }
                    }, _cancellation
                )
                .ContinueWith(_ => Complete());
        }

        public void StopAsync()
        {
            Debug.WriteLine("StopAsync"); //TODO DEBUG
            _cancellationSource.Cancel();
        }

        public void CancelAsync()
        {
            Debug.WriteLine("CancelAsync"); //TODO DEBUG
            _cancellationSource.Cancel();
            System.Threading.Tasks.Task.Factory.StartNew(() => Tasks.ForEach(task => task.Cancel()));
        }
    }
}