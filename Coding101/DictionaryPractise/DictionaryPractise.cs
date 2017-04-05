using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DictionaryPractise
{
    class DictionaryPractise
    {
        private static void Main(string[] args)
        {

            var start = 2;
            for (int i = 0; i < 1000; i++)
            {
                start *= 20;
                Console.Write(start + " ");
            }
        }
    }
}
