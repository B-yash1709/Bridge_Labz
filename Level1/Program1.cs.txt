using System;

public class Book
{
    // Attributes (Properties of the Book)
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    // Default Constructor (No parameters, assigns default values)
    public Book()
    {
        Title = "Unknown Title";
        Author = "Unknown Author";
        Price = 0.0;
    }

    // Parameterized Constructor (Takes values from the user)
    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    // Method to Display Book Details
    public void DisplayBookDetails()
    {
        Console.WriteLine("Book Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Price: " + Price);
    }
}

public class Program
{
    public static void Main()
    {
        // Using Default Constructor (Creates an object with default values)
        Console.WriteLine("Book Details (Using Default Constructor):");
        Book defaultBook = new Book(); // Calls the default constructor
        defaultBook.DisplayBookDetails(); // Calls the method to print book details

        Console.WriteLine("\n--------------------------------\n");

        // Using Parameterized Constructor (Creates an object with user-defined values)
        Console.WriteLine("Book Details (Using Parameterized Constructor):");
        Book parameterizedBook = new Book("Ramayan", "Tulsi Das", 1000); // Calls parameterized constructor
        parameterizedBook.DisplayBookDetails(); // Calls the method to print book details
    }
}
