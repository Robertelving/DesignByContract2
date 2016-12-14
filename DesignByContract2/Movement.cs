using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Movement
	{

		public readonly DateTime date = DateTime.Now; 
		public double Amount { get; }
		public Account Source { get; }
		public Account Target { get; }

		public Movement(double amount, Account source, Account target)
		{
			Amount = amount;
			Source = source;
			Target = target;
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(Source != null);
			Contract.Invariant(Target != null);			        
			Contract.Invariant(Amount == 0D);
		}

	}
}
