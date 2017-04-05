using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentIntegersSize
{
    class DifferentIntegersSize
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool canBeFited = true;
            List<string> result = new List<string>();
            try
            {
                sbyte num = sbyte.Parse(input);
                result.Add("sbyte");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                byte num = byte.Parse(input);
                result.Add("byte");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                short num = short.Parse(input);
                result.Add("short");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                ushort num = ushort.Parse(input);
                result.Add("ushort");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                int num = int.Parse(input);
                result.Add("int");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                uint num = uint.Parse(input);
                result.Add("uint");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }
            try
            {
                long num = long.Parse(input);
                result.Add("long");
            }
            catch (System.OverflowException)
            {
                canBeFited = false;
            }

            if (result.Count > 0)
            {
                Console.WriteLine($"{input} can fit in:");
                Console.WriteLine("* " + string.Join("\n* ", result));
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}
