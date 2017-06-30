using System;
using System.Reflection;

namespace Problem_1.Define_a_class_Person
{
    class Startup
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}
