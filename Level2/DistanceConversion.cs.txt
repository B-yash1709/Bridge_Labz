using System;

class UnitConverter {
    // Method to convert kilometers to miles
    public static double ConvertKmToMiles(double km) {
        double km2miles = 0.621371;
        return km * km2miles;
    }

    // Method to convert miles to kilometers
    public static double ConvertMilesToKm(double miles) {
        double miles2km = 1.60934;
        return miles * miles2km;
    }

    // Method to convert meters to feet
    public static double ConvertMetersToFeet(double meters) {
        double meters2feet = 3.28084;
        return meters * meters2feet;
    }

    // Method to convert feet to meters
    public static double ConvertFeetToMeters(double feet) {
        double feet2meters = 0.3048;
        return feet * feet2meters;
    }
}

class Solution {
    public static void Main() {
        // Demonstrate conversions
        Console.WriteLine("Calculator for conversions");
        
        // Kilometers to Miles
        Console.Write("Enter kilometers to convert to miles: ");
        double km = double.Parse(Console.ReadLine());
        Console.WriteLine(km+" km is "+UnitConverter.ConvertKmToMiles(km).ToString("F2")+" miles.");
        
        // Miles to Kilometers
        Console.Write("Enter miles to convert to kilometers: ");
        double miles = double.Parse(Console.ReadLine());
        Console.WriteLine(miles+" miles is "+UnitConverter.ConvertMilesToKm(miles).ToString("F2")+" kilometers.");
        
        // Meters to Feet
        Console.Write("Enter meters to convert to feet: ");
        double meters = double.Parse(Console.ReadLine());
        Console.WriteLine(meters+" meters is "+UnitConverter.ConvertMetersToFeet(meters).ToString("F2")+" feet.");
        
        // Feet to Meters
        Console.Write("Enter feet to convert to meters: ");
        double feet = double.Parse(Console.ReadLine());
        Console.WriteLine(feet+" feet is "+UnitConverter.ConvertFeetToMeters(feet).ToString("F2")+" meters.");
    }
}
