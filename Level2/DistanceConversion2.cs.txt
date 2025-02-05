using System;

class UnitConverter {
    // Method to convert yards to feet
    public static double ConvertYardsToFeet(double yards) {
        double yards2feet = 3;
        return yards * yards2feet;
    }

    // Method to convert feet to yards
    public static double ConvertFeetToYards(double feet) {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    // Method to convert meters to inches
    public static double ConvertMetersToInches(double meters) {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    // Method to convert inches to meters
    public static double ConvertInchesToMeters(double inches) {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    // Method to convert inches to centimeters
    public static double ConvertInchesToCentimeters(double inches) {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }
}

class Solution {
    static void Main(string[] args) {
        Console.WriteLine("Calculator for conversions");

        // Yards to Feet
        Console.Write("Enter yards to convert to feet: ");
        double yards = double.Parse(Console.ReadLine());
        Console.WriteLine(yards+" yards is "+UnitConverter.ConvertYardsToFeet(yards).ToString("F2")+" feet.");

        // Feet to Yards
        Console.Write("Enter feet to convert to yards: ");
        double feet = double.Parse(Console.ReadLine());
        Console.WriteLine(feet+" feet is "+UnitConverter.ConvertFeetToYards(feet).ToString("F2")+" yards.");

        // Meters to Inches
        Console.Write("Enter meters to convert to inches: ");
        double meters = double.Parse(Console.ReadLine());
        Console.WriteLine(meters+" meters is "+UnitConverter.ConvertMetersToInches(meters).ToString("F2")+" inches.");

        // Inches to Meters
        Console.Write("Enter inches to convert to meters: ");
        double inches = double.Parse(Console.ReadLine());
        Console.WriteLine(inches+" inches is "+UnitConverter.ConvertInchesToMeters(inches).ToString("F2")+" meters.");

        // Inches to Centimeters
        Console.Write("Enter inches to convert to centimeters: ");
        inches = double.Parse(Console.ReadLine());
        Console.WriteLine(inches+" inches is "+UnitConverter.ConvertInchesToCentimeters(inches).ToString("F2")+" centimeters.");
    }
}
