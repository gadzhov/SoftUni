using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Local_Store
{
    using System.Collections.Generic;
    using Local_Store.Models;
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new StoreContext();
            context.Database.Initialize(true);
            Console.WriteLine(context.Products.FirstOrDefault().Name);
        }
    }
}
