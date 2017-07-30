using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_9.Linked_List_Traversal.Generics
{
    public class MyLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        public MyLinkedList()
        {
            this.Head = null;
            this.Count = 0;
        }

        private LinkedListNode<T> Head { get; set; }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.Head = new LinkedListNode<T>(item);
            }
            else
            {
                var lastNode = GetElementAtIndex(this.Count - 1);
                lastNode.Next = new LinkedListNode<T>(item);
            }

            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        public T Remove(int index)
        {
            var removeValue = default(T);

            if (index == 0)
            {
                removeValue = this.Head.Value;
                this.Head = this.Head.Next;
            }
            else
            {
                var prevNode = this.GetElementAtIndex(index - 1);
                var currentNode = this.GetElementAtIndex(index);
                prevNode.Next = currentNode.Next;

                removeValue = currentNode.Value;
            }

            this.Count--;

            return removeValue;
        }

        public int FirstIndexOf(T element)
        {
            var firstIndex = IndexOf(element, true);
            return firstIndex;
        }

        public int LastIndexOf(T element)
        {
            var lastIndex = IndexOf(element, false);
            return lastIndex;
        }

        private int IndexOf(T element, bool isFirstFoundIndexNeeded)
        {
            var foundIndex = -1;
            var currentNode = this.Head;
            for (var index = 0; index < this.Count; index++)
            {
                if (currentNode.Value.Equals(element))
                {
                    foundIndex = index;
                    if (isFirstFoundIndexNeeded)
                    {
                        return foundIndex;
                    }
                }

                currentNode = currentNode.Next;
            }

            return foundIndex;
        }

        private LinkedListNode<T> GetElementAtIndex(int index)
        {
            var currentElement = this.Head;
            for (var i = 0; i < index; i++)
            {
                currentElement = currentElement.Next;
            }

            return currentElement;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
