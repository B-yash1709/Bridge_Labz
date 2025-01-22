﻿Best Programming Practices
1. Use variables for all values, including inputs, fixed values, and results.
2. Avoid hardcoding values.
3. Use meaningful variable names.
4. Properly name programs and classes.
* String name = "Eric"; 
* double height = Convert.ToDouble(Console.ReadLine());
* double totalDistance = distanceFromToVia + distanceViaToFinalCity;
5. Maintain proper indentation.
Problem Statement: Write a program to display Sam with Roll Number 1, Percent Marks 99.99, and the result ‘P’ indicating Pass (‘P’) or Fail (‘F’).

Program Requirements:
* Use variables for all values (name, roll number, percent marks, result).
* Avoid hardcoding values.
* Follow proper naming conventions.
Code Format (C#):
// Creating a class with the name DisplayResult indicating the purpose is to display 
// result. Notice that the class name is a Noun.
using System;


class DisplayResult {
    public static void Main(string[] args) {
     
        // Create a string variable 'name' and assign value "Sam"
        string name = "Sam";
     
        // Create an int variable 'rollNumber' and assign value 1
        int rollNumber = 1;
     
        // Create a double variable 'percentMarks' and assign value 99.99
        double percentMarks = 99.99;
     
        // Create a char variable 'result' and assign value 'P' for pass
        char result = 'P';
        
        // Display the result
        Console.WriteLine($"Displaying Result:\n{name} with Roll Number {rollNumber} has Scored {percentMarks}% Marks and Result is {result}");
    }
}
________________


Sample Program 2 - Eric Travels:
Problem Statement: Eric travels from Chennai to Bangalore via Vellore. The distance from Chennai to Vellore is 156.6 km and the time taken is 4 hours 4 minutes. The distance from Vellore to Bangalore is 211.8 km and the time taken is 4 hours 25 minutes. Compute the total distance and total time from Chennai to Bangalore.
Program Requirements:
* Use variables to hold city names and travel data.
* Calculate and display the total distance and total time.
* Proper indentation and naming conventions.
Code Format (C#):


using System;


class TravelComputation {
   public static void Main(string[] args) {


      // Create a variable 'name' to indicate the person traveling
      string name = "Eric";
      
      // Create variables 'fromCity', 'viaCity', and 'toCity' for the cities
      string fromCity = "Chennai", viaCity = "Vellore", toCity = "Bangalore";


      // Create variables for distances and times
      double distanceFromToVia = 156.6;
      int timeFromToVia = 4 * 60 + 4; // Time in minutes
      double distanceViaToFinalCity = 211.8;
      int timeViaToFinalCity = 4 * 60 + 25; // Time in minutes


      // Compute the total distance and total time
      double totalDistance = distanceFromToVia + distanceViaToFinalCity;
      int totalTime = timeFromToVia + timeViaToFinalCity;


      // Print the travel details
      Console.WriteLine($"The Total Distance travelled by {name} from {fromCity} to {toCity} via {viaCity} is {totalDistance} km and the Total Time taken is {totalTime} minutes");
   }
}
________________




Level 2 Practice Programs
________________


1. Write a program to take 2 numbers and print their quotient and remainder
Hint: Use division operator (/) for quotient and modulus operator (%) for remainder
I/P => number1, number2
O/P => The Quotient is ___ and Remainder is ___ of two numbers ___ and ___
using System;

class Operator{
 static void Main (string[] args){
   Console.Write("Enter the first no. ");
//        Taking input from the user for first no.
   double firstNumber = Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the second no. ");
// Taking input from the userCl for the second no.
        double secondNumber = Convert.ToDouble(Console.ReadLine());
   double Quotient = firstNumber / secondNumber;
        double Remainder = firstNumber % secondNumber;
        Console.WriteLine( "The Quotient is " + Quotient + " and Remainder is " + Remainder + " of two numbers " + firstNumber + " and "  + secondNumber);
   } 
}        
	

________________


2. Write an IntOperation program by taking a, b, and c as input values and print the following integer operations: a + b * c, a * b + c, c + a / b, and a % b + c. Please also understand the precedence of the operators.
Hint:
Create variables a, b, and c of int data type.
Take user input for a, b, and c.
Compute the 3 integer operations and assign results to variables.
Finally, print the results and understand operator precedence.
I/P => a, b, c
O/P => The results of Int Operations are ___, ___, and ___
using System;
class IntOperation{
static void Main(string[] args ){
   // Taking input from the user for a, b and c.
   Console.Write("Enter the number a: ");
   int a= Convert.ToInt32(Console.ReadLine());
   Console.Write("Enter the number b: ");
   int b= Convert.ToInt32(Console.ReadLine());
   Console.Write("Enter the number c: ");
   int c= Convert.ToInt32(Console.ReadLine());
   // Formula to calculate Operations
   int operation_1 = a + b * c;
   int operation_2 = a * b + c;
   int operation_3 = c + a / b;
   int operation_4 = a % b + c;
   Console.WriteLine("The results of Int Operations are " +operation_1+", "+operation_2 +", " +operation_3+ ", and " +operation_4); 

   }
}
	



________________


3. Similarly, write the DoubleOpt program by taking double values and doing the same operations.
I/P => a, b, c
O/P => The results of Double Operations are ___, ___, and ___
________________
using System;
class DoubleOpt{
static void Main(string[] args ){
   // Taking input from the user for a, b and c.
   Console.Write("Enter the number a: ");
   double a= Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the number b: ");
   double b= Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the number c: ");
   double c= Convert.ToDouble(Console.ReadLine());
   // Formula to calculate Operations
   double operation_1 = a + b * c;
   double operation_2 = a * b + c;
   double operation_3 = c + a / b;
   double operation_4 = a % b + c;
   Console.WriteLine("The results of Double Operations are " +operation_1+", "+operation_2 +", " +operation_3+ ", and " +operation_4); 

   }
}
	



________________


4. Write a TemperatureConversion program, given the temperature in Celsius as input that outputs the temperature in Fahrenheit
Hint:
Create a celsius variable and take the temperature as user input.
Use the formula: Celsius to Fahrenheit: (°C × 9/5) + 32 = °F
Assign the result to fahrenheitResult and print the result.
I/P => celsius
O/P => The ___ Celsius is ___ Fahrenheit
using System;
class TemperatureConversion{
static void Main(string[] args ){
   // Taking input from the user for Temperature in Celcius.
   Console.Write("Enter the Temperature in Celsius: ");
   double celcius= Convert.ToDouble(Console.ReadLine());
   // Formula to calculate Temperature in Fahrenheit
   double fahrenheit =(celcius * 9/5) + 32;
   
   Console.WriteLine("The "+celcius+ " Celsius is " +fahrenheit " Fahrenheit"
); 

   }
}

	

________________


5. Write a TemperatureConversion program, given the temperature in Fahrenheit as input that outputs the temperature in Celsius
Hint:
Create a fahrenheit variable and take the user's input.
Use the formula: Fahrenheit to Celsius: (°F − 32) x 5/9 = °C
Assign the result to celsiusResult and print the result.
I/P => fahrenheit
O/P => The ___ Fahrenheit is ___ Celsius
using System;
class TemperatureConversion{
static void Main(string[] args ){
   // Taking input from the user for Temperature in Fahrenheit.
   Console.Write("Enter the Temperature in Fahrenheit: ");
   double fahrenheit= Convert.ToDouble(Console.ReadLine());
   // Formula to calculate Temperature in celcius
   double celcius =(fahrenheit - 32) *5/9;
   
   Console.WriteLine("The "+celcius+ " Celsius is " +fahrenheit " Fahrenheit"); 
   }
}
	

________________


6. Create a program to find the total income of a person by taking salary and bonus from the user
Hint:
Create a variable named salary and take user input.
Create another variable bonus and take user input.
Compute income by adding salary and bonus and print the result.
I/P => salary, bonus
O/P => The salary is INR ___ and bonus is INR ___. Hence Total Income is INR ___
using System;
class TotalIncome{
static void Main(string[] args ){
   // Taking input from the user for salary
   Console.Write("Enter the Salary: ");
   double salary= Convert.ToDouble(Console.ReadLine());
   // Taking input from the user for bonus
       Console.Write("Enter the Bonus: ");
   double bonus= Convert.ToDouble(Console.ReadLine());
   // Formula to calculate Total Salary
   double totalIncome = salary + bonus;
   
   Console.WriteLine("The salary in INR "+salary+ " and bonus is INR " +bonus+ ". Hence Total Income is "+totalIncome);
   }
}
	

________________


7. Create a program to swap two numbers
Hint:
Create a variable number1 and take user input.
Create a variable number2 and take user input.
Swap number1 and number2 and print the swapped output.
I/P => number1, number2
O/P => The swapped numbers are ___ and ___
using System;
class TotalIncome{
static void Main(string[] args ){
   // Taking input from the user for Number 1.
   Console.Write("Enter the number 1: ");
   double number_1= Convert.ToDouble(Console.ReadLine());
   // Taking input from the user for Number 2.
       Console.Write("Enter the number 2: ");
   double number_2= Convert.ToDouble(Console.ReadLine());
   // Formula to swap two numbers
   double temp = number_1;
   number_1 = number_2;
   number_2 = temp;
   
   
   Console.WriteLine("The swapped numbers are "+number_1+ " and " +number_2 );
   }
}
	

________________


8. Rewrite the Sample Program 2 with user inputs
Hint:
Create variables and take user inputs for name, fromCity, viaCity, toCity.
Create variables and take user inputs for distances: fromToVia and viaToFinalCity in miles.
Create variables and take the time taken for the journey.
Finally, print the results and try to understand operator precedence.
I/P => name, fromCity, viaCity, toCity, fromToVia, viaToFinalCity, timeTaken
O/P => The results of the trip are: ___, ___, and ___
using System;
class TravelDetails{
static void Main(string[] args ){
   // Taking input from the user details.
   Console.Write("Enter your name: ");
   string name = Console.ReadLine();
   Console.Write("Enter the starting city : ");
   string fromCity = Console.ReadLine();
   Console.Write("Enter the city you travel via: ");
   string viaCity = Console.ReadLine();
   Console.Write("Enter the final destination city: ");
   string finalCity = Console.ReadLine();
   // Taking input from the user for Distance and Time.
   Console.Write("Enter the distance from starting city to via city (in km): ");
   double fromToVia =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the distance from via city to final city (in km): ");
   double viaToFinalCity =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the time from starting city to via city (in hours): ");
   double timeFromToVia =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the time from via city to final city (in hours): ");
   double timeViaToFinalCity =  Convert.ToDouble(Console.ReadLine());
   
   // Formula to calculate total distance and time
   double totalDistance = fromToVia + viaToFinalCity;
   double totalTime = timeFromToVia + timeViaToFinalCity;
   
   
   
   Console.WriteLine("The results of the trip are; "+name+ " traveled from " +fromCity+" via "+viaCity+ " to " +finalCity+". The total distance traveled is "+totalDistance+"km. The total time taken for the journey is " +totalTime+ "hrs" );
   }
}
	

________________


9. An athlete runs in a triangular park with sides provided as input by the user in meters. If the athlete wants to complete a 5 km run, then how many rounds must the athlete complete?
Hint:
The perimeter of a triangle is the addition of all sides.
Rounds = distance / perimeter
I/P => side1, side2, side3
O/P => The total number of rounds the athlete will run is ___ to complete 5 km
using System;
class TotalNoOfRounds{
static void Main(string[] args ){
   // Taking input from the user for the distance of sides of triangular park.
   Console.Write("Enter the length of side 1 (in meters): ");
   double side_1 =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the distance of side 2 (in meters): ");
   double side_2 =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the distance of side 3 (in meters): ");
   double side_3 =  Convert.ToDouble(Console.ReadLine());

  // Formula to calculate perimeter and no of rounds 
   double perimeterOfPark  = side_1 + side_2 + side_3;
   double noOfRounds = 5/perimeterOfPark * 1000;
   Console.WriteLine("The total number of rounds the athlete will run is "+noOfRounds+" to complete 5 km" );
   }
}
	

________________


10. Create a program to divide N number of chocolates among M children.
Hint:
Get an integer value from the user for numberOfChocolates and numberOfChildren.
Find the number of chocolates each child gets and the number of remaining chocolates.
Display the results.
I/P => numberOfChocolates, numberOfChildren
O/P => The number of chocolates each child gets is ___ and the number of remaining chocolates is ___
using System;
class chocolateDistribution{
static void Main(string[] args ){
   // Taking input from the user for number of students an Chocolates
   Console.Write("Enter the total no. of Children: ");
   int totalChildren  =  Convert.ToInt32(Console.ReadLine());
   Console.Write("Enter the total no. of Chocolates: ");
   int totalChocolates =  Convert.ToInt32(Console.ReadLine());
  
  // Formula to calculate no. of chocolates each children will get  and the remaining chocolates
   int chocolatesPerChild = totalChocolates / totalChildren;
   int remainingChocolates = totalChocolates % totalChildren;
   Console.WriteLine("The number of chocolates each child gets is " +chocolatesPerChild+" and the number of remaining chocolates is "+ remainingChocolates );
   }
}
	

________________


11. Write a program to input the Principal, Rate, and Time values and calculate Simple Interest.
Hint:
Simple Interest = (Principal * Rate * Time) / 100
I/P => principal, rate, time
O/P => The Simple Interest is ___ for Principal ___, Rate of Interest ___ and Time ___
using System;
class simpleInterest{
static void Main(string[] args ){
   // Taking input from the user to calculate Simple Interest
   Console.Write("Enter the Principal Amount: ");
   double principal  =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the Rate of Interest: ");
   double rate =  Convert.ToDouble(Console.ReadLine());
   Console.Write("Enter the Total Time(in years): ");
   double time =  Convert.ToDouble(Console.ReadLine());
  
  // Formula to calculate Simple Interest
   double simpleInterest = (principal * rate * time) / 100;
   Console.WriteLine("The Simple Interest is "+simpleInterest+" for Principal "+principal+", Rate of Interest "+rate+" and Time is " +time+" years.");
   }
}

	________________


12. Create a program to convert weight in pounds to kilograms.
Hint:
1 pound = 2.2 kg
I/P => weight (in pounds)
O/P => The weight of the person in pounds is ___ and in kg is ___
using System;
class weightConversion{
static void Main(string[] args ){
   // Taking input from the user for weight(in pounds)
   Console.Write("Enter the weight (in pounds): ");
   double pounds  =  Convert.ToDouble(Console.ReadLine());
  
  // Formula to convert pounds to kilograms
   double kilograms = pounds * 2.2;
   Console.WriteLine("The weight of the person in pounds is "+ pounds +" and in kg is " + kilograms);
   }
}