using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = Head;

        Head = new Node(item);
        Head.Next = old;

        if (Count == 0)
        {
            Tail = Head;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        Node old = Tail;

        Tail = new Node(item);

        if (Count == 0)
        {
            Head = Tail;
        }
        else
        {
            old.Next = Tail;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = Head.Value;
        Head = Head.Next;
        Count--;

        if (Count == 0)
        {
            Tail = null;
        }

        return element;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = Tail.Value;

        if (Count == 1)
        {
            Head = Tail = null;
        }
        else
        {
            Node secondToLast = null;
            Node parrent = Head;
            while (parrent != null)
            {
                if (parrent.Next == Tail)
                {
                    secondToLast = parrent;
                    break;
                }

                parrent = parrent.Next;
            }

            Tail = secondToLast;
            Tail.Next = null;
        }

        Count--;

        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region helpers
    public class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node Next { get; set; }
    }
    #endregion
}
