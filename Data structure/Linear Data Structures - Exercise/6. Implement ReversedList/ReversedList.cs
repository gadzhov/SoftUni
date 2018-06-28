using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private readonly int initialCapacity = 2;
    private T[] data;

    public ReversedList()
    {
        this.data = new T[this.initialCapacity];
    }

    public int Count { get; set; }

    public int Capacity => this.data.Length;

    public T this[int index]
    {
        get
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.data[this.Count - 1 - index];
        }
        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data[this.Count - 1 - index] = value;
        }
    }

    public void Add(T element)
    {
        if (this.Count == this.Capacity)
        {
            this.Resize();
        }

        this.data[this.Count] = element;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var element = this.data[this.Count - 1 - index];
        this.data[this.Count - 1 - index] = default(T);
        this.Count--;
        this.Shift(this.Count - index);

        if (this.Count <= this.Capacity / 2)
        {
            this.Shrink();
        }

        return element;
    }

    #region helpers
    private void Resize()
    {
        var newArray = new T[this.Capacity * 2];
        Array.Copy(this.data, newArray, this.Capacity);
        this.data = newArray;
    }

    private void Shrink()
    {
        var newArray = new T[this.Capacity / 2];
        Array.Copy(this.data, newArray, this.Count);
        this.data = newArray;
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Capacity - 1; i++)
        {
            this.data[i] = this.data[i + 1];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    #endregion
}