using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_8.Custom_List.Generics
{
    public class CustomList<T>
        where T : IComparable<T>
    {
        private IList<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove(int index)
        {
            var rem = this.data[index];
            this.data.RemoveAt(index);

            return rem;
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            var item1 = this.data[index1];
            var item2 = this.data[index2];

            this.data.RemoveAt(index1);
            this.data.Insert(index1, item2);
            this.data.RemoveAt(index2);
            this.data.Insert(index2, item1);
        }

        public int CountGreaterThan(T element)
        {
            return this.data.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
