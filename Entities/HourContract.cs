using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_enum.Entities
{
    public class HourContract
    {
        public DateTime Date { get; set; }
        public double ValueperHour { get; set; }
        public int Hours { get; set; }

        public HourContract()
        {
        }

        public HourContract(DateTime date, double valueperHour, int hours)
        {
            Date = date;
            ValueperHour = valueperHour;
            Hours = hours;
        }

        public double totalValue()
        {
            return Hours * ValueperHour;
        }
    }
}
