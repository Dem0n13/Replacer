using System;
using System.ComponentModel;

namespace Dem0n13.Replacer.Library.Tasks
{
    public interface IProgress
    {
        void Report(object sender, ManagerProgressChangedEventArgs args);
        void Report(ManagerProgressChangedEventArgs args);
        event EventHandler<ManagerProgressChangedEventArgs> ProgressChanged;
    }
}