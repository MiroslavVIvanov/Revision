namespace HumanSystemConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HumanSystem.Classes;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("---------- Students ----------");
            List<Student> students = new List<Student>();
            students.Add(new Student("Pesho", "Peshev", 2));
            students.Add(new Student("Gosho", "Goshev", 1));
            students.Add(new Student("Mariya", "Ivanova", 7));
            students.Add(new Student("Ivan", "Ivanov", 7));
            students.Add(new Student("Minko", "Minkov", 9));
            students.Add(new Student("Gergana", "Ivanova", 12));
            students.Add(new Student("Iliya", "Iliev", 1));
            students.Add(new Student("Toshko", "Toshev", 6));
            students.Add(new Student("Dimitar", "Dimitrov", 6));
            students.Add(new Student("Nikolay", "Nikolov", 7));

            students
                .OrderBy(s => s.Grade)
                .ToList()
                .ForEach(s =>
                {
                    Console.WriteLine(s.ToStringWithAdditionalInfo());
                });

            Console.WriteLine("---------- Workers ----------");
            List<Worker> workers = new List<Worker>();

            workers.Add(new Worker("John", "Doe", 220, 6, 6));
            workers.Add(new Worker("Jane", "Doe", 300));
            workers.Add(new Worker("William", "Doe", 50));
            workers.Add(new Worker("Alan", "Doe", 120));
            workers.Add(new Worker("Dustin", "Doe", 1300));
            workers.Add(new Worker("Johnson", "Doe", 2220, 6, 6));
            workers.Add(new Worker("Mary", "Doe", 130));
            workers.Add(new Worker("Lary", "Doe", 50));
            workers.Add(new Worker("Charles", "Doe", 305));
            workers.Add(new Worker("Jake", "Doe", 713));

            workers
                .OrderBy(w => w.MoneyPerHour())
                .ToList()
                .ForEach(w =>
                {
                    Console.WriteLine(w.ToStringWithAdditionalInfo());
                });

            Console.WriteLine("---------- All ----------");
            List<Human> people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);

            people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList()
                .ForEach(p =>
                {
                    Console.WriteLine(p.ToString());
                });
        }
    }
}
