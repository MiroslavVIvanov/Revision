namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;

        private ICollection<Student> students;

        public Course(ICollection<Student> students)
        {
            this.Students = students;
        }

        public int NumberOfStudentsInCourse
        {
            get
            {
                return this.Students.Count;
            }
        }

        private ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The collection of students can not be null");
                }

                if (value.Count > 30)
                {
                    throw new ArgumentException(
                        string.Format("Too much studens in the course! Max = {0}", MaxStudentsInCourse));
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Count > 30)
            {
                throw new ArgumentException(
                    string.Format("Too much studens in the course! Max = {0}", MaxStudentsInCourse));
            }

            if (student == null)
            {
                throw new ArgumentNullException("Can not add null to course students");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Can not remove null from course students");
            }

            if (this.Students.Count == 0)
            {
                throw new InvalidOperationException("No students in the course");
            }

            if (!this.Students.Contains(student))
            {
                throw new ArgumentException("No such student in this course");
            }

            this.Students.Remove(student);
        }
    }
}
