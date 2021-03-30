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
            Archive test = new Archive();
            
            test.Load();
            test.AllTemps();
            test.AverageYearTemps();
            test.AverageMonthTemps();
            test.Calibration(0.1);
            test.Save();

            Console.ReadLine();
        }
    }
}
