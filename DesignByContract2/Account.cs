using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Account
	{

		private long number { get; }
		private double balance { get;}

		public Account(int number, double balance)
		{
			this.number = number;
			this.balance = balance;
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(id > 0);
			Contract.Invariant(!String.IsNullOrWhiteSpace(name));
		}

	}
}
