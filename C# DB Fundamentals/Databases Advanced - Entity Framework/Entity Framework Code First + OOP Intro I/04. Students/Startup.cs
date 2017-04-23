using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class Startup
    {
        public class Student
        {
            private string _name;
            public static int count;

            public Student(string name)
            {
                this._name = name;
                count++;
            }

            public string Name
            {
                get { return this._name; }
                set { this._name = value; }
            }
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input != "End")
            {
                var student = new Student(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(Student.count);
        }
    }
}
