using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Delete_by_Id_RS
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            //var project = context.Projects.Where(p => p.ProjectID != 2).Take(10).ToList();
            //project.ForEach(p => Console.WriteLine(p.Name));

            var project = context.Projects.Find(2);
            foreach (var emp in project.Employees)
            {
                emp.Projects.Remove(project);
            }
            context.Projects.Remove(project);
            //context.SaveChanges();
        }
    }
}
