
using Banking22.Banking;
using Banking22.Banking.Account;
using Banking22.Banking.Ownership;

namespace Bank22.Tests
{


    class FakeCheckingFactoryWithBalance : IAccountFactory
    {

        Account IAccountFactory.Create(string name, Account.AccountTypes accountType)
        {
            return new CheckingAccount(DateTime.Now.Ticks.ToString(), new IndividualOwner(name));
        }
    }


    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void TestDeposit()
        {
            const double initialBalance = 100d;
            var bank = new Bank("Bank 22", new FakeCheckingFactoryWithBalance());
            var accountNumber = bank.CreateNewAccount("My Account",
                initialBalance, Account.AccountTypes.Checking);

            var actualBalance = bank.GetAccountBalance(accountNumber);
            const double expectedBalance = initialBalance;

            Assert.AreEqual(expectedBalance, actualBalance);

            bank.Deposit(accountNumber, 100d);

            var actualNewBalance = bank.GetAccountBalance(accountNumber);
            const double expectedNewBalance = initialBalance + 100d;
            Assert.AreEqual(expectedNewBalance, actualNewBalance);
        }


        [TestMethod]
        public void TestWithdrawal()
        {
            const double initialBalance = 100d;
            var bank = new Bank("Bank 22", new FakeCheckingFactoryWithBalance());
            var accountNumber = bank.CreateNewAccount("My Account",
                initialBalance, Account.AccountTypes.Checking);

            bank.Withdraw(accountNumber, 10d);

            var actualBalance = bank.GetAccountBalance(accountNumber);
            const double expectedBalance = initialBalance - 10d;
            Assert.AreEqual(expectedBalance, actualBalance);
        }


        [TestMethod]
        public void TestTransfer()
        {
            const double initialBalance = 100d;
            var bank = new Bank("Bank 22", new FakeCheckingFactoryWithBalance());
            var accountNumber = bank.CreateNewAccount("My Account",
                initialBalance, Account.AccountTypes.Checking);

          
            var account2Number = bank.CreateNewAccount("My Account 2", 0d, Account.AccountTypes.Checking);


            bank.Transfer(accountNumber, account2Number, 10d);

            var account1Balance = bank.GetAccountBalance(accountNumber);
            const double expectedBalance = initialBalance - 10d;
            Assert.AreEqual(expectedBalance, account1Balance);


            var account2Balance = bank.GetAccountBalance(account2Number);
            const double expectedAccount2Balance = 10d;
            Assert.AreEqual(expectedAccount2Balance, account2Balance);
        }

    }
}