using System;

namespace Dem0n13.Replacer.Library.Tasks
{
    public interface IProgress<T> where T: EventArgs
    {
        event EventHandler<T> ProgressChanged;
        event EventHandler Completed;
        void Report(object sender, ManagerProgressChangedEventArgs args);
        void Report(ManagerProgressChangedEventArgs args);
        void Complete();
    }
}