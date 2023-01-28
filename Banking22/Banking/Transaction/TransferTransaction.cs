namespace Banking22.Banking.Transaction
{
    public class TransferTransaction : Transaction
    {
        private readonly Account.Account fromAccount;
        private readonly Account.Account toAccount;

        public TransferTransaction(double amount, Account.Account fromAccount,
            Account.Account toAccount)
            : base(amount)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
        }

        public override void Process()
        {
            fromAccount.Debit(this);
            toAccount.Credit(this);
        }
    }
}
