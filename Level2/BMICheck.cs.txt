using System;

class BMI_Calculator
{
    // Method to calculate BMI and populate the array
    public static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < 10; i++)
        {
            double weight = data[i, 0]; // Weight in kg
            double heightInMeters = data[i, 1] / 100; // Height in cm, convert to meters
            double bmi = weight / (heightInMeters * heightInMeters); // BMI formula
            data[i, 2] = bmi; // Store BMI in the third column
        }
    }

    // Method to determine BMI status
    public static string[] DetermineBMIStatus(double[,] data)
    {
        string[] status = new string[10];

        for (int i = 0; i < 10; i++)
        {
            double bmi = data[i, 2]; // Get the BMI from the array

            if (bmi <= 18.4)
            {
                status[i] = "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                status[i] = "Normal weight";
            }
            else if (bmi >= 25 && bmi < 39.9)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }

        return status;
    }
}

class Program
{
    static void Main(string[] args)
    {
        double[,] data = new double[10, 3]; // 10 rows, 3 columns (weight, height, BMI)
        string[] status = new string[10];

        // Taking user input for weight and height
        Console.WriteLine("Enter the weight (in kg) and height (in cm) for 10 individuals:");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\nPerson " + (i + 1) + ":");
            Console.Write("Enter weight (in kg): ");
            data[i, 0] = double.Parse(Console.ReadLine());
            Console.Write("Enter height (in cm): ");
            data[i, 1] = double.Parse(Console.ReadLine());
        }

        // Calculate BMI for all individuals
        BMI_Calculator.CalculateBMI(data);

        // Get BMI status
        status = BMI_Calculator.DetermineBMIStatus(data);

        // Display results
        Console.WriteLine("\nBMI and Status for each individual:");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\nPerson " + (i + 1) + ":");
            Console.WriteLine("Weight: " + data[i, 0] + " kg");
            Console.WriteLine("Height: " + data[i, 1] + " cm");
            Console.WriteLine("BMI: " + data[i, 2].ToString("0.00"));
            Console.WriteLine("Status: " + status[i]);
        }
    }
}
