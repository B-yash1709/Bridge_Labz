//1. Welcome to Bridgelabz!
//Write a program that prints "Welcome to Bridgelabz!" to the screen. 

using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Bridgelabz!");
    }
}


//2. Add Two Numbers
//Write a program that takes two numbers as input from the user and prints their sum. 
using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());


        Console.Write("Enter the second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());


        int sum = number1 + number2;
        Console.WriteLine("The sum is: " + sum);
    }
}


//3. Celsius to Fahrenheit Conversion
//Write a program that takes the temperature in Celsius as input and converts it to Fahrenheit using the formula: 
Fahrenheit = (Celsius * 9/5) + 32. 




using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());


        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine("Temperature in Fahrenheit: " + fahrenheit);
    }
}


// 4. Area of a Circle
// Write a program to calculate the area of a circle. Take the radius as input and use the formula: 
// Area = π * radius^2. 
// using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the radius of the circle: ");
        double radius = Convert.ToDouble(Console.ReadLine());


        double area = Math.PI * radius * radius;
        Console.WriteLine("The area of the circle is: " + area);
    }
}


// 5. Volume of a Cylinder
// Write a program to calculate the volume of a cylinder. Take the radius and height as inputs and use the formula: 
// Volume = π * radius^2 * height


using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the radius of the cylinder: ");
        double radius = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the height of the cylinder: ");
        double height = Convert.ToDouble(Console.ReadLine());


        double volume = Math.PI * radius * radius * height;
        Console.WriteLine("The volume of the cylinder is: " + volume);
    }
}


// Self Problems
// 1. Calculate Simple Interest
// Write a program to calculate simple interest using the formula: Simple Interest = (Principal * Rate * Time) / 100. Take Principal, Rate, and Time as inputs from the user. 


using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the Principal amount: ");
        double principal = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the Rate of interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine());


        double simpleInterest = (principal * rate * time) / 100;
        Console.WriteLine("The Simple Interest is: " + simpleInterest);
    }
}


// 2. Perimeter of a Rectangle
// Write a program to calculate the perimeter of a rectangle. Take the length and width as inputs and use the formula: 
// Perimeter = 2 * (length + width).


using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the rectangle: ");
        double length = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the width of the rectangle: ");
        double width = Convert.ToDouble(Console.ReadLine());


        double perimeter = 2 * (length + width);
        Console.WriteLine("The perimeter of the rectangle is: " + perimeter);
    }
}


// 3. Power Calculation
// Write a program that takes two numbers as input: a base and an exponent, and prints the result of base raised to the exponent (without using loops or conditionals)


using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the base number: ");
        double baseNumber = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the exponent: ");
        double exponent = Convert.ToDouble(Console.ReadLine());


        double result = Math.Pow(baseNumber, exponent);
        Console.WriteLine("The result is: " + result);
    }
}


// 4. Calculate Average of Three Numbers
// Write a program that takes three numbers as input from the user and prints their average
using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double number1 = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the second number: ");
        double number2 = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter the third number: ");
        double number3 = Convert.ToDouble(Console.ReadLine());


        double average = (number1 + number2 + number3) / 3;
        Console.WriteLine("The average is: " + average);
    }
}


// 5. Convert Kilometers to Miles
// Write a program that takes the distance in kilometers as input from the user and converts it into miles using the formula: 
// Miles = Kilometers * 0.621371


using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter distance in kilometers: ");
        double kilometers = Convert.ToDouble(Console.ReadLine());


        double miles = kilometers * 0.621371;
        Console.WriteLine("Distance in miles: " + miles);
    }
}