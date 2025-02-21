Practice Problems for Exception Handling in C#
1. Handling File Not Found Exception
💡 Problem Statement:
Create a C# program that reads a file named "data.txt". If the file does not exist, handle the IOException properly and display a user-friendly message.
Expected Behavior:
* If the file exists, print its contents.
* If the file does not exist, catch the IOException and print "File not found".
using System;
using System.IO;

namespace FileHandling
{
   class Program
   {
       static void Main(string[] args)
       {
           string filePath = "data.txt"; // File to read

           try
           {
               // Attempt to open and read the file
               using (StreamReader sr = new StreamReader(filePath))
               {
                   Console.WriteLine("File Contents:\n");
                   string line;
                   while ((line = sr.ReadLine()) != null)
                   {
                       Console.WriteLine(line);
                   }
               }
           }
           catch (FileNotFoundException)  // Catches missing file error
           {
               Console.WriteLine("File not found.");
           }
           catch (IOException ex) // Handles other I/O errors
           {
               Console.WriteLine($"An error occurred: {ex.Message}");
           }
       }
   }
}

	

________________


2. Handling Division and Input Errors
💡 Problem Statement:
Write a C# program that asks the user to enter two numbers and divides them. Handle possible exceptions such as:
* DivideByZeroException if division by zero occurs.
* FormatException if the user enters a non-numeric value.
Expected Behavior:
* If the user enters valid numbers, print the result of the division.
* If the user enters 0 as the denominator, catch and handle DivideByZeroException.
* If the user enters a non-numeric value, catch and handle FormatException.
using System;

namespace ExceptionHandling
{
   class Program
   {
       static void Main(string[] args)
       {
           try
           {
               // Asking for user input
               Console.Write("Enter the first number: ");
               double num1 = Convert.ToDouble(Console.ReadLine()); // May cause FormatException

               Console.Write("Enter the second number: ");
               double num2 = Convert.ToDouble(Console.ReadLine()); // May cause FormatException

               // Perform division
               double result = num1 / num2; // May cause DivideByZeroException
               
               Console.WriteLine($"Result: {result}");
           }
           catch (DivideByZeroException)
           {
               Console.WriteLine("Error: Division by zero is not allowed.");
           }
           catch (FormatException)
           {
               Console.WriteLine("Error: Invalid input. Please enter numeric values only.");
           }
           catch (Exception ex) // General exception handling
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}
	



________________


3. Creating and Handling a Custom Exception
💡 Problem Statement:
* Create a custom exception called InvalidAgeException.
* Write a method ValidateAge(int age) that throws InvalidAgeException if the age is below 18.
* In Main(), take user input and call ValidateAge().
* If an exception occurs, display "Age must be 18 or above".
Expected Behavior:
* If the age is >=18, print "Access granted!".
* If age <18, throw InvalidAgeException and display the message.
using System;

namespace CustomExceptionHandling
{
   // Step 1: Define a custom exception
   class InvalidAgeException : Exception
   {
       public InvalidAgeException(string message) : base(message) { }
   }

   class Program
   {
       // Step 2: Method to validate age
       static void ValidateAge(int age)
       {
           if (age < 18)
           {
               throw new InvalidAgeException("Age must be 18 or above.");
           }
           Console.WriteLine("Access granted!");
       }

       static void Main(string[] args)
       {
           try
           {
               // Step 3: Take user input
               Console.Write("Enter your age: ");
               int age = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               // Step 4: Validate the age
               ValidateAge(age);
           }
           catch (InvalidAgeException ex)
           {
               Console.WriteLine($"Error: {ex.Message}");
           }
           catch (FormatException)
           {
               Console.WriteLine("Error: Invalid input. Please enter a numeric age.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}
	



________________


4. Handling Multiple Exceptions
💡 Problem Statement:
Create a C# program that performs array operations.
* Accept an integer array and an index number.
* Retrieve and print the value at that index.
* Handle the following exceptions:
   * IndexOutOfRangeException if the index is out of range.
   * NullReferenceException if the array is null.
Expected Behavior:
* If valid, print "Value at index X: Y".
* If the index is out of bounds, display "Invalid index!".
* If the array is null, display "Array is not initialized!".
using System;

namespace ExceptionHandling
{
   class Program
   {
       static void Main(string[] args)
       {
           try
           {
               // Step 1: Declare and initialize the array (Uncomment to test null case)
               int[] numbers = { 10, 20, 30, 40, 50 };
               // int[] numbers = null; // Uncomment this to test the NullReferenceException

               // Step 2: Take user input for index
               Console.Write("Enter the index number: ");
               int index = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               // Step 3: Retrieve and print value
               Console.WriteLine($"Value at index {index}: {numbers[index]}");
           }
           catch (IndexOutOfRangeException)
           {
               Console.WriteLine("Invalid index!");
           }
           catch (NullReferenceException)
           {
               Console.WriteLine("Array is not initialized!");
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid input! Please enter a numeric index.");
           }
           catch (Exception ex) // General exception handler
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}

	

________________


5. Using using Statement for File Handling
💡 Problem Statement:
Write a C# program that reads the first line of a file named "info.txt" using StreamReader.
* Use using to ensure the file is automatically closed after reading.
* Handle any IOException that may occur.
Expected Behavior:
* If the file exists, print its first line.
* If the file does not exist, catch IOException and print "Error reading file".
using System;
using System.IO;

namespace FileHandling
{
   class Program
   {
       static void Main(string[] args)
       {
           string filePath = "info.txt"; // File to read

           try
           {
               // Step 1: Open file using "using" (ensures automatic closure)
               using (StreamReader sr = new StreamReader(filePath))
               {
                   // Step 2: Read and print the first line
                   string firstLine = sr.ReadLine();
                   Console.WriteLine($"First Line: {firstLine}");
               }
           }
           catch (IOException)
           {
               Console.WriteLine("Error reading file.");
           }
       }
   }
}
	



________________


6. Handling Invalid Input in Interest Calculation
💡 Problem Statement:
Create a method CalculateInterest(double amount, double rate, int years) that:
* Throws ArgumentException if amount or rate is negative.
* Propagates the exception using throw and handles it in Main().
Expected Behavior:
* If valid, return and print the calculated interest.
* If invalid, catch and display "Invalid input: Amount and rate must be positive".
using System;

namespace InterestCalculation
{
   class Program
   {
       // Method to calculate interest
       static double CalculateInterest(double amount, double rate, int years)
       {
           if (amount < 0 || rate < 0)
           {
               throw new ArgumentException("Amount and rate must be positive.");
           }

           return amount * (rate / 100) * years; // Simple Interest Formula
       }

       static void Main(string[] args)
       {
           try
           {
               // User input
               Console.Write("Enter the principal amount: ");
               double amount = Convert.ToDouble(Console.ReadLine()); // May throw FormatException

               Console.Write("Enter the interest rate (in %): ");
               double rate = Convert.ToDouble(Console.ReadLine()); // May throw FormatException

               Console.Write("Enter the number of years: ");
               int years = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               // Calculate interest
               double interest = CalculateInterest(amount, rate, years);
               Console.WriteLine($"Calculated Interest: {interest}");
           }
           catch (ArgumentException ex)
           {
               Console.WriteLine($"Invalid input: {ex.Message}");
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid input: Please enter numeric values.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}
	



________________


7. Demonstrating finally Block Execution
💡 Problem Statement:
Write a program that performs integer division and demonstrates the finally block execution.
* The program should:
   * Take two integers from the user.
   * Perform division.
   * Handle DivideByZeroException (if dividing by zero).
   * Ensure "Operation completed" is always printed using finally.
Expected Behavior:
* If valid, print the result.
* If an exception occurs, handle it and still print "Operation completed".
using System;

namespace FinallyBlockDemo
{
   class Program
   {
       static void Main(string[] args)
       {
           try
           {
               // Step 1: Take user input
               Console.Write("Enter the numerator: ");
               int numerator = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               Console.Write("Enter the denominator: ");
               int denominator = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               // Step 2: Perform division
               int result = numerator / denominator; // May throw DivideByZeroException
               Console.WriteLine($"Result: {result}");
           }
           catch (DivideByZeroException)
           {
               Console.WriteLine("Error: Division by zero is not allowed.");
           }
           catch (FormatException)
           {
               Console.WriteLine("Error: Invalid input. Please enter numeric values.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
           finally
           {
               // Step 3: Finally block executes always
               Console.WriteLine("Operation completed.");
           }
       }
   }
}
	



________________


8. Propagating Exceptions Across Methods
💡 Problem Statement:
Create a C# program with three methods:
1. Method1(): Throws an ArithmeticException (10 / 0).
2. Method2(): Calls Method1().
3. Main(): Calls Method2() and handles the exception.
Expected Behavior:
* The exception propagates from Method1() → Method2() → Main().
* Catch and handle it in Main(), printing "Handled exception in Main".
using System;

namespace ExceptionPropagation
{
   class Program
   {
       // Method1: Throws an ArithmeticException (10 / 0)
       static void Method1()
       {
           throw new ArithmeticException("Attempted to divide by zero.");
       }

       // Method2: Calls Method1()
       static void Method2()
       {
           Method1();
       }

       // Main: Calls Method2() and handles the exception
       static void Main(string[] args)
       {
           try
           {
               Method2(); // Calls Method2, which calls Method1()
           }
           catch (ArithmeticException ex)
           {
               Console.WriteLine("Handled exception in Main: " + ex.Message);
           }
       }
   }
}
	



________________


9. Using Nested try-catch Blocks
💡 Problem Statement:
Write a C# program that:
* Takes an array and a divisor as input.
* Tries to access an element at an index.
* Tries to divide that element by the divisor.
* Uses nested try-catch to handle:
   * IndexOutOfRangeException if the index is invalid.
   * DivideByZeroException if the divisor is zero.
Expected Behavior:
* If valid, print the division result.
* If the index is invalid, catch and display "Invalid array index!".
* If division by zero, catch and display "Cannot divide by zero!".
using System;

namespace NestedTryCatch
{
   class Program
   {
       static void Main(string[] args)
       {
           try
           {
               // Step 1: Declare and initialize the array
               int[] numbers = { 10, 20, 30, 40, 50 };

               // Step 2: Get user input for index
               Console.Write("Enter the index to access: ");
               int index = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

               try
               {
                   // Step 3: Try accessing the element at the given index
                   int value = numbers[index];

                   // Step 4: Get user input for divisor
                   Console.Write("Enter the divisor: ");
                   int divisor = Convert.ToInt32(Console.ReadLine()); // May throw FormatException

                   try
                   {
                       // Step 5: Perform division
                       int result = value / divisor; // May throw DivideByZeroException
                       Console.WriteLine($"Result: {result}");
                   }
                   catch (DivideByZeroException)
                   {
                       Console.WriteLine("Cannot divide by zero!");
                   }
               }
               catch (IndexOutOfRangeException)
               {
                   Console.WriteLine("Invalid array index!");
               }
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid input! Please enter numeric values.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}
	



________________


10. Implementing a Bank Transaction System
💡 Problem Statement:
Develop a Bank Account System where:
* Withdraw(double amount) method:
   * Throws InsufficientFundsException if withdrawal amount exceeds balance.
   * Throws ArgumentException if the amount is negative.
* Handle exceptions in Main().
Expected Behavior:
* If valid, print "Withdrawal successful, new balance: X".
* If balance is insufficient, throw and handle "Insufficient balance!".
* If the amount is negative, throw and handle "Invalid amount!".
using System;

namespace BankTransactionSystem
{
   // Custom exception for insufficient funds
   class InsufficientFundsException : Exception
   {
       public InsufficientFundsException(string message) : base(message) { }
   }

   class BankAccount
   {
       public double Balance { get; private set; }

       public BankAccount(double initialBalance)
       {
           Balance = initialBalance;
       }

       public void Withdraw(double amount)
       {
           if (amount < 0)
           {
               throw new ArgumentException("Invalid amount! Amount must be positive.");
           }

           if (amount > Balance)
           {
               throw new InsufficientFundsException("Insufficient balance!");
           }

           Balance -= amount;
           Console.WriteLine($"Withdrawal successful, new balance: {Balance}");
       }
   }

   class Program
   {
       static void Main(string[] args)
       {
           try
           {
               // Initialize account with balance
               BankAccount account = new BankAccount(1000);

               // User input for withdrawal amount
               Console.Write("Enter withdrawal amount: ");
               double amount = Convert.ToDouble(Console.ReadLine()); // May throw FormatException

               // Attempt withdrawal
               account.Withdraw(amount);
           }
           catch (InsufficientFundsException ex)
           {
               Console.WriteLine(ex.Message);
           }
           catch (ArgumentException ex)
           {
               Console.WriteLine(ex.Message);
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid input! Please enter a numeric value.");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"An unexpected error occurred: {ex.Message}");
           }
       }
   }
}
	



________________


Conclusion
🔹 These practice problems help reinforce exception handling concepts in C#, including:
✔ Handling file and input-related exceptions
✔ Creating and using custom exceptions
✔ Using multiple catch blocks
✔ Implementing finally for cleanup
✔ Propagating exceptions across methods
✔ Handling nested try-catch scenarios
✔ Real-world use cases like banking systems