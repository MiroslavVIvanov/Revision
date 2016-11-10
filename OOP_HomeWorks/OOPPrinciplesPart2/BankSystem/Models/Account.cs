namespace BankSystem.Models
{
    using System;
    using BankSystem.Interfaces;
    using Enumerations;

    public abstract class Account : IAccount, IInterestCalculator
    {
        protected Account(Customer customer, decimal initialBalance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = initialBalance;
            this.InterestRate = interestRate;
            this.CustomerType = customer.CustomerType;
        }

        public Customer Customer { get; set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; set; }

        protected CustomerType CustomerType { get; set; }

        public void DepositMoney(decimal amountToDeposit)
        {
            if (amountToDeposit < 0)
            {
                throw new ArgumentException("The amount to deposit can not be negative!");
            }

            this.Balance += amountToDeposit;
        }

        public virtual decimal CalculateInterest(int numberOfMonths)
        {
            return (numberOfMonths * this.InterestRate * this.Balance) / 100;
        }

        public override string ToString()
        {
            return string.Format(
                "Account customer: {0}, Balance: {1}, Interest: {2}%",
                this.Customer.Name,
                this.Balance,
                this.InterestRate);
        }
    }
}
