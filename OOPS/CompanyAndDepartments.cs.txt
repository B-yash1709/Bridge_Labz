using System;
using System.Collections.Generic;

// Employee class
class Employee
{
    public string name;
    public string position;

    // Constructor
    public Employee(string name, string position)
    {
        this.name = name;
        this.position = position;
    }

    // Method to display details
    public void DisplayEmployee()
    {
        Console.WriteLine("Employee: {0}, position: {1}", this.name , this.position);
    }
}

// Department class
class Department
{
    public string departmentName;
    private List<Employee> employees;

    // Constructor 
    public Department(string departmentName)
    {
        this.departmentName = departmentName;
        this.employees = new List<Employee>();
    }

    // Method to add an employee
    public void AddEmployee(string name, string position)
    {
        employees.Add(new Employee(name, position));
    }

    // Method to display all employees
    public void DisplayDepartment()
    {
        Console.WriteLine("Department: {0}", departmentName);
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees in this department.");
            return;
        }
        foreach (var employee in employees)
        {
            employee.DisplayEmployee();
        }
    }
}

// Company class 
class Company
{
    public string companyName;
    private List<Department> departments;

    // Constructor 
    public Company(string companyName)
    {
        this.companyName = companyName;
        this.departments = new List<Department>();
    }

    // Method to add a department 
    public void AddDepartment(string departmentName)
    {
        departments.Add(new Department(departmentName));
    }

    // Method to get a department 
    public Department GetDepartment(string departmentName)
    {
        foreach (var dept in departments)
        {
            if (dept.departmentName == departmentName) 
                return dept;
        }   
        return null;
    }

    // Method to display all information
    public void DisplayCompany()
    {
        Console.WriteLine("Company: {0}" , companyName);
        if (departments.Count == 0)
        {
            Console.WriteLine("No departments in the company.");
            return;
        }
        foreach (var department in departments)
        {
            department.DisplayDepartment();
        }
    }
}

// Main class (composition)
class Program
{
    public static void Main()
    {
        // Creating company
        Company company = new Company("X-park Technologies");
        
        // Adding departments
        company.AddDepartment("Technical");
        company.AddDepartment("Human Resources");
        
        // Adding employees to departments
        Department technical = company.GetDepartment("Technical");
        technical.AddEmployee("Vansh Saxena", "Software Analyst");
        technical.AddEmployee("Krishana", "CTO");

        
        Department hr = company.GetDepartment("Human Resources");
        hr.AddEmployee("Rahul Kumar", "HR Manager");

        
        // Displaying Company info
        company.DisplayCompany();
    }
}
