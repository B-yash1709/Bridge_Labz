using System;

public class Book
{
    public string Title;
    public string Author;
    public double Price;
    public bool IsAvailable;

    // Constructor to Initialize Book
    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
        IsAvailable = true; // Book is available by default
    }

    // Method to Borrow a Book
    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false; // Mark as borrowed
            Console.WriteLine("You have successfully borrowed \""+Title+"\" by "+Author);
        }
        else
        {
            Console.WriteLine("Sorry, \""+Title+"\" is currently unavailable.");
        }
    }

    // Method to Display Book Details
    public void DisplayBook()
    {
        Console.WriteLine("Title: "+Title+", Author: "+Author+", Price: "+Price+", Available: "+(IsAvailable ? "Yes" : "No"));
    }
}

public class Program
{
    public static void Main()
    {
        // Creating Book Objects
        Book book1 = new Book("C# Programming", "John Smith", 3000);
        Book book2 = new Book("Data Structures", "Alice Johnson", 2000);

        // Display Book Details
        Console.WriteLine("Book Details:");
        book1.DisplayBook();
        book2.DisplayBook();

        // Borrow Book
        Console.WriteLine("\nBorrowing a book...");
        book1.BorrowBook(); // Borrowing C# Programming
        book1.BorrowBook(); // Trying to borrow again

        // Display Updated Book Status
        Console.WriteLine("\nUpdated Book Details:");
        book1.DisplayBook();
        book2.DisplayBook();
    }
}
