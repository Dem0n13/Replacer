﻿using System;
using System.Threading.Tasks;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class Progress : IProgress<ManagerProgressChangedEventArgs>
    {
        public event EventHandler<ManagerProgressChangedEventArgs> ProgressChanged;
        public event EventHandler Completed;
        private readonly TaskFactory _uiFactory;

        public Progress()
        {
            _uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void Report(ManagerProgressChangedEventArgs args)
        {
            Report(this, args);
        }

        public void Report(object sender, ManagerProgressChangedEventArgs args)
        {
            _uiFactory.StartNew(() =>
            {
                var handler = ProgressChanged;
                if (handler != null)
                    handler(sender, args);
            }).Wait();
        }

        public void Complete()
        {
            _uiFactory.StartNew(() =>
            {
                var handler = Completed;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }).Wait();
        }
    }
}
