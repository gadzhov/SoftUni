using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection
{
    class Lection
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(
  "Server=(localdb)\\MSSQLLocalDB; " +
  "Database=SoftUni; " +
  "Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                var name = Console.ReadLine();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Employees 
                    WHERE FirstName = @name", dbCon);
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} - {reader["Salary"]}");
                    }
                }
            }
        }
    }
}
