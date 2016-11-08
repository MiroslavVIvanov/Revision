namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;
    using AnimalSystem.Interfaces;

    public abstract class Animal : IAnimal, ISound
    {
        protected Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Sex { get; set; }

        public abstract string MakeSound();
    }
}
