using System;

// Base Class: Book
public class Book
{
    public string ISBN;    
    protected string Title; 
    private string Author;  

    // Constructor
    public Book(string isbn, string title, string author)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
    }

    // Method to set the author's name
    public void SetAuthor(string author)
    {
        Author = author;
    }

    // Method to get the author's name
    public string GetAuthor()
    {
        return Author;
    }

    // Display method to show Book details
    public void DisplayBookDetails()
    {
        Console.WriteLine("ISBN: "+ISBN+", Title: "+Title+", Author: "+Author);
    }
}

// Derived Class: EBook
public class EBook : Book
{
    public string FileFormat { get; set; }

    // Constructor
    public EBook(string isbn, string title, string author, string fileFormat)
        : base(isbn, title, author)
    {
        FileFormat = fileFormat;
    }

    // Display method to show EBook details (accessing ISBN and Title)
    public void DisplayEBookDetails()
    {
        Console.WriteLine("EBook - ISBN: "+ISBN+", Title: "+Title+", Author: "+GetAuthor()+", File Format: "+FileFormat);
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Creating a Book object
        Book book1 = new Book("978-3-16-148410-0", "C# Programming", "John Doe");
        book1.DisplayBookDetails();

        // Creating an EBook object
        EBook ebook1 = new EBook("978-1-234-56789-0", "Advanced C#", "Jane Doe", "PDF");
        ebook1.DisplayEBookDetails();

        // Setting and getting the author's name using methods
        ebook1.SetAuthor("Michael Smith");
        Console.WriteLine("Updated Author for EBook: " + ebook1.GetAuthor());
    }
}
