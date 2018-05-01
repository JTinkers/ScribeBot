using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ScribeBot.Wrappers
{
    [MoonSharpUserData]
    static class Database
    {
        private static SQLiteConnection connection;

        static Database()
        {
            if (!File.Exists("Data/User Data/database.db"))
                SQLiteConnection.CreateFile("Data/User Data/database.db");

            connection = new SQLiteConnection("Data Source=Data/User Data/database.db");
        }

        public static Dictionary<string, object>[] Query(string query)
        {
            connection.Open();

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;

            try
            {
                SQLiteDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    data.Add(row);
                }
            }
            catch (Exception e)
            {
                Core.WriteLine(e.Message);
            }

            connection.Close();

            return data.ToArray();
        }
    }
}
