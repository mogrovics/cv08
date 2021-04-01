using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08
{
    public class YearTemp
    {
        private int year;
        private List<double> monthTemp;    

        public YearTemp(int year, List<double> monthTemp)
        {
            Year = year;
            MonthTemp = monthTemp;
        }

        public int Year { get => year; set => year = value; }
        public List<double> MonthTemp { get => monthTemp; set => monthTemp = value; }
        public double MaxTemp { get => MonthTemp.Max(); }
        public double MinTemp { get => MonthTemp.Min(); }
        public double AverageYearTemp { get => MonthTemp.Average(); }   
    }
}