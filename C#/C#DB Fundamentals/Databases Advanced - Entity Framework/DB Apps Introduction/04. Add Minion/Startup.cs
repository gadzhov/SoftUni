using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Add_Minion
{
    class Startup
    {
        static void Main()
        {
            Console.Write("Minion: ");
            var minionInfo = Console.ReadLine().Split(' ').ToArray();
            var minionName = minionInfo[0];
            var minionAge = int.Parse(minionInfo[1]);
            var minionTown = minionInfo[2];
            Console.Write("Villain: ");
            var villainName = Console.ReadLine();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; " +
             "Database=MinionsDB; " +
             "MultipleActiveResultSets=true;" +
             "Integrated Security=true");
            connection.Open();
            using (connection)
            {
                var queryTownCheck =
                        File.ReadAllText(
                            @"D:\Projects\Visual Studio 2015\Projects\Databases Advanced - Entity Framework\DB Apps Introduction\04. Add Minion\TownsCheck.sql");
                // insert query path
                SqlCommand commandTownCheck = new SqlCommand(queryTownCheck, connection);
                commandTownCheck.Parameters.AddWithValue("@name", minionTown);
                SqlDataReader readerTownCheck = commandTownCheck.ExecuteReader();
                using (readerTownCheck)
                {
                    readerTownCheck.Read();
                    var townId = -1;
                    if (readerTownCheck.HasRows)
                    {
                        townId = (int)readerTownCheck[0];
                    }
                    else
                    {
                        InsertTown(minionTown, connection);
                        townId = GetTownId(connection, minionTown);
                    }
                    InsertMinion(minionName, minionAge, townId, connection);  
                }

                CheckVillainExist(villainName, connection);

                var villainId = GetVillainId(connection, villainName);
                var minionId = GerMinionId(connection, minionName);
                SetMinionToServe(villainId, minionId, connection, minionName, villainName);
            }
        }

        private static void SetMinionToServe(int villainId, int minionId, SqlConnection connection, string minionName, string villainName)
        {
            var querySetMinionToServe = @"INSERT INTO MinionsServeToVillains VALUES
                (@villianId, @minionId)";
            SqlCommand commandSetMinionToServe = new SqlCommand(querySetMinionToServe, connection);
            commandSetMinionToServe.Parameters.AddWithValue("@villianId", villainId);
            commandSetMinionToServe.Parameters.AddWithValue("@minionId", minionId);
            var rowsAfecteed = commandSetMinionToServe.ExecuteNonQuery();
            if (rowsAfecteed > 0)
            {
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
            }
            else
            {
                // Rollback
            }
        }

        private static void CheckVillainExist(string villainName, SqlConnection connection)
        {
            var queryCheckVillain = @"SELECT COUNT(*) FROM Villains
where Name = @name";
            SqlCommand commandCheckVillain = new SqlCommand(queryCheckVillain, connection);
            commandCheckVillain.Parameters.AddWithValue("@name", villainName);
            var villainRows = (int)commandCheckVillain.ExecuteScalar();
            if (villainRows == 0)
            {
                InsertVillain(villainName, connection);
            }
            else
            {
                // roll back
            }
        }

        private static int GerMinionId(SqlConnection connection, string minionName)
        {
            var id = -1;
            const string queryGetMinionId = @"SELECT Id FROM Minions
                WHERE Name = @name";
            SqlCommand commandGetTownId = new SqlCommand(queryGetMinionId, connection);
            commandGetTownId.Parameters.AddWithValue("@name", minionName);
            SqlDataReader readerGetId = commandGetTownId.ExecuteReader();
            if (readerGetId.Read())
            {
                id = (int)readerGetId[0];
            }
            return id;
        }

        private static int GetVillainId(SqlConnection connection, string villainName)
        {
            var id = -1;
            const string queryGetVillainId = @"SELECT Id FROM Villains
                WHERE Name = @name";
            SqlCommand commandGetTownId = new SqlCommand(queryGetVillainId, connection);
            commandGetTownId.Parameters.AddWithValue("@name", villainName);
            SqlDataReader readerGetId = commandGetTownId.ExecuteReader();
            if (readerGetId.Read())
            {
                id = (int)readerGetId[0];
            }
            return id;
        }

        private static void InsertVillain(string villainName, SqlConnection connection)
        {
            const string queryInsertVillain = @"INSERT INTO Villains VALUES
                (@name, 'evil')";
            SqlCommand commandInsertVillain = new SqlCommand(queryInsertVillain, connection);
            commandInsertVillain.Parameters.AddWithValue("@name", villainName);
            var rowsAffected = (int) commandInsertVillain.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            else
            {
                Console.WriteLine("Erro when try to insert evil");
                // Rollback
            }
        }

        public static void InsertTown(string minionTown, SqlConnection connection)
        {
            const string queryInsertTown = @"insert into Towns values
              (@name, 1)"; // Inserting country id bcs is not null
            SqlCommand commandTownInsert = new SqlCommand(queryInsertTown, connection);
            commandTownInsert.Parameters.AddWithValue("@name", minionTown);
            int townInsertedRows = commandTownInsert.ExecuteNonQuery();
            if (townInsertedRows > 0)
            {
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
        }

        public static void InsertMinion(string minionName, int minionAge, int townId, SqlConnection connection)
        {
            const string queryInsertMinion = @"insert into Minions values
                (@minionName, @minionAge, @townId)";
            SqlCommand commandInsertMinion = new SqlCommand(queryInsertMinion,connection);
            commandInsertMinion.Parameters.AddWithValue("@minionName", minionName);
            commandInsertMinion.Parameters.AddWithValue("@minionAge", minionAge);
            commandInsertMinion.Parameters.AddWithValue("@townId", townId);
            var minionInsertedRow = commandInsertMinion.ExecuteNonQuery();
            if (minionInsertedRow > 0)
            {
            }
            else
            {
                // Rollback Implemation
            }
        }

        public static int GetTownId(SqlConnection connection, string townName)
        {
            int id = -2;
            const string queryGetTownId = @"SELECT Id FROM Towns
                WHERE Name = @name";
            SqlCommand commandGetTownId = new SqlCommand(queryGetTownId, connection);
            commandGetTownId.Parameters.AddWithValue("@name", townName);
            SqlDataReader readerGetId = commandGetTownId.ExecuteReader();
            if (readerGetId.Read())
            {
                id = (int)readerGetId[0];
            }
            return id;
        }
    }
}
