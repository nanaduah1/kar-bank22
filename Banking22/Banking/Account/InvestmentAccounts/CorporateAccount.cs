
using Banking22.Banking.Ownership;

namespace Banking22.Banking.Account.InvestmentAccounts
{
    public class CorporateAccount : Account
    {
        public CorporateAccount(string accountNumber, CorporateOwner owner,
            double initialBalance = 0d)
            : base(accountNumber, owner, initialBalance)
        {
        }
    }
}

