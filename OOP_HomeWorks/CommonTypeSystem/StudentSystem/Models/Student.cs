namespace StudentSystem.Models
{
    using System;
    using StudentSystem.Enumerations;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, ulong ssn)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ulong SSN { get; set; }

        public string PermanentAddress { get; set; }

        public string MobilePhone { get; set; }

        public int Course { get; set; }

        public Universities University { get; set; }

        public Faculties Falculty { get; set; }

        public Specialties Specialty { get; set; }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public override bool Equals(object student)
        {
            if (!(student is Student))
            {
                return false;
            }

            Student otherStudent = student as Student;
            if (this.FirstName == otherStudent.FirstName &&
                this.MiddleName == otherStudent.MiddleName &&
                this.LastName == otherStudent.LastName &&
                this.SSN == otherStudent.SSN)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 1;
            for (int i = 0; i < this.FirstName.Length; i++)
            {
                hashCode ^= this.FirstName[i];
            }

            for (int i = 0; i < this.LastName.Length; i++)
            {
                hashCode ^= this.LastName[i];
            }

            for (int i = 0; i < this.SSN.ToString().Length; i++)
            {
                hashCode ^= this.SSN.ToString()[i];
            }

            return hashCode;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} {1} {2}, SSN: {3}",
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SSN);
        }

        public object Clone()
        {
            Student newStudent = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN)
            {
                PermanentAddress = this.PermanentAddress,
                MobilePhone = this.MobilePhone,
                Course = this.Course,
                University = this.University,
                Falculty = this.Falculty,
                Specialty = this.Specialty
            };

            return newStudent;
        }

        public int CompareTo(object student)
        {
            if (!(student is Student))
            {
                throw new ArgumentException("Cannot compare the two objects!");
            }

            Student otherStudent = student as Student;

            return this.CompareTo(otherStudent);
        }

        public int CompareTo(Student other)
        {
            string firstString = string.Format("{0}{1}{2}", this.FirstName, this.MiddleName, this.LastName);
            string secondString = string.Format("{0}{1}{2}", other.FirstName, other.MiddleName, other.LastName);

            if (firstString.CompareTo(secondString) == -1)
            {
                return 1;
            }

            if (firstString.CompareTo(secondString) == 1)
            {
                return -1;
            }

            if (this.SSN > other.SSN)
            {
                return -1;
            }

            if (this.SSN < other.SSN)
            {
                return 1;
            }

            return 0;
        }
    }
}
