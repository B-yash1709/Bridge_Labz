using System;

class Student
{
    // Static variable shared by all students
    public static string UniversityName = "GLA University";
    private static int totalStudents = 0; 

    // Readonly variable for unique Roll Number
    public readonly int RollNumber;

    // Instance variables
    public string Name;
    public char Grade;

    // Constructor 
    public Student(int rollNumber, string name, char grade)
    {
        this.RollNumber = rollNumber;
        this.Name = name;
        this.Grade = grade;
        totalStudents++;
    }

    // Method to display student details
    public void DisplayStudentDetails()
    {
        Console.WriteLine("Roll Number: "+RollNumber+", Name: "+Name+", Grade: "+Grade+", University: "+UniversityName);
    }

    // Static method to display total students enrolled
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: "+totalStudents);
    }
}

class Program
{
    static void Main()
    {
        // Creating student objects
        Student s1 = new Student(1001, "Aman", 'A');
        Student s2 = new Student(1002, "Rahul", 'B');

        // Checking if student1 is an instance of Student class using 'is' operator
        if (s1 is Student)
        {
            s1.DisplayStudentDetails();
        }

        if (s2 is Student)
        {
            s2.DisplayStudentDetails();
        }

        // Display total number of students
        Student.DisplayTotalStudents();
    }
}
