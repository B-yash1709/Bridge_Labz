Best Programming Practice 
1. All values as variables including Fixed, User Inputs, and Results 
2. Avoid Hard Coding of variables wherever possible
3. Proper naming conventions for all variables 
4. Proper Program Name and Class Name
5. Follow proper indentation
6. Give comments for every step or logical block like a variable declaration or conditional and loop blocks
7. For every user input validate the user input, if invalid, state the error either exit the program or ask user to enter again
8. Use the Array Length property while using for loops.
1. Sample Program 1 - Create a program to find the sum of all the digits of a number given by a user using an array and display the sum.
Hint => 
1. Take the input for a number and validate, if failed state and exit the program
2. Find the count of digits in the number
3. Find the digits in the number and save them in an array
4. Find the sum of the digits of the number and display the sum


// Create SumOfDigit Class to compute the sum of all digits of a number using 
// an array
using System;
class SumOfDigits
{
    static void Main(string[] args)
    {
        // Take input for a number
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int number) || number < 0)
        {
            Console.WriteLine("Invalid Number.");
            return;
        }
        // Find the count of digits
        int count = input.Length;


        // Extract digits and store in an array
        int[] digits = new int[count];
        for (int i = 0; i < count; i++)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        // Compute the sum of the digits
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }
        // Display the sum
        Console.WriteLine($"Sum of Digits: {sum}");
    }
}

2. Sample Program 2 - Working with Multi-Dimensional Arrays. Write a C# program to create a 2 Dimensional (2D) array (matrix) of integers, initialize it with values, and print the sum of all elements in the matrix
Hint => 
1. Take the input for a number of rows and columns
2. Create a 2D array (matrix) of integers
3. Take the input for the elements of the matrix 
4. Calculate the sum of all elements in the matrix and display the sum
5. Also, Display the matrix 


// Program to create a 2D array, display the elements and calculate the sum of 
// the elements of the array
using System;
class TwoDArray
{
    static void Main(string[] args)
    {
        // Take input for the number of rows and columns
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        // Create the 2D array
        int[,] matrix = new int[rows, cols];


        // Input the elements of the matrix
        Console.WriteLine("Enter the elements of the matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        // Display the matrix and calculate the sum
        int sum = 0;
        Console.WriteLine("The elements of the matrix are:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
                sum += matrix[i, j];
            }
            Console.WriteLine();
        }
        // Display the sum of the elements
        Console.WriteLine($"The sum of all elements is: {sum}");
    }
}

________________
Level 2 Practice Programs
1. Create a program to find the bonus of 10 employees based on their years of service and the total bonus amount the company Zara has to pay, along with the old and new salary.
Hint => 
1. Zara decides to give a bonus of 5% to employees whose year of service is more than 5 years or 2% if less than 5 years
2. Define a double array to save salary and years of service for each of the 10 employees
3. Also define a double array to save the new salary and the bonus amount as well as variables to save the total bonus, total old salary, and new salary
4. Define a loop to take input from the user. If salary or year of service is an invalid number then ask the user to enter again. Note in this case you will have to decrement the index counter
5. Define another loop to calculate the bonus of 10 employees based on their years of service. Save the bonus in the array, compute the new salary, and save in the array. Also, the total bonus and total old and new salary can be calculated in the loop
6. Print the total bonus payout as well as the total old and new salary of all the employees
using System;

class ZaraBonusCalculator
{
   static void Main()
   {
       const int employeeCount = 10;
       double[] salaries = new double[employeeCount];
       int[] yearsOfService = new int[employeeCount];
       double[] bonuses = new double[employeeCount];
       double[] newSalaries = new double[employeeCount];

       double totalOldSalary = 0, totalBonus = 0, totalNewSalary = 0;

       for (int i = 0; i < employeeCount; i++)
       {
           Console.Write($"Enter salary for employee {i + 1}: ");
           salaries[i] = double.Parse(Console.ReadLine());

           Console.Write($"Enter years of service for employee {i + 1}: ");
           yearsOfService[i] = int.Parse(Console.ReadLine());

           if (yearsOfService[i] > 5)
               bonuses[i] = salaries[i] * 0.05; // 5% bonus
           else
               bonuses[i] = salaries[i] * 0.02; // 2% bonus

           newSalaries[i] = salaries[i] + bonuses[i];

           totalOldSalary += salaries[i];
           totalBonus += bonuses[i];
           totalNewSalary += newSalaries[i];
       }

       Console.WriteLine($"\nTotal Old Salary: {totalOldSalary:C}");
       Console.WriteLine($"Total Bonus Amount: {totalBonus:C}");
       Console.WriteLine($"Total New Salary: {totalNewSalary:C}");
   }
}
	



2. Create a program to find the youngest friends among 3 Amar, Akbar, and Anthony based on their ages and the tallest among the friends based on their heights
Hint => 
1. Take user input for age and height for the 3 friends and store it in two arrays each to store the values for age and height of the 3 friends
2. Loop through the array and find the youngest of the 3 friends and the tallest of the 3 friends
3. Finally display the youngest and tallest of the 3 friends
using System;

class YoungestAndTallest
{
   static void Main()
   {
       string[] names = { "Amar", "Akbar", "Anthony" };
       int[] ages = new int[3];
       double[] heights = new double[3];

       for (int i = 0; i < 3; i++)
       {
           Console.Write($"Enter the age of {names[i]}: ");
           ages[i] = int.Parse(Console.ReadLine());

           Console.Write($"Enter the height of {names[i]} (in cm): ");
           heights[i] = double.Parse(Console.ReadLine());
       }

       int youngestIndex = 0;
       double tallestIndex = 0;

       for (int i = 1; i < 3; i++)
       {
           if (ages[i] < ages[youngestIndex])
               youngestIndex = i;

           if (heights[i] > heights[tallestIndex])
               tallestIndex = i;
       }

       Console.WriteLine($"\nYoungest: {names[youngestIndex]} (Age: {ages[youngestIndex]})");
       Console.WriteLine($"Tallest: {names[tallestIndex]} (Height: {heights[tallestIndex]} cm)");
   }
}
	



3. Create a program to store the digits of the number in an array and find the largest and second largest element of the array.
Hint => 
1. Create a number variable and take user input. 
2. Define an array to store the digits. Set the size of the array to maxDigit variable initially set to 10
3. Create an integer variable index with the value 0 to reflect the array index.
4. Use a loop to iterate until the number is not equal to 0.
5. Remove the last digit from the number in each iteration and add it to the array.
6. Increment the index by 1 in each iteration and if the index count equals maxDigit then break out of the loop and the remaining digits are not added to the array
7. Define variable to store largest and second largest digit and initialize it to zero
8. Loop through the array and use conditional statements to find the largest and second largest number in the array
9. Finally display the largest  and second-largest number
using System;

class LargestAndSecondLargest
{
   static void Main()
   {
       Console.Write("Enter a number: ");
       int number = int.Parse(Console.ReadLine());
       int maxDigit = 10, index = 0;

       int[] digits = new int[maxDigit];

       while (number != 0)
       {
           if (index == maxDigit)
           {
               maxDigit += 10;
               Array.Resize(ref digits, maxDigit);
           }

           digits[index++] = number % 10;
           number /= 10;
       }

       int largest = 0, secondLargest = 0;

       foreach (int digit in digits)
       {
           if (digit > largest)
           {
               secondLargest = largest;
               largest = digit;
           }
           else if (digit > secondLargest)
           {
               secondLargest = digit;
           }
       }

       Console.WriteLine($"\nLargest Digit: {largest}");
       Console.WriteLine($"Second Largest Digit: {secondLargest}");
   }
}
	



4. Rework the program 2, especially the Hint: if index equals maxDigit, we break from the loop. Here we want to modify to increase the size of the array i,e maxDigit by 10 if the index is equal to maxDigit. This is done to consider all digits to find the largest and second-largest number 
Hint => 
1. In Hint f inside the loop if the index is equal to maxDigit, increase maxDigit and make digits array to store more elements. 
2. To do this, we need to create a new temp array of size maxDigit, copy from the current digits array the digits into the temp array, and assign the current digits array to the temp array
3. Now the digits array will be able to store all digits of the number in the array and then find the largest and second largest number
using System;

class LargestAndSecondLargest
{
   static void Main()
   {
       Console.Write("Enter a number: ");
       int number = int.Parse(Console.ReadLine());
       int maxDigit = 10, index = 0;

       int[] digits = new int[maxDigit];

       while (number != 0)
       {
           if (index == maxDigit)
           {
               maxDigit += 10;
               Array.Resize(ref digits, maxDigit);
           }

           digits[index++] = number % 10;
           number /= 10;
       }

       int largest = 0, secondLargest = 0;

       foreach (int digit in digits)
       {
           if (digit > largest)
           {
               secondLargest = largest;
               largest = digit;
           }
           else if (digit > secondLargest)
           {
               secondLargest = digit;
           }
       }

       Console.WriteLine($"\nLargest Digit: {largest}");
       Console.WriteLine($"Second Largest Digit: {secondLargest}");
   }
}
	



5. Create a program to take a number as input and reverse the number. To do this, store the digits of the number in an array and display the array in reverse order
Hint => 
1. Take user input for a number. 
2. Find the count of digits in the number. 
3. Find the digits in the number and save them in an array
4. Create an array to store the elements of the digits array in reverse order
5. Finally, display the elements of the array in reverse order  
using System;

class ReverseNumber
{
   static void Main()
   {
       Console.Write("Enter a number: ");
       int number = int.Parse(Console.ReadLine());

       int count = 0, temp = number;

       while (temp != 0)
       {
           count++;
           temp /= 10;
       }

       int[] digits = new int[count];
       for (int i = 0; i < count; i++)
       {
           digits[i] = number % 10;
           number /= 10;
       }

       Console.Write("Reversed Number: ");
       foreach (int digit in digits)
       {
           Console.Write(digit);
       }
       Console.WriteLine();
   }
}

	

6. An organization took up an exercise to find the Body Mass Index (BMI) of all the persons in the team. For this create a program to find the BMI and display the height, weight, BMI and status of each individual
Hint => 
1. Take input for a number of persons
2. Create arrays to store the weight, height, BMI, and weight status of the persons
3. Take input for the weight and height of the persons
4. Calculate the BMI of all the persons and store them in an array and also find the weight status of the persons
5. Display the height, weight, BMI, and weight status of each person
6. Use the table to determine the weight status of the person
using System;

class BMICalculator
{
   static void Main()
   {
       Console.Write("Enter the number of persons: ");
       int count = int.Parse(Console.ReadLine());

       double[] heights = new double[count];
       double[] weights = new double[count];
       double[] bmis = new double[count];
       string[] statuses = new string[count];

       for (int i = 0; i < count; i++)
       {
           Console.Write($"Enter height (in meters) for person {i + 1}: ");
           heights[i] = double.Parse(Console.ReadLine());

           Console.Write($"Enter weight (in kg) for person {i + 1}: ");
           weights[i] = double.Parse(Console.ReadLine());

           bmis[i] = weights[i] / (heights[i] * heights[i]);

           if (bmis[i] < 18.5)
               statuses[i] = "Underweight";
           else if (bmis[i] < 24.9)
               statuses[i] = "Normal";
           else if (bmis[i] < 29.9)
               statuses[i] = "Overweight";
           else
               statuses[i] = "Obese";
       }

       Console.WriteLine("\nPerson\tHeight\tWeight\tBMI\tStatus");
       for (int i = 0; i < count; i++)
       {
           Console.WriteLine($"{i + 1}\t{heights[i]:F2}\t{weights[i]:F2}\t{bmis[i]:F2}\t{statuses[i]}");
       }
   }
}
	



  
 
7. Rewrite the above program using multi-dimensional array to store height, weight, and BMI in 2D array for all the persons
Hint => 
1. Take input for a number of persons
2. Create a multi-dimensional array to store weight, height and BMI. Also create an to store the weight status of the persons
       double[][] personData = new double[number][3];
       String[] weightStatus = new String[number];
3. Take input for weight and height of the persons and for negative values, ask the user to enter positive values
4. Calculate BMI of all the persons and store them in the personData array and also find the weight status and put them in the weightStatus array
5. Display the height, weight, BMI and status of each person
using System;

class BMICalculator2D
{
   static void Main()
   {
       Console.Write("Enter the number of persons: ");
       int count = int.Parse(Console.ReadLine());

       double[,] personData = new double[count, 3]; // [height, weight, BMI]
       string[] statuses = new string[count];

       for (int i = 0; i < count; i++)
       {
           do
           {
               Console.Write($"Enter height (in meters) for person {i + 1}: ");
               personData[i, 0] = double.Parse(Console.ReadLine());
               if (personData[i, 0] <= 0) Console.WriteLine("Height must be positive!");
           } while (personData[i, 0] <= 0);

           do
           {
               Console.Write($"Enter weight (in kg) for person {i + 1}: ");
               personData[i, 1] = double.Parse(Console.ReadLine());
               if (personData[i, 1] <= 0) Console.WriteLine("Weight must be positive!");
           } while (personData[i, 1] <= 0);

           personData[i, 2] = personData[i, 1] / (personData[i, 0] * personData[i, 0]); // BMI Calculation

           statuses[i] = personData[i, 2] switch
           {
               < 18.5 => "Underweight",
               >= 18.5 and < 24.9 => "Normal",
               >= 25 and < 29.9 => "Overweight",
               _ => "Obese"
           };
       }

       Console.WriteLine("\nPerson\tHeight\tWeight\tBMI\t\tStatus");
       for (int i = 0; i < count; i++)
       {
           Console.WriteLine($"{i + 1}\t{personData[i, 0]:F2}\t{personData[i, 1]:F2}\t{personData[i, 2]:F2}\t{statuses[i]}");
       }
   }
}
	





8. Create a program to take input marks of students in 3 subjects physics, chemistry, and maths. Compute the percentage and then calculate the grade  as per the following guidelines 
  

Hint => 
1. Take input for the number of students
2. Create arrays to store marks, percentages, and grades of the students
3. Take input for marks of students in physics, chemistry, and maths. If the marks are negative, ask the user to enter positive values and decrement the index
4. Calculate the percentage and grade of the students based on the percentage
5. Display the marks, percentages, and grades of each student
using System;

class StudentGrades
{
   static void Main()
   {
       Console.Write("Enter the number of students: ");
       int studentCount = int.Parse(Console.ReadLine());

       double[,] marks = new double[studentCount, 3];
       double[] percentages = new double[studentCount];
       char[] grades = new char[studentCount];

       for (int i = 0; i < studentCount; i++)
       {
           Console.WriteLine($"\nEnter marks for Student {i + 1}:");

           for (int j = 0; j < 3; j++)
           {
               string subject = j switch
               {
                   0 => "Physics",
                   1 => "Chemistry",
                   2 => "Maths",
                   _ => "Unknown"
               };

               do
               {
                   Console.Write($"  {subject}: ");
                   marks[i, j] = double.Parse(Console.ReadLine());

                   if (marks[i, j] < 0 || marks[i, j] > 100)
                       Console.WriteLine("    Invalid marks! Please enter between 0 and 100.");
               } while (marks[i, j] < 0 || marks[i, j] > 100);
           }

           double totalMarks = marks[i, 0] + marks[i, 1] + marks[i, 2];
           percentages[i] = (totalMarks / 300) * 100;

           grades[i] = percentages[i] switch
           {
               >= 90 => 'A',
               >= 80 => 'B',
               >= 70 => 'C',
               >= 60 => 'D',
               _ => 'F'
           };
       }

       Console.WriteLine("\nStudent\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
       for (int i = 0; i < studentCount; i++)
       {
           Console.WriteLine($"{i + 1}\t{marks[i, 0]:F1}\t{marks[i, 1]:F1}\t{marks[i, 2]:F1}\t{percentages[i]:F1}%\t\t{grades[i]}");
       }
   }
}
	



9. Rewrite the above program to store the marks of the students in physics, chemistry, and maths in a 2D array and then compute the percentage and grade
Hint => 
1. All the steps are the same as the problem 8 except the marks are stored in a 2D array
2. Use the 2D array to calculate the percentages, and grades of the students
using System;

class StudentGrades2D
{
   static void Main()
   {
       Console.Write("Enter the number of students: ");
       int studentCount = int.Parse(Console.ReadLine());

       // 2D array to store marks for Physics, Chemistry, and Maths
       double[,] marks = new double[studentCount, 3];
       double[] percentages = new double[studentCount];
       char[] grades = new char[studentCount];

       // Input marks for each student
       for (int i = 0; i < studentCount; i++)
       {
           Console.WriteLine($"\nEnter marks for Student {i + 1}:");

           for (int j = 0; j < 3; j++)
           {
               string subject = j switch
               {
                   0 => "Physics",
                   1 => "Chemistry",
                   2 => "Maths",
                   _ => "Unknown"
               };

               do
               {
                   Console.Write($"  {subject}: ");
                   marks[i, j] = double.Parse(Console.ReadLine());

                   if (marks[i, j] < 0 || marks[i, j] > 100)
                       Console.WriteLine("    Invalid marks! Please enter a value between 0 and 100.");
               } while (marks[i, j] < 0 || marks[i, j] > 100);
           }
       }

       // Calculate percentage and grade for each student
       for (int i = 0; i < studentCount; i++)
       {
           double totalMarks = marks[i, 0] + marks[i, 1] + marks[i, 2];
           percentages[i] = (totalMarks / 300) * 100;

           grades[i] = percentages[i] switch
           {
               >= 90 => 'A',
               >= 80 => 'B',
               >= 70 => 'C',
               >= 60 => 'D',
               _ => 'F'
           };
       }

       // Display results
       Console.WriteLine("\nStudent\tPhysics\tChemistry\tMaths\tPercentage\tGrade");
       for (int i = 0; i < studentCount; i++)
       {
           Console.WriteLine($"{i + 1}\t{marks[i, 0]:F1}\t{marks[i, 1]:F1}\t\t{marks[i, 2]:F1}\t{percentages[i]:F1}%\t\t{grades[i]}");
       }
   }
}
	





10. Create a program to take a number as input find the frequency of each digit in the number using an array and display the frequency of each digit
Hint => 
1. Take the input for a number
2. Find the count of digits in the number
3. Find the digits in the number and save them in an array
4. Find the frequency of each digit in the number. For this define a frequency array of size 10, Loop through the digits array, and increase the frequency of each digit
5. Display the frequency of each digit in the number
using System;

class DigitFrequency
{
   static void Main()
   {
       Console.Write("Enter a number: ");
       int number = Math.Abs(int.Parse(Console.ReadLine())); // Use absolute value for negative numbers.

       int[] frequency = new int[10];

       while (number > 0)
       {
           int digit = number % 10;
           frequency[digit]++;
           number /= 10;
       }

       Console.WriteLine("\nDigit\tFrequency");
       for (int i = 0; i < 10; i++)
       {
           if (frequency[i] > 0)
               Console.WriteLine($"{i}\t{frequency[i]}");
       }
   }
}