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
            
            archive.Load("data_load.txt");
            archive.AllTemps();
            archive.AverageYearTemps();
            archive.AverageMonthTemps();
            archive.Calibration(-0.1);
            archive.Save("data_save.txt");

            Console.ReadLine();
        }
    }
}