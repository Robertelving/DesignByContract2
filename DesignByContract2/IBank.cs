using System;
namespace DesignByContract2
{
	public interface IBank
	{
		void Move(double amount, Account source, Account target);

		string MakeStatement(Customer customer, int accountId);

	}
}
