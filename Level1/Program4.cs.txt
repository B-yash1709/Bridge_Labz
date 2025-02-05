using System;

public class HotelBooking
{
    public string GuestName;
    public string RoomType;
    public int Nights;

    // Default Constructor
    public HotelBooking()
    {
        GuestName = "Unknown";
        RoomType = "Standard";
        Nights = 1;
    }

    // Parameterized Constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        GuestName = guestName;
        RoomType = roomType;
        Nights = nights;
    }

    // Copy Constructor (Cloning an existing booking)
    public HotelBooking(HotelBooking other)
    {
        GuestName = other.GuestName;
        RoomType = other.RoomType;
        Nights = other.Nights;
    }

    // Method to Display Booking Details
    public void DisplayBooking()
    {
        Console.WriteLine("Guest: "+GuestName+", Room Type: "+RoomType+", Nights: "+Nights);
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a booking using the Parameterized Constructor
        HotelBooking booking1 = new HotelBooking("Aman Sharma", "Deluxe", 3);
        Console.WriteLine("Original Booking:");
        booking1.DisplayBooking();

        // Creating a copy of booking1 using the Copy Constructor
        HotelBooking booking2 = new HotelBooking(booking1);
        Console.WriteLine("\nCopied Booking:");
        booking2.DisplayBooking();

        // Creating a booking with the Default Constructor
        HotelBooking booking3 = new HotelBooking();
        Console.WriteLine("\nDefault Booking:");
        booking3.DisplayBooking();
    }
}
