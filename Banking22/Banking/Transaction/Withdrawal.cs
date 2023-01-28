
namespace Banking22.Banking.Transaction
{
    public class Withdrawal : Transaction
    {
        private readonly Account.Account account;
        public Withdrawal(double amount, Account.Account account) :
            base(amount)
        {
            this.account = account;
        }

        public override void Process()
        {
            account.Debit(this);
        }
    }

}

