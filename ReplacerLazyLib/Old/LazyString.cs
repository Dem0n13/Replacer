using System;
using System.Linq;
using System.Text;
using Dem0n13.Replacer.LazyLibrary;
using System.Collections.Generic;

namespace ReplacerLazyLib
{
    public class LazyString : System.Collections.Generic.LinkedList<LazySubstring>
    {
        public int Length { get { return this.Aggregate(0, (result, item) => result += item.Length); } }
    }
}
