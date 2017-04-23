using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Increase_Age_Stored_Procedure
{
    class Startup
    {
        static void Main()
        {
            var id = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                // Check is there such procedure in db
                var query =
                    @"select count(*) from sys.objects where type_desc = 'SQL_STORED_PROCEDURE' AND name = 'usp_GetOlder'";

                SqlCommand command = new SqlCommand(query, connection);
                var rows = (int)command.ExecuteScalar();
                // If missing, creat one
                if (rows < 1)
                {
                var query2 = @"create proc usp_GetOlder(@id int)
                    as
                    begin
	                    update Minions
	                    set Age += 1
	                    where Id = @id

	                    select concat(Name,' ', Age) from Minions
		                where Id = @id
                    end";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.ExecuteNonQuery();
                }

                // Exec usp_GetOlder
                SqlCommand cmd = new SqlCommand("usp_GetOlder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteScalar();
                Console.WriteLine(reader);
            }
        }
    }
}
