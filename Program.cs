using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string string_connection = "Data Source = C:\\Users\\Mark\\Desktop\\Itay\\EXAMENS\\30.12.20 SQL\\DB_SQlite\\301220EXAMEN_SQLite.db;Version = 3";
            using(SQLiteConnection connection = new SQLiteConnection(string_connection))
            {

                connection.Open();
                TestsDAO test = new TestsDAO();
                CarsDAO car = new CarsDAO();
                Tests test1 = new Tests()
                {
                    Id = 2,
                    Car_Id = 3,
                    IsPassed = false,

                };
                test.connection = connection;
                car.connection = connection;
                test.GetAllTests();
                /*test.UpdateTests(1);
                test.GetAllTestsWithCars();  */       
            }
          
        }
    }
}
