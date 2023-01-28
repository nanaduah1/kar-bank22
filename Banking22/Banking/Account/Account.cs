using Banking22.Banking.Ownership;

namespace Banking22.Banking.Account
{

    public abstract class Account
    {
        public string AccountNumber { get; }
        public Owner Owner { get; }
        public double Balance { get; private set; }
        private readonly IList<Transaction.Transaction> transactions
            = new List<Transaction.Transaction>();

        protected Account(string accountNumber, Owner owner,
               double initialBalance = 0d)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Owner = owner;
        }


        public virtual void Credit(Transaction.Transaction credit)
        {
            Balance += credit.Amount;
            transactions.Add(credit);
        }

        public virtual void Debit(Transaction.Transaction debit)
        {
            bool hasInSufficientBalance = Balance < debit.Amount;
            if (hasInSufficientBalance)
            {
                throw new InsufficientBalanceException();
            }

            Balance -= debit.Amount;
            transactions.Add(debit);

        }


        public enum AccountTypes
        {
            Checking = 1,
            IndividualInvestment = 2,
            CorporateInvestment = 3
        }

    }
}