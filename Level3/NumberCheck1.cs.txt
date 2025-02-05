using System;

class Solution {
    // Extract digits of a number as an array
    public static int[] GetDigits(int number) {
        int length = 0, tempNumber = number;
        while (tempNumber != 0) {
            length++;
            tempNumber /= 10;
        }
        int[] digits = new int[length];
        int i = length - 1; 
        while (number != 0) {
            digits[i] = number % 10;
            i--;
            number /= 10;
        }
        return digits;
    }

    // Check if a number is a Duck Number
    public static bool IsDuckNumber(int number) {
        int[] digits = GetDigits(number);
        if (digits[0] == 0) return false;
        foreach (int digit in digits) {
            if (digit == 0) return true;
        }
        return false;
    }

    // Check if a number is an Armstrong Number
    public static bool IsArmstrongNumber(int number) {
        int[] digits = GetDigits(number);
        int power = digits.Length;
        int sum = 0;
        foreach (int digit in digits) {
            sum += (int)Math.Pow(digit, power);
        }
        return sum == number;
    }

    // Find the largest and second-largest digits
    public static void FindLargestAndSecondLargest(int[] digits) {
        int largest = int.MinValue, secondLargest = int.MinValue;
        foreach (int digit in digits) {
            if (digit > largest) {
                secondLargest = largest;
                largest = digit;
            } else if (digit > secondLargest) {
                secondLargest = digit;
            }
        }
        Console.WriteLine("Largest: {0}, Second Largest: {1}", largest, secondLargest);
    }

    // Find the smallest and second-smallest digits
    public static void FindSmallestAndSecondSmallest(int[] digits) {
        int smallest = int.MaxValue, secondSmallest = int.MaxValue;
        foreach (int digit in digits) {
            if (digit < smallest) {
                secondSmallest = smallest;
                smallest = digit;
            } else if (digit < secondSmallest) {
                secondSmallest = digit;
            }
        }
        Console.WriteLine("Smallest: {0}, Second Smallest: {1}", smallest, secondSmallest);
    }

    // Main Method
    public static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Is Duck Number: {0}", IsDuckNumber(number));
        Console.WriteLine("Is Armstrong Number: {0}", IsArmstrongNumber(number));

        int[] digits = GetDigits(number);
        FindLargestAndSecondLargest(digits);
        FindSmallestAndSecondSmallest(digits);
    }
}
