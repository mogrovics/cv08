using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08
{
    class Program
    {
        static void Main(string[] args)
        {
            Archive archive = new Archive();
            
            archive.Load();
            archive.AllTemps();
            archive.AverageYearTemps();
            archive.AverageMonthTemps();
            //archive.Calibration(-0.1);
            archive.Save();

            archive.AllTemps();
            archive.AverageYearTemps();
            archive.AverageMonthTemps();

            Console.ReadLine();
        }
    }
}