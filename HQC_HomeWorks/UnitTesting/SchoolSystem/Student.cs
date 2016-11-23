namespace StudentSystem
{
    using System;

    public class Student
    {
        private School school;

        public Student(string name, School school)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Student name can not be null");
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Student name can not be empty");
            }

            if (school == null)
            {
                throw new ArgumentNullException("The school can not be null");
            }

            this.school = school;

            this.Name = name;
            this.Number = school.GenerateStudenUniquetNumber();
        }

        public string Name { get; set; }

        public int Number { get; set; }
    }
}
