namespace BankSystem.Models
{
    using BankSystem.Interfaces;

    public class Mortgage : Account, IAccount, IInterestCalculator
    {
        private const int MonthsWithoutInterest = 12;

        public Mortgage(Customer customer, decimal initialBalance, decimal interestRate)
            : base(customer, initialBalance, interestRate)
        {
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            switch (this.CustomerType)
            {
                case Enumerations.CustomerType.Individual:
                    numberOfMonths -= 6;
                    base.CalculateInterest(numberOfMonths);
                    break;
                case Enumerations.CustomerType.Company:
                    if (numberOfMonths <= MonthsWithoutInterest)
                    {
                        return base.CalculateInterest(numberOfMonths) / 2m;
                    }

                    decimal tempInterest = 0;
                    tempInterest += base.CalculateInterest(MonthsWithoutInterest) / 2m;
                    numberOfMonths -= MonthsWithoutInterest;
                    tempInterest += base.CalculateInterest(numberOfMonths);

                    return tempInterest;
            }

            return base.CalculateInterest(numberOfMonths);
        }
    }
}
