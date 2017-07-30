using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekday, string notes)
    {
        this.WeekDay = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay WeekDay { get; }

    public string Notes { get; }

    public int CompareTo(WeeklyEntry other)
    {
        var result = this.WeekDay.CompareTo(other.WeekDay);

        if (result == 0)
        {
            result = this.Notes.CompareTo(other.Notes);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}
