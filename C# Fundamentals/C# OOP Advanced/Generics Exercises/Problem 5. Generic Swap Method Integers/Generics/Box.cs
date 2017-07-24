using System.Collections.Generic;
using System.Text;

namespace Problem_5.Generic_Swap_Method_Integers.Generics
{
    public class Box<T>
    {
        private IList<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T item)
        {
            this.data.Add(item);
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var d in this.data)
            {
                sb.AppendLine($"{typeof(T).FullName}: {d}");
            }

            return sb.ToString().Trim();
        }
    }
}
