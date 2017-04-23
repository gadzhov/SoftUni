using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Print_All_Minion_Names
{
    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                var query = "select Name from Minions";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                var namesList = new List<string>();
                using (reader)
                {
                    while (reader.Read())
                    {
                        namesList.Add((string)reader[0]);
                    }
                }
                for (int i = 0; i < namesList.Count / 2; i++)
                {
                    Console.WriteLine(namesList[i]);
                    Console.WriteLine(namesList[namesList.Count - i - 1]);
                }
                if (namesList.Count % 2 > 0)
                {
                    Console.WriteLine(namesList[namesList.Count / 2]);
                }
            }
        }
    }
}
