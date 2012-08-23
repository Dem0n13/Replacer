using System.ComponentModel;

namespace Dem0n13.Replacer.Library.Tasks
{
    public class ManagerProgressChangedEventArgs : ProgressChangedEventArgs
    {
        public int CurrentItem { get; private set; }

        public ManagerProgressChangedEventArgs(int currentItem, int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
            CurrentItem = currentItem;
        }

        public ManagerProgressChangedEventArgs(int currentItem, ProgressChangedEventArgs args)
            : base(args.ProgressPercentage, args.UserState)
        {
            CurrentItem = currentItem;
        }
    }
}