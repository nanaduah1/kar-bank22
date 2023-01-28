using System;
using Banking22.Banking.Ownership;

namespace Banking22.Banking.Account
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(
            string accountNumber, Owner owner, double initialBalance = 0d)
            : base(accountNumber, owner,initialBalance)
        {
        }
    }
}
