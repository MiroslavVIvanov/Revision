namespace BankSystem.Models
{
    public class Company : Customer
    {
        public Company(string name) 
            : base(name)
        {
            this.CustomerType = Enumerations.CustomerType.Company;
        }
    }
}
