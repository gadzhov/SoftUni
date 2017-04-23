using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lection.Data;
using Lection.Models;

namespace Lection
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new RelationContext();
            context.Database.Initialize(true);
        }
    }
}
