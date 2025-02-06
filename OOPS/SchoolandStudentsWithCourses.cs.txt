using System;
using System.Collections.Generic;

// Course class
class Course
{
    public string courseName;
    private List<Student> students;

    // Constructor
    public Course(string courseName)
    {
        this.courseName = courseName;
        this.students = new List<Student>();
    }

    // Method to enroll a student
    public void EnrollStudent(Student student)
    {
        students.Add(student);
    }

    // Method to display enrolled students
    public void DisplayStudents()
    {
        Console.WriteLine("Course: {0}", courseName);
        if (students.Count == 0)
        {
            Console.WriteLine("No students enrolled in this course.");
            return;
        }
        foreach (var student in students)
        {
            Console.WriteLine("Student: {0}", student.studentName);
        }
    }
}

// Student class
class Student
{
    public string studentName;
    private List<Course> courses;

    // Constructor
    public Student(string studentName)
    {
        this.studentName = studentName;
        this.courses = new List<Course>();
    }

    // Method to enroll in a course
    public void EnrollInCourse(Course course)
    {
        courses.Add(course);
        course.EnrollStudent(this);
    }

    // Method to display enrolled courses
    public void DisplayCourses()
    {
        Console.WriteLine("Student: {0}", studentName);
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses enrolled.");
            return;
        }
        foreach (var course in courses)
        {
            Console.WriteLine("Course: {0}", course.courseName);
        }
    }
}

// School class
class School
{
    public string schoolName;
    private List<Student> students;

    // Constructor
    public School(string schoolName)
    {
        this.schoolName = schoolName;
        this.students = new List<Student>();
    }

    // Method to add a student
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    // Method to display all students
    public void DisplayStudents()
    {
        Console.WriteLine("School: {0}", schoolName);
        if (students.Count == 0)
        {
            Console.WriteLine("No students in the school.");
            return;
        }
        foreach (var student in students)
        {
            student.DisplayCourses();
        }
    }
}

// Main class
class Program
{
    static void Main()
    {
        // Creating school
        School school = new School("Kendriya Vidyalaya");
        
        // Creating students
        Student rohit = new Student("Rohti");
        Student mohit = new Student("Mohit");
        
        // Creating courses
        Course math = new Course("Mathematics");
        Course science = new Course("Science");
        
        // Enrolling students in courses
        rohit.EnrollInCourse(math);
        rohit.EnrollInCourse(science);
        mohit.EnrollInCourse(math);
        
        // Adding students to the school
        school.AddStudent(rohit);
        school.AddStudent(mohit);
        
        // Displaying school details
        school.DisplayStudents();
        
        // Displaying course details
        math.DisplayStudents();
        science.DisplayStudents();
    }
}
