using System;

public class Scale<T>
    where T : IComparable<T>
{
    public Scale(T left, T rigt)
    {
        this.Left = left;
        this.Rigt = rigt;
    }

    private T Left { get; }

    private T Rigt { get; }

    public T GetHavier()
    {
        if (this.Left.CompareTo(this.Rigt) > 0) return this.Left;
        if (this.Left.CompareTo(this.Rigt) < 0) return this.Rigt;

        return default(T);
    }
}
