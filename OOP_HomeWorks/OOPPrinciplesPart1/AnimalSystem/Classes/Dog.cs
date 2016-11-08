namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;

    public class Dog : Animal
    {
        public Dog(string name, int age, Gender sex) : base(name, age, sex)
        {
        }

        public override string MakeSound()
        {
            return "Baaaaauuuu";
        }
    }
}
