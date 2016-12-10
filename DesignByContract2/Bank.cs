using System;
namespace DesignByContract2
{
	public class Bank
	{

		private string name { get; }

		public Bank()
		{
		}

		public bool move(double amount, Account source, Account target) {
			throw new NotSupportedException();
		}

		public string makeStatement(Customer customer, Account account) { 
			throw new NotSupportedException();
		}
	}
}
