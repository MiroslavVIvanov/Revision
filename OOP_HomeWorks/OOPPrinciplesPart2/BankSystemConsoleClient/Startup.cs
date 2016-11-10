namespace BankSystemConsoleClient
{
    using System;
    using BankSystem.Models;

    public class Startup
    {
        public static void Main()
        {
            Bank bank = new Bank();
            Customer individual = new Individual("Pesho Peshev");
            Customer company = new Company("Company Ltd.");

            Loan loan = new Loan(individual, 10001, 5);
            Deposit deposit = new Deposit(individual, 10001, 5);
            Mortgage mortgage = new Mortgage(individual, 10001, 5);
            Loan compLoan = new Loan(company, 10001, 5);
            Deposit compDeposit = new Deposit(company, 10001, 5);
            Mortgage compMortgage = new Mortgage(company, 10001, 5);

            bank.AddAccount(loan);
            bank.AddAccount(deposit);
            bank.AddAccount(mortgage);
            bank.AddAccount(compLoan);
            bank.AddAccount(compDeposit);
            bank.AddAccount(compMortgage);

            foreach (Account account in bank.BankAccounts)
            {
                Console.WriteLine("{0}, interest for 36 months: {1}", account.ToString(), account.CalculateInterest(36));
            }
        }
    }
}
