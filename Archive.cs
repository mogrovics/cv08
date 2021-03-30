using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv08
{
    public class Archive
    {
        private SortedDictionary<int, YearTemp> _archive;

        public void Load()
        {
            string line;
            int year;
            _archive = new SortedDictionary<int, YearTemp>();

            StreamReader reader = File.OpenText(@"soubor.txt");
            
            
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                char[] separator = { ' ', ':', ';' };
                string[] partition = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                List<double> temparatures = new List<double>();

                year = Int32.Parse(partition[0]);
                
                for (int i = 1; i < partition.Length; i++) 
                {
                    temparatures.Add(Double.Parse(partition[i]));
                }

                _archive.Add(year, new YearTemp(year, temparatures));
            }

            reader.Close();
        }

        public void Save()
        {
            StreamWriter writer = File.CreateText(@"soubor.txt");

            foreach (var yearTemp in _archive.Values)
            {
                writer.Write("{0}: ", yearTemp.Year);

                for (int i = 0; i < yearTemp.MonthTemp.Count; i++)
                {
                    if (i != yearTemp.MonthTemp.Count - 1)
                        writer.Write("{0:0.0}; ", yearTemp.MonthTemp[i]);
                    else
                        writer.Write("{0:0.0}\n", yearTemp.MonthTemp[i]);
                }
            }

            writer.Close();
        }

        public void Calibration(double calibrationValue)
        {
            foreach (var temp in _archive.Values)
            {
                for (int i = 0; i < temp.MonthTemp.Count; i++)
                {
                    temp.MonthTemp[i] += calibrationValue;
                }
            }
        }

        public YearTemp Search(int year)
        {
            try
            {
                return _archive[year];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {

                throw new System.Collections.Generic.KeyNotFoundException("Invalid year.");
            }
        }

        public void AllTemps()
        {
            Console.WriteLine("All temperatures by year:");

            foreach (var yearData in _archive.Values)
            {
                Console.Write("{0}: ", yearData.Year);
                
                for (int i = 0; i < yearData.MonthTemp.Count; i++)
                {
                    if (i != yearData.MonthTemp.Count - 1)
                        Console.Write("{0:0.0}  ", yearData.MonthTemp[i]);
                    else
                        Console.Write("{0:0.0}\n", yearData.MonthTemp[i]);
                }
            }
            
            /*
            for (int i = 0; i < _archive.Count; i++)
            {
                int year = _archive.Keys.ElementAt(i);
                YearTemp yearData = Search(year);

                Console.Write("{0}: ", yearData.Year);

                for (int j = 0; j < yearData.MonthTemp.Count; j++)
                {
                    if (j != yearData.MonthTemp.Count - 1)
                        Console.Write("{0:0.0}  ", yearData.MonthTemp[j]);
                    else
                        Console.Write("{0:0.0}\n", yearData.MonthTemp[j]);
                }
            }
            */
        }

        public void AverageYearTemps()
        {
            Console.WriteLine("\nAverage year temperatures:");

            foreach (var yearData in _archive.Values)
            {
                Console.WriteLine("{0}: {1:0.0}", yearData.Year, yearData.AverageYearTemp);
            }
            
        }

        public void AverageMonthTemps()
        {
            Console.WriteLine("\nAverage monthly temperatures:");
            List<double> monthAverages = new List<double>();
            //YearTemp dataSet = Search(_archive.First().Key);

            foreach (var yearData in _archive.Values)
            {
                for (int i = 0; i < yearData.MonthTemp.Count; i++)
                {
                    if (monthAverages.Count < yearData.MonthTemp.Count)
                        monthAverages.Add(yearData.MonthTemp[i]);

                    else
                        monthAverages[i] += yearData.MonthTemp[i];
                }
            }

            for (int i = 0; i < monthAverages.Count; i++)
            {
                monthAverages[i] /= _archive.Values.Count;

                if (i != monthAverages.Count - 1)
                    Console.Write("{0:0.0}  ", monthAverages[i]);
                else
                    Console.Write("{0:0.0}\n", monthAverages[i]);
            }
            
            

            

        }
    }
}
