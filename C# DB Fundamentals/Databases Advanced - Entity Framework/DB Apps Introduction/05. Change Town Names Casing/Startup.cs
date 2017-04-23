using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Change_Town_Names_Casing
{
    class Startup
    {
        static void Main()
        {
            var country = Console.ReadLine();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                const string query = @"update Towns
                    set Name = upper(t.Name)
                    from Countries as c
                    inner join Towns as t
                    on t.CountryId = c.Id
                    where c.Name = @countryName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@countryName", country);
                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"{rowsAffected} town names were affected.");
                    SelectAllChangedTowns(country, connection);
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }

        private static void SelectAllChangedTowns(string country, SqlConnection connection)
        {
            const string query = @"select t.Name as 'TownName' from Countries as c
                inner join Towns as t
                on t.CountryId = c.Id
                where c.Name = @countryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", country);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                var listTowns = new List<string>();
                Console.Write("[");
                while (reader.Read())
                {
                    listTowns.Add((string)reader["TownName"]);
                }
                Console.Write(string.Join(", ", listTowns));
                Console.WriteLine("]");
            }
        }
    }
} 