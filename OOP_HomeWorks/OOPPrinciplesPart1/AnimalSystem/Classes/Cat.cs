namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;

    public class Cat : Animal
    {
        public Cat(string name, int age, Gender sex) : base(name, age, sex)
        {
        }

        public override string MakeSound()
        {
            return "Miau";
        }
    }
}
