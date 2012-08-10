using System;

namespace Dem0n13.Replacer.Library
{
    public class LengthChangedEventArgs: EventArgs
    {
        public readonly int OldLength;
        public readonly int CurrentLength;
        public readonly int StartChangingIndex;
        public int Delta { get { return CurrentLength - OldLength; } }

        public LengthChangedEventArgs(int oldLength, int currentLength, int startChangingIndex)
        {
            OldLength = oldLength;
            CurrentLength = currentLength;
            StartChangingIndex = startChangingIndex;
        }
    }
}