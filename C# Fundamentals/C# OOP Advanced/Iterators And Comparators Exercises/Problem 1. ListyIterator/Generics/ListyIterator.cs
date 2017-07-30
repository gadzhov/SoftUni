using System;
using System.Collections.Generic;

namespace Problem_1.ListyIterator.Generics
{
    public class ListyIterator<T>
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
    }
}
