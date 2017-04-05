using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new HospitalContext();
            var dr = context.Doctors.ToList();
            foreach (var doctor in dr)
            {
                foreach (var visit in doctor.Visitations)
                {
                    Console.WriteLine(visit.Comments.Length);
                }
            }
        }
    }
}
