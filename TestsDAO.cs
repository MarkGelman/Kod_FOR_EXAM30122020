using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class TestsDAO : ITests
    {
        string _query;
        internal SQLiteConnection connection;
       // SQLiteCommand command;
        List<Tests> allTests = new List<Tests>();
        public void AddTests(Tests t)
        {

            _query = $"INSERT INTO tests" +
                    $"VALUES ({t.Car_Id},{t.IsPassed},{t.Date})";
            int row = NonReader(_query);
        }

        public void DeleteTests(int id)
        {
            _query = $"DELETE FROM tests WHERE id ={id}";
            int row = NonReader(_query);
        }

        public void GetAllTests()
        {
            _query = $"SELECT * FROM tests";

            Reader(_query).ForEach(t => Console.WriteLine(  JsonConvert.SerializeObject(t)));
        }

        public void GetAllTestsWithCars()
        {
            _query = $"SELECT t.isPassed,t.date,c.Manufacturer,c.Model,c.Year FROM tests t JOIN cars c" +
                $" ON t.id = c.car_id";
            using (SQLiteCommand command = new SQLiteCommand(_query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        var Cars_With_Tests = new
                        {
                            Id = i++,
                            Manufacturer = (string)reader["c.manufacturer"],
                            Model = (string)reader["c.model"],
                            Year = (int)reader["c.year"],
                            IsPassed = (bool)reader["t.isPassed"],
                            Date = (DateTime)reader["t.date"]
                        };
                        Console.WriteLine(JsonConvert.SerializeObject(Cars_With_Tests));
                    }

                }
            }
        }
        public void UpdateTests(int id, Tests t)
        {
            _query = $"UPDATE tests SET id = {t.Id},car_id = {t.Car_Id}, isPassed = {t.IsPassed},date = {t.Date} ";
            int row = NonReader(_query);
        }

        public  List<Tests> Reader (string query)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tests t = new Tests
                        {
                            Id = (long)reader["id"],
                            Car_Id = (long)reader["car_id"],
                            IsPassed = (bool)reader["isPassed"],
                            Date = (DateTime)reader["date"]
                        };
                         allTests.Add(t);
                    }
                    return allTests;
                   
                }
            }
        }

        public int NonReader(string query)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }

    }
}
