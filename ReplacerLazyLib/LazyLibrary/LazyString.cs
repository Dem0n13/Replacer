using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Dem0n13.Replacer.LazyLibrary
{
    public class LazyString : LinkedList<LazySubstring>
    {
        public int Length;

        public override void Append(LazySubstring value)
        {
            Length += value.Length;
            base.Append(value);
        }

        public override void RemoveLast()
        {
            if (Count > 0) Length -= Last.Value.Length;
            base.RemoveLast();
        }

        public override void Clear()
        {
            Length = 0;
            base.Clear();
        }

        public LazyString CreateCopy()
        {
            var result = new LazyString();
            foreach (var node in this)
                result.Append(node.Value);
            return result;
        }

        public virtual string BuildToString()
        {
            var result = ToString();
            
            Clear();
            Append(new LazySubstring(result));

            return result;
        }

        public override string ToString()
        {
            if (Count == 1)
            {
                return First.Value.BuildToString();
            }

            var builder = new StringBuilder(Length);
            foreach (var substr in this)
            {
                builder.Append(substr.Value.BuildToString());
            }

            return builder.ToString();
        }
    }


}
