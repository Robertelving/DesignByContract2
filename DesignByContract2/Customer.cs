using System;
using System.Diagnostics.Contracts;

namespace DesignByContract2
{
	public class Customer
	{

		private int id { get; }
		private string name { get; }

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(id > 0);
			Contract.Invariant(!String.IsNullOrWhiteSpace(name));
		}

		public Customer(int id, string name)
		{
			this.id = id;
			this.name = name;
			Contract.Ensures(id > 0);
		}

		static void Main(string[] args)
		{

			var c = new Customer(-1 , "Robert");

			Console.WriteLine("Customer: {0} - {1}", c.id, c.name);
			Console.ReadKey();
		}

	}

}
