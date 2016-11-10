namespace BankSystem.Models
{
    public class Individual : Customer
    {
        public Individual(string name) 
            : base(name)
        {
            this.CustomerType = Enumerations.CustomerType.Individual;
        }
    }
}
