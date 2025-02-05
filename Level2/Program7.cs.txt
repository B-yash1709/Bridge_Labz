using System;

public class Employee
{
    public int EmployeeID;
    protected string Department;
    private decimal Salary;

    // Constructor to initialize employee details
    public Employee(int employeeID, string department, decimal salary)
    {
        EmployeeID = employeeID;
        Department = department;
        Salary = salary;
    }

    // Public method to modify salary
    public void ModifySalary(decimal newSalary)
    {
        Salary = newSalary;
        Console.WriteLine("Salary updated to: "+Salary);
    }

    // Method to display employee details
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Employee ID: "+EmployeeID);
        Console.WriteLine("Department: "+Department);
        Console.WriteLine("Salary: "+Salary);
    }
}

public class Manager : Employee
{
    // Constructor for Manager to access Employee properties
    public Manager(int employeeID, string department, decimal salary)
        : base(employeeID, department, salary) { }

    // Method to display manager details
    public void DisplayManagerDetails()
    {
        Console.WriteLine("Manager Details:");
        Console.WriteLine("Employee ID: "+EmployeeID);  // Accessing public property
        Console.WriteLine("Department: "+Department);  // Accessing protected property
        // Cannot access Salary directly here as it's private to the Employee class
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating an Employee object
        Employee employee = new Employee(101, "Marketing", 50000);

        // Display employee details
        employee.DisplayEmployeeDetails();

        // Modify salary
        employee.ModifySalary(55000);

        // Display updated employee details
        employee.DisplayEmployeeDetails();

        // Creating a Manager object
        Manager manager = new Manager(102, "Sales", 70000);

        // Display manager details
        manager.DisplayManagerDetails();
    }
}
