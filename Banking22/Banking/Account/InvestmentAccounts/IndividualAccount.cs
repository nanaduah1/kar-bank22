
using Banking22.Banking.Ownership;

namespace Banking22.Banking.Account.InvestmentAccounts
{
    public class IndividualAccount : Account
    {

        public IndividualAccount(string accountNumber, IndividualOwner owner,
            double initialBalance = 0d) :
            base(accountNumber, owner, initialBalance)
        {
        }

        public override void Debit(Transaction.Transaction deposit)
        {
            ValidateTransaction(deposit);
            base.Debit(deposit);
        }

        private void ValidateTransaction(Transaction.Transaction deposit)
        {
            const double withdrawalLimit = 500d;
            if (withdrawalLimit < deposit.Amount)
            {
                throw new WithdrawalLimitExceededException(withdrawalLimit);
            }
        }
    }
}

