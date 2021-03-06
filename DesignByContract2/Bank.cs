﻿using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace DesignByContract2
{
	public class Bank : IBank
	{

		public string Name { get; }

		public Bank(String name)
		{
			this.Name = name;
		}


		[ContractInvariantMethod]
		public void ObjectInvariantBank()
		{
			Contract.Invariant(!String.IsNullOrWhiteSpace(Name));
		}

		public void Move(double amount, Account source, Account target)
		{
			Contract.Ensures(source != null);
			Contract.Ensures(target != null);
			Contract.Ensures(amount > 0);

			source.WithDraw(amount, target);
			target.Deposit(amount, source);
		}

		public string MakeStatement(Customer customer, Account account)
		{
			Contract.Requires(customer != null);
			Contract.Requires(account != null);
			Contract.Requires(customer.GetAccount(account.Number) != null);

			var message = new StringBuilder();

			message.Append("statement for [ACCOUNT]: " + account.Number + "\n");
			message.Append("[ACTION]\t [FROM]\t [TO]\t [DATE]\t\t\t [AMOUNT]\n");

			foreach (var item in account.GetMovements())
			{
				if (item.Amount < 0)
				{
					message.Append("WITHDRAW\t " + item.Source.Number + "\t " + item.Target.Number + "\t ");
					message.Append(item.date + "\t " + item.Amount + "\n");
				}
				else
				{
					message.Append("DEPOSIT\t\t " + item.Source.Number + "\t " + item.Target.Number + "\t ");
					message.Append(item.date + "\t " + item.Amount + "\n");
				}
			}
			message.Append("\t\t\t\t\t\t\t" + account.Balance + " [TOTAL]");
			return message.ToString();
		}
	}
}
