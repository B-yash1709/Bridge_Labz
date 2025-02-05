// Calculate Wind Chill Temperature
using System;

class Solution {
    // Method to calculate wind chill temperature
    public static double CalculateWindChill(double temperature, double windSpeed) {
        return 35.74 + (0.6215 * temperature) + ((0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16));
    }

    public static void Main() {
        Console.Write("Enter the temperature in Fahrenheit: ");
        double temperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the wind speed in mph: ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        // Validate wind speed
        if (windSpeed < 0) {
            Console.WriteLine("Wind speed cannot be negative.");
        }
		else {
        // Calculate and display wind chill temperature
        double windChill = CalculateWindChill(temperature, windSpeed);
        Console.WriteLine("The wind chill temperature is {0:F2}°F.", windChill);
		}
    }
}