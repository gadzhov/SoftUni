using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class EmployeeData
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            ushort age = ushort.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            ulong id = ulong.Parse(Console.ReadLine());
            uint uen = uint.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}\nLast name: {lastName}\nAge: {age}\nGender: {gender}\nPersonal ID: {id}\nUnique Employee number: {uen}");
        }
    }
}
