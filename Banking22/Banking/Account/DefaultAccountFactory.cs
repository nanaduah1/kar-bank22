
using Banking22.Banking.Account.InvestmentAccounts;
using Banking22.Banking.Ownership;

namespace Banking22.Banking.Account
{
    public class DefaultAccountFactory : IAccountFactory
    {
        public DefaultAccountFactory()
        {
        }

        Account IAccountFactory.Create(string name, Account.AccountTypes accountType)
        {
            switch (accountType)
            {
                case Account.AccountTypes.Checking:
                    return new CheckingAccount(GenerateAccountNumber(), new IndividualOwner(name));
                case Account.AccountTypes.IndividualInvestment:
                    return new IndividualAccount(GenerateAccountNumber(), new IndividualOwner(name));
                case Account.AccountTypes.CorporateInvestment:
                    return new CorporateAccount(GenerateAccountNumber(), new CorporateOwner(name));
                default:
                    throw new ArgumentException($"Unsupported account type value '{accountType}'");
            }
        }

        // TODO: Extract account number generation into a separate
        // class or let individual account types internally define
        // how they generate account numbers
        // Not too bad to leave this here for now
        private string GenerateAccountNumber()
        {
            return $"{new Random().NextInt64()}-{DateTime.Now.Year}";
        }
    }
}

