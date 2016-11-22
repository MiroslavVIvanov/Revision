namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Utils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex + count > arr.Length)
            {
                throw new IndexOutOfRangeException("The subsequence leaves the bounds of the array");
            }

            if (startIndex < 0)
            {
                throw new IndexOutOfRangeException("Start index can not be less than 0");
            }

            if (startIndex >= arr.Length)
            {
                throw new IndexOutOfRangeException("Start index can not be more than the array length");
            }

            if (count <= 0)
            {
                throw new IndexOutOfRangeException("The count of the subsequence must be more than 0");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentException("The count can not be more than array length");
            }

            if (str == string.Empty)
            {
                throw new ArgumentException("The string can not be empty");
            }

            if (str == null)
            {
                throw new ArgumentNullException("The string can not be null");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}