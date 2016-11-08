namespace SchoolSystem.Classes.Models
{
    using System;
    using SchoolSystem.Intefaces;

    public class Student : Person, ICommentContainer
    {
        private Class studentClass;

        public Student(string name, Class studentClass) 
            : base(name)
        {
            this.studentClass = studentClass;
            studentClass.AddStudent(this);
        }

        public byte ClassNumber { get; set; }

        public string OptionalComment { get; set; }
    }
}
