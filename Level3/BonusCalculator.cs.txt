using System;

public class Solution {
    // Generates random salaries (5-digit) and years of service for employees
    public static double[,] GenerateEmployeeData(int numEmployees) {
        double[,] employeeData = new double[numEmployees, 2];
        Random random = new Random();

        for (int i = 0; i < numEmployees; i++) {
            // Generate a random 5-digit salary
            employeeData[i, 0] = random.Next(10000, 100000);

            // Generate random years of service
            employeeData[i, 1] = random.Next(1, 11);
        }

        return employeeData;
    }

    // Calculates the bonus and new salary for each employee
    public static double[,] CalculateBonusAndNewSalary(double[,] employeeData, int numEmployees) {
        double[,] updatedData = new double[numEmployees, 2];

        for (int i = 0; i < numEmployees; i++) {
            // Extract salary and years of service
			
            double salary = employeeData[i, 0];
            double yearsOfService = employeeData[i, 1];
            double bonus;

            // Calculate bonus based on years of service
            if (yearsOfService > 5) {
                bonus = salary * 0.05;
            }
            else {
                bonus = salary * 0.02; 
            }

            // Calculate new salary
            double newSalary = salary + bonus;

            // Store bonus and new salary in the array
            updatedData[i, 0] = bonus;
            updatedData[i, 1] = newSalary;
        }

        return updatedData;
    }

    // Displays the employee details along with total salary and bonus amounts
    public static void DisplayResults(double[,] employeeData, double[,] updatedData, int numEmployees)
{
    double totalOldSalary = 0, totalBonus = 0, totalNewSalary = 0;

    // Print table header
    Console.WriteLine("Employee\tSalary\t\tYears\t\tBonus\t\tNew Salary");

    for (int i = 0; i < numEmployees; i++){
        // Extract details
        double salary = employeeData[i, 0];
        double yearsOfService = employeeData[i, 1];
        double bonus = updatedData[i, 0];
        double newSalary = updatedData[i, 1];

        // Print details in a single line
        Console.WriteLine("{0}\t\t{1:F2}\t{2}\t\t{3:F2}\t\t{4:F2}", i + 1, salary, yearsOfService, bonus, newSalary);

        // Update totals
        totalOldSalary += salary;
        totalBonus += bonus;
        totalNewSalary += newSalary;
    }

    // Print totals
    Console.WriteLine("Total\t\t{0:F2}\t\t\t{1:F2}\t{2:F2}", totalOldSalary, totalBonus, totalNewSalary);
}

	
	public static void Main() {
        // Number of employees
        int numEmployees = 10;

        // Generate random salary and years of service for employees
        double[,] employeeData = GenerateEmployeeData(numEmployees);

        // Calculate bonuses and new salaries
        double[,] updatedData = CalculateBonusAndNewSalary(employeeData, numEmployees);

        // Display results and totals
        DisplayResults(employeeData, updatedData, numEmployees);
    }
}
