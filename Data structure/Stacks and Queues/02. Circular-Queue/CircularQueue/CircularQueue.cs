using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
    private T[] _elements;
    private int _startIndex;
    private int _endIndex;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        _elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= _elements.Length)
        {
            this.Resize();
        }

        _elements[_endIndex] = element;
        _endIndex = (_endIndex + 1) % _elements.Length;
        Count++;
    }

    private void Resize()
    {
        var newArray = new T[2 * _elements.Length];
        this.CopyAllElements(newArray);
        _elements = newArray;
        _startIndex = 0;
        _endIndex = this.Count;
    }

    private void CopyAllElements(T[] newArray)
    {
        var sourceIndex = _startIndex;
        var destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newArray[destinationIndex] = _elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % _elements.Length;
            destinationIndex++;
        }
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var element = _elements[_startIndex];
        _startIndex = (_startIndex + 1) % _elements.Length;
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        var result = new T[this.Count];
        CopyAllElements(result);

        return result;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
