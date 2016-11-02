namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ExtensionMethods.Extensions;

    public class Startup
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder("abcdefghijklmnopqrstuvwxyz");
            Console.WriteLine(sb.Substring(0, 2).ToString());

            List<int> list = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine(list.Max());
        }
    }
}
