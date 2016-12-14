using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Customer
	{

		public int Id { get; }
		public string Name { get; }
		public IBank Bank { get; }
		private List<Account> accounts = new List<Account>();


		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(Id > 0);
			Contract.Invariant(Bank != null);
			Contract.Invariant(!String.IsNullOrWhiteSpace(Name));
		}

		public Customer(int id, string name, IBank bank)
		{
			Id = id;
			Name = name;
			Bank = bank;
		}

		public Account GetAccount(long id) {
			return accounts.Find((obj) => obj.Number == id);
		}

		public void AddAccount(Account account) {
			Contract.Requires(account != null);
			accounts.Add(account);
		}

	}
}
