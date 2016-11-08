namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;

    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, Gender.Female)
        {
        }

        public override string MakeSound()
        {
            return "Prrrrrr";
        }
    }
}
