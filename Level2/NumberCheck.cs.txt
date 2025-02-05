using System;

public class NumberChecker
{
    // Method to check if a number is positive or negative
    public static bool IsPositive(int number)
    {
        return number >= 0;
    }

    // Method to check if a number is even or odd
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // Method to compare two numbers
    public static int Compare(int number1, int number2)
    {
        if (number1 > number2) return 1;
        if (number1 == number2) return 0;
        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5];

        Console.WriteLine("Enter 5 numbers:");

        // Taking user input for the array
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nAnalysis of the numbers:");

        // Loop through the array to analyze each number
        for (int i = 0; i < numbers.Length; i++)
        {
            if (NumberChecker.IsPositive(numbers[i]))
            {
                if (NumberChecker.IsEven(numbers[i]))
                {
                    Console.WriteLine("Number " + numbers[i] + " is Positive and Even.");
                }
                else
                {
                    Console.WriteLine("Number " + numbers[i] + " is Positive and Odd.");
                }
            }
            else
            {
                Console.WriteLine("Number " + numbers[i] + " is Negative.");
            }
        }

        // Comparing the first and last elements of the array
        int comparisonResult = NumberChecker.Compare(numbers[0], numbers[numbers.Length - 1]);
        Console.WriteLine("\nComparison between first and last elements:");

        if (comparisonResult == 1)
        {
            Console.WriteLine("The first element (" + numbers[0] + ") is greater than the last element (" + numbers[numbers.Length - 1] + ").");
        }
        else if (comparisonResult == 0)
        {
            Console.WriteLine("The first element (" + numbers[0] + ") is equal to the last element (" + numbers[numbers.Length - 1] + ").");
        }
        else
        {
            Console.WriteLine("The first element (" + numbers[0] + ") is less than the last element (" + numbers[numbers.Length - 1] + ").");
        }
    }
}
