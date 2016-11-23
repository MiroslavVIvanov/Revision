namespace SchoolSystem.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void TestTheGenerationOfUniqueStudentNumbers()
        {
            School school = new School();

            var expectedAnswer = 10000 + 2;
            var result = school.GenerateStudenUniquetNumber();
            result = school.GenerateStudenUniquetNumber();

            Assert.AreEqual(
                expectedAnswer, 
                result, 
                "Inaccurate generation of student unique number");
        }

        [TestMethod]
        public void TestTheGenerationOfUniqueStudentNumbersWithMoreGenerations()
        {
            School school = new School();

            int numberOfGenerations = 15000;
            var expectedAnswer = 10000 + numberOfGenerations;
            
            var result = 0;
            for (int i = 0; i < numberOfGenerations; i++)
            {
                result = school.GenerateStudenUniquetNumber();
            }

            Assert.AreEqual(
                expectedAnswer, 
                result, 
                "Inaccurate generation of student unique number with 10 000 generations");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTheGenerationOfUniqueStudentNumbersWhenOverflowing()
        {
            School school = new School();

            int numberOfGenerations = 100000;

            var result = 0;
            for (int i = 0; i < numberOfGenerations; i++)
            {
                result = school.GenerateStudenUniquetNumber();
            }
        }

        [TestMethod]
        public void TestTheGenerationOfUniqueStudentNumbersInDifferentSchools()
        {
            School firstSchool = new School();
            School secondSchool = new School();

            var firstSchoolNumber = firstSchool.GenerateStudenUniquetNumber();

            var secondSchoolNumber = firstSchool.GenerateStudenUniquetNumber();
            secondSchoolNumber = firstSchool.GenerateStudenUniquetNumber();

            Assert.AreNotEqual(
                firstSchool, 
                secondSchool, 
                "Inaccurate generation of student number when more than one school is instantiated.");
        }
    }
}
