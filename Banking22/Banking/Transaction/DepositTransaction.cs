
namespace Banking22.Banking.Transaction
{
    public class DepositTransaction : Transaction
    {
        private readonly Account.Account account;

        public DepositTransaction(double amount, Account.Account account) : base(amount)
        {
            this.account = account;
        }

        public override void Process()
        {
            account.Credit(this);
        }
    }
}

