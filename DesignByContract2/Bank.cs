using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Bank
	{

		private string name { get; }

		public Bank()
		{
		}

		public bool move(double amount, Account source, Account target) {
			Contract.Requires(source != null);
			Contract.Requires(target != null);
			Contract.Requires(amount > 0);
			Contract.Ensures(Contract.Result<double>() == Contract.OldValue(source.getBalance()) - amount);
			Contract.Ensures(Contract.Result<double>() == Contract.OldValue(target.getBalance()) + amount);
			throw new NotSupportedException();
		}

		public string makeStatement(Customer customer, Account account) { 
			throw new NotSupportedException();
		}
	}
}
