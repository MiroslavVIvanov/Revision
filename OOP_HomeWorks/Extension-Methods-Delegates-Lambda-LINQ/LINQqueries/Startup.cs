namespace LINQqueries
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student() { FirstName = "Alex", LastName = "Petrov", Age = 7 },
                new Student() { FirstName = "Haralampi", LastName = "Ivanov", Age = 11 },
                new Student() { FirstName = "Gruiu", LastName = "Draganov", Age = 13 },
                new Student() { FirstName = "Ramadan", LastName = "Gruev", Age = 22 },
                new Student() { FirstName = "Kuna", LastName = "Mihailova", Age = 27 },
                new Student() { FirstName = "Pena", LastName = "Petrova", Age = 23 },
                new Student() { FirstName = "Pesho", LastName = "Goshov", Age = 18 }
            };

            // Problem 3.First before last
            // Write a method that from a given array of students 
            // finds all students whose first name is before its last name alphabetically.
            // Use LINQ query operators.
            var filteredStudents =
                from stud in students
                where (stud.FirstName.CompareTo(stud.LastName) < 0)
                select stud;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            // Problem 4.Age range
            // Write a LINQ query that finds the first name and 
            // last name of all students with age between 18 and 24.
            Console.WriteLine("------------------------------------------");
            var studentsFilteredByAge =
                from stud in students
                where (stud.Age >= 18 && stud.Age <= 24)
                select new { stud.FirstName, stud.LastName };

            foreach (var student in studentsFilteredByAge)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            // Problem 5.Order students
            // Using the extension methods OrderBy() and ThenBy() 
            // with lambda expressions sort the students by 
            // first name and last name in descending order.
            // Rewrite the same with LINQ.
            Console.WriteLine("------------------------------------------");
            var orderedStudents =
                from stud in students
                orderby stud.FirstName ascending,
                stud.LastName descending
                select stud;

            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            var anotherOrderedStudents =
                students
                .OrderBy(stud => stud.FirstName)
                .ThenByDescending(stud => stud.LastName)
                .ToList();

            Console.WriteLine("-  -  -  -  -  -");
            foreach (var student in anotherOrderedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            // Problem 6.Divisible by 7 and 3
            // Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
            // Use the built-in extension methods and lambda expressions.Rewrite the same with LINQ.
            Console.WriteLine("------------------------------------------");

            int[] arrayOfNumbers = new int[] { 2, 77, 30, 21, 49, 42, 100, 147 };

            var devisable =
                from number in arrayOfNumbers
                where (number % 3 == 0 && number % 7 == 0)
                select number;

            foreach (var num in devisable)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("-  -  -  -  -  -");
            var devisableWihtExtensions =
                arrayOfNumbers
                    .Where(number => number % 3 == 0 && number % 7 == 0)
                    .ToList();

            foreach (var num in devisableWihtExtensions)
            {
                Console.WriteLine(num);
            }
        }
    }
}
