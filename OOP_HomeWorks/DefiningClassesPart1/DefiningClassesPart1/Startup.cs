namespace DefiningClassesPart1
{
    using System;

    internal class Startup
    {
        static void Main()
        {
            GSMTest.TestGSMClass();
            Console.WriteLine("******************************");
            GSMCallHistoryTest.TestGSMCalls();
        }
    }
}
