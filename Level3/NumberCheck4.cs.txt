using System;

class Solution {
	
    // Method to get the digits of a number as an array
    public static int[] GetDigits(int number) {
        int length = 0, tempNumber = number;
        while (tempNumber != 0) {
            length++;
            tempNumber /= 10;
        }
        int[] digits = new int[length];
        int i = 0;
        while (number != 0) {
            int digit = number % 10;
            digits[length - 1 - i] = digit; 
            i++;
            number /= 10;
        }
        return digits;
    }

    // Method to get the sum of the digits of a number
    public static int GetSum(int number) {
        int[] digits = GetDigits(number);
        int sum = 0;
        foreach (int digit in digits) {
            sum += digit;
        }
        return sum;
    }

    // Method to get the product of the digits of a number
    public static int GetProduct(int number) {
        int[] digits = GetDigits(number);
        int product = 1;
        foreach (int digit in digits) {
            product *= digit;
        }
        return product;
    }

    // Method to check if a number is a Neon number
    public static bool CheckNeonNumber(int number) {
        int squareNumber = (int)Math.Pow(number, 2);
        int squareSum = GetSum(squareNumber);
		
        return number == squareSum;
    }

    // Method to check if a number is a Spy number
    public static bool CheckSpyNumber(int number) {
        int product = GetProduct(number);
        int sum = GetSum(number);
		
        return sum == product;
    }

    // Method to check if a number is an Automorphic number
    public static bool CheckAutomorphicNumber(int number) {
        int squareNumber = (int)Math.Pow(number, 2);
        while (number > 0) {
            int numDigit = number % 10;
            int squareDigit = squareNumber % 10;
			
            if (numDigit != squareDigit) return false;
			
            number /= 10;
            squareNumber /= 10;
        }
        return true;
    }

    // Method to check if a number is a Buzz number
    public static bool CheckBuzzNumber(int number) {
        return number % 7 == 0 || number % 10 == 7;
    }

    // Method to check if a number is Prime
    public static bool CheckPrime(int number) {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++) {
            if (number % i == 0) return false;
        }
        return true;
    }

    // Main method
    public static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digitsArray = GetDigits(number);

        Console.WriteLine("Digits array is: {0}", string.Join(",", digitsArray));
        Console.WriteLine("Is the number prime? {0}", CheckPrime(number));
        Console.WriteLine("Is the number a Neon number? {0}", CheckNeonNumber(number));
        Console.WriteLine("Is the number a Spy number? {0}", CheckSpyNumber(number));
        Console.WriteLine("Is the number an Automorphic number? {0}", CheckAutomorphicNumber(number));
        Console.WriteLine("Is the number a Buzz number? {0}", CheckBuzzNumber(number));
    }
}
