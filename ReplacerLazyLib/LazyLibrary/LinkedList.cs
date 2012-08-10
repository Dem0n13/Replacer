using System;
using System.Collections;
using System.Collections.Generic;

namespace Dem0n13.Replacer.LazyLibrary
{
    public class LinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T> First;
        public Node<T> Last;
        public int Count;

        public IEnumerator<Node<T>> GetEnumerator() { return new LinkedListEnumerator<T>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new LinkedListEnumerator<T>(this); }

        public virtual void Append(T value)
        {
            Append(new Node<T>(value));
        }

        public virtual void Append(Node<T> node)
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

        public virtual void Append(LinkedList<T> list)
        {
            if (Count == 0) // TODO prev
            {
                First = list.First;
                Last = list.Last;
            }
            else
            {
                Last.Next = list.First;
            }
            Last = list.Last;            
            Count += list.Count;
        }

        public virtual void RemoveLast()
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

        public virtual void Clear()
        {
            First = Last = null;
            Count = 0;
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<Node<T>>
    {
        private Node<T> _resettedItem;
        
        public LinkedListEnumerator(LinkedList<T> linkedList)
        {
            _resettedItem = new Node<T>(default(T));
            _resettedItem.Next = linkedList.First;
            Current = _resettedItem;
        }
        
        public bool MoveNext()
        {
            Current = Current.Next;
            if (Current != null)
                return true;
            return false;
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
