using System;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty stack.");
        }

        var value = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;

        return value;
    }

    public T[] ToArray()
    {
        var newArray = new T[this.Count];
        var current = this.firstNode.NextNode;
        var index = 0;
        while (current != null)
        {
            newArray[index] = current.Value;
            index++;
            current = current.NextNode;
        }

        return newArray;
    }

    private class Node<T>
    {
        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public Node<T> NextNode { get; set; }

        public T Value { get; private set; }
    }
}
