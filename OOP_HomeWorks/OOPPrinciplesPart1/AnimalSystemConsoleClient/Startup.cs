namespace AnimalSystemConsoleClient
{
    using System;
    using System.Collections.Generic;
    using AnimalSystem.Classes;
    using AnimalSystem.Enumerations;
    using AnimalSystem.Utilities;

    public class Startup
    {
        public static void Main()
        {
            List<Cat> cats = new List<Cat>();
            cats.Add(new Kitten("Kitty", 1));
            cats.Add(new Kitten("Another Kitty", 2));
            cats.Add(new Kitten("Yet Another Kitty", 1));
            cats.Add(new TomCat("Tom", 12));
            cats.Add(new TomCat("Tomy", 16));
            cats.Add(new TomCat("Tomas", 7));
            cats.Add(new TomCat("Tommy", 8));
            cats.Add(new Cat("Maca", 4, Gender.Female));

            Console.WriteLine("Average age of all cats is: {0:F1} years.", AnimalAgeOperations.AverageAge(cats));

            List<Dog> dogs = new List<Dog>();

            dogs.Add(new Dog("Sharo", 5, Gender.Male));
            dogs.Add(new Dog("Rex", 5, Gender.Male));
            dogs.Add(new Dog("Balkan", 5, Gender.Male));
            dogs.Add(new Dog("Topcho", 5, Gender.Male));

            Console.WriteLine("Average age of all dogs is: {0:F1} years.", AnimalAgeOperations.AverageAge(dogs));

        }
    }
}
