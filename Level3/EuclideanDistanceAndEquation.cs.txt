using System;

class Solution {
    // Method to calculate the Euclidean distance between two points
    public static double CalculateDistance(double x1, double y1, double x2, double y2) {
        double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		
        return distance;
    }

    // Method to calculate the slope and y-intercept of a line passing through two points
    public static double[] GetLineEquation(double x1, double y1, double x2, double y2) {
        double slope = (y2 - y1) / (x2 - x1); 
        double yIntercept = y1 - slope * x1; 
		
        return new double[] { slope, yIntercept }; 
    }

    public static void Main() {
        // Input for two points
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        // Calculate distance
        double distance = CalculateDistance(x1, y1, x2, y2);
        Console.WriteLine("Euclidean Distance: {0}" , distance);

        // Calculate line equation
        double[] lineEquation = GetLineEquation(x1, y1, x2, y2);
        Console.WriteLine("Equation of the Line: y = {0} * x + {1}" , lineEquation[0] ,lineEquation[1]);
    }
}
