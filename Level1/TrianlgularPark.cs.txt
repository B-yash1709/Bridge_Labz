// Triangular Park Rounds
using System;

class Solution {
    // Method to calculate the number of rounds to cover a distance
    public static int CalculateRounds(double side1, double side2, double side3, double distance) {
        double perimeter = side1 + side2 + side3;
        return (int)Math.Ceiling(distance / perimeter);
    }

    public static void Main() {
		
		// prompt user for 3 sides input
        Console.Write("Enter side1 (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side2 (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side3 (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        const double distance = 5000;
        int rounds = CalculateRounds(side1, side2, side3, distance);
		
		// print result
        Console.WriteLine("The athlete needs to complete {0} rounds to finish 5 km.", rounds);
    }
}
