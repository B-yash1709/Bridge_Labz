using System;

class UnitConverter {
    // Method to convert Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit) {
        return (fahrenheit - 32) * 5 / 9;
    }

    // Method to convert Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius) {
        return (celsius * 9 / 5) + 32;
    }

    // Method to convert pounds to kilograms
    public static double ConvertPoundsToKilograms(double pounds) {
        double pounds2kilograms = 0.453592;
        return pounds * pounds2kilograms;
    }

    // Method to convert kilograms to pounds
    public static double ConvertKilogramsToPounds(double kilograms) {
        double kilograms2pounds = 2.20462;
        return kilograms * kilograms2pounds;
    }

    // Method to convert gallons to liters
    public static double ConvertGallonsToLiters(double gallons) {
        double gallons2liters = 3.78541;
        return gallons * gallons2liters;
    }

    // Method to convert liters to gallons
    public static double ConvertLitersToGallons(double liters) {
        double liters2gallons = 0.264172;
        return liters * liters2gallons;
    }
}

class Solution {
    public static void Main() {
        Console.WriteLine("Calculator for conversions");

        // Fahrenheit to Celsius
        Console.Write("Enter temperature in Fahrenheit to convert to Celsius: ");
        double fahrenheit = double.Parse(Console.ReadLine());
        Console.WriteLine(fahrenheit+"°F is "+UnitConverter.ConvertFahrenheitToCelsius(fahrenheit).ToString("F2")+"°C.");

        // Celsius to Fahrenheit
        Console.Write("Enter temperature in Celsius to convert to Fahrenheit: ");
        double celsius = double.Parse(Console.ReadLine());
        Console.WriteLine(celsius+"°C is "+UnitConverter.ConvertCelsiusToFahrenheit(celsius).ToString("F2")+"°F.");

        // Pounds to Kilograms
        Console.Write("Enter weight in pounds to convert to kilograms: ");
        double pounds = double.Parse(Console.ReadLine());
        Console.WriteLine(pounds+" pounds is "+UnitConverter.ConvertPoundsToKilograms(pounds).ToString("F2")+" kilograms.");

        // Kilograms to Pounds
        Console.Write("Enter weight in kilograms to convert to pounds: ");
        double kilograms = double.Parse(Console.ReadLine());
        Console.WriteLine(kilograms+" kilograms is "+UnitConverter.ConvertKilogramsToPounds(kilograms).ToString("F2")+" pounds.");

        // Gallons to Liters
        Console.Write("Enter volume in gallons to convert to liters: ");
        double gallons = double.Parse(Console.ReadLine());
        Console.WriteLine(gallons+" gallons is "+UnitConverter.ConvertGallonsToLiters(gallons).ToString("F2")+" liters.");

        // Liters to Gallons
        Console.Write("Enter volume in liters to convert to gallons: ");
        double liters = double.Parse(Console.ReadLine());
        Console.WriteLine(liters+" liters is "+UnitConverter.ConvertLitersToGallons(liters).ToString("F2")+" gallons.");
    }
}
