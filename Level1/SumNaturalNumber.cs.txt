// Sum of N Natural Numbers
using System;

class Solution {
    // Method to calculate the sum of the first N natural numbers
    public static int CalculateSum(int n) {
        int sum = 0;
        for (int i = 1; i <= n; i++) {
            sum += i;
        }
        return sum;
    }

    public static void Main() {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSum(n);
        Console.WriteLine("The sum of the first {0} natural numbers is {1}.", n, sum);
    }
}
