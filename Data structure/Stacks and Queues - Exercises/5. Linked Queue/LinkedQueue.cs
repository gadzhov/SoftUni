using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }

        this.Count++;
    }

    public T Dequeue()
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; private set; }

        public QueueNode<T> PrevNode { get; private set; }
    }
}