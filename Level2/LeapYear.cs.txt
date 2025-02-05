using System;

class Program
{
    // Method to check if a year is a leap year
    public static bool IsLeapYear(int year)
    {
        if (year < 1582)
        {
            Console.WriteLine("The year must be 1582 or later");
            return false;
        }

        // Check leap year conditions
        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            return true; // Leap year
        }
        return false; // Not a leap year
    }

    static void Main(string[] args)
    {
        // Input: Take year input from the user
        Console.Write("Enter a year (>= 1582): ");
        int year = int.Parse(Console.ReadLine());
        

        // Check if the year is a leap year
        bool isLeap = IsLeapYear(year);

        // Output the result
        if (isLeap)
        {
            Console.WriteLine("This is a Leap Year.");
        }
        else
        {
            Console.WriteLine("This is NOT a Leap Year.");
        }
    }
}
