namespace SchoolSystem.Classes.Models
{
    using System;
    using System.Collections.Generic;
    using Intefaces;

    public class Class : ICommentContainer
    {
        private ICollection<Student> studentsInClass;

        public Class(string id)
        {
            this.ID = id;
            this.studentsInClass = new List<Student>();
        }

        public string ID { get; set; }

        public string OptionalComment { get; set; }

        public ICollection<Student> StudentsInClass
        {
            get
            {
                return this.studentsInClass;
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (studentToAdd == null)
            {
                throw new ArgumentException();
            }

            this.studentsInClass.Add(studentToAdd);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (studentToRemove == null)
            {
                throw new ArgumentException();
            }

            this.studentsInClass.Remove(studentToRemove);
        }
    }
}
