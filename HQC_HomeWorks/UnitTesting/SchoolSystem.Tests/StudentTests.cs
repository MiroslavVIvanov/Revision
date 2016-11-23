namespace SchoolSystem.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentCosntructorWithEmptyName()
        {
            School school = new School();
            string studentName = string.Empty;

            Student student = new Student(studentName, school);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentCosntructorWithNullName()
        {
            School school = new School();
            string studentName = null;

            Student student = new Student(studentName, school);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentCosntructorWithNullSchool()
        {
            string studentName = "Student name";
            School school = null;

            Student student = new Student(studentName, school);
        }

        [TestMethod]
        public void TestStudentCosntructor()
        {
            string studentName = "Pesho";
            School school = new School();

            Student student = new Student(studentName, school);

            Assert.AreEqual(
                studentName, 
                student.Name,
                "Student name is not assignet properly");
        }

        [TestMethod]
        public void TestStudentUniqueNumber()
        {
            School school = new School();

            string firstStudentName = "First Student";
            string secondStudentName = "Second Student";

            Student firstStudent = new Student(firstStudentName, school);
            Student secondStudent = new Student(secondStudentName, school);

            var expectedSecondStudentNumber = 10000 + 2;

            Assert.AreEqual(
                expectedSecondStudentNumber, 
                secondStudent.Number,
                "Student number is not assignet properly");
        }
    }
}
