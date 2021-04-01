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
        private double averageYearTemp;
        

        public YearTemp(int year, List<double> monthTemp)
        {
            this.Year = year;
            this.MonthTemp = monthTemp;
        }

        public int Year { get => year; set => year = value; }
        public List<double> MonthTemp { get => monthTemp; set => monthTemp = value; }
        public double MaxTemp 
        { 
            get
            {
                MonthTemp.Sort();
                return MonthTemp.LastOrDefault();
            }

        }
        public double MinTemp 
        { 
            get
            {
                MonthTemp.Sort();
                return MonthTemp.FirstOrDefault();
            }
        }
        public double AverageYearTemp { get => averageYearTemp = MonthTemp.Average(); }   
    }
}