namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;

    public class Frog : Animal
    {
        public Frog(string name, int age, Gender sex) : base(name, age, sex)
        {
        }

        public override string MakeSound()
        {
            return "Croak";
        }
    }
}
