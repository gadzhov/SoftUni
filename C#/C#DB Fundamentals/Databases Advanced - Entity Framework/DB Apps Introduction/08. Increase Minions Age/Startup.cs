using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Increase_Minions_Age
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var minionsId = string.Join(", ", input);
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                // for the hell sql cannot compare case sensitive
                var query = $@"update Minions
set Name = case
			when substring(Name, 1, 1) = upper(substring(Name, 1, 1)) then replace(Name, substring(Name, 1, 1), lower(substring(Name, 1, 1)))
			when substring(Name, 1, 1) = lower(substring(Name, 1, 1)) then replace(Name, substring(Name, 1, 1), upper(substring(Name, 1, 1)))
			end
where id in ({minionsId})";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                var minionsList = GetMinionList(connection, minionsId);
                foreach (var minion in minionsList)
                {
                    Console.WriteLine(minion);
                }
            }
        }

        private static List<string> GetMinionList(SqlConnection connection, string minionsId)
        {
            var query = $"select * from Minions where Id in ({minionsId})";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            var minionsList = new List<string>();
            using (reader)
            {
                while (reader.Read())
                {
                    var minion = (string)reader[1] + " " + (int)reader[2];
                    minionsList.Add(minion);
                }
            }
            return minionsList;
        }
    }
}
