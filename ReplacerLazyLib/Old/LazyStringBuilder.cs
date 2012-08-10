using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Dem0n13.Replacer.LazyLibrary;
using Dem0n13.Replacer.Library;

namespace ReplacerLazyLib
{
    public class LazyStringBuilder : INotifyLengthChanged
    {
        private LazyString _substrings;
        private int _tailStartIndex { get { return Length - _substrings.Last.Value.Length; } }

        public int Length { get; private set; }

        public event EventHandler<LengthChangedEventArgs> LengthChanged;

        public LazyStringBuilder(string source)
        {
            _substrings = new LazyString();
            _substrings.AddFirst(new LazySubstring(source));
            Length = source.Length;
        }

        public void Replace(RelatedLocation location, string replacement)
        {
            // tail replacing
            if (location.StartIndex < _tailStartIndex) return;

            var tail = _substrings.Last.Value;

            var beforeLength = location.StartIndex - _tailStartIndex;
            var afterLength = tail.Length - beforeLength - location.Length;

            _substrings.RemoveLast();

            if (beforeLength > 0) _substrings.AddLast(new LazySubstring(tail.Source, tail.StartIndex, beforeLength));
            _substrings.AddLast(new LazySubstring(replacement));
            if (afterLength > 0) _substrings.AddLast(new LazySubstring(tail.Source, tail.StartIndex + beforeLength + location.Length, afterLength));

            if (location.Length!=replacement.Length)
            {
                var e = new LengthChangedEventArgs(Length, Length += replacement.Length - location.Length, location.StartIndex + location.Length);
                OnLengthChanged(e);
            }
        }

        public void Replace(RelatedLocation location, LazyString replacement)
        {
            // tail replacing
            if (location.StartIndex < _tailStartIndex) return;

            var tail = _substrings.Last.Value;

            var beforeLength = location.StartIndex - _tailStartIndex;
            var afterLength = tail.Length - beforeLength - location.Length;

            _substrings.RemoveLast();

            if (beforeLength > 0) _substrings.AddLast(new LazySubstring(tail.Source, tail.StartIndex, beforeLength));
            foreach (var r in replacement) _substrings.AddLast(r);
            if (afterLength > 0) _substrings.AddLast(new LazySubstring(tail.Source, tail.StartIndex + beforeLength + location.Length, afterLength));

            if (location.Length != replacement.Length)
            {
                var e = new LengthChangedEventArgs(Length, Length += replacement.Length - location.Length, location.StartIndex + location.Length);
                OnLengthChanged(e);
            }
        }

        public string BuildToString(bool unsubscribe = true)
        {
            if (_substrings.Count == 1)
            {
                return _substrings.First.Value.BuildToString();
            }

            var builder = new StringBuilder(Length);
            foreach (var substr in _substrings)
            {
                builder.Append(substr.BuildToString());
            }

            _substrings.Clear();
            _substrings.AddFirst(new LazySubstring(builder.ToString()));

            return builder.ToString();
        }

        private void OnLengthChanged(LengthChangedEventArgs e)
        {
            var handler = LengthChanged;
            if (handler != null) handler(this, e);
        }
    }
}
