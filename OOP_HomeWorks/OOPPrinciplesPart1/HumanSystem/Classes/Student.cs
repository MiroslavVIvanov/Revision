namespace HumanSystem.Classes
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, byte grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public byte Grade { get; set; }

        public override string ToStringWithAdditionalInfo()
        {
            return this.ToString() + string.Format(" - {0} grade", this.Grade);
        }
    }
}
