namespace StudentsQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            // Problem 9.Student groups
            // Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks(a List), GroupNumber.
            // Create a List<Student> with sample students.Select only the students that are from group number 2.
            // Use LINQ query.Order the students by FirstName.
            // Problem 10.Student groups extensions
            // Implement the previous using the same query expressed with extension methods.
            Console.WriteLine("---------- 9, 10 ----------");

            List<Student> newStudents = new List<Student>();
            newStudents.Add(new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Email = "P.Peshev@abv.bg",
                GroupNumber = 2,
                Telephone = "021111111",
                Marks = new List<byte>() { 2, 4, 3, 6 },
                FN = 111106
            });
            newStudents.Add(new Student()
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Email = "G.Goshev@abv.bg",
                GroupNumber = 3,
                Telephone = "051111111",
                Marks = new List<byte>() { 2, 4, 3 },
                FN = 111103
            });
            newStudents.Add(new Student()
            {
                FirstName = "Haralampi",
                LastName = "Ivanov",
                Email = "Haralampi132@gmail.com",
                GroupNumber = 2,
                Telephone = "+35922222222",
                Marks = new List<byte>() { 6, 6 },
                FN = 111106
            });
            newStudents.Add(new Student()
            {
                FirstName = "Kuna",
                LastName = "Iovanova",
                Email = "kuna@hotmail.com",
                GroupNumber = 1,
                Telephone = "35923333333",
                Marks = new List<byte>() { 2, 2, 2 },
                FN = 111116
            });
            newStudents.Add(new Student()
            {
                FirstName = "Pena",
                LastName = "Pesheva",
                Email = "P.Pesheva@abv.bg",
                GroupNumber = 2,
                Telephone = "051111111",
                Marks = new List<byte>() { 6, 4, 6, 6 },
                FN = 111106
            });

            var selectedStudentsLINQ =
                from stud in newStudents
                where (stud.GroupNumber == 2)
                orderby stud.FirstName
                select stud;

            var selectedStudentsExtensions =
                newStudents
                .Where(s => s.GroupNumber == 2)
                .OrderBy(s => s.FirstName)
                .ToList();

            foreach (var student in selectedStudentsLINQ)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.GroupNumber);
            }

            Console.WriteLine("-  -  -  -  -  -");
            foreach (var student in selectedStudentsExtensions)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.GroupNumber);
            }

            // Problem 11.Extract students by email
            // Extract all students that have email in abv.bg.
            // Use string methods and LINQ.
            Console.WriteLine("---------- 11 ----------");

            var studentsByEmail =
                from student in newStudents
                where (student.Email.Substring(student.Email.Length - 6).ToLower() == "abv.bg")
                select student;

            foreach (var student in studentsByEmail)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Email);
            }

            // Problem 12.Extract students by phone
            // Extract all students with phones in Sofia.
            // Use LINQ.
            Console.WriteLine("---------- 12 ----------");

            var studentsByPhone =
                from student in newStudents
                where (
                (student.Telephone.Substring(0, 2) == "02") ||
                (student.Telephone.Substring(0, 4) == "3592") ||
                (student.Telephone.Substring(0, 5) == "+3592"))
                select student;

            foreach (var student in studentsByPhone)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Telephone);
            }

            // Problem 13.Extract students by marks
            // Select all students that have at least one mark Excellent(6) into a new anonymous class that has properties – FullName and Marks.
            // Use LINQ.
            Console.WriteLine("---------- 13 ----------");

            var excellentStudents =
                from student in newStudents
                where student.Marks.Any(m => m == 6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            foreach (var student in excellentStudents)
            {
                Console.WriteLine(student.FullName);
            }

            // Problem 14.Extract students with two marks
            // Write down a similar program that extracts the students with exactly two marks "2".
            // Use extension methods
            Console.WriteLine("---------- 14 ----------");

            var twoMarktStudents =
                newStudents
                    .Where(s => s.Marks.Count == 2)
                    .Select(s => new
                    {
                        FullName = s.FirstName + " " + s.LastName
                    });

            foreach (var student in twoMarktStudents)
            {
                Console.WriteLine(student.FullName);
            }

            // Problem 15.Extract marks
            // Extract all Marks of the students that enrolled in 2006. 
            // (The students from 2006 have 06 as their 5 - th and 6 - th digit in the FN).
            Console.WriteLine("---------- 15 ----------");

            var marksEx = newStudents
                .Where(s => s.FN % 100 == 6)
                .SelectMany(s => s.Marks)
                .ToList();

            Console.WriteLine("Extension methods: " + string.Join(", ", marksEx));

            var marks =
                from mark in (
                    from student in newStudents
                    where (student.FN % 100 == 6)
                    select student.Marks)
                select mark;

            Console.WriteLine("LINQ query: ");
            foreach (var mark in marks)
            {
                Console.WriteLine(string.Join(", ", mark));
            }

            // Problem 18.Grouped by GroupNumber
            // Create a program that extracts all students 
            // grouped by GroupNumber and then prints them to the console.
            // Use LINQ.
            Console.WriteLine("---------- 18 ----------");

            var groups =
                from student in newStudents
                orderby student.GroupNumber
                group student by student.GroupNumber;

            foreach (var group in groups)
            {
                foreach (var student in group)
                {
                    Console.WriteLine("Group number: {0} - {1} {2}", student.GroupNumber, student.FirstName, student.LastName);
                }
            }

            // Problem 19.Grouped by GroupName extensions
            // Rewrite the previous using extension methods.
            Console.WriteLine("---------- 19 ----------");

            var groupEx = newStudents
                .OrderBy(s => s.GroupNumber)
                .GroupBy(s => s.GroupNumber)
                .ToList();

            foreach (var group in groupEx)
            {
                foreach (var student in group)
                {
                    Console.WriteLine("Group number: {0} - {1} {2}", student.GroupNumber, student.FirstName, student.LastName);
                }
            }
        }
    }
}
