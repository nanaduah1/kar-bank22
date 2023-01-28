
namespace Banking22.Banking.Account
{
	public interface IAccountFactory
	{
		public Account Create(string name, Account.AccountTypes accountType);
	}
}

