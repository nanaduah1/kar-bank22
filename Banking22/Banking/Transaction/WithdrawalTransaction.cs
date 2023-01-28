
namespace Banking22.Banking.Transaction
{
    public class WithdrawalTransaction : Transaction
    {
        private readonly Account.Account account;
        public WithdrawalTransaction(double amount, Account.Account account) :
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

