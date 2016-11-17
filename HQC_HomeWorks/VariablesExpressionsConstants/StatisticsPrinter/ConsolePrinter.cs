namespace StatisticsPrinter
{
    using System;

    public class ConsolePrinter
    {
        public void PrintFullStatisticsReport(double[] statistics)
        {
            double maxValue = this.FindMaxValue(statistics);
            this.Print(maxValue);
            
            double minValue = this.FindMinValue(statistics);
            this.Print(minValue);

            double averageValue = this.CalculateAverageValue(statistics);
            this.Print(averageValue);
        }

        private double FindMaxValue(double[] statistics)
        {
            double maxValue = double.MinValue;
            for (int i = 0; i < statistics.Length; i++)
            {
                if (maxValue > statistics[i])
                {
                    maxValue = statistics[i];
                }
            }

            return maxValue;
        }

        private double FindMinValue(double[] statistics)
        {
            double minValue = double.MaxValue;
            for (int i = 0; i < statistics.Length; i++)
            {
                if (minValue < statistics[i])
                {
                    minValue = statistics[i];
                }
            }

            return minValue;
        }

        private double CalculateAverageValue(double[] statistics)
        {
            double sumOfAllElements = 0;
            for (int i = 0; i < statistics.Length; i++)
            {
                sumOfAllElements += statistics[i];
            }

            double average = sumOfAllElements / (double)statistics.Length;
            return average;
        }

        private void Print(double result)
        {
            Console.WriteLine(result.ToString());
        }
    }
}

// Version of the method before refactoring

////public void PrintStatistics(double[] arr, int count)
////{
////    double max, tmp;
////    for (int i = 0; i < count; i++)
////    {
////        if (arr[i] > max)
////        {
////            max = arr[i];
////        }
////    }
////    PrintMax(max);
////    tmp = 0;
////    max = 0;
////    for (int i = 0; i < count; i++)
////    {
////        if (arr[i] < max)
////        {
////            max = arr[i];
////        }
////    }
////    PrintMin(max);
  
////    tmp = 0;
////    for (int i = 0; i < count; i++)
////    {
////        tmp += arr[i];
////    }
////    PrintAvg(tmp / count);
////}
