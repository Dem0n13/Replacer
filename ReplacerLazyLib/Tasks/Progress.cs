using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class Progress : IProgress
    {
        public event EventHandler<ManagerProgressChangedEventArgs> ProgressChanged;
        public TaskScheduler Scheduler { get; private set; }

        public Progress()
        {
            Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public void Report(ManagerProgressChangedEventArgs args)
        {
            Report(this, args);
        }

        public void Report(object sender, ManagerProgressChangedEventArgs args)
        {
            Debug.WriteLine("Report"); //TODO DEBUG
            Task.Factory.StartNew(() =>
            {
                var handler = ProgressChanged;
                if (handler != null)
                    handler(sender, args);
            }, CancellationToken.None, TaskCreationOptions.None, Scheduler);
        }
    }
}
