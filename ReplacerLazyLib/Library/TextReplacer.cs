using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dem0n13.Replacer.LazyLibrary;

namespace Dem0n13.Replacer.Library
{
    public class TextReplacer : INotifyLengthChanged
    {
        private LazyString _workingText;
        private int _tailStartIndex { get { return _workingText.Length - _workingText.Last.Value.Length; } }

        public event EventHandler<LengthChangedEventArgs> LengthChanged;

        public void Replace(RelatedLocation location, LazyString replacement)
        {
            // tail replacing
            if (location.StartIndex < _tailStartIndex) return;

            var tail = _workingText.Last.Value;

            var beforeLength = location.StartIndex - _tailStartIndex;
            var afterLength = tail.Length - beforeLength - location.Length;

            _workingText.RemoveLast();

            // tail_1_2_3 -> tail_1 + replacement + tail_3
            if (beforeLength > 0) _workingText.Append(tail.Substring(0, beforeLength));
            _workingText.Append(replacement);
            if (afterLength > 0) _workingText.Append(tail.Substring(beforeLength + location.Length, afterLength));

            if (location.Length != replacement.Length)
            {
                var e = new LengthChangedEventArgs(_workingText.Length, _workingText.Length += replacement.Length - location.Length, location.StartIndex + location.Length);
                OnLengthChanged(e);
            }
        }

        private void OnLengthChanged(LengthChangedEventArgs e)
        {
            var handler = LengthChanged;
            if (handler != null) handler(this, e);
        }

        public string BuildResult(bool unsubscribe = false)
        {
            if (unsubscribe) LengthChanged = null;
            return _workingText.BuildToString();
        }

        public override string ToString()
        {
            return _workingText.ToString();
        }
    }
}
