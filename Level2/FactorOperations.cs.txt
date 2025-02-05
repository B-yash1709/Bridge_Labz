using System;

class Solution {
	static int [] findFactors(int number){
		int count = 0;

        // First loop to count the number of factors
        for (int i = 1; i <= number; i++) {
            if (number % i == 0)
                count++;
        }

        // Initialize the array with the count of factors
        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++) {
            if (number % i == 0) {
                factors[index] = i;
                index++;
            }
        }
        return factors;
	}

	// method to calculate the sum
	public static int CalculateSum(int[] factors) {
        int sum = 0;
        foreach (int factor in factors) {
            sum += factor;
        }
        return sum;
    }

	//method to calculate the product
	public static long CalculateProduct(int[] factors) {
        long product = 1;
        foreach (int factor in factors) {
            product *= factor;
        }
        return product;
    }

	// Method to calculate the sum of the square of factors
    public static int CalculateSumOfSquares(int[] factors) {
        int sumOfSquares = 0;
        foreach (int factor in factors) {
            sumOfSquares += (int)Math.Pow(factor, 2);
        }
        return sumOfSquares;
    }

	public static void Main(){
		// prompt the user to enter a number
		Console.Write("Enter a number: ");
		int num = int.Parse(Console.ReadLine());
		
		int[] factors = findFactors(num);
		
		Console.WriteLine("Factors of the number: ");
		Console.WriteLine(string.Join(", ", factors));

        // Calculate and display the sum of the factors
        int sum = CalculateSum(factors);
        Console.WriteLine("Sum of the factors: "+sum);

        // Calculate and display the product of the factors
        long product = CalculateProduct(factors);
        Console.WriteLine("Product of the factors: "+product);

        // Calculate and display the sum of the square of the factors
        int sumOfSquares = CalculateSumOfSquares(factors);
        Console.WriteLine("Sum of the square of the factors: "+sumOfSquares);
	}
}