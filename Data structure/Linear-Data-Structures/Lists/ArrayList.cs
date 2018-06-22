using System;

public class ArrayList<T>
{
    private const int _capacity = 2;
    private T[] _items;

    public ArrayList()
    {
        _items = new T[_capacity];
    }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _items[index];
        }

        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (Count == _items.Length)
        {
            Resize();
        }

        _items[Count] = item;
        Count++;
    }

    public T RemoveAt(int index)
    {
        if (index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = _items[index];
        _items[index] = default(T);
        Shift(index);
        Count--;

        if (Count <= _items.Length / 4)
        {
            Shrink();
        }

        return element;
    }

    #region helpers
    private void Resize()
    {
        T[] copy = new T[_items.Length * 2];
        for (int i = 0; i < _items.Length; i++)
        {
            copy[i] = _items[i];
        }

        _items = copy;
    }

    private void Shift(int index)
    {
        for (int i = index; i < Count; i++)
        {
            _items[i] = _items[i + 1];
        }
    }

    private void Shrink()
    {
        T[] copy = new T[_items.Length / 2];
        for (int i = 0; i < Count; i++)
        {
            copy[i] = _items[i];
        }

        _items = copy;
    }
    #endregion
}