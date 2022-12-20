using ADATO.MVVM.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADATO.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<DataDate> DataDates { get; set; }

        public DayOfWeek NowDay = DateTime.Now.DayOfWeek;
        string dayName;
        int numOfDay = DateTime.Now.DayOfYear;
        //string dzien = numOfDay.ToString();

        int week = DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(DateTime.Now, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);


        public MainViewModel()
        {
            FillData();
        }

        private void FillData()
        {
            #region IfDay

            if (NowDay == DayOfWeek.Monday)
            {
                dayName = "Poniedziałek";
            }
            else if (NowDay == DayOfWeek.Tuesday)
            {
                dayName = "Wtorek";
            }
            else if (NowDay == DayOfWeek.Wednesday)
            {
                dayName = "Środa";
            }
            else if (NowDay == DayOfWeek.Thursday)
            {
                dayName = "Czwartek";
            }
            else if (NowDay == DayOfWeek.Friday)
            {
                dayName = "Piątek";
            }
            else if (NowDay == DayOfWeek.Saturday)
            {
                dayName = "Sobota";
            }
            else if (NowDay == DayOfWeek.Sunday)
            {
                dayName = "Niedziela";
            }
            #endregion


            DataDates = new ObservableCollection<DataDate>
            {

                new DataDate
                {
                    TodayDay = DateTime.Today,
                    DayName = dayName,
                    NumOfDayTxt = numOfDay + " dzień.",
                    NumOfWeekTxt = week + " tydzień.",
                }

            };

        }
        


    }
}

