
namespace Banking22.Banking
{
    public class InsufficientBalanceException : Exception
    {

    }


    public class WithdrawalLimitExceededException : Exception
    {
        public WithdrawalLimitExceededException(double withdrawalLimit) :
            base(message: $"Withdrawal limit of {withdrawalLimit} exceeded!")
        { }

    }
}
