using System;

class Book {
    // static variable
    public static string LibraryName = "GLA Library";
    // readonly variable
    public readonly string ISBN;
    // instance variable
    public string Title;
    public string Author;

    // constructor
    public Book(string title,string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }
    // method to display the book details
    public void DisplayBookDetails()
    {
        Console.WriteLine("Title: "+Title+", Author: "+Author+", ISBN: "+ISBN);
    }
    // method to display library name
    public static void DisplayLibraryName() {
        Console.WriteLine("Library: "+LibraryName);
    }
}
class Program
{
    static void Main() {
        // display static library name
        Book.DisplayLibraryName();

        Book b1 = new Book("Python","Eric Matthes", "9780061122415");
        Book b2 = new Book("Java", "Kathy Sierra & Bert Bates", "9780747532743");

        // verifing the book instance
        if (b1 is Book) {
            Console.WriteLine("b1 is instance of Book");
            b1.DisplayBookDetails();
        }
        if (b2 is Book) {
            Console.WriteLine("b2 is instance of Book");
            b2.DisplayBookDetails();
        }
    }
}