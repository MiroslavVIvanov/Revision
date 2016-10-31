namespace Attributes
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var attributes = typeof(Sample).GetCustomAttributes(false);
            foreach (var item in attributes)
            {
                var attr = (Version)item;
                Console.WriteLine(attr);
                Console.WriteLine("Major version: {0}", attr.MajorVersion);
                Console.WriteLine("Minor version: {0}", attr.MinorVersion);
            }
        }
    }
}
