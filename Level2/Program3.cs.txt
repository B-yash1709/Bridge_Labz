using System;

public class Vehicle
{
    public string OwnerName;
    public string VehicleType; // Car, Bike, Truck, etc.

    // Static variable (shared among all vehicles)
    private static double RegistrationFee = 500; // Default fee

    // Constructor
    public Vehicle(string owner, string type)
    {
        OwnerName = owner;
        VehicleType = type;
    }

    // Method to display vehicle details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner: "+OwnerName+", Vehicle Type: "+VehicleType+", Registration Fee: "+RegistrationFee);
    }

    // Method to update registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }
}

class Program
{
    static void Main()
    {
        Vehicle v1 = new Vehicle("Aman Kumar", "Car");
        Vehicle v2 = new Vehicle("Rahul Kumar", "Bike");

        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();

        // Update registration fee
        Vehicle.UpdateRegistrationFee(600);

        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();
    }
}
