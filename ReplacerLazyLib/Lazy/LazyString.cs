using System.Linq;
using System.Text;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library.Lazy
{
    public sealed class LazyString : LinkedList<LazySubstring>
    {
        public int Length;

        public LazyString()
        {
        }

        public LazyString(string source)
        {
            Append(new LazySubstring(source));
        }

        public new void Append(LazySubstring value)
        {
            Length += value.Length;
            base.Append(value);
        }

        public new void Append(Node<LazySubstring> node)
        {
            Length += node.Value.Length;
            base.Append(node);
        }

        public new void Append(LinkedList<LazySubstring> list)
        {
            Length += list.Sum(node => node.Value.Length);
            base.Append(list);
        }

        public void Append(LazyString lazyString)
        {
            Length += lazyString.Length;
            base.Append(lazyString);
        }

        public new void RemoveLast()
        {
            if (Count > 0) Length -= Last.Value.Length;
            base.RemoveLast();
        }

        public new void Clear()
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

        public string BuildToString()
        {
            var result = ToString();

            base.Clear();
            base.Append(new LazySubstring(result));

            return result;
        }

        public override string ToString()
        {
            switch (Count)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return First.Value.BuildToString();
                default:
                    var builder = new StringBuilder(Length);
                    foreach (var substr in this) builder.Append(substr.Value.BuildToString());
                    return builder.ToString();
            }
        }
    }
}
