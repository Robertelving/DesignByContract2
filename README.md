# Design By Contract 2

Members: Robert Elving, Simon Grønborg, ChristopherMortensen

## Purpose of using contracts during development
The usage of contracts, gives you a wide selection of tools you can use for your team. 
Contracts are especially useful, if your team are working remotely, so developers that
are not sitting together everyday, can use such guidelines during the development of the software.

## Purpose of the assignment
We have a simple bank, that contains Customers and Accounts. Each Account is performing Movements, which the Bank-class controls in a double entry bookkeeping manner. 

Looking at situations happening in a Bank is a good example in the usage of contracts. 
In this assignment, we are using Code Contracts for .net to enforce some rules, that should apply different places in the logic of the application.

We will describe the practices we have used in our code in the next couple of sections.

## Requires (Pre-conditions)
Works as a Pre-condition, that developers can state in the code, so you can expect some certain values.
Is used in the beginning of a function, before its logic is executed. We have, among other places, used it in the Deposit-function located in the Account-class.

See the following:
```cs
public void Deposit(double amount, Account source)
{
	Contract.Requires(amount > 0);
	Contract.Ensures((Contract.OldValue(Balance)) > Balance);
	movements.Add(new Movement(amount, source, this));
}
```

The very first statement is using the Contract instance, which holds the Requires-function. Everything inside its parameter should always be true. If not, then the contract is violated. 

## Ensures (Post-condtions)
Ensures is a function, that should work as post-condition. It sets up a condition, that should be true, to ensure, that some instance got a specific value. 

Let us look at the Withdraw-function located in the Account-class:
```cs
public void WithDraw(double amount, Account target)
{
	Contract.Requires(amount > 0);
	Contract.Ensures((Contract.OldValue(Balance)) < Balance);
	movements.Add(new Movement(-amount, this, target));
}
```

The second statement contains the Post-condition logic. It takes a condition as input. In this case, we store an instance of the Balance. The Balance is the aggregated sum of all our movements, at the moment, we use the Ensures-function. 
When the Withdraw-function eventually ends, the Ensures Post-condition verifies the conditien, in our case, checking that the old Balance is less than the Balance at the end of a Withdrawal. 
This is quite useful, because no matter what, a Withdrawal should ALWAYS make the Balance on the Account smaller than before. 

## Invariant 
An Invariant works as a static rule that should be met before and after funtion invocations.  
The Invariants specified, will be checked during runtime, so it is always sure, what state our application and its members is in. 

You "annotate" a function with the follwing ```[ContractInvariantMethod]```.
This function will hold your invariant declarations, and will make sure to be checked during runtime before and after function invocations. 

Using Invariants, makres sure, that you will always perform logic in your Application with valid values you or another developer has specified. 

Let us look at how we have used it in the Movement-class:

```cs
[ContractInvariantMethod]
private void ObjectInvariant()
{
	Contract.Invariant(Source != null);
	Contract.Invariant(Target != null);			        
	Contract.Invariant(Amount == 0D);
}
```

To make sure that the double entry bookkeeping is performed with valid objects, we need to put some rules on the table. Both the Source and the Target, which in our case are Accounts, shoul NEVER be null. The amount, that is either deposited or withdrawed, should also never be exactly zero. 

Now we can make sure to ping the user/developer if an invariant is not meeting the condition it got, when created. 

## Usage of interfaces
Even though this principle is not CodeContracts specific, we would still emphasize our usage of an interface for the Bank, since this also enforces a contract to be met between developers. 

See the simple interface:
```cs
public interface IBank
{
	void Move(double amount, Account source, Account target);

	string MakeStatement(Customer customer, Account account);

}
```

We have now enforced what functions the Bank should have, what parameters it takes to perform the functions and what return-value they should have. 

In theory, people would not need much explanation, to implement this functionality, and all developers can rely on something for their further independent development.  
