using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_3.Stack.Generics
{
    public class Stack<T> : IEnumerable<T>
    {
        private IList<T> data;

        public Stack()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get => this.data;
            set => this.data = value;
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this.data.Add(element);
            }
        }

        public void Pop()
        {
            if (this.data.Count != 0)
            {
                this.data.RemoveAt(this.data.Count - 1);
            }
            else
            {
                throw new ArgumentException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
