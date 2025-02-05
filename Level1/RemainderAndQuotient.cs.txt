// Remainder and Quotient
using System;

class Solution {
    // Method to calculate quotient and remainder
    public static int[] FindRemainderAndQuotient(int number, int divisor) {
        int quotient = number / divisor;
        int remainder = number % divisor;
        return new int[] { quotient, remainder };
    }

    public static void Main() {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(number, divisor);
        Console.WriteLine("Quotient: {0}, Remainder: {1}.", result[0], result[1]);
    }
}
