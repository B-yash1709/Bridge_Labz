using System;

public class BankAccount
{
    private static string bankname = "HDFC";
    private static int totalAccounts = 0; // countering for total accounts

    // readonly variable ==> cannot change
    public readonly int AccountNumber;

    // instance variables
    private string AccountHolderName;
    private decimal Balance;

    public BankAccount(int accountNumber, string accountHolderName, decimal initialBalance)
    {
        this.AccountNumber = accountNumber;
        this.AccountHolderName = accountHolderName;
        this.Balance = initialBalance;
        // increasing total accounts
        totalAccounts++;
    }

    // method to display account details
    public void DisplayAccount() {
        if (this is BankAccount) {
            Console.WriteLine("Bank: "+bankname+", Account No.: "+AccountNumber+", Holder: "+AccountHolderName+", Balance: "+Balance);
        }
    }

    public static void ShowTotalAccounts() {
        Console.WriteLine("Total accounts: " + totalAccounts);
    }
}
public class Program
{
    public static void Main()
    {
        BankAccount acc1 = new BankAccount(1001, "Aman",2000);
        BankAccount acc2 = new BankAccount(1002, "Rahul",3000);


        // display the accounts
        acc1.DisplayAccount();
        acc2.DisplayAccount();

        // showing total accounts
        BankAccount.ShowTotalAccounts();
    }
}