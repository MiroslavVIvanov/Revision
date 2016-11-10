namespace BankSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bank
    {
        private ICollection<Account> bankAccounts;

        public Bank()
        {
            this.bankAccounts = new List<Account>();
        }

        public ICollection<Account> BankAccounts
        {
            get
            {
                return this.bankAccounts;
            }

            private set
            {
                this.bankAccounts = value;
            }
        }

        public void AddAccount(Account accountToAdd)
        {
            this.BankAccounts.Add(accountToAdd);
        }

        public void RemoveAccount(Account accountToRemove)
        {
            this.BankAccounts.Remove(accountToRemove);
        }

        public string DisplayAccounts()
        {
            StringBuilder sb = new StringBuilder();
            this.BankAccounts
                .ToList()
                .ForEach(a =>
                {
                    sb.AppendLine(a.ToString());
                });
            return sb.ToString().Trim();
        }
    }
}
