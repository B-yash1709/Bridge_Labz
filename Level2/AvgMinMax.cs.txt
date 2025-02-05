using System;

class Program
{
    // Method to generate an array of 4-digit random numbers
    public static int[] Generate4DigitRandomArray(int size)
    {
        Random rand = new Random();
        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            // Generate a random 4-digit number (1000 to 9999)
            numbers[i] = rand.Next(1000, 10000);
        }

        return numbers;
    }

    // Method to find the average, minimum, and maximum value of an array
    public static double[] FindAverageMinMax(int[] numbers)
    {
        double sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }

        double average = sum / numbers.Length;
        return new double[] { average, min, max };
    }

    static void Main(string[] args)
    {
        // Generate an array of 5 random 4-digit numbers
        int[] randomNumbers = Generate4DigitRandomArray(5);

        // Find the average, minimum, and maximum values
        double[] results = FindAverageMinMax(randomNumbers);

        // Display the generated random numbers
        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (int number in randomNumbers)
        {
            Console.WriteLine(number);
        }

        // Display the results (average, min, max)
        Console.WriteLine("\nResults:");
        Console.WriteLine("Average: " + results[0].ToString("0.00"));
        Console.WriteLine("Minimum: " + results[1]);
        Console.WriteLine("Maximum: " + results[2]);
    }
}
