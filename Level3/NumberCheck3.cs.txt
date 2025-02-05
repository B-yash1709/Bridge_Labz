using System;

class Solution {
    // Method to count the number of digits in a number
    public static int GetDigitCount(int number) {
		int length=0;
		while (number != 0) {
            length++;
            number /= 10;
        }
        return length;
    }

    // Method to get the digits of a number as an array
    public static int[] GetDigits(int number) {
        int length = GetDigitCount(number);
        int[] digits = new int[length];
        int i = length - 1;

        while (number != 0) {
            digits[i] = number % 10;
            i--;
            number /= 10;
        }

        return digits;
    }

    // Method to reverse the digits array
    public static int[] ReverseDigitsArray(int[] digitsArray) {
        return digitsArray.Reverse().ToArray();
    }

    // Method to check if two arrays are equal
    public static bool CheckArraysEqual(int[] array1, int[] array2) {
        return array1.SequenceEqual(array2);
    }

    // Method to check if a number is a palindrome
    public static bool CheckPalindrome(int number) {
        int[] digitsArray = GetDigits(number);
        int[] reversedArray = ReverseDigitsArray(digitsArray);
		
        return CheckArraysEqual(digitsArray, reversedArray);
    }

    // Method to check if a number is a duck number
    public static bool CheckDuckNumber(int number) {
        int[] digits = GetDigits(number);
        foreach (int digit in digits) {
            if (digit == 0) return true;
        }
        return false;
    }

    // Main method
    public static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digitsArray = GetDigits(number);
        int[] digitsArrayReversed = ReverseDigitsArray(digitsArray);

        Console.WriteLine("Digits array is: {0}", string.Join(",", digitsArray));
        Console.WriteLine("Reversed digits array is: {0}", string.Join(",", digitsArrayReversed));
        Console.WriteLine("Is the digits array equal to its reverse? {0}", CheckArraysEqual(digitsArray, digitsArrayReversed));
        Console.WriteLine("Is the number a palindrome? {0}", CheckPalindrome(number));
        Console.WriteLine("Is the number a Duck Number? {0}", CheckDuckNumber(number));
    }
}
