// Divide Chocolates Among Children
using System;

class Solution {
    // Method to calculate quotient and remainder
    public static int[] FindRemainderAndQuotient(int number, int divisor) {
        int quotient = number / divisor;
        int remainder = number % divisor;
        return new int[] { quotient, remainder };
    }

    public static void Main() {
        Console.Write("Enter the number of chocolates: ");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of children: ");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        // Check if divisor (number of children) is zero
        if (numberOfChildren == 0) {
            Console.WriteLine("Number of children cannot be zero.");
        }
		else {
        // Calculate and display the results
        int[] result = FindRemainderAndQuotient(numberOfChocolates, numberOfChildren);
        Console.WriteLine("Each child gets {0} chocolates, and {1} chocolates remain.", result[0], result[1]);
		}
    }
}
