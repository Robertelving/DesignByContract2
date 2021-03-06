﻿using System;

namespace DesignByContract2
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			var bank = new Bank("Roberts Røverrede");
			var cust = new Customer(78324, "Simon", bank);
			var c = new Customer(23, "Christopher", bank);
			var a1 = new Account(1, bank, cust);
			var a2 = new Account(2, bank, c);
			var a3 = new Account(3, bank, c);
			var a4 = new Account(4, bank, c);
			var a5 = new Account(5, bank, c);

			cust.AddAccount(a1);
			bank.Move(100, a1, a2);
			bank.Move(40, a1, a2);
			bank.Move(23.4, a2, a1);
			bank.Move(10.2, a5, a1);
			bank.Move(130, a4, a1);
			bank.Move(89.5, a2, a1);
			bank.Move(40, a2, a1);
			bank.Move(23.45, a3, a1);
			bank.Move(13, a2, a1);
			bank.Move(1234, a1, a2);
			bank.Move(156, a1, a3);
			bank.Move(985, a1, a4);
			bank.Move(34, a4, a2);

			Console.WriteLine(bank.MakeStatement(cust, a1));


		}
	}
}
