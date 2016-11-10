namespace ExceptionsTask
{
    using System;

    public class TestException
    {
        public static void Main()
        {
            Console.Write("Input number [0...100]: ");
            int testInt = int.Parse(Console.ReadLine());

            try
            {
                if (testInt < 0 || testInt > 100)
                {
                    throw new InvalidRangeException<int>("Number is out of the range", 0, 100);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{0}: [{1}...{2}]", ex.Message, ex.RangeStart, ex.RangeEnd);
            }

            Console.Write("Input date (dd.MM.yyyy): ");

            DateTime testdate = DateTime.ParseExact(
                Console.ReadLine(),
                "dd.MM.yyyy",
                System.Globalization.DateTimeFormatInfo.InvariantInfo);

            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            try
            {
                if (testdate < startDate || testdate > endDate)
                {
                    throw new InvalidRangeException<DateTime>("Date is out of the range", startDate, endDate);
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("{0}: [{1:dd.MM.yyyy}...{2:dd.MM.yyyy}]", ex.Message, ex.RangeStart, ex.RangeEnd);
            }
        }
    }
}
