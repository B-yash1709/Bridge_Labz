using System;

public class Person
{
    public string Name;
    public int Age;

    // Default Constructor
    public Person()
    {
        Name = "Unknown";
        Age = 0;
    }

    // Parameterized Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Copy Constructor (Cloning)
    public Person(Person other)
    {
        Name = other.Name; // Copy name
        Age = other.Age;   // Copy age
    }

    // Method to Display Person Details
    public void Display()
    {
        Console.WriteLine("Name: "+Name+", Age: "+Age);
    }
}

public class Program
{
    public static void Main()
    {
        // Creating a Person using Parameterized Constructor
        Person person1 = new Person("Alice", 25);
        Console.WriteLine("Original Person:");
        person1.Display();

        // Creating a Copy of person1 using the Copy Constructor
        Person person2 = new Person(person1);
        Console.WriteLine("\nCopied Person:");
        person2.Display();
    }
}
