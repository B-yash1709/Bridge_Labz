using System;

class Solution {
    // Method to get digits of a number as an array
    public static int[] GetDigits(int number) {
        int length = 0, tempNumber = number;
        while (tempNumber != 0) {
            length++;
            tempNumber /= 10;
        }

        int[] digits = new int[length];
        int i = 0;
        while (number != 0) {
            digits[i] = number % 10;
            i++;
            number /= 10;
        }

        return digits;
    }

    // Method to calculate the sum of digits of a number
    public static int GetSum(int number) {
        int[] digits = GetDigits(number);
        int sum = 0;
        foreach (int digit in digits) {
            sum += digit;
        }
        return sum;
    }

    // Method to calculate the sum of squares of digits of a number
    public static double GetSumOfSquaresOfDigits(int number) {
        int[] digits = GetDigits(number);
        double sumSquares = 0;
        foreach (int digit in digits) {
            sumSquares += Math.Pow(digit, 2);
        }
        return sumSquares;
    }

    // Method to check if a number is a Harshad number
    public static bool CheckHarshadNumber(int number) {
        int sum = GetSum(number);
        return (number % sum == 0);
    }

	// Method to get frequency of digits
	public static int[,] GetDigitFrequency(int number) {
		int[] digitsArray = GetDigits(number);
		int[] frequencyArray = new int[10]; 

		// Count the frequency of each digit
		foreach (int digit in digitsArray) {
			frequencyArray[digit]++;
		}

		// Determine the number of unique digits
		int uniqueDigitCount = 0;
		for (int i = 0; i < frequencyArray.Length; i++) {
			if (frequencyArray[i] > 0) {
				uniqueDigitCount++;
			}
		}

		// Create a 2D array for digit and frequency
		int[,] result = new int[uniqueDigitCount, 2];
		int index = 0;

		// Populate the result array
		for (int i = 0; i < frequencyArray.Length; i++) {
			if (frequencyArray[i] > 0) {
				result[index, 0] = i;
				result[index, 1] = frequencyArray[i]; 
				index++;
			}
		}
		return result;
	}


    // Main method to test the utility
    public static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Calculate and display results
        Console.WriteLine("Sum of digits: {0}", GetSum(number));
        Console.WriteLine("Sum of squares of digits: {0}", GetSumOfSquaresOfDigits(number));
        Console.WriteLine("Is Harshad Number: {0}", CheckHarshadNumber(number));

        // Get and display digit frequency
        int[,] frequencyArray = GetDigitFrequency(number);
        Console.WriteLine("Digit Frequencies:");
        for (int i = 0; i < frequencyArray.GetLength(0); i++) {
            Console.WriteLine("Digit: {0}, Frequency: {1}", frequencyArray[i, 0], frequencyArray[i, 1]);
        }
    }
}
