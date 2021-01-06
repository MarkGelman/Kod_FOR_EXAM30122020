using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class Tests
    {
        public Int64 Id { get; set; }
        public Int64 Car_Id { get; set; }
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }

        public Tests()
        {

        }
        public Tests(long id,long car_id,bool isPassed,DateTime date)
        {
            Id = id;
            Car_Id = car_id;
            IsPassed = isPassed;
            Date = date;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
