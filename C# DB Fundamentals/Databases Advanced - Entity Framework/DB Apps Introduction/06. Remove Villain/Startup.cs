using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace _06.Remove_Villain
{
    class Startup
    {
        static void Main()
        {
            var villainId = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                const string query = @"delete from MinionsServeToVillains
                where VillainsId = @villainId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                var count = command.ExecuteNonQuery();
                var name = GetVilliandName(villainId, connection);
                if (count >= 0 && name != null)
                {
                    DeleteEvil(villainId, connection);
                    Console.WriteLine($"{name} was deleted");
                    Console.WriteLine($"{count} minions released");
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }

        private static string GetVilliandName(int villainId, SqlConnection connection)
        {
            const string query = @"select Name from Villains
                where Id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", villainId);
            var name = command.ExecuteScalar();
            return (string)name;
        }

        private static void DeleteEvil(int villainId, SqlConnection connection)
        {
            const string query = @"delete from  Villains
                where Id = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", villainId);
            var rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                // RollBack
            }
        }
    }
}
