using System.Reflection;

namespace Problem_1.Generic_Box.Generics
{
    public class Box<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }

        private T Data { get; }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.Data}";
        }
    }
}
