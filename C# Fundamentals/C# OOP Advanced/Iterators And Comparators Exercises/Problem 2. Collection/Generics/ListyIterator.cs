using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_2.Collection.Generics
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index = 0;

        public ListyIterator(params T[] elements)
        {
            this.data = new List<T>();
            if (elements.Length != 0)
            {
                this.data.AddRange(elements);
            }
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return this.data.Count > this.index + 1;
        }

        public T Print()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            return this.data[this.index];
        }

        public string PrintAll()
        {
            if (this.data.Count != 0)
            {
                return string.Join(" ", this.data);
            }
            throw new ArgumentException("Invalid Operation!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in this.data)
            {
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
