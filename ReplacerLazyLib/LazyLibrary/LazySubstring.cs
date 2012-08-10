using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dem0n13.Replacer.LazyLibrary
{
    public class LazySubstring
    {
        #region private fields

        private string _built = null;

        #endregion

        public string Source { get; private set; }

        public int StartIndex { get; private set; }

        public int Length { get; private set; }

        public LazySubstring() : this(string.Empty) { }

        public LazySubstring(string source) : this(source, 0, source.Length) { }

        public LazySubstring(string source, int startIndex, int length)
        {
            if (source == null) 
                throw new ArgumentNullException("source");
            if (startIndex < 0 || length < 0 || startIndex + length > source.Length)
                throw new ArgumentOutOfRangeException();
            
            Source = source;
            StartIndex = startIndex;
            Length = length;
            if (startIndex == 0 && length == source.Length)
                _built = source;
        }

        public LazySubstring Substring(int startIndex, int length)
        {
            return new LazySubstring(Source, startIndex + startIndex, length);
        }

        public string BuildToString()
        {
            if (_built == null)
                _built = ToString();
            return _built;
        }

        public override string ToString()
        {
            return Source.Substring(StartIndex, Length);
        }
    }
}
