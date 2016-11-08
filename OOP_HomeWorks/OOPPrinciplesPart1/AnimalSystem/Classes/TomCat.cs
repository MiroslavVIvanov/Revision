namespace AnimalSystem.Classes
{
    using AnimalSystem.Enumerations;

    public class TomCat : Cat
    {
        public TomCat(string name, int age) : base(name, age, Gender.Male)
        {
        }

        public override string MakeSound()
        {
            return "Miiiiiaaaaaauuuuuu";
        }
    }
}
