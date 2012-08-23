using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dem0n13.Replacer.Library.Lazy;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library
{
    public class TextReplacer : TextLengthChanger
    {
        private readonly LazyString _workingText;
        private int TailStartIndex { get { return _workingText.Length - _workingText.Last.Value.Length; } }

        public TextReplacer(string text)
        {
            _workingText = new LazyString(text);
            TotalLegthCorrection = new Boxed<int>();
        }

        public void Replace(RelatedLocation location, LazyString replacement)
        {
            // only tail replacing
            if (location.StartIndex < TailStartIndex) return;

            var tail = _workingText.Last.Value;

            var beforeLength = location.StartIndex - TailStartIndex;
            var afterLength = tail.Length - beforeLength - location.Length;

            _workingText.RemoveLast();

            // tail_1_2_3 -> tail_1 + replacement + tail_3
            if (beforeLength > 0) _workingText.Append(tail.Substring(0, beforeLength));
            _workingText.Append(replacement);
            if (afterLength > 0) _workingText.Append(tail.Substring(beforeLength + location.Length, afterLength));
            
            TotalLegthCorrection.Value += replacement.Length - location.Length;
        }

        public string BuildResult()
        {
            return _workingText.BuildToString();
        }

        public override string ToString()
        {
            return _workingText.ToString();
        }
    }
}
