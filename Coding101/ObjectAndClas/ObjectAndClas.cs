using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectAndClas.Models;

namespace ObjectAndClas
{
    class ObjectAndClas
    {
        static void Main(string[] args)
        {
            Human pesho = new Human();
            pesho.Name = "Pesho";
            pesho.Age = 26;
            
            Dog sharo = new Dog("sharo", "male");
            Dog spas = new Dog("Spas");
            Console.WriteLine(spas.WoofName());
        }
    }
}
