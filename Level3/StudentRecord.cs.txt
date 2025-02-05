using System;

class Solution {
    // Method to generate random marks for Physics, Chemistry, and Mathematics for each student
    public static int[,] GenerateMarks(int numStudents) {
        int[,] marks = new int[numStudents, 3];
        Random random = new Random();

        for (int i = 0; i < numStudents; i++) {
            // Generate random marks for Physics, Chemistry, and Mathematics
            marks[i, 0] = random.Next(50, 101);  
            marks[i, 1] = random.Next(50, 101);  
            marks[i, 2] = random.Next(50, 101);  
        }
        return marks;
    }

    // Method to calculate the total, average, and percentage for each student
    public static double[,] CalculateResults(int[,] marks, int numStudents) {
        double[,] results = new double[numStudents, 3];  

        for (int i = 0; i < numStudents; i++) {
            int totalMarks = marks[i, 0] + marks[i, 1] + marks[i, 2]; 
            double averageMarks = totalMarks / 3.0;  
            double percentage = Math.Round((totalMarks / 300.0) * 100, 2); 

            results[i, 0] = totalMarks;
            results[i, 1] = Math.Round(averageMarks, 2);  
            results[i, 2] = percentage;
        }

        return results;
    }

    // Method to display the scorecard in a tabular format
    public static void DisplayResults(int[,] marks, double[,] results, int numStudents) {
        // Display table headers
        Console.WriteLine("Student\tPhysics\tChemistry\tMathematics\tTotal\t\tAverage\t\tPercentage");

        for (int i = 0; i < numStudents; i++) {
            // Extract individual student details
            int physics = marks[i, 0];
            int chemistry = marks[i, 1];
            int mathematics = marks[i, 2];
            double total = results[i, 0];
            double average = results[i, 1];
            double percentage = results[i, 2];

            // Display the student results in a tabular format
            Console.WriteLine($" {i + 1} \t{physics}\t{chemistry}\t\t{mathematics}\t\t{total}\t\t{average}\t\t{percentage}%");
        }
    }
	
	public static void Main() {
        // Prompt for the number of students
        Console.WriteLine("Enter the number of students: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());

        // Generate random marks for Physics, Chemistry, and Mathematics
        int[,] studentMarks = GenerateMarks(numStudents);

        // Calculate total, average, and percentage for each student
        double[,] studentResults = CalculateResults(studentMarks, numStudents);

        // Display the scorecard in tabular format
        DisplayResults(studentMarks, studentResults, numStudents);
    }

}
