using System;

public class ArrayStack<T>
{
    private T[] elements;
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; set; }

    public void Push(T element)
    {
        this.elements[Count++] = element;

        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty stack.");
        }

        var element = this.elements[this.Count];
        this.elements[this.Count--] = default(T);

        return element;
    }

    public T[] ToArray()
    {
        var subArray = new T[this.Count];
        Array.Copy(this.elements, subArray, this.Count);

        return subArray;
    }

    private void Grow()
    {
        var newArray = new T[this.elements.Length * 2];
        Array.Copy(this.elements, newArray, this.Count);

        this.elements = newArray;
    }
}
