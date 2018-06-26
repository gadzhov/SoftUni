using System;
using System.Linq;

namespace _1.Sum_and_Average
{
    public class Startup
    {
        public static void Main()
        {
            var list = new CustomList();
            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => list.Add(x));

            Console.WriteLine($"Sum={list.Sum()}; Average={list.Average():F2}");
        }

        public class CustomList
        {
            private readonly int initialCapacity = 2;
            private int[] data;

            public CustomList()
            {
                this.data = new int[this.initialCapacity];
            }

            public int Count { get; set; }

            public void Add(int element)
            {
                if (this.Count == data.Length)
                {
                    this.Resize();
                }

                this.data[Count] = element;
                this.Count++;
            }

            public int Sum()
            {
                var result = 0;

                for (int i = 0; i < Count; i++)
                {
                    result += this.data[i];
                }

                return result;
            }

            public double Average()
            {
                var result = 0.0;

                if (this.Count > 0)
                {
                    result = (double)this.Sum() / (double)this.Count;
                }

                return result;
            }

            #region helpers
            private void Resize()
            {
                var newArray = new int[this.data.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newArray[i] = this.data[i];
                }

                this.data = newArray;
            }
            #endregion
        }
    }
}