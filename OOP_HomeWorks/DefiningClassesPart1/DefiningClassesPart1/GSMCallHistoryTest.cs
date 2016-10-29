//Problem 12. Call history test

//Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//Create an instance of the GSM class.
//Add few calls.
//Display the information about the calls.
//Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//Remove the longest call from the history and calculate the total price again.
//Finally clear the call history and print it.

namespace DefiningClassesPart1
{
    using System;

    public static class GSMCallHistoryTest
    {
        public static void TestGSMCalls()
        {
            GSM phone = new GSM("G3", "LG");

            phone.AddCall(new DateTime(2016, 10, 27, 10, 35, 12), "+359888888888", 137);
            phone.AddCall(new DateTime(2016, 10, 29, 19, 35, 12), "+359888888888", 13);
            phone.AddCall(new DateTime(2016, 10, 28, 17, 35, 12), "+359888123456", 2232);
            phone.AddCall(new DateTime(2016, 10, 29, 13, 35, 12), "+359888654321", 101);
            phone.AddCall(new DateTime(2016, 10, 29, 19, 35, 12), "+359888888888", 128);

            Console.WriteLine(phone.CallHistoryToString());

            Console.WriteLine("Total price of all list: {0}", phone.CallHistoryTotalPrice(0.37));

            int maxDuration = 0;
            Call callWithMaxDuration = phone.CallHistory[0];

            foreach (Call call in phone.CallHistory)
            {
                if (call.DurationInSec >= maxDuration)
                {
                    maxDuration = call.DurationInSec;
                    callWithMaxDuration = call;
                }
            }

            phone.RemoveCall(callWithMaxDuration);

            Console.WriteLine("Total price of all list after removing longest call: {0}", phone.CallHistoryTotalPrice(0.37));
        }
    }
}
