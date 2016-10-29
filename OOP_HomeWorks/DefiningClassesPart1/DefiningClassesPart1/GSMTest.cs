//Problem 7. GSM test

//Write a class GSMTest to test the GSM class:
//Create an array of few instances of the GSM class.
//Display the information about the GSMs in the array.
//Display the information about the static property IPhone4S.

namespace DefiningClassesPart1
{
    using System;

    public static class GSMTest
    {
        public static void TestGSMClass()
        {
            GSM[] testArray = new GSM[] {
                new GSM("HD7", "HTC"),
                new GSM("3310", "Nokia", 1, "Pesho"),
                new GSM("A536", "Lenovo", 250, "Me", new Battery("Some battery model", 24, 6), new Display(5, 16000000))
            };

            Console.WriteLine("******************************");
            foreach (GSM gsm in testArray)
            {
                Console.WriteLine(gsm.ToString());
                Console.WriteLine("******************************");
            }

            Console.WriteLine(GSM.IPhone4S.ToString());
        }
    }
}
