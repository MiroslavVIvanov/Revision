namespace SchoolSystem.Classes.Models
{
    public abstract class Person
    {
        protected Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
