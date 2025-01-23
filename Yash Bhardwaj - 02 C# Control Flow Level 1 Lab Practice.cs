Best Programming Practices
1. All values as variables including Fixed, User Inputs, and Results 
2. Proper naming conventions for all variables 
String name = "Eric"; 
double height = input.nextDouble();
double totalDistance = distanceFromToVia + distanceViaToFinalCity;
3. Proper Program Name and Class Name
4. Follow proper indentation
5. Give comments for every step or logical block like a variable declaration or conditional and loop blocks


Sample Program 1 - Create a program to check if 3 values are internal angles of a triangle.
IMP => Follow Good Programming Practice demonstrated below in all Practice Programs
Hint:
1. Get integer inputs for 3 variables named x, y, and z.
2. Calculate the sum of x, y, and z.
3. If the sum equals 180, print "The given angles are internal angles of a triangle."
4. Otherwise, print "They are not internal angles of a triangle."
________________




using System;
class TriangleChecker
{
    static void Main(string[] args)
    {
        // Prompt the user for input
        Console.WriteLine("Enter three angles of a triangle:");


        // Get 3 input values for angles
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int z = int.Parse(Console.ReadLine());


        // Calculate the sum of all angles
        int sumOfAngles = x + y + z;


        // Display the sum of angles
        Console.WriteLine($"The given angles {x}, {y}, {z} add to {sumOfAngles}");


        // Check if the sum equals 180 and display the result
        if (sumOfAngles == 180)
        {
            Console.WriteLine("The given angles are internal angles of a Triangle.");
        }
        else
        {
            Console.WriteLine("The given angles are not internal angles of a Triangle.");
        }
    }
}



________________


Sample Program 2 - Create a program to find the sum of all the digits of a number given by a user.
Hint => 
1. Get an integer input for the number variable.
1. Create an integer variable sum with an initial value of 0.
1. Create a while loop to access each digit of the number.
1. Inside the loop, add each digit of the number to the sum.
1. Finally, print the sum outside the loop




using System;


class SumOfDigits
{
    static void Main(string[] args)
    {
        // Prompt the user for input
        Console.WriteLine("Enter a number:");


        // Get input value for the number
        int origNumber = int.Parse(Console.ReadLine());


        // Define variables
        int number = origNumber;
        int sum = 0;


        // Loop to extract and sum each digit
        while (number != 0)
        {
            // Extract the last digit
            int digit = number % 10;


            // Add the digit to the sum
            sum += digit;


            // Remove the last digit from the number
            number /= 10;
        }


        // Display the sum of the digits
        Console.WriteLine($"The sum of the digits of {origNumber} is {sum}");
    }
}



Level 1 Practice Programs
1. Write a program to check if a number is divisible by 5
I/P => number
O/P => Is the number ___ divisible by 5? ___
using System;

class Divisibility
{
   static void Main(string[] args)
   {
       // Taking input from user for any number
       Console.WriteLine("Enter the number: ");
       int input = Convert.ToInt32(Console.ReadLine());

       // Checking the divisibility of the input number by 5
       if (input % 5 == 0)
       {
           Console.WriteLine("Is the number " + input + " divisible by 5? Yes");
       }
       else
       {
           Console.WriteLine("Is the number " + input + " divisible by 5? No");
       }
   }
}

	



2. Write a program to check if the first is the smallest of the 3 numbers.
I/P => number1, number2, number3
O/P => Is the first number the smallest? ____
using System;
class DivisibilityCheck
{
   static void Main(string[] args)
   {
       // Taking input from user for any number
       Console.WriteLine("Enter the first number: ");
       int num1 = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Enter the second number: ");
       int num2 = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Enter the third number: ");
       int num3 = Convert.ToInt32(Console.ReadLine());

       // Checking the divisibility of the input number by 5
       if (num1 < num2 && num1 < num3)
       {
           Console.WriteLine("Is the First number  smallest? Yes");
       }
       else
       {
           Console.WriteLine("Is the first number smallest? No");
       }
   }
}
	





3. Write a program to check if the first, second, or third number is the largest of the three.
I/P => number1, number2, number3
O/P => 
Is the first number the largest? ____
Is the second number the largest? ___
Is the third number the largest? ___
using System;

class LargestNumber
{
   static void Main(string[] args)
   {
       // Taking input from user for any number
       Console.WriteLine("Enter the first number: ");
       int num1 = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Enter the second number: ");
       int num2 = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Enter the third number: ");
       int num3 = Convert.ToInt32(Console.ReadLine());

       // Checking for the largest number
       string isFirstLargest =( num1 > num2 && num1 > num3) ? "Yes" : "No";
       string isSecondLargest =( num2 > num1 && num2 > num3) ? "Yes" : "No";
       string isThirdLargest =( num3 > num1&& num3 > num2) ? "Yes" : "No";
       // Display result
       Console.WriteLine($"Is the first number the largest? {isFirstLargest}");
       Console.WriteLine($"Is the second number the largest?{isSecondLargest}");
       Console.WriteLine($"Is the third number the largest?{isThirdLargest}");
   }
}

	



4. Write a program to check for the natural number and write the sum of n natural numbers 
Hint => 
1. A Natural Number is a positive integer (1,2,3, etc) sometimes with the inclusion of 0
2. A sum of n natural numbers is n * (n+1) / 2 
I/P => number
O/P => If the number is a positive integer then the output is
The sum of ___ natural numbers is ___
Otherwise 
The number ___ is not a natural number
using System;
class NumberSum
{
   static void Main(string[] args)
   {
       // Taking input from user for any number
       Console.WriteLine("Enter the number (greater than 0): ");
       int n = Convert.ToInt32(Console.ReadLine());
       // Calculating the sum of n numbers
       if (n>0){
           int sum = n * (n + 1)/2;
           Console.WriteLine("The sum of " +n+" natural number is "+sum );
       }
       else{
           Console.WriteLine(" The number "+n+" is not a natural number");
       }
   }
}
	



5. Write a program to check whether a person can vote, depending on whether his/her age is greater than or equal to 18.
Hint => 
1. Get integer input from the user and store it in the age variable.
2. If the person is 18 or older, print "The person can vote." Otherwise, print "The person Ecannot vote." 
I/P => age
O/P => If the person's age is greater or equal to 18 then the output is 
The person's age is ___ and can vote.
Otherwise 
The person's age is ___ and cannot vote.
using System;
class VotingEligibility
{
   static void Main(string[] args)
   {
       // Taking input of user's age
       Console.WriteLine("Enter your Age: ");
       int Age = Convert.ToInt32(Console.ReadLine());
       // Checking the eligibility of user to vote
       if (Age>=18){
           Console.WriteLine("The person's age is "+Age+ " and can vote." );
       }
       else{
           Console.WriteLine(" The person's age is "+Age+" and cannot vote.");
       }
   }
}

	



________________


6. Write a program to check whether a number is positive, negative, or zero.
Hint => 
1. Get integer input from the user and store it in the number variable.
2. If the number is positive, print positive.
3. If the number is negative, print negative.
4. If the number is zero, print zero. 
using System;
class NumberChecking
{
   static void Main(string[] args)
   {
       // Taking input of user for any number
       Console.WriteLine("Enter the number: ");
       int num = Convert.ToInt32(Console.ReadLine());
       // Checking the number
       if (num>0){
           Console.WriteLine(" positive" );
       }
       else if (num==0){
           Console.WriteLine(" Zero");
       }
       else {
           Console.WriteLine("Negative");
       }
   }
}
	

7. Write a program SpringSeason that takes two int values month and day from the command line and prints “Its a Spring Season” otherwise prints “Not a Spring Season”. 
Hint => 
1. Spring Season is from March 20 to June 20
using System;

class SpringSeason
{
   static void Main(string[] args)
   {
       // Check if two arguments (month and day) are provided
       if (args.Length < 2)
       {
           Console.WriteLine("Please provide both month and day as command-line arguments.");
           return;
       }

       // Parse the command-line arguments
       int month = Convert.ToInt32(args[0]);
       int day = Convert.ToInt32(args[1]);

       // Check if the date falls in the spring season (March 20 to June 20)
       bool isSpring = (month == 3 && day >= 20 && day <= 31) || // March 20-31
                       (month == 4 && day >= 1 && day <= 30) ||   // April 1-30
                       (month == 5 && day >= 1 && day <= 31) ||   // May 1-31
                       (month == 6 && day >= 1 && day <= 20);     // June 1-20

       // Print the result
       if (isSpring)
       {
           Console.WriteLine("It's a Spring Season");
       }
       else
       {
           Console.WriteLine("Not a Spring Season");
       }
   }
}
	



8. Write a program to count down the number from the user input value to 1 using a while loop for a rocket launch
Hint => 
1. Create a variable counter to take user inputted value for the countdown.
2. Use the while loop to check if the counter is 1
3. Inside a while loop, print the value of the counter and decrement the counter.
using System;

class RocketLaunch
{
   static void Main(string[] args)
   {
       // taking input from user to countdown
      Console.WriteLine("Enter the number to countdown: ");
       int countDown = Convert.ToInt32(Console.ReadLine());
       while(countDown != 0){
           Console.WriteLine(countDown);
           countDown--;
       }
       Console.WriteLine("Rocket Launched!!!");
   }
}
	





9. Rewrite program 8 to do the countdown using the for-loop
using System;

class RocketLaunch
{
   static void Main(string[] args)
   {
       // taking input from user to countdown
      Console.WriteLine("Enter the number to countdown: ");
       int n = Convert.ToInt32(Console.ReadLine());
       for (int i = n; i>=0; i--){
       Console.WriteLine(n);
       n--;
       }
       Console.WriteLine("Rocket Launched!!!");
   }
}
	

10. Write a program to find the sum of numbers until the user enters 0
Hint => 
1. Create a variable total of type double initialize to 0.0. Also, create a variable to store the double value the user enters
2. Use the while loop to check if the user entered is 0
3. If the user entered value is not 0 then inside the while block add user entered value to the total and ask the user to input again
4. The loop will continue till the user enters zero and outside the loop display the total value
using System;
class AdditionTillZero
{
   static void Main(string[] args)
   {
       // Initiating userInput by 1 to satisfy the while condition for the first time to get user input. 
   double userInput =1, total = 0.0;
   while(userInput != 0){
       Console.WriteLine("Enter numbers: ");
       userInput = Convert.ToInt32(Console.ReadLine());
       total = total+userInput;
      }
       Console.WriteLine(total);
   }
}
	

11. Rewrite the program 10 to find the sum until the user enters 0 or a negative number using while loop and break statement
Hint => 
1. Use infinite while loop as in while (true)
2. Take the user entry and check if the user entered 0 or a negative number to break the loop using break;
using System;
class AdditionTillZeroOrNegative
{
   static void Main(string[] args)
   {
       // Initiating userInput by 1 to satisfy the while condition for the first time to get user input. 
   double userInput =1, total = 0.0;
   while(userInput > 0){
       Console.WriteLine("Enter numbers: ");
       userInput = Convert.ToInt32(Console.ReadLine());
       if(userInput<0){
           break;
           }
       total = total+userInput;
   }
       Console.WriteLine(total);
   }
}
	

12. Write a program to find the sum of n natural numbers using while loop compare the result with the formulae n*(n+1)/2 and show the result from both computations was correct. 


Hint => 
1. Take the user input number and check whether it's a Natural number
2. If it's a natural number Compute using formulae as well as compute using while loop
3. Compare the two results and print the result
using System;
class ComputationVerification{
   static void Main(string[] args){
       //  Taking input from user for Number
       Console.WriteLine("Enter the number: ");
       double n = Convert.ToDouble(Console.ReadLine());
       double  formulae=0;
       double sum = 0;
       
       if (n>0){
           formulae = n*(n+1)/2;
            while(n>0){
               sum = sum + n;
               n--;
           }
            Console.WriteLine("The result from using loop is "+sum);
            Console.WriteLine("The result from formulae is "+formulae);
           
            if (formulae == sum){
                Console.WriteLine("Both computations was correct");
               }
            else{
                 Console.WriteLine("Discrepancy in the answers");
             }
       
       }
       else{
           Console.WriteLine("Invalid input, Enter the Natural number.");
       }
   }
}
	

13. Rewrite the program number 12 with the for loop instead of a while loop to find the sum of n Natural Numbers. 
Hint => 
1. Take the user input number and check whether it's a Natural number
2. If it's a natural number Compute using formulae as well as compute using for loop
3. Compare the two results and print the result
using System;
class ComputationVerification{
   static void Main(string[] args){
       //  Taking input from user for Number
       Console.WriteLine("Enter the number: ");
       double n = Convert.ToDouble(Console.ReadLine());
       double  formulae=0;
       double sum = 0;
       
       if (n>0){
           formulae = n*(n+1)/2;
           for(int i=0; i<=n; i++){
               sum = sum + i;
           }
            Console.WriteLine("The result from using loop is "+sum);
            Console.WriteLine("The result from formulae is "+formulae);
           
            if (formulae == sum){
                Console.WriteLine("Both computations was correct");
               }
            else{
                 Console.WriteLine("Discrepancy in the answers");
             }
       
       }
       else{
           Console.WriteLine("Invalid input, Enter the Natural number.");
       }
   }
}
	

14. Write a Program to find the factorial of an integer entered by the user.
Hint => 
1. For example, the factorial of 4 is 1 * 2 * 3 * 4 which is 24.
2. Take an integer input from the user and assign it to the variable. Check the user has entered a positive integer.
3. Using a while loop, compute the factorial.
4. Print the factorial at the end.
using System;
class ComputationVerification{
   static void Main(string[] args){
       //  Taking input from user for Number
       Console.WriteLine("Enter the number: ");
       double n = Convert.ToDouble(Console.ReadLine());
       double factorial = 1;
       if (n>0){
           while(n >0){
               factorial = factorial * n;
               n--;
           }
           
            Console.WriteLine("The result from factorial is "+factorial);
            
           }
            else{
           Console.WriteLine("Invalid input, Enter the Natural number.");
       }
       
    }
}
	

15. Rewrite program 14 using for loop
Hint => 
1. Take the integer input, check for natural number and determine the factorial using for loop and finally print the result
using System;
class ComputationVerification{
   static void Main(string[] args){
       //  Taking input from user for Number
       Console.WriteLine("Enter the number: ");
       double n = Convert.ToDouble(Console.ReadLine());
       double factorial = 1;
       if (n>0){
           for(int i=1; i<=n; i++){
           factorial= factorial * i;
           }
           Console.WriteLine("The result from factorial is "+factorial);
          }
      else
      {
           Console.WriteLine("Invalid input, Enter the Natural number.");
       }
       
    }
}
	. 
16. Create a program to print odd and even numbers between 1 to the number entered by the user.
Hint => 
1. Get an integer input from the user, assign to a variable number and check for Natural Number
2. Using a for loop, iterate from 1 to the number
3. In each iteration of the loop, print the number is odd or even number
using System;
class EvenOdd{
   static void Main(string[] args){
       //  Taking input from user for Number
       Console.WriteLine("Enter the number: ");
       double n = Convert.ToDouble(Console.ReadLine());
       if (n>0) {
           for(int i=0; i<=n; i++){
               if(i%2==0){
               Console.WriteLine("Even numbers is: "+ (i));
               }
               else{
               Console.WriteLine("Odd number is: "+(i));
               }  
            }
       }
           else
                {
          Console.WriteLine("Invalid input, Enter the Natural number.");
            }
        }
}
	



17. Create a program to find the bonus of employees based on their years of service.
Hint => 
1. Zara decided to give a bonus of 5% to employees whose year of service is more than 5 years.
2. Take salary and year of service in the year as input.
3. Print the bonus amount.
using System;
class BonusAmount{
   static void Main(string[] args){
       //  Taking input from user for Salary and year of service
       Console.WriteLine("Enter your Salary: ");
       double salary = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter your Experience (in years): ");
       double experience = Convert.ToDouble(Console.ReadLine());
       // Calculating the bonus as per the experience
       
       if(experience>=5){
           double bonus = 0.05 * salary;
           Console.WriteLine("The bonus amount will be"+ bonus);
       }
       else{
           Console.WriteLine("Sorry, Not eligible for bonus");
       }
   }
}
	

18. Create a program to find the multiplication table of a number entered by the user from 6 to 9.
Hint => 
1. Take integer input and store it in the variable number
2. Using a for loop, find the multiplication table of number from 6 to 9 and print it in the format number * i = ___
using System;
class MultiplicationTable{
   static void Main(string[] args){
       //  Taking input from user for number
       Console.WriteLine("Enter any number: ");
       double n = Convert.ToDouble(Console.ReadLine());
        
        // Calculating the table from 6 to 9
       for(int i=6; i<=9; i++){
           Console.WriteLine(n+"*"+i+"="+n*i);
       }
   }
}