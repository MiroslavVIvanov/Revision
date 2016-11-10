namespace BankSystem.Models
{
    using BankSystem.Enumerations;

    public abstract class Customer
    {
        protected Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public CustomerType CustomerType { get; protected set; }
    }
}
