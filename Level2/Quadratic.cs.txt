using System;

class Quadratic
{
    // Method to find the roots of the quadratic equation
    public static double[] FindRoots(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c; // Delta formula

        if (delta > 0) // Two real and distinct roots
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return new double[] { root1, root2 };
        }
        else if (delta == 0) // One real root
        {
            double root = -b / (2 * a);
            return new double[] { root };
        }
        else // Delta is negative, no real roots
        {
            return new double[] { }; // Returning an empty array
        }
    }

    static void Main(string[] args)
    {
        // Taking input values for a, b, and c
        Console.Write("Enter the coefficient a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter the coefficient b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter the coefficient c: ");
        double c = double.Parse(Console.ReadLine());

        // Finding the roots
        double[] roots = FindRoots(a, b, c);

        // Displaying the roots
        if (roots.Length == 2)
        {
            Console.WriteLine("The two roots are: root1 = " + roots[0] + ", root2 = " + roots[1]);
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine("The only root is: root = " + roots[0]);
        }
        else
        {
            Console.WriteLine("The equation has no real roots.");
        }
    }
}
