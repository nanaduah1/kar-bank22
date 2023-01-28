
using Banking22.Banking;
using Banking22.Banking.Account;
using Banking22.Banking.Ownership;
using Banking22.Banking.Transaction;

namespace Bank22.Tests
{
    [TestClass]
    public class AccountTransactionTests
    {

        [TestMethod]
        public void TestDeposit()
        {
            var account = CreateIndividualCheckingAccount(balance: 0.25d);
            var deposit = new DepositTransaction(10.25, account);
            deposit.Process();

            const double expectedBalance = 10.50d;

            Assert.AreEqual(expectedBalance, account.Balance);
        }


        [TestMethod]
        public void TestWithdrawal()
        {
            var account = CreateIndividualCheckingAccount(balance: 10.50d);
            var withdrawal = new WithdrawalTransaction(0.25, account);
            withdrawal.Process();

            const double expectedBalance = 10.25d;

            Assert.AreEqual(expectedBalance, account.Balance);
        }


        [TestMethod]
        public void TestCannotOverWithdrawAccount()
        {
            var account = CreateIndividualCheckingAccount(balance: 10.50d);
            var withdrawal = new WithdrawalTransaction(11.25, account);


            Assert.ThrowsException<InsufficientBalanceException>(
                () => withdrawal.Process());


            const double expectedBalance = 10.50d;

            Assert.AreEqual(expectedBalance, account.Balance);
        }


        [TestMethod]
        public void TestTransfer()
        {
            var senderAccount = CreateIndividualCheckingAccount(balance: 10.50d);
            var receiverAccount = CreateIndividualCheckingAccount(balance: 0d);
            var transfer = new TransferTransaction(0.25, senderAccount, receiverAccount);
            transfer.Process();

            const double expectedBalance = 10.25d;

            Assert.AreEqual(expectedBalance, senderAccount.Balance);
            Assert.AreEqual(0.25d, receiverAccount.Balance);
        }


        [TestMethod]
        public void TestCannotOverTransferAboveBalance()
        {

            var senderAccount = CreateIndividualCheckingAccount(balance: 10.50d);
            var receiverAccount = CreateIndividualCheckingAccount(balance: 0d);
            var transfer = new TransferTransaction(11.25, senderAccount, receiverAccount);

            Assert.ThrowsException<InsufficientBalanceException>(
                () => transfer.Process());


            const double expectedBalance = 10.50d;

            Assert.AreEqual(expectedBalance, senderAccount.Balance);
            Assert.AreEqual(0d, receiverAccount.Balance);
        }

        private Account CreateIndividualCheckingAccount(double balance = 0d)
        {
            return new CheckingAccount("12345", new IndividualOwner("Customer55"), balance);
        }
    }
}

