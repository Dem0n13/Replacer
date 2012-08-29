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
        public List<ReplacerTask> Tasks = new List<ReplacerTask>();
        private readonly IProgress _progress;
        private  CancellationToken _cancellation;
        private CancellationTokenSource _cancellationSource;
        public bool Busy { get; private set; }

        public ReplacerTaskManager(IProgress progress)
        {
            _progress = progress;
        }

        public void RunAllAsync()
        {
            Debug.WriteLine("RunAllAsync"); //TODO DEBUG

            // cancellation
            _cancellationSource = new CancellationTokenSource();
            _cancellation = _cancellationSource.Token;

            // progress
            if (_progress != null)
                for (var i = 0; i < Tasks.Count; i++)
                {
                    var taskIndex = i;
                    Tasks[i].ProgressChanged +=
                        (sender, args) => _progress.Report(sender, new ManagerProgressChangedEventArgs(taskIndex, args));
                }

            Task.Factory.StartNew(() => Busy = true)
                .ContinueWith(_ =>
                    {
                        foreach (var replacerTask in Tasks)
                        {
                            Debug.WriteLine("rTask"); //TODO DEBUG
                            replacerTask.Run(_cancellation);
                        }
                    }, _cancellation
                )
                .ContinueWith(_ => Busy = false)
                .ContinueWith(_ =>
                    {
                        if (_progress != null) _progress.Report(null);
                    });
            Debug.WriteLine("endRunAll"); //TODO DEBUG
        }

        public void StopAsync()
        {
            Debug.WriteLine("StopAsync"); //TODO DEBUG
            _cancellationSource.Cancel(true);
        }

        public void CancelAsync()
        {
            Debug.WriteLine("CancelAsync"); //TODO DEBUG
            _cancellationSource.Cancel(false);
        }
    }
}