namespace StudentSystemConsoleClient
{
    using StudentSystem.Models;

    public class Startup
    {
        public static void Main()
        {
            Student student = new Student("Pesho", "Ivanov", "Peshev", 1111111111)
            {
                MobilePhone = "+359888123465",
                Course = 3,
                PermanentAddress = "Some permanent address",
                University = StudentSystem.Enumerations.Universities.SU,
                Falculty = StudentSystem.Enumerations.Faculties.Faculty1,
                Specialty = StudentSystem.Enumerations.Specialties.Specialty1
            };
            Student anotherStudent = new Student("Pesho", "Ivanov", "Peshev", 1111111111)
            {
                MobilePhone = "+359888123465",
                Course = 3,
                PermanentAddress = "Some permanent address",
                University = StudentSystem.Enumerations.Universities.SU,
                Falculty = StudentSystem.Enumerations.Faculties.Faculty1,
                Specialty = StudentSystem.Enumerations.Specialties.Specialty1
            };

            System.Console.WriteLine(student.CompareTo(anotherStudent));
        }
    }
}
