namespace SchoolSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentSystem;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseConstructorWithNullStudents()
        {
            List<Student> students = null;

            Course course = new Course(students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructorWithStudentsMoreThanCourseCapacity()
        {
            School school = new School();

            List<Student> students = new List<Student>();
            for (int i = 0; i < 40; i++)
            {
                students.Add(new Student(i.ToString(), school));
            }

            Course course = new Course(students);
        }

        [TestMethod]
        public void TestCourseConstructor()
        {
            School school = new School();

            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student(i.ToString(), school));
            }

            Course course = new Course(students);

            Assert.AreEqual(
                students.Count, 
                course.NumberOfStudentsInCourse,
                "Inaccurate assigning of students");
        }

        [TestMethod]
        public void TestAddingStudentInCourse()
        {
            School school = new School();

            List<Student> students = new List<Student>();

            Course course = new Course(students);

            int expectedStudentCount = 1;
            course.AddStudent(new Student("Some student's name", school));

            Assert.AreEqual(
                expectedStudentCount,
                course.NumberOfStudentsInCourse,
                "Inacurate adding of student to course");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddingMoreStudentInCourseThanAllowed()
        {
            School school = new School();
            List<Student> students = new List<Student>();
            Course course = new Course(students);

            for (int i = 0; i < 40; i++)
            {
                course.AddStudent(new Student(i.ToString(), school));
            }
        }

        [TestMethod]
        public void TestRemovingStudent()
        {
            School school = new School();
            List<Student> students = new List<Student>();
            Course course = new Course(students);
            Student student = new Student("some student name", school);
            course.AddStudent(student);
            int expectedNumberOfStudents = 0;

            course.RemoveStudent(student);

            Assert.AreEqual(
                expectedNumberOfStudents,
                course.NumberOfStudentsInCourse,
                "Inaccurate removing of student from course");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemovingStudentFromEmptyCollection()
        {
            School school = new School();
            List<Student> students = new List<Student>();
            Course course = new Course(students);
            Student student = new Student("some student name", school);

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingStudentThatDoesNotExistInCourse()
        {
            School school = new School();
            List<Student> students = new List<Student>() { new Student("Name", school) };
            Course course = new Course(students);

            Student studentToBeRemoved = new Student("some student name", school);

            course.RemoveStudent(studentToBeRemoved);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullFromCourse()
        {
            School school = new School();
            List<Student> students = new List<Student>() { new Student("Name", school) };
            Course course = new Course(students);

            Student studentToBeRemoved = null;

            course.RemoveStudent(studentToBeRemoved);
        }
    }
}
