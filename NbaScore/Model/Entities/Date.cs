using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.Model.Entities
{
    class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string DayName { get; set; }

        public string Color { get; set; }

        public Date(int day, int month, int year, string dayName, string color)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.DayName = dayName;
            this.Color = color;
        }
    }
}
