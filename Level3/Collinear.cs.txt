using System;

class CollinearityChecker {
    // Method to check collinearity using the slope formula
    public static bool CheckCollinearUsingSlope(double x1, double y1, double x2, double y2, double x3, double y3) {
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);

        return (slopeAB == slopeAC && slopeAB == slopeBC);
    }

    // Method to check collinearity using the area of the triangle formula
    public static bool CheckCollinearUsingArea(double x1, double y1, double x2, double y2, double x3, double y3) {
        double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        return Math.Abs(area) == 0; 
    }

    public static void Main() {
        // Input for three points
        Console.Write("Enter x1, y1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter x2, y2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter x3, y3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());

        // Check collinearity using slope formula
        bool collinearSlope = CheckCollinearUsingSlope(x1, y1, x2, y2, x3, y3);
        Console.WriteLine("Collinear using Slope Formula: {0}" , collinearSlope);

        // Check collinearity using area formula
        bool collinearArea = CheckCollinearUsingArea(x1, y1, x2, y2, x3, y3);
        Console.WriteLine("Collinear using Area Formula: {0}" , collinearArea);
    }
}
