// Problem 2. IEnumerable extensions
// Implement a set of extension methods for IEnumerable<T> that implement the 
// following group functions: sum, product, min, max, average.

    namespace ExtensionMethods.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection empty!");
            }

            double test;

            if (!double.TryParse(collection.First().ToString(), out test))
            {
                throw new ArgumentException("Elements in collection must be numbers!");
            }

            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }

            return (T)sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection empty!");
            }

            double test;
            if (!double.TryParse(collection.First().ToString(), out test))
            {
                throw new ArgumentException("Elements in collection must be numbers!");
            }

            dynamic product = 1;
            foreach (var item in collection)
            {
                product *= (dynamic)item;
            }

            return (T)product;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection empty!");
            }

            double test;
            if (!double.TryParse(collection.First().ToString(), out test))
            {
                throw new ArgumentException("Elements in collection must be numbers!");
            }

            dynamic sum = 0.0d;
            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }

            return (T)(sum / (double)collection.Count());
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection empty!");
            }

            T min = collection.First();

            foreach (var item in collection)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection empty!");
            }

            T max = collection.First();

            foreach (var item in collection)
            {
                if (item.CompareTo(max) >= 0)
                {
                    max = item;
                }
            }

            return max;
        }
    }
}
