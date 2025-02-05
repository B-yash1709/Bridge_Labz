using System;

public class BankAccount
{
    // Public properties
    public string AccountNumber;
    public string AccountHolder;

    // Private property
    private decimal Balance;

    // Constructor to initialize account details
    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    // Method to deposit money
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine("Deposited: "+amount+", New Balance: "+Balance);
    }

    // Method to withdraw money
    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine("Withdrawn: "+amount+", Remaining Balance: "+Balance);
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    // Method to display account details
    public void DisplayAccountDetails()
    {
        Console.WriteLine("Account Number: "+AccountNumber);
        Console.WriteLine("Account Holder: "+AccountHolder);
        Console.WriteLine("Balance: "+Balance);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a bank account
        BankAccount account = new BankAccount("123456", "Aman Kumar", 1000);

        // Display account details
        account.DisplayAccountDetails();

        // Deposit money
        account.Deposit(500);

        // Withdraw money
        account.Withdraw(300);

        // Display account details again
        account.DisplayAccountDetails();
    }
}
