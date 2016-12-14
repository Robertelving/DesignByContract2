using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Account
	{

		private readonly List<Movement> movements = new List<Movement>();
		private double _balance;

		public IBank Bank { get; }
		public Customer Customer { get; }
		public long Number { get; }
		public double Balance
		{
			get
			{
				var sum = 0D;
				foreach (var movement in movements)
				{
					sum += movement.Amount;
				}
				return sum;
			}
		}


		public Account(int number, IBank bank, Customer customer)
		{
			Bank = bank;
			Customer = customer;
			Number = number;
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(Number > 0);
		}

		public List<Movement> GetMovements()
		{
			return movements;
		}

		public void Deposit(double amount, Account source)
		{
			Contract.Requires(amount > 0);
			Contract.Ensures((Contract.OldValue(Balance)) > Balance);
			movements.Add(new Movement(amount, source, this));
		}


		public void WithDraw(double amount, Account target)
		{
			Contract.Requires(amount > 0);
			Contract.Ensures((Contract.OldValue(Balance)) < Balance);
			movements.Add(new Movement(-amount, this, target));
		}
	}
}
