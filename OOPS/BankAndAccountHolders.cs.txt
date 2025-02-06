using System;
using System.Collections.Generic;

// Bank class 
class Bank
{
    public string bankName;
    private List<Customer> customers;

    // Constructor 
    public Bank(string bankName)
    {
        this.bankName = bankName;
        customers = new List<Customer>();
    }

    // Method to open an account
    public void OpenAccount(Customer customer, decimal deposit)
    {
        Account newAccount = new Account(this, deposit);
        customer.AddAccount(newAccount);
        customers.Add(customer);
    }

    // Method to display customers 
    public void DisplayCustomers()
    {
        Console.WriteLine("Bank: {0} - Customer Accounts:" , bankName);
        foreach (var customer in customers)
        {
            customer.ViewAccounts();
        }
    }
}

class Customer
{
    public string name;
    private List<Account> accounts;

    // Constructor
    public Customer(string name)
    {
        this.name = name;
        accounts = new List<Account>();
    }

    // Method to add an account
    public void AddAccount(Account account)
    { 
        accounts.Add(account);
    }

    // Method to view all accounts 
    public void ViewAccounts()
    {
        Console.WriteLine("Customer: {0}" , Name);
        foreach (var account in accounts)
        {
            account.DisplayAccountInfo();
        }
    }
}

class Account
{
    private static int accountNumberSeed = 1000;
    public int accountNumber;
    public Bank bank;
    public decimal balance;

    // Constructor 
    public Account(Bank bank, decimal deposit)
    {
        this.bank = bank;
        this.balance = deposit;
        this.accountNumber = accountNumberSeed++;
    }

    // Method to display account details
    public void DisplayAccountInfo()
    {
        Console.WriteLine("Account Number: {0}, Bank: {1}, balance: {2}" , accountNumber , Bank.bankName , balance);
    }
}

// Main class (association)
class Program
{
    static void Main()
    {
        
        // Creating a bank
        Bank bank1 = new Bank("INDIAN BANK");
            
        // Creating customers
        Customer customer1 = new Customer("Rohit Dixit");
        Customer customer2 = new Customer("Rahul Dixit");
            
        // Opening accounts for customers
        bank1.OpenAccount(customer1, 1000);
        bank1.OpenAccount(customer2, 1500);
            
        // Display all customers 
        bank1.DisplayCustomers();
        
       
    }
}
