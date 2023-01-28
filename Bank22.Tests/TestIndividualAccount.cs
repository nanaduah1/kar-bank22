
using Banking22.Banking;
using Banking22.Banking.Account.InvestmentAccounts;
using Banking22.Banking.Ownership;
using Banking22.Banking.Transaction;

namespace Bank22.Tests
{
    [TestClass]
    public class TestIndividualAccount
    {
        [TestMethod]
        public void TestCanWithdrawBelowLimit()
        {
            var account = new IndividualAccount(
                "12345", new IndividualOwner("Customer12"), 1000d);

            var withDrawal = new WithdrawalTransaction(500d, account);
           withDrawal.Process();

            const double expectedBalance = 500d;

            Assert.AreEqual(expectedBalance, account.Balance);
        }


        [TestMethod]
        public void TestCannotWithdrawAboveLimit()
        {
            var account = new IndividualAccount(
                "12345", new IndividualOwner("Customer33"), 1000d);

            var withDrawal = new WithdrawalTransaction(500.01d, account);

            Assert.ThrowsException<WithdrawalLimitExceededException>(
               () => withDrawal.Process());


            const double expectedBalance = 1000d;

            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}

