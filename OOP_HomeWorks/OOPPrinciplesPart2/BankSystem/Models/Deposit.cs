namespace BankSystem.Models
{
    using System;
    using BankSystem.Interfaces;

    public class Deposit : Account, IAccount, IInterestCalculator
    {
        public Deposit(Customer customer, decimal initialBalance, decimal interestRate) 
            : base(customer, initialBalance, interestRate)
        {
        }

        public void WithdrawMoney(decimal amountToWithdraw)
        {
            if (amountToWithdraw < 0)
            {
                throw new ArgumentException("Amount to withdraw can not be negative!");
            }

            if (amountToWithdraw > this.Balance)
            {
                throw new ArgumentException("Insufficient account balance!");
            }

            this.Balance -= amountToWithdraw;
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(numberOfMonths);
        }
    }
}
