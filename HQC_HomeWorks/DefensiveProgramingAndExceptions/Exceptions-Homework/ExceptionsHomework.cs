namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            try
            {
                var substr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
                Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
                Console.WriteLine(Utils.ExtractEnding("beer", 4));
                Console.WriteLine(Utils.ExtractEnding("Hi", 100));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var firstNumber = 23;
            var secondNumber = 33;

            Console.WriteLine(firstNumber + (Utils.CheckPrime(firstNumber) ? " is prime." : " is not prime"));
            Console.WriteLine(secondNumber + (Utils.CheckPrime(secondNumber) ? " is prime." : " is not prime"));

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}