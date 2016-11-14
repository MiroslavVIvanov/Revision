namespace PersonSystem
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Person person = new Person("Pesho", 23);
            Person anotherPerson = new Person("Gosho");

            Console.WriteLine(person);
            Console.WriteLine(anotherPerson);
        }
    }
}
