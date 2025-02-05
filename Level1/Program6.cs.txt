using System;

public class CarRental
{
    public string CustomerName;
    public string CarModel;
    public int RentalDays;
    public double TotalCost;

    // Constructor
    public CarRental(string name, string model, int days)
    {
        CustomerName = name;
        CarModel = model;
        RentalDays = days;
        TotalCost = days * 50; // Assuming a fixed rate of $50 per day
    }

    // Method to Display Rental Details
    public void DisplayDetails()
    {
        Console.WriteLine("Customer: "+CustomerName);
        Console.WriteLine("Car Model: "+CarModel);
        Console.WriteLine("Rental Days: "+RentalDays);
        Console.WriteLine("Total Cost: "+TotalCost);
    }
}

class Program
{
    static void Main()
    {
        // Taking user input
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Rental Days: ");
        int days = Convert.ToInt32(Console.ReadLine());

        // Creating an object
        CarRental rental = new CarRental(name, model, days);

        // Displaying details
        Console.WriteLine("\nRental Details:");
        rental.DisplayDetails();
    }
}
