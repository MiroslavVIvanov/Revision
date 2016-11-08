namespace AnimalSystem.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using AnimalSystem.Classes;

    public static class AnimalAgeOperations
    {
        public static double AverageAge(IEnumerable<Animal> collectionOfAnimals)
        {
            var result = collectionOfAnimals
                .Select(a => a.Age)
                .Average();

            return result;
        }
    }
}
