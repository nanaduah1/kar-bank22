
namespace Banking22.Banking.Transaction
{
    public class Deposit : Transaction
    {
        private readonly Account.Account account;

        public Deposit(double amount, Account.Account account) : base(amount)
        {
            this.account = account;
        }

        public override void Process()
        {
            account.Credit(this);
        }
    }
}

