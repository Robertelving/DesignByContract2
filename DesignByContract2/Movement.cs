using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Movement
	{

		private readonly DateTime date = DateTime.Now; 
		private double amount { get; }

		public Movement(double amount)
		{
			this.amount = amount;
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(date != null);
			Contract.Invariant(amount > 0);
		}


	}
}
