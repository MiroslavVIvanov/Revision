namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "Can not sort empty array!");
            Debug.Assert(arr != null, "Can not sort null array!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "Can not traverse empty array!");
            Debug.Assert(arr != null, "Can not traverse null array!");
            Debug.Assert(startIndex >= 0, "Start index is out of range");
            Debug.Assert(endIndex < arr.Length, "End index is out of range");
            Debug.Assert(startIndex <= endIndex, "End index is smaller than start index");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= 0, "Min element index is out of range ( less than 0 )");
            Debug.Assert(
                minElementIndex < arr.Length,
                "Min element index is out of range ( more than the length of the array )");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 0, "Can not traverse empty array!");
            Debug.Assert(arr != null, "Can not traverse null array!");
            Debug.Assert(startIndex >= 0, "Start index is out of range");
            Debug.Assert(endIndex < arr.Length, "End index is out of range");
            Debug.Assert(startIndex <= endIndex, "End index is smaller than start index");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}