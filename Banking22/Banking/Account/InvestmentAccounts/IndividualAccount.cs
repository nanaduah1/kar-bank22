
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

        public override void Debit(Transaction.Transaction debit)
        {
            ValidateTransaction(debit);
            base.Debit(debit);
        }

        private void ValidateTransaction(Transaction.Transaction debit)
        {
            const double withdrawalLimit = 500d;
            if (withdrawalLimit < debit.Amount)
            {
                throw new WithdrawalLimitExceededException(withdrawalLimit);
            }
        }
    }
}

