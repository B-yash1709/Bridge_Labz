// Smallest and Largest
using System;
using Math;

class Solution {
    // Method to find smallest and largest numbers
    public static int[] FindSmallestAndLargest(int num1, int num2, int num3) {
        int smallest = Min(num1, Min(num2, num3));
        int largest = Max(num1, Max(num2, num3));
        return new int[] { smallest, largest };
    }

    public static void Main() {
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        int[] result = FindSmallestAndLargest(num1, num2, num3);
        Console.WriteLine("Smallest: {0}, Largest: {1}.", result[0], result[1]);
    }
}