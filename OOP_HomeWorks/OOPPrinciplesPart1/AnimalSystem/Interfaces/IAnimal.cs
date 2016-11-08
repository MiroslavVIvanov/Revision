namespace AnimalSystem.Interfaces
{
    using AnimalSystem.Enumerations;

    public interface IAnimal
    {
        string Name { get; set; }

        int Age { get; set; }

        Gender Sex { get; set; }
    }
}
