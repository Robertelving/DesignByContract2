using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Account
	{

		private long number;
		private double balance; 

		public Account(int number, double balance)
		{
			this.number = number;
			this.balance = balance;
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(number > 0);

		}

		public double getBalance() {
			return this.balance;
		}

	}
}
