using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Get_Villains__Name
{
    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
  "Database=MinionsDB; " +
  "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                string query =
                    File.ReadAllText(
                        @"D:\Projects\Visual Studio 2015\Projects\Databases Advanced - Entity Framework\DB Apps Introduction\02. Get Villains' Name\SQLQueryCommand.sql");
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Count"]}");
                    }
                }
            }
        }
    }
}
