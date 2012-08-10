using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dem0n13.Replacer.LazyLibrary
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T value)
        {
            Value = value;
        }
    }
}
