using System;
using System.Collections;
using System.Collections.Generic;
using Dem0n13.Replacer.Library.Lazy;

namespace Dem0n13.Replacer.Library.Utils
{
    public class LinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T> First;
        public Node<T> Last;
        public int Count;

        public IEnumerator<Node<T>> GetEnumerator() { return new LinkedListEnumerator<T>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new LinkedListEnumerator<T>(this); }

        public void Append(T value)
        {
            Append(new Node<T>(value));
        }

        public void Append(Node<T> node)
        {
            if (Count == 0)
                First = node;
            else
            {
                Last.Next = node;
            }
            node.Previous = Last;
            Last = node;
            Count++;
        }

        public void Append(LinkedList<T> list)
        {
            if (list.Count == 0) return;
            if (Count == 0)
                First = list.First;
            else
                Last.Next = list.First;
            list.First.Previous = Last;
            Last = list.Last;
            
            Count += list.Count;
        }

        public void RemoveLast()
        {
            if (Count <= 0) 
                throw new IndexOutOfRangeException();

            if (Count == 1)
                First = Last = null;
            else
            {
                Last = Last.Previous;
                Last.Next = null;
            }
            Count--;
        }

        public void Clear()
        {
            First = Last = null;
            Count = 0;
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<Node<T>>
    {
        private readonly Node<T> _resettedItem;
        
        public LinkedListEnumerator(LinkedList<T> linkedList)
        {
            _resettedItem = new Node<T>(default(T)) {Next = linkedList.First};
            Current = _resettedItem;
        }
        
        public bool MoveNext()
        {
            Current = Current.Next;
            return Current != null;
        }

        public void Reset() { Current = _resettedItem; }

        void IDisposable.Dispose() { }

        public Node<T> Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
