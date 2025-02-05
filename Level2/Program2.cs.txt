using System;

public class Course
{
    public string CourseName;
    public int Duration; // in months
    public double Fee;

    // Static variable (shared by all courses)
    private static string InstituteName = "Tech Academy";

    // Constructor
    public Course(string name, int duration, double fee)
    {
        CourseName = name;
        Duration = duration;
        Fee = fee;
    }

    // Method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Institute: "+InstituteName+", Course: "+CourseName+", Duration: "+Duration+" months, Fee: "+Fee);
    }

    // Method to update institute name
    public static void UpdateInstituteName(string newName)
    {
        InstituteName = newName;
    }
}

class Program
{
    static void Main()
    {
        Course c1 = new Course("Web Development", 6, 800);
        Course c2 = new Course("Data Science", 9, 1200);

        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();

        // Update institute name
        Course.UpdateInstituteName("Code Academy");

        c1.DisplayCourseDetails();
        c2.DisplayCourseDetails();
    }
}
