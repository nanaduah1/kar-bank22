
namespace Banking22.Banking.Transaction
{
    public abstract class Transaction
    {
        protected Transaction(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }

        public abstract void Process();
    }
}

