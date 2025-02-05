// Calculate Trigonometric Functions
using System;

class Solution {
    // Method to calculate trigonometric functions
    public static double[] CalculateTrigonometricFunctions(double angle) {
        // Convert angle from degrees to radians
        double radians = Math.PI * angle / 180.0;
        double sine = Math.Sin(radians);
        double cosine = Math.Cos(radians);
        double tangent = Math.Tan(radians);

        return new double[] { sine, cosine, tangent };
    }

    public static void Main() {
        Console.Write("Enter an angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        // Calculate and display trigonometric values
        double[] results = CalculateTrigonometricFunctions(angle);

        Console.WriteLine("Sine: {0}", results[0]);
        Console.WriteLine("Cosine: {0}", results[1]);
        Console.WriteLine("Tangent: {0}", results[2]);
    }
} 
