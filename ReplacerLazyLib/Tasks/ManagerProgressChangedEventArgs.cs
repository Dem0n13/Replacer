using System;
using System.ComponentModel;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class ManagerProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public int TaskIndex { get; private set; }

        public ManagerProgressChangedEventArgs(int taskIndex, int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
            TaskIndex = taskIndex;
        }

        public ManagerProgressChangedEventArgs(int taskIndex, ProgressChangedEventArgs args)
            : base(args.ProgressPercentage, args.UserState)
        {
            TaskIndex = taskIndex;
        }
    }
}