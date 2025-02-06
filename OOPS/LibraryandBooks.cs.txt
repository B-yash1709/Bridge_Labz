using System;
using System.Collections.Generic;

class Book
{   
    public string title;
    public string author;

    // Constructor
    public Book(string title, string author)
    {        
        this.title = title;
        this.author = author;
    }

    // Method to display book details
    public void DisplayBook()
    {
        Console.WriteLine("this.title: {0}, this.author: {1}" , this.title , this.author);
    }
}

// Library class
class Library
{
    // List to hold books 
    private readonly List<Book> books;
        
    public string libraryName;
    
    // Constructor
    public Library(string name)
    {    
        libraryName = name;
        books = new List<Book>();
    }

    // Method to add a book
    public void AddBook(Book book)
    {        
        books.Add(book);
    }

    // Method to display all books
    public void DisplayLibraryBooks()
    {
        Console.WriteLine("Library: {0} contains the following books:" , libraryName);
        if (books.Count == 0)
        {
            Console.WriteLine("No books available in the library.");
            return;
        }
        foreach (var book in books)
        {
            book.DisplayBook();
        }
    }
}

// Main class (aggregation)
class Program
{
    static void Main()
    {
        
        // Creating Book objects
        Book book1 = new Book("The Last Kingdom", "Rohit");
        Book book2 = new Book("The Last Kingdom: Revolution", "Atul");
        Book book3 = new Book("Falling Kingdom", "Aman");

        // Creating Library objects
        Library library1 = new Library("GLA Central Library");
        Library library2 = new Library("GLA MBA Library");

        // Adding books to different libraries
        library1.AddBook(book1);
        library1.AddBook(book2);
            
        library2.AddBook(book2); 
        library2.AddBook(book3);

        // Display books in each library
        library1.DisplayLibraryBooks();
        library2.DisplayLibraryBooks();
        
    }
}
