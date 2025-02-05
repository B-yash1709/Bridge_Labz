using System;

// Base Class: Student
public class Student
{
    public int RollNumber;   // Public
    protected string Name;   // Protected
    private double CGPA;     // Private

    // Constructor
    public Student(int roll, string name, double cgpa)
    {
        RollNumber = roll;
        Name = name;
        CGPA = cgpa;
    }

    // Method to get CGPA
    public double GetCGPA()
    {
        return CGPA;
    }

    // Method to set CGPA
    public void SetCGPA(double cgpa)
    {
        if (cgpa >= 0 && cgpa <= 10)
        {
            CGPA = cgpa;
        }
    }

    // Display student details
    public void Display()
    {
        Console.WriteLine("Roll No: "+RollNumber+", Name: "+Name+", CGPA: "+CGPA);
    }
}

// Derived Class: PostgraduateStudent
public class PostgraduateStudent : Student
{
    public string ResearchTopic;

    // Constructor
    public PostgraduateStudent(int roll, string name, double cgpa, string topic)
        : base(roll, name, cgpa)
    {
        ResearchTopic = topic;
    }

    // Display postgraduate details
    public void DisplayPG()
    {
        Console.WriteLine("Roll No: "+RollNumber+", Name: "+Name+", Research: "+ResearchTopic+", CGPA: "+GetCGPA());
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Student s1 = new Student(101, "Aman", 9.2);
        s1.Display();

        PostgraduateStudent pg1 = new PostgraduateStudent(201, "Rahul", 8.8, "AI Research");
        pg1.DisplayPG();
    }
}
