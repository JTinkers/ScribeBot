using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ScribeBot.Engine.Wrappers
{
    [MoonSharpUserData]
    static class DatabaseWrapper
    {
        private static SQLiteConnection connection;

        /// <summary>
        /// Static constructor creating a database file.
        /// </summary>
        static DatabaseWrapper()
        {
            if (!File.Exists("Data/User Data/database.db"))
                SQLiteConnection.CreateFile("Data/User Data/database.db");

            connection = new SQLiteConnection("Data Source=Data/User Data/database.db");
        }

        /// <summary>
        /// Execute a query on the local database.
        /// </summary>
        /// <param name="query">Query string to execute.</param>
        /// <returns>Results or null if query yields no returned data.</returns>
        public static Dictionary<string, object>[] Query(string query)
        {
            connection.Open();

            var data = new List<Dictionary<string, object>>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = query;

            try
            {
                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    data.Add(row);
                }
            }
            catch (Exception e)
            {
                CoreWrapper.WriteLine(e.Message);
            }

            connection.Close();

            return data.ToArray();
        }
    }
}
