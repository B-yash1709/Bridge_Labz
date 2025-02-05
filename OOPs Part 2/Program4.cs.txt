using System;

class Product
{
    // Static variable shared by all products
    public static double Discount = 10;  // Default discount in percentage
    // Readonly variable for unique Product ID
    public readonly int ProductID;

    // Instance variables
    public string ProductName;
    public double Price;
    public int Quantity;

    // Constructor using 'this' keyword to initialize attributes
    public Product(int productID, string productName, double price, int quantity)
    {
        this.ProductID = productID;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
    }

    // Method to calculate final price after applying discount
    public double GetFinalPrice()
    {
        double discountAmount = (Price * Discount) / 100;
        return Price - discountAmount;
    }

    // Method to display product details
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product ID: "+ProductID+", Name: "+ProductName+", Price: "+Price+", Quantity: "+Quantity+", Final Price: "+GetFinalPrice());
    }

    // Static method to update discount
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
        Console.WriteLine("Discount updated to "+Discount+"%");
    }
}

class Program
{
    static void Main()
    {
        // Creating product objects
        Product p1 = new Product(101, "Laptop", 1000, 1);
        Product p2 = new Product(102, "Smartphone", 500, 2);

        // Checking if product1 is an instance of Product class using 'is' operator
        if (p1 is Product)
        {
            p1.DisplayProductDetails();
        }

        if (p2 is Product)
        {
            p2.DisplayProductDetails();
        }

        // Update discount for all products
        Product.UpdateDiscount(15);

        // Display product details after discount update
        p1.DisplayProductDetails();
        p2.DisplayProductDetails();
    }
}
