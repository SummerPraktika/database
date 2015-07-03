using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;

namespace Sqlite_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = @"D:\test.db";
            SQLiteConnection.CreateFile(databaseName);
            Console.WriteLine(File.Exists(databaseName) ? "База данных создана" : "Возникла ошибка при создании базы данных");

            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            SQLiteCommand command =
            new SQLiteCommand("CREATE TABLE example (id INTEGER PRIMARY KEY, value TEXT);", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            SQLiteCommand command1 = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;", connection);
            SQLiteDataReader reader = command1.ExecuteReader();
            foreach (DbDataRecord record in reader)
                Console.WriteLine("Таблица: " + record["name"]);
            connection.Close();

            connection.Open();
            SQLiteCommand command2 = new SQLiteCommand("INSERT INTO 'example' ('id', 'value') VALUES (1, 'Вася');", connection);
            command2.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Запись добавлена");

            connection.Open();
            SQLiteCommand command4 = new SQLiteCommand("SELECT * FROM 'example';", connection);
            SQLiteDataReader reader4 = command4.ExecuteReader();

            foreach (DbDataRecord record11 in reader4)
            {
                string id = record11["id"].ToString();
                string value = record11["value"].ToString();
                Console.WriteLine(id + " " + value);
            }
            connection.Close();
            
            Console.ReadKey();
        }
    }
}
