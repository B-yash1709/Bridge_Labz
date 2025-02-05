using System;

class Vehicle
{
    // Static variable shared across all vehicles
    public static double RegistrationFee = 5000;
    // Readonly variable for unique registration number
    public readonly string RegistrationNumber;

    // Instance variables
    public string OwnerName;
    public string VehicleType;

    // Constructor
    public Vehicle(string regNumber, string owner, string type)
    {
        this.RegistrationNumber = regNumber;
        this.OwnerName = owner;
        this.VehicleType = type;
    }

    // Method to display vehicle details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner: " + OwnerName +", Vehicle Type: "+VehicleType+", Registration Number: "+RegistrationNumber+", Fee: "+RegistrationFee);
    }

    // Static method to update registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }
}

class Program
{
    static void Main()
    {
        // Creating vehicle objects
        Vehicle v1 = new Vehicle("V12345", "Aman", "Car");
        Vehicle v2 = new Vehicle("V67890", "Rahul", "Bike");

        // Checking if vehicle1 is an instance of Vehicle class using 'is' operator
        if (v1 is Vehicle)
        {
            v1.DisplayVehicleDetails();
        }

        if (v2 is Vehicle)
        {
            v2.DisplayVehicleDetails();
        }

        // Updating registration fee
        Vehicle.UpdateRegistrationFee(5500.0);
        Console.WriteLine("\nUpdated Registration Fee Applied!");
        // Displaying details after updating fee
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();
    }
}
