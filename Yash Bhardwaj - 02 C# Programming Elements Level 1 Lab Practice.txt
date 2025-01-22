Sample Program 1 - Display Result:
Best Programming Practices
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


Level 1 Practice Programs
________________


1. Write a program to find the age of Harry if the birth year is 2000. Assume the Current Year is 2024
I/P => NONE
O/P => Harry's age in 2024 is ___
using System;

class HarryAge
{
   static void Main(string[] args)
   {
       int birthYear = 2000;
       int currentYear = 2024;
// Formula to calculate the age
       int age = currentYear - birthYear;
       Console.WriteLine($"Harry's age in {currentYear} is {age}.");
   }
}
	



________________


2. Sam’s mark in Maths is 94, Physics is 95, and Chemistry is 96 out of 100. Find the average percent mark in PCM
I/P => NONE
O/P => Sam’s average mark in PCM is ___
using System;

class SamAverageMark
{
   static void Main(string[] args)
   {
       double maths = 94, physics = 95, chemistry = 96;
// Formula to calculate average marks
       double averageMark = (maths + physics + chemistry) / 3;
       Console.WriteLine($"Sam's average mark in PCM is {averageMark}%.");
   }
}
	



________________


3. Create a program to convert the distance of 10.8 kilometers to miles.
Hint: 1 km = 1.6 miles
I/P => NONE
O/P => The distance ___ km in miles is ___
using System;

class KilometersToMiles
{
   static void Main(string[] args)
   {
       double kilometers = 10.8;
// Formula to convert Miles to Kilometers     
  double miles = kilometers / 1.6;
       Console.WriteLine($"The distance {kilometers} km in miles is {miles} miles.");
   }
}
	



________________


4. Create a program to calculate the profit and loss in number and percentage based on the cost price of INR 129 and the selling price of INR 191.
Hint:
Use a single print statement to display multiline text and variables.
Profit = selling price - cost price
Profit Percentage = profit / cost price * 100
I/P => NONE
O/P =>
The Cost Price is INR ___ and Selling Price is INR ___
The Profit is INR ___ and the Profit Percentage is ___
using System;

class ProfitAndLoss
{
   static void Main(string[] args)
   {
       double costPrice = 129, sellingPrice = 191;
    // Formula to calculate profit
       double profit = sellingPrice - costPrice;
   // // Formula to calculate profit percentage
       double profitPercentage = (profit / costPrice) * 100;
       Console.WriteLine($"The Cost Price is INR {costPrice} and Selling Price is INR {sellingPrice}\nThe Profit is INR {profit} and the Profit Percentage is {profitPercentage}%.");
   }
}
	



________________


5. Suppose you have to divide 14 pens among 3 students equally. Write a program to find how many pens each student will get if the pens must be divided equally. Also, find the remaining non-distributed pens.
Hint:
Use Modulus Operator (%) to find the reminder.
Use Division Operator to find the Quantity of pens
I/P => NONE
O/P => The Pen Per Student is ___ and the remaining pen not distributed is ___
using System;

class DividePens
{
   static void Main(string[] args)
   {
       int totalPens = 14, students = 3;
   // Formula to calculate Pens per Student
       int pensPerStudent = totalPens / students;
 // Formula to calculate remaining Pens 
     int remainingPens = totalPens % students;
       Console.WriteLine($"The Pen Per Student is {pensPerStudent} and the remaining pen not distributed is {remainingPens}.");
   }
}

	

________________


6. The University is charging the student a fee of INR 125000 for the course. The University is willing to offer a discount of 10%. Write a program to find the discounted amount and discounted price the student will pay for the course.
Hint:
Create a variable named fee and assign 125000 to it.
Create another variable discountPercent and assign 10 to it.
Compute discount and assign it to the discount variable.
Compute and print the fee you have to pay by subtracting the discount from the fee.
I/P => NONE
O/P => The discount amount is INR ___ and final discounted fee is INR ___
using System;

class DiscountedFee
{
   static void Main(string[] args)
   {
       double fee = 125000;
       double discountPercent = 10;
    // Formula to calculate 
       double discountAmount = (discountPercent / 100) * fee;
   // Formula to calculate discounted fee
       double discountedFee = fee - discountAmount;
       Console.WriteLine($"The discount amount is INR {discountAmount} and final discounted fee is INR {discountedFee}.");
   }
}
	

________________


7. Write a Program to compute the volume of Earth in km^3 and miles^3
Hint: Volume of a Sphere is (4/3) * pi * r^3 and radius of earth is 6378 km
O/P => The volume of earth in cubic kilometers is ____ and cubic miles is ____
using System;

class EarthVolume
{
   static void Main(string[] args)
   {
       double radiusKm = 6378; 
      // Formula to calculate radius Miles to Kilometers
       double radiusMiles = radiusKm / 1.6;
     // Formula to calculate the Volume in Kilometers
       double volumeKm = (4.0 / 3) * Math.PI * Math.Pow(radiusKm, 3);
     // Formula to calculate the volume in Miles
       double volumeMiles = (4.0 / 3) * Math.PI * Math.Pow(radiusMiles, 3);
       Console.WriteLine($"The volume of Earth in cubic kilometers is {volumeKm} km³ and in cubic miles is {volumeMiles} mi³.");
   }
}
	

________________


8. Create a program to convert distance in kilometers to miles.
Hint:
Create a variable km and assign type as double as in double km;
Create Scanner Object to take user input from Standard Input that is the Keyboard as in Scanner input = new Scanner(System.in);
Use Scanner Object to take user input for km as in km = input.nextInt();
Use 1 mile = 1.6 km formulae to calculate miles and show the output
I/P => km
O/P => The total miles is ___ mile for the given ___ km


________________


9. Write a new program similar to the program # 6 but take user input for Student Fee and University Discount
Hint:
Create a variable named fee and take user input for fee.
Create another variable discountPercent and take user input.
Compute the discount and assign it to the discount variable.
Compute and print the fee you have to pay by subtracting the discount from the fee.
I/P => fee, discountPrecent
O/P => The discount amount is INR ___ and final discounted fee is INR ___
using System;
class UserInputDiscountedFee
{
   static void Main(string[] args)
   {
       Console.Write("Enter the fee: ");
    // Taking input from user for fee 
       double fee = Convert.ToDouble(Console.ReadLine());
       Console.Write("Enter the discount percent: ");
    // Taking input from user for discount percentage
       double discountPercent = Convert.ToDouble(Console.ReadLine());
    // // Formula to calculate discount amount
       double discountAmount = (discountPercent / 100) * fee;
       double discountedFee = fee - discountAmount;
       Console.WriteLine($"The discount amount is INR {discountAmount} and final discounted fee is INR {discountedFee}.");
   }
}

	

________________


10. Write a program that takes your height in centimeters and converts it into feet and inches
Hint: 1 foot = 12 inches and 1 inch = 2.54 cm
I/P => height
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___


using System;
class HeightConverter
{
   static void Main(string[] args)
   {
       Console.Write("Enter height in centimeters: "); 
    // Taking input from user for height
       double heightCm = Convert.ToDouble(Console.ReadLine());
   // Formula to calculate height in inches 
       double heightInches = heightCm / 2.54;
       int feet = (int)(heightInches / 12);
       double inches = heightInches % 12;
       Console.WriteLine($"Your height in cm is {heightCm} cm while in feet is {feet} feet and {inches} inches.");
   }
}

	

________________


11. Write a program to create a basic calculator that can perform addition, subtraction, multiplication, and division. The program should ask for two numbers (floating point) and perform all the operations
Hint:
Create a variable number1 and number 2 and take user inputs.
Perform Arithmetic Operations of addition, subtraction, multiplication, and division and assign the result to a variable and finally print the result
I/P => number1, number2
O/P => The addition, subtraction, multiplication and division value of 2 numbers ___ and ___ is ___, ____, ____, and ___
using System;

class BasicCalculator
{
   static void Main(string[] args)
   {
       Console.Write("Enter the first number: ");
    // Taking input from user for number1
       double number1 = Convert.ToDouble(Console.ReadLine());
       Console.Write("Enter the second number: ");
    // Taking input from user for number2
       double number2 = Convert.ToDouble(Console.ReadLine());
    // Formula to calculate answers 
       double sum = number1 + number2;
       double difference = number1 - number2;
       double product = number1 * number2;
       double quotient = number1 / number2;

       Console.WriteLine($"The addition, subtraction, multiplication, and division of {number1} and {number2} are {sum}, {difference}, {product}, and {quotient} respectively.");
   }
}
	



________________


12. Write a program that takes the base and height to find the area of a triangle in square inches and square centimeters
Hint: Area of a Triangle is ½ * base * height
I/P => base, height
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___
using System;

class TriangleArea
{
   static void Main(string[] args)
   { // Taking input from user to enter the base
       Console.Write("Enter the base of the triangle in cm: ");
       double baseCm = Convert.ToDouble(Console.ReadLine());
    // Taking input from user to enter the height
       Console.Write("Enter the height of the triangle in cm: ");
       double heightCm = Convert.ToDouble(Console.ReadLine());
    // Formula to calculate the area of triangle  
       double areaCm = 0.5 * baseCm * heightCm;
       double areaInches = areaCm / 6.4516; // 1 square inch = 6.4516 square cm

       Console.WriteLine($"The area of the triangle is {areaCm} square centimeters and {areaInches} square inches.");
   }
}
	

________________


13. Write a program to find the side of the square whose perimeter you read from user
Hint: Perimeter of Square is 4 times side
I/P => perimeter
O/P => The length of the side is ___ whose perimeter is ____
using System;

class SquareSide
{
   static void Main(string[] args)
   {
       Console.Write("Enter the perimeter of the square: ");
       double perimeter = Convert.ToDouble(Console.ReadLine());
    // Formula to calculate Side 
       double side = perimeter / 4;
       Console.WriteLine($"The length of the side is {side} units.");
   }
}

	

________________


14. Write a program to find the distance in yards and miles for the distance provided by the user in feet
Hint: 1 mile = 1760 yards and 1 yard is 3 feet
I/P => distanceInFeet
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___
using System;

class FeetToYardsAndMiles
{
   static void Main(string[] args)
   {
       Console.Write("Enter distance in feet: ");
    // Taking input from user for distance
       double distanceInFeet = Convert.ToDouble(Console.ReadLine());
   //  Formula to convert Feet in Yards
       double yards = distanceInFeet / 3;
       double miles = yards / 1760;

       Console.WriteLine($"The distance in yards is {yards} and in miles is {miles}.");
   }
}
	

________________


15. Write a program to input the unit price of an item and the quantity to be bought. Then, calculate the total price.
Hint: NA
I/P => unitPrice, quantity
O/P => The total purchase price is INR ___ if the quantity ___ and unit price is INR ___
using System;

class TotalPrice
{
   static void Main(string[] args)
   {
       Console.Write("Enter the unit price of the item: ");
    // Taking input from user for the  unit price
       double unitPrice = Convert.ToDouble(Console.ReadLine());
       Console.Write("Enter the quantity: ");
    // taking input from user to enter the quantity
       int quantity = Convert.ToInt32(Console.ReadLine());
       double totalPrice = unitPrice * quantity;
       Console.WriteLine($"The total purchase price is INR {totalPrice} for {quantity} items at INR {unitPrice} each.");
   }
}
	

________________


16. Create a program to find the maximum number of handshakes among N number of students.
Hint:
Get integer input for numberOfStudents variable.
Use the combination = (n * (n - 1)) / 2 formula to calculate the maximum number of possible handshakes.
Display the number of possible handshakes.
 cusing System;

class Handshakes
{
   static void Main(string[] args)
   {
       Console.Write("Enter the number of students: ");
    // Taking input from user for students
       int numberOfStudents = Convert.ToInt32(Console.ReadLine());
   //  Formula to calculate no. of handshakes
       int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;
       Console.WriteLine($"The maximum number of handshakes among {numberOfStudents} students is {handshakes}.");
   }
}