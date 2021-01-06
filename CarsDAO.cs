using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class CarsDAO : ICarsDAO
    {
        string _query;
        internal SQLiteConnection connection;
        List<Cars> allCars = new List<Cars>();
        public void AddCar(Cars c)
        {
            Console.WriteLine("ALL Cars");
            Console.WriteLine("==============================================================================================");
            _query = $"INSERT INTO tests" +
                    $"VALUES ({c.Manufacturer},{c.Model},{c.Year})";
            int row = NonReader(_query);
            Console.WriteLine("==============================================================================================");
            Console.WriteLine();
        }

        public void DeleteCar(int id)
        {
            Console.WriteLine("DELETE CAR");
            Console.WriteLine("==============================================================================================");

             _query = $"DELETE FROM cars WHERE id ={id}";
             int row = NonReader(_query);

            Console.WriteLine("==============================================================================================");
            Console.WriteLine();
           
        }

        public void GetAllByManufacturer(string manufacturer)
        {
            Console.WriteLine("DELETE CAR");
            Console.WriteLine("==============================================================================================");

             _query = $"Select * FROM cars"+
                                  $"WHERE manufacturer = {manufacturer}";

                        Reader(_query);
        }

        public void GetAllCar()
        {
            _query = $"SELECT * FROM cars";

            Reader(_query);
        }

        public void UpdateCar(int id, Cars c)
        {
            _query = $"UPDATE tests SET id = {c.Id},manufacturer = {c.Manufacturer}, model = {c.Model},year = {c.Year} ";
            NonReader(_query);
        }

        public List<Cars> Reader(string query)
        {
            List<Cars> allCars = new List<Cars>();
            using (SQLiteCommand command = new SQLiteCommand(query,connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cars t = new Cars
                        {
                            Id = (long)reader["id"],
                            Manufacturer = reader["manufacturer"].ToString(),
                            Model = reader["model"].ToString(),
                            Year = (int)reader["year"]
                        };
                        allCars.Add(t);
                    }
                }
            }
            return allCars;
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
