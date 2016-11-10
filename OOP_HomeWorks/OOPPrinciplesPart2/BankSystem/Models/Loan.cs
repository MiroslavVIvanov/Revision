namespace BankSystem.Models
{
    using System;
    using BankSystem.Interfaces;

    public class Loan : Account, IAccount, IInterestCalculator
    {
        public Loan(Customer customer, decimal initialBalance, decimal interestRate) 
            : base(customer, initialBalance, interestRate)
        {
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (this.CustomerType == Enumerations.CustomerType.Individual)
            {
                numberOfMonths -= 3;
            }

            if (this.CustomerType == Enumerations.CustomerType.Company)
            {
                numberOfMonths -= 2;
            }

            return base.CalculateInterest(numberOfMonths);
        }
    }
}
