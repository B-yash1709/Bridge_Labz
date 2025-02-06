using System;
using System.Collections.Generic;

// Faculty class
class Faculty
{
    public string name;
    public string designation;

    // Constructor
    public Faculty(string name, string designation)
    {
        this.name = name;
        this.designation = designation;
    }

    // Display Faculty details
    public void DisplayFaculty()
    {
        Console.WriteLine("Faculty: {0}, designation: {1}", this.name, this.designation);
    }
}

// Department class
class Department
{
    public string departmentName ;
    private List<Faculty> facultyMembers;

    // Constructor
    public Department(string departmentName)
    {
        this.departmentName = departmentName;
        this.facultyMembers = new List<Faculty>();
    }

    // Method to add a Faculty 
    public void AddFaculty(Faculty faculty)
    {
        facultyMembers.Add(faculty);
    }

    // Display department 
    public void DisplayDepartment()
    {
        Console.WriteLine("Department: {0}", this.departmentName);
        if (facultyMembers.Count == 0)
        {
            Console.WriteLine("No faculty members in this department");
            return;
        }
        foreach (var faculty in facultyMembers)
        {
            faculty.DisplayFaculty();
        }
    }
}

// University class
class University
{
    public string universityName;
    private List<Department> departments;

    // Constructor
    public University(string universityName)
    {
        this.universityName = universityName;
       this. departments = new List<Department>();
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

    // Display university details
    public void DisplayUniversity()
    {
        Console.WriteLine("University: {0}", this.universityName);
        if (departments.Count == 0)
        {
            Console.WriteLine("No departments in the university");
            return;
        }
        foreach (var department in departments)
        {
            department.DisplayDepartment();
        }
    }
}

// Main class
class Program
{
    static void Main()
    {
        // Creating university
        University university = new University("GLA University");
        
        // Adding departments
        university.AddDepartment("Computer Science");
        university.AddDepartment("Physics");
        
        // Creating faculty members
        Faculty prof1 = new Faculty("Rohit Dixit", "Professor");
        Faculty prof2 = new Faculty("Mohit Singh", "Assistant Professor");
        
        // Assigning faculty to departments
        Department cs = university.GetDepartment("Computer Science");
        cs.AddFaculty(prof1);
        
        Department physics = university.GetDepartment("Physics");
        physics.AddFaculty(prof2);
        
        // Displaying info
        university.DisplayUniversity();
    }
}
