using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADATO.MVVM.Models
{
    public class DataDate
    {
        public DateTime Date { get; set; }
        public DateTime TodayDay { get; set; }
        public string NumOfWeekTxt { get; set; }
        public string NumOfDayTxt { get; set; }
        public string DayName { get; set; }
    }
}
