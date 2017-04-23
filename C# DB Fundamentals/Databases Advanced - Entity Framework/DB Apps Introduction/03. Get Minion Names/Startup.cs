using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Get_Minion_Names
{
    class Startup
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
  "Database=MinionsDB; " +
  "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                var id = int.Parse(Console.ReadLine());
                string query =
                    File.ReadAllText(
                        @"D:\Projects\Visual Studio 2015\Projects\Databases Advanced - Entity Framework\DB Apps Introduction\03. Get Minion Names\SQLQueryCommand.sql");
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    var villain = "";
                    var minionsList = new List<string>();

                    if (!reader.HasRows)
                    {
                        villain = null;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            villain = (string)reader["VillainName"];
                            var minion = reader["MinionName"] + " " +
                                         reader["MinionAge"];
                            if (minion != " ")
                            {
                                minionsList.Add(minion);
                            }
                        }
                    }
                    if (villain != null)
                    {
                        Console.WriteLine($"Villain: {villain}");
                        for (int i = 0; i < minionsList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {minionsList[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                    }
                }
            }
        }
    }
}
