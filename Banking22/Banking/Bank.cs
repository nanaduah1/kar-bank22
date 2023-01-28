
using Banking22.Banking.Account;
using Banking22.Banking.Transaction;

namespace Banking22.Banking
{
    public class Bank
    {
        public string Name { get; }
        private IAccountFactory accountFactory;

        private readonly IDictionary<string, Account.Account>
            accounts = new Dictionary<string, Account.Account>();

        public Bank(string name, IAccountFactory accountFactory)
        {
            Name = name;
            this.accountFactory = accountFactory;
        }

        public string CreateNewAccount(string accountName, double initialBalance,
            Account.Account.AccountTypes accountType)
        {
            var account = accountFactory.Create(accountName, accountType);
            accounts.Add(account.AccountNumber, account);
            Deposit(account.AccountNumber, initialBalance);
            return account.AccountNumber;
        }

        public void Deposit(string accountNumber, double amount)
        {
            ValidateDepositInputs(accountNumber, amount);

            var account = accounts[accountNumber];
            var deposit = new Deposit(amount, account);
            deposit.Process();
        }


        private void ValidateDepositInputs(string accountNumber, double amount)
        {
            // TODO: Add validations for the input data
            // Example: Is the account number even valid
        }


        public void Withdraw(string accountNumber, double amount)
        {
            ValidateWithdrawalInputs(accountNumber, amount);

            var account = accounts[accountNumber];
            var withdrawal = new Withdrawal(amount, account);
            withdrawal.Process();
        }

        private void ValidateWithdrawalInputs(string accountNumber, double amount)
        {
            // TODO: Add validations for the input data
            // Example: Is the account number even valid
        }


        public void Transfer(string senderAccountNumber, string
            recipientAccountNumber, double amount)
        {
            ValidateTransferInputs(senderAccountNumber, recipientAccountNumber, amount);

            var fromAccount = accounts[senderAccountNumber];
            var recipientAccount = accounts[recipientAccountNumber];

            var transfer = new Transfer(amount, fromAccount, recipientAccount);
            transfer.Process();
        }

        private void ValidateTransferInputs(string fromAccountNumber, string toAccountNumber, double amount)
        {
            // TODO: Add validations for the input data
            // Example: Is the account number even valid
        }

        public double GetAccountBalance(string accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber].Balance;
            }

            throw new ArgumentException($"Unknown account number '{accountNumber}'");
        }
    }
}

