namespace FormattingCode
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            while (Engine.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }
    }
}