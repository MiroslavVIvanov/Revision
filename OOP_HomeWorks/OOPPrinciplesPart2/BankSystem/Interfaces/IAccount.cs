namespace BankSystem.Interfaces
{
    using BankSystem.Models;

    public interface IAccount
    {
        decimal Balance { get; }

        Customer Customer { get; set; }

        decimal InterestRate { get; set; }

        void DepositMoney(decimal amountToDeposit);
    }
}