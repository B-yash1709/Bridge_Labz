using System;

class Employee {
    // static variable
    public static string CompanyName = "Capgemini";
    // static variable to count total employees
    private static int totalEmployees = 0;

    // readonly variable for empId
    public readonly int empId;


    // instance variables
    public string Name;
    public string Designation;

    // constructor
    public Employee(int empId, string name, string designation)
    {
        this.empId = empId;
        this.Name = name;
        this.Designation = designation;
        totalEmployees++;
    }
    // Method to display employee details
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("EmployeeID: "+empId+", Name: "+Name+", Designation: "+Designation+", Company: "+CompanyName);
    }

    // Static method to display total employees
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: "+totalEmployees);
    }
}
class Program { 
    static void Main(string[] args)
    {
        Employee e1 = new Employee(1001, "Aman", "Software Engineer");
        Employee e2 = new Employee(1002, "Rahul", "Manager");

        // Checking if emp1 is an instance of Employee class using 'is' operator
        if (e1 is Employee)
        {
            e1.DisplayEmployeeDetails();
        }

        if (e2 is Employee)
        {
            e2.DisplayEmployeeDetails();
        }

        // Display total employees
        Employee.DisplayTotalEmployees();
    }
}