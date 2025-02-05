// Check Number Type
using System;

class Solution {
    // Method to check if a number is positive, negative, or zero
    public static int CheckNumber(int number) {
        if (number > 0) return 1;
        if (number < 0) return -1;
        return 0;
    }

    public static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int result = CheckNumber(number);
        string type = result == 1 ? "Positive" : result == -1 ? "Negative" : "Zero";
        Console.WriteLine("The number is {0}.", type);
    }
}
