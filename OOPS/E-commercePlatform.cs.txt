using System;
using System.Collections.Generic;

// Product class 
class Product
{
    public string productName;
    public decimal price;

    // constructor
    public Product(string productName, decimal price)
    {
        this.productName = productName;
        this.price = price;
    }

    // method to display product
    public void DisplayProduct()
    {
        Console.WriteLine("Product: {0}, price: {1:C}", productName, price);
    }
}

// Order class
class Order
{
    public int orderId;
    private List<Product> products;

    // constructor
    public Order(int orderId)
    {
        this.orderId = orderId;
        this.products = new List<Product>();
    }

    // method to Add Product
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // method to Display Orders
    public void DisplayOrder()
    {
        Console.WriteLine("Order ID: {0}", orderId);
        foreach (var product in products)
        {
            product.DisplayProduct();
        }
    }
}

// Customer class placing orders
class Customer
{
    public string customerName;
    private List<Order> orders;

    // customer
    public Customer(string customerName)
    {
        this.customerName = customerName;
       this. orders = new List<Order>();
    }

    // method to Place Order
    public void PlaceOrder(Order order)
    {
        orders.Add(order);
    }

    // method to display All Customers Orders
    public void DisplayCustomerOrders()
    {
        Console.WriteLine("Customer: {0}", this.customerName);
        foreach (var order in orders)
        {
            order.DisplayOrder();
        }
    }
}

// Main class
class Program
{
    static void Main()
    {
        // Creating products
        Product product1 = new Product("Shoes", 800);
        Product product2 = new Product("Smart and Handsome Cream", 50);
        
        // Creating an order object
        Order order = new Order(101);
        order.AddProduct(product1);
        order.AddProduct(product2);
        
        // Creating a customer objectu
        Customer customer = new Customer("Vansh Saxena");
        customer.PlaceOrder(order);
        
        // Displaying customer orders
        customer.DisplayCustomerOrders();
    }
}
