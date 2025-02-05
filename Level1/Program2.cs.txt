using System;

public class Circle
{
    // Attribute (Property)
    public double Radius { get; set; }

    // Default Constructor (Initializes Radius to 1.0)
    public Circle() : this(1.0)  // Calls the parameterized constructor
    {
    }

    // Parameterized Constructor (Initializes Radius with User-Provided Value)
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Method to Calculate Area
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Method to Calculate Circumference
    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius;
    }

    // Method to Display Circle Details
    public void DisplayDetails()
    {
        Console.WriteLine("Radius: "+Radius);
        Console.WriteLine("Area: "+CalculateArea());
        Console.WriteLine("Circumference: "+CalculateCircumference());
    }
}

public class Program
{
    public static void Main()
    {
        // Using Default Constructor (Radius = 1.0)
        Console.WriteLine("Circle Details (Using Default Constructor):");
        Circle defaultCircle = new Circle();
        defaultCircle.DisplayDetails();

        Console.WriteLine("\n--------------------------------\n");

        // Using Parameterized Constructor (Radius = 5.0)
        Console.WriteLine("Circle Details (Using Parameterized Constructor):");
        Circle parameterizedCircle = new Circle(5.0);
        parameterizedCircle.DisplayDetails();
    }
}
