namespace StudentsQueries
{
    using System.Collections.Generic;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FN { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public List<byte> Marks { get; set; }

        public int GroupNumber { get; set; }
    }
}
