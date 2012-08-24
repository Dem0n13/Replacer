using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class ReplacerTaskManager
    {
        public List<ReplacerTask> Tasks = new List<ReplacerTask>();
        public event EventHandler<ManagerProgressChangedEventArgs> ProgressChanged;
        private readonly TaskScheduler _uiThread;

        public void OnProgressChanged(ManagerProgressChangedEventArgs e)
        {
            Debug.WriteLine("OnProgressChanged(ManagerProgressChangedEventArgs e)");
            var handler = ProgressChanged;
            if (handler != null) handler(this, e);
        }

        public ReplacerTaskManager(TaskScheduler fromCurrentSynchronizationContext)
        {
            _uiThread = fromCurrentSynchronizationContext;
            //Debug.WriteLine(_uiThread == Task.Factory);
        }

        public void RunAll()
        {
            var i = 0; 
            Tasks.ForEach(task => task.ProgressChanged += (sender, args) => Task.Factory.StartNew(
                () => OnProgressChanged(new ManagerProgressChangedEventArgs(i++, args)),CancellationToken.None,TaskCreationOptions.None, _uiThread));

            var workTask = Task.Factory.StartNew(() => { }, TaskCreationOptions.PreferFairness);
            foreach (var replacerTask in Tasks)
            {
                var rTask = replacerTask;
                workTask.ContinueWith(_ => rTask.Run());
            }
        }

        public void Stop()
        {
            
        }

        public void Cancel()
        {
            
        }
    }
}