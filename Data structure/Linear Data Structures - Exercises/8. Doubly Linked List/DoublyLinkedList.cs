using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newHead = new ListNode<T>(element);
            newHead.NextNode = this.head;
            this.head.PrevNode = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.tail = this.head = new ListNode<T>(element);
        }
        else
        {
            var newTail = new ListNode<T>(element);
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty list.");
        }

        var firstElement = this.head.Vaue;
        this.head = this.head.NextNode;

        // There are more elements than 1.
        if (this.head != null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;

        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty list.");
        }

        var lastElement = this.tail.Vaue;
        this.tail = tail.PrevNode;

        // We more elements than 1.
        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;

        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Vaue);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Vaue;
            current = current.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var current = this.head;
        var index = 0;
        while (current != null)
        {
            array[index++] = current.Vaue;
            current = current.NextNode;
        }

        return array;
    }

    #region helpers
    private class ListNode<T>
    {
        public T Vaue { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Vaue = value;
        }
    }
    #endregion
}