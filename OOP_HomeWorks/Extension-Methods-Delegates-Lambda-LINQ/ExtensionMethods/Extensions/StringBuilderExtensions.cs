// Problem 1. StringBuilder.Substring
// Implement an extension method Substring(int index, int length) for the 
// class StringBuilder that returns new StringBuilder 
// and has the same functionality as Substring in the class String.

namespace ExtensionMethods.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder newStringBuilder = new StringBuilder();
            try
            {
                for (int i = index; i < length; i++)
                {
                    newStringBuilder.Append(sb[i]);
                }

                return newStringBuilder;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
