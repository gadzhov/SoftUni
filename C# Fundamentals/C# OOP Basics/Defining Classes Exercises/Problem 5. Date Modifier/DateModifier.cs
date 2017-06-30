using System;

namespace Problem_5.Date_Modifier
{
    public class DateModifier
    {
        public int Deference { get; set; }

        public void CalculateDeference(string date1, string date2)
        {
            var firstDate = DateTime.Parse(date1);
            var secondDate = DateTime.Parse(date2);

            var deference = firstDate - secondDate;

            this.Deference = Math.Abs(deference.Days);
        }
    }
}
