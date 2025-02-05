using System;

public class Product
{
    // Instance variables
    public string ProductName;
    public double Price;

    // Class variable (shared among all products)
    private static int totalProducts = 0;

    // Constructor
    public Product(string name, double price)
    {
        ProductName = name;
        Price = price;
        totalProducts++; // Increment the count of total products
    }

    // Instance Method to Display Product Details
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name: "+ProductName);
        Console.WriteLine("Price: "+Price);
    }

    // Class Method to Display Total Products
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: "+totalProducts);
    }
}

class Program
{
    static void Main()
    {
        // Creating Product Objects
        Product p1 = new Product("Laptop", 800);
        Product p2 = new Product("Smartphone", 500);
        Product p3 = new Product("Tablet", 300);

        // Displaying details of each product
        Console.WriteLine("Product Details:");
        p1.DisplayProductDetails();
        Console.WriteLine();

        p2.DisplayProductDetails();
        Console.WriteLine();

        p3.DisplayProductDetails();
        Console.WriteLine();

        // Displaying Total Products
        Product.DisplayTotalProducts();
    }
}
