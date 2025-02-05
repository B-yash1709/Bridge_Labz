using System;

class Solution {
    // Method to find factors of a number and return them as an array
    public static int[] FindFactors(int number) {
        int count = 0;

        // Count the number of factors
        for (int i = 1; i <= number; i++) {
            if (number % i == 0) count++;
        }

        int[] factors = new int[count];
        int index = 0;

        // Store the factors in an array
        for (int i = 1; i <= number; i++) {
            if (number % i == 0) {
                factors[index] = i;
            }
			index++;
        }

        return factors;
    }

    // Method to find the greatest factor of a number
    public static int FindGreatestFactor(int number) {
        int[] factors = FindFactors(number);
		
        return factors[factors.Length - 1];
    }

    // Method to find the sum of the factors
    public static int SumOfFactors(int number) {
        int[] factors = FindFactors(number);
        int sum = 0;

        foreach (int factor in factors) {
            sum += factor;
        }

        return sum;
    }

    // Method to find the product of the factors
    public static long ProductOfFactors(int number) {
        int[] factors = FindFactors(number);
        long product = 1;

        foreach (int factor in factors) {
            product *= factor;
        }

        return product;
    }	
	
    // Method to find the product of the cubes of the factors
    public static double ProductOfCubesOfFactors(int number) {
        int[] factors = FindFactors(number);
        double product = 1;

        foreach (int factor in factors) {
            product *= Math.Pow(factor, 3);
        }

        return product;
    }

	// Helper Method to calculate proper divisor sum of number
    public static bool ProperDivisorSum(int number) {
        int[] factors = FindFactors(number);
        int sum = 0;
		
        for (int i = 0; i < factors.Length - 1; i++) {
            sum += factors[i];
        }

        return sum;
    }
	
    // Method to check if a number is a perfect number
    public static bool IsPerfectNumber(int number) {
        int sum = ProperDivisorSum(number);

        return sum == number;
    }

    // Method to check if a number is an abundant number
    public static bool IsAbundantNumber(int number) {
        int sum = ProperDivisorSum(number);

        return sum > number;
    }

    // Method to check if a number is a deficient number
    public static bool IsDeficientNumber(int number) {
        int sum = ProperDivisorSum(number);

        return sum < number;
    }

	// Helper method to calculate the factorial of a number
    private static int Factorial(int n) {
        int result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }

    // Method to check if a number is a strong number
    public static bool IsStrongNumber(int number) {
        int temp = number;
        int sum = 0;

        while (temp > 0) {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }

        return sum == number;
    }

    
    // Main method to call the utility methods and display results
    public static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);
        Console.WriteLine("Factors: " + string.Join(", ", factors));
        Console.WriteLine("Greatest Factor: " + FindGreatestFactor(number));
        Console.WriteLine("Sum of Factors: " + SumOfFactors(number));
        Console.WriteLine("Product of Factors: " + ProductOfFactors(number));
        Console.WriteLine("Product of Cubes of Factors: " + ProductOfCubesOfFactors(number));
        Console.WriteLine("Is Perfect Number: " + IsPerfectNumber(number));
        Console.WriteLine("Is Abundant Number: " + IsAbundantNumber(number));
        Console.WriteLine("Is Deficient Number: " + IsDeficientNumber(number));
        Console.WriteLine("Is Strong Number: " + IsStrongNumber(number));
    }
}
