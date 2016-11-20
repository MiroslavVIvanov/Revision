namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private ICollection<string> students;

        public Course(string courseName, string teacherName, ICollection<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Course name invalid!");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("Teacher name invalid!");
                }

                this.teacherName = value;
            }
        }

        private ICollection<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The collection of students is invalid!");
                }

                this.students = value;
            }
        }

        public void AddStudent(string studentName)
        {
            if (studentName == null || studentName.Length == 0)
            {
                throw new ArgumentException("Student name invalid!");
            }

            this.Students.Add(studentName);
        }

        public void RemoveStudent(string studentName)
        {
            if (studentName == null || studentName.Length == 0)
            {
                throw new ArgumentException("Student name invalid!");
            }

            if (!this.Students.Contains(studentName))
            {
                throw new ArgumentException("No student with such name in course students!");
            }

            this.Students.Remove(studentName);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Course { ");
            result.AppendFormat("    Name = {0};\n\r", this.Name);
            result.AppendFormat("    Teacher = {0};\n\r", this.TeacherName);
            result.AppendFormat("    Students = {0};\n\r", this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students.Count == 0)
            {
                return "{ No students in this course }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
