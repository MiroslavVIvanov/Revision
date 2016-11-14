namespace PersonSystem
{
    public class Person
    {
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, age: {1}", 
                this.Name, 
                this.Age != null ? this.Age.ToString() : "not specified");
        }
    }
}
