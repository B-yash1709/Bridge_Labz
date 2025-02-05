//Calculate Simple Interest
using System;

class Solution {
    // Method to calculate simple interest
    public static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    public static void Main() {
	
		// prompt user for principal, interest, time input
        Console.Write("Enter Principal: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine());
		
		// calculate and print simple Interest
        double simpleInterest = CalculateSimpleInterest(principal, rate, time);
        Console.WriteLine("The Simple Interest is {0} for Principal {1}, Rate of Interest {2}, and Time {3}", simpleInterest, principal, rate, time);
    }
}