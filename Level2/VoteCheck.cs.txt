using System;

public class StudentVoteChecker
{
    // Method to check if the student can vote
    public static bool CanStudentVote(int age)
    {
        if (age < 0)
        {
            // Negative age is invalid
            return false;
        }
        else if (age >= 18)
        {
            // Age 18 or above can vote
            return true;
        }
        else
        {
            // Below 18 cannot vote
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Array to hold ages of 10 students
        int[] studentAges = new int[10];

        Console.WriteLine("Enter the ages of 10 students:");

        // Loop to get user input for student ages
        for (int i = 0; i < studentAges.Length; i++)
        {
            Console.Write("Enter age of student " + (i + 1) + ": ");
            studentAges[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nVoting Eligibility Results:");

        // Loop to check voting eligibility for each student
        for (int i = 0; i < studentAges.Length; i++)
        {
            bool canVote = StudentVoteChecker.CanStudentVote(studentAges[i]);

            if (studentAges[i] < 0)
            {
                Console.WriteLine("Student " + (i + 1) + ": Invalid age (" + studentAges[i] + ").");
            }
            else if (canVote)
            {
                Console.WriteLine("Student " + (i + 1) + ": Age " + studentAges[i] + " - Eligible to vote.");
            }
            else
            {
                Console.WriteLine("Student " + (i + 1) + ": Age " + studentAges[i] + " - Not eligible to vote.");
            }
        }
    }
}
