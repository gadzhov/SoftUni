using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        var newNode = new QueueNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(newNode.Value);
        }
        else
        {
            this.tail.NextNode = newNode;
            newNode.PrevNode = this.tail;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty queue.");
        }

        var element = this.head.Value;
        this.head = this.head.NextNode;
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        var subArray = new T[this.Count];

        var current = this.head;
        var index = 0;
        while (current != null)
        {
            subArray[index++] = current.Value;
            current = current.NextNode;
        }

        return subArray;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }
}