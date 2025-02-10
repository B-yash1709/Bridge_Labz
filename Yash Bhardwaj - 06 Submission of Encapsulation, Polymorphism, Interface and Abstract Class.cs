Best Programming Practices in C#
Encapsulation
✅ Use private access modifiers for class fields to restrict direct access.
✅ Provide public properties (getters & setters) to access and modify private fields.
✅ Implement validation logic in property setters to ensure data integrity.
✅ Use readonly fields and avoid setters for immutable classes.
✅ Follow C# naming conventions (e.g., PascalCase for properties, camelCase for private fields).
________________
Polymorphism
✅ Program to an interface, not an implementation (use interface for flexibility).
✅ Ensure overridden methods use override and adhere to the base class method’s contract.
✅ Avoid explicit casting (as and is should be used cautiously); rely on polymorphic behavior.
✅ Use covariant return types when overriding methods in derived classes.
✅ Keep inheritance hierarchies shallow to maintain simplicity and avoid complexity.
________________
Interfaces
✅ Use interfaces (interface) to define a contract or behavior.
✅ Prefer default interface implementations only for backward compatibility.
✅ Combine multiple interfaces to create modular, reusable behaviors.
✅ Favor composition over inheritance when combining multiple behaviors.
________________
Abstract Classes
✅ Use abstract classes (abstract class) for shared state and functionality among related classes.
✅ Avoid overusing abstract classes; use them only when clear shared behavior exists.
✅ Combine abstract classes and interfaces to separate behavior and implementation.
✅ Avoid deep inheritance hierarchies; keep designs flexible and maintainable.
________________
General Practices
✅ Follow C# naming conventions (PascalCase for classes, methods, and properties).
✅ Document code using XML comments (///) to improve readability.
✅ Ensure consistency and readability by adhering to team or industry coding standards.
✅ Apply SOLID principles, particularly Single Responsibility and Interface Segregation (we will learn these soon).












Tips for Implementation
* Encapsulation: Ensure all sensitive fields are private and accessed through well-defined getter and setter methods. Include validation logic where applicable.
* Polymorphism: Use abstract class references or interface references to handle objects of multiple types dynamically.
* Abstract Classes: Use them to define a common structure and behavior while deferring specific details to subclasses.
* Interfaces: Use them to define additional capabilities or contracts that are not tied to the class hierarchy.
Problem Statements
1. Employee Management System


Description: Build an employee management system with the following requirements:
* Use an abstract class Employee with fields like employeeId, name, and baseSalary.
* Provide an abstract method CalculateSalary() and a concrete method DisplayDetails().
* Create two subclasses: FullTimeEmployee and PartTimeEmployee, implementing CalculateSalary() based on work hours or fixed salary.
* Use encapsulation to restrict direct access to fields and provide properties for access.
* Create an interface IDepartment with methods like AssignDepartment() and GetDepartmentDetails().
* Ensure polymorphism by processing a list of employees and displaying their details using the Employee reference.
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
   // Interface for Department
   public interface IDepartment
   {
       void AssignDepartment(string department);
       string GetDepartmentDetails();
   }

   // Abstract class Employee
   public abstract class Employee
   {
       // Private fields with encapsulation
       private int _employeeId;
       private string _name;
       private double _baseSalary;

       // Public properties with validation
       public int EmployeeId
       {
           get { return _employeeId; }
           set
           {
               if (value > 0)
                   _employeeId = value;
               else
                   throw new ArgumentException("Employee ID must be greater than 0.");
           }
       }

       public string Name
       {
           get { return _name; }
           set
           {
               if (!string.IsNullOrWhiteSpace(value))
                   _name = value;
               else
                   throw new ArgumentException("Name cannot be null or empty.");
           }
       }

       public double BaseSalary
       {
           get { return _baseSalary; }
           set
           {
               if (value >= 0)
                   _baseSalary = value;
               else
                   throw new ArgumentException("Base salary cannot be negative.");
           }
       }

       // Abstract method to calculate salary
       public abstract double CalculateSalary();

       // Concrete method to display employee details
       public void DisplayDetails()
       {
           Console.WriteLine($"Employee ID: {EmployeeId}");
           Console.WriteLine($"Name: {Name}");
           Console.WriteLine($"Base Salary: {BaseSalary:C}");
           Console.WriteLine($"Calculated Salary: {CalculateSalary():C}");
       }
   }

   // FullTimeEmployee class
   public class FullTimeEmployee : Employee, IDepartment
   {
       // Additional field for full-time employees
       private double _bonus;
       private string _department;

       public double Bonus
       {
           get { return _bonus; }
           set
           {
               if (value >= 0)
                   _bonus = value;
               else
                   throw new ArgumentException("Bonus cannot be negative.");
           }
       }

       // Implementation of IDepartment interface
       public void AssignDepartment(string department)
       {
           _department = department;
       }

       public string GetDepartmentDetails()
       {
           return _department;
       }

       // Override abstract method to calculate salary
       public override double CalculateSalary()
       {
           return BaseSalary + Bonus;
       }
   }

   // PartTimeEmployee class
   public class PartTimeEmployee : Employee, IDepartment
   {
       // Additional fields for part-time employees
       private int _hoursWorked;
       private double _hourlyRate;
       private string _department;

       public int HoursWorked
       {
           get { return _hoursWorked; }
           set
           {
               if (value >= 0)
                   _hoursWorked = value;
               else
                   throw new ArgumentException("Hours worked cannot be negative.");
           }
       }

       public double HourlyRate
       {
           get { return _hourlyRate; }
           set
           {
               if (value >= 0)
                   _hourlyRate = value;
               else
                   throw new ArgumentException("Hourly rate cannot be negative.");
           }
       }

       // Implementation of IDepartment interface
       public void AssignDepartment(string department)
       {
           _department = department;
       }

       public string GetDepartmentDetails()
       {
           return _department;
       }

       // Override abstract method to calculate salary
       public override double CalculateSalary()
       {
           return HoursWorked * HourlyRate;
       }
   }

   // Main program
   class Program
   {
       static void Main(string[] args)
       {
           // Create a list of employees
           List<Employee> employees = new List<Employee>();

           // Create a full-time employee
           FullTimeEmployee fullTimeEmployee = new FullTimeEmployee
           {
               EmployeeId = 1,
               Name = "John Doe",
               BaseSalary = 50000,
               Bonus = 10000
           };
           fullTimeEmployee.AssignDepartment("IT");
           employees.Add(fullTimeEmployee);

           // Create a part-time employee
           PartTimeEmployee partTimeEmployee = new PartTimeEmployee
           {
               EmployeeId = 2,
               Name = "Jane Smith",
               HoursWorked = 20,
               HourlyRate = 25
           };
           partTimeEmployee.AssignDepartment("HR");
           employees.Add(partTimeEmployee);

           // Display details of all employees using polymorphism
           foreach (var employee in employees)
           {
               employee.DisplayDetails();
               if (employee is IDepartment departmentEmployee)
               {
                   Console.WriteLine($"Department: {departmentEmployee.GetDepartmentDetails()}");
               }
               Console.WriteLine();
           }
       }
   }
}
	

________________


2. E-Commerce Platform
Description: Develop a simplified e-commerce platform:
* Create an abstract class Product with fields like productId, name, and price, and an abstract method CalculateDiscount().
* Extend it into concrete classes: Electronics, Clothing, and Groceries.
* Implement an interface ITaxable with methods CalculateTax() and GetTaxDetails() for applicable product categories.
* Use encapsulation to protect product details, allowing updates only through setter methods.
* Showcase polymorphism by creating a method that calculates and prints the final price (price + tax - discount) for a list of products.
using System;
using System.Collections.Generic;

namespace ECommercePlatform
{
   // Interface for taxable products
   public interface ITaxable
   {
       double CalculateTax();
       string GetTaxDetails();
   }

   // Abstract class Product
   public abstract class Product
   {
       // Private fields with encapsulation
       private int _productId;
       private string _name;
       private double _price;

       // Public properties with validation
       public int ProductId
       {
           get { return _productId; }
           set
           {
               if (value > 0)
                   _productId = value;
               else
                   throw new ArgumentException("Product ID must be greater than 0.");
           }
       }

       public string Name
       {
           get { return _name; }
           set
           {
               if (!string.IsNullOrWhiteSpace(value))
                   _name = value;
               else
                   throw new ArgumentException("Name cannot be null or empty.");
           }
       }

       public double Price
       {
           get { return _price; }
           set
           {
               if (value >= 0)
                   _price = value;
               else
                   throw new ArgumentException("Price cannot be negative.");
           }
       }

       // Abstract method to calculate discount
       public abstract double CalculateDiscount();

       // Method to display product details
       public void DisplayDetails()
       {
           Console.WriteLine($"Product ID: {ProductId}");
           Console.WriteLine($"Name: {Name}");
           Console.WriteLine($"Price: {Price:C}");
           Console.WriteLine($"Discount: {CalculateDiscount():C}");
       }
   }

   // Electronics class
   public class Electronics : Product, ITaxable
   {
       // Additional field for electronics
       private double _warrantyYears;

       public double WarrantyYears
       {
           get { return _warrantyYears; }
           set
           {
               if (value >= 0)
                   _warrantyYears = value;
               else
                   throw new ArgumentException("Warranty years cannot be negative.");
           }
       }

       // Override abstract method to calculate discount
       public override double CalculateDiscount()
       {
           // 10% discount for electronics
           return Price * 0.10;
       }

       // Implementation of ITaxable interface
       public double CalculateTax()
       {
           // 18% tax for electronics
           return Price * 0.18;
       }

       public string GetTaxDetails()
       {
           return "GST (18%)";
       }
   }

   // Clothing class
   public class Clothing : Product, ITaxable
   {
       // Additional field for clothing
       private string _size;

       public string Size
       {
           get { return _size; }
           set
           {
               if (!string.IsNullOrWhiteSpace(value))
                   _size = value;
               else
                   throw new ArgumentException("Size cannot be null or empty.");
           }
       }

       // Override abstract method to calculate discount
       public override double CalculateDiscount()
       {
           // 5% discount for clothing
           return Price * 0.05;
       }

       // Implementation of ITaxable interface
       public double CalculateTax()
       {
           // 12% tax for clothing
           return Price * 0.12;
       }

       public string GetTaxDetails()
       {
           return "GST (12%)";
       }
   }

   // Groceries class
   public class Groceries : Product
   {
       // Additional field for groceries
       private DateTime _expiryDate;

       public DateTime ExpiryDate
       {
           get { return _expiryDate; }
           set
           {
               if (value > DateTime.Now)
                   _expiryDate = value;
               else
                   throw new ArgumentException("Expiry date must be in the future.");
           }
       }

       // Override abstract method to calculate discount
       public override double CalculateDiscount()
       {
           // No discount for groceries
           return 0;
       }
   }

   // Main program
   class Program
   {
       static void Main(string[] args)
       {
           // Create a list of products
           List<Product> products = new List<Product>();

           // Create an electronics product
           Electronics laptop = new Electronics
           {
               ProductId = 1,
               Name = "Laptop",
               Price = 1200,
               WarrantyYears = 2
           };
           products.Add(laptop);

           // Create a clothing product
           Clothing shirt = new Clothing
           {
               ProductId = 2,
               Name = "Shirt",
               Price = 50,
               Size = "M"
           };
           products.Add(shirt);

           // Create a groceries product
           Groceries milk = new Groceries
           {
               ProductId = 3,
               Name = "Milk",
               Price = 3,
               ExpiryDate = DateTime.Now.AddDays(7)
           };
           products.Add(milk);

           // Calculate and display final price for each product
           foreach (var product in products)
           {
               double discount = product.CalculateDiscount();
               double tax = 0;
               string taxDetails = "No Tax";

               if (product is ITaxable taxableProduct)
               {
                   tax = taxableProduct.CalculateTax();
                   taxDetails = taxableProduct.GetTaxDetails();
               }

               double finalPrice = product.Price + tax - discount;

               Console.WriteLine($"Product: {product.Name}");
               Console.WriteLine($"Price: {product.Price:C}");
               Console.WriteLine($"Discount: {discount:C}");
               Console.WriteLine($"Tax: {tax:C} ({taxDetails})");
               Console.WriteLine($"Final Price: {finalPrice:C}");
               Console.WriteLine();
           }
       }
   }
}
	



________________


3. Vehicle Rental System
Description: Design a system to manage vehicle rentals:
* Define an abstract class Vehicle with fields like vehicleNumber, type, and rentalRate.
* Add an abstract method CalculateRentalCost(int days).
* Create subclasses Car, Bike, and Truck with specific implementations of CalculateRentalCost().
* Use an interface IInsurable with methods CalculateInsurance() and GetInsuranceDetails().
* Apply encapsulation to restrict access to sensitive details like insurance policy numbers.
* Demonstrate polymorphism by iterating over a list of vehicles and calculating rental and insurance costs for each.
using System;
using System.Collections.Generic;

// Abstract class for Vehicle
abstract class Vehicle
{
   public string VehicleNumber { get; private set; }
   public string Type { get; private set; }
   public double RentalRate { get; protected set; }

   protected Vehicle(string vehicleNumber, string type, double rentalRate)
   {
       VehicleNumber = vehicleNumber;
       Type = type;
       RentalRate = rentalRate;
   }

   public abstract double CalculateRentalCost(int days);
}

// Interface for Insurance
interface IInsurable
{
   double CalculateInsurance();
   string GetInsuranceDetails();
}

// Car subclass
class Car : Vehicle, IInsurable
{
   private string InsurancePolicyNumber;

   public Car(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
       : base(vehicleNumber, "Car", rentalRate)
   {
       InsurancePolicyNumber = insurancePolicyNumber;
   }

   public override double CalculateRentalCost(int days)
   {
       return days * RentalRate;
   }

   public double CalculateInsurance()
   {
       return RentalRate * 0.05; // 5% of rental rate
   }

   public string GetInsuranceDetails()
   {
       return $"Car Insurance Policy: {InsurancePolicyNumber}";
   }
}

// Bike subclass
class Bike : Vehicle, IInsurable
{
   private string InsurancePolicyNumber;

   public Bike(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
       : base(vehicleNumber, "Bike", rentalRate)
   {
       InsurancePolicyNumber = insurancePolicyNumber;
   }

   public override double CalculateRentalCost(int days)
   {
       return days * RentalRate;
   }

   public double CalculateInsurance()
   {
       return RentalRate * 0.02; // 2% of rental rate
   }

   public string GetInsuranceDetails()
   {
       return $"Bike Insurance Policy: {InsurancePolicyNumber}";
   }
}

// Truck subclass
class Truck : Vehicle, IInsurable
{
   private string InsurancePolicyNumber;

   public Truck(string vehicleNumber, double rentalRate, string insurancePolicyNumber)
       : base(vehicleNumber, "Truck", rentalRate)
   {
       InsurancePolicyNumber = insurancePolicyNumber;
   }

   public override double CalculateRentalCost(int days)
   {
       return days * RentalRate * 1.2; // 20% extra for trucks
   }

   public double CalculateInsurance()
   {
       return RentalRate * 0.1; // 10% of rental rate
   }

   public string GetInsuranceDetails()
   {
       return $"Truck Insurance Policy: {InsurancePolicyNumber}";
   }
}

// Main class to test the system
class Program
{
   static void Main()
   {
       List<Vehicle> vehicles = new List<Vehicle>
       {
           new Car("C123", 50, "CAR12345"),
           new Bike("B456", 20, "BIKE67890"),
           new Truck("T789", 100, "TRUCK54321")
       };

       int rentalDays = 5;

       foreach (var vehicle in vehicles)
       {
           Console.WriteLine($"Vehicle: {vehicle.Type} ({vehicle.VehicleNumber})");
           Console.WriteLine($"Rental Cost for {rentalDays} days: ${vehicle.CalculateRentalCost(rentalDays)}");
           
           if (vehicle is IInsurable insurable)
           {
               Console.WriteLine($"Insurance Cost: ${insurable.CalculateInsurance()}");
               Console.WriteLine(insurable.GetInsuranceDetails());
           }

           Console.WriteLine("------------------------------");
       }
   }
}
	



________________


4. Banking System
Description: Create a banking system with different account types:
* Define an abstract class BankAccount with fields like accountNumber, holderName, and balance.
* Add methods like Deposit(double amount), Withdraw(double amount), and an abstract method CalculateInterest().
* Implement subclasses SavingsAccount and CurrentAccount with unique interest calculations.
* Create an interface ILoanable with methods ApplyForLoan() and CalculateLoanEligibility().
* Use encapsulation to secure account details and restrict unauthorized access.
* Demonstrate polymorphism by processing different account types and calculating interest dynamically.
using System;
using System.Collections.Generic;

// Abstract class for BankAccount
abstract class BankAccount
{
   public string AccountNumber { get; private set; }
   public string HolderName { get; private set; }
   protected double Balance;

   protected BankAccount(string accountNumber, string holderName, double initialBalance)
   {
       AccountNumber = accountNumber;
       HolderName = holderName;
       Balance = initialBalance;
   }

   public void Deposit(double amount)
   {
       if (amount > 0)
       {
           Balance += amount;
           Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
       }
       else
       {
           Console.WriteLine("Deposit amount must be positive.");
       }
   }

   public virtual void Withdraw(double amount)
   {
       if (amount > 0 && amount <= Balance)
       {
           Balance -= amount;
           Console.WriteLine($"Withdrawn ${amount}. Remaining balance: ${Balance}");
       }
       else
       {
           Console.WriteLine("Invalid withdrawal amount.");
       }
   }

   public abstract double CalculateInterest();
}

// Interface for loanable accounts
interface ILoanable
{
   void ApplyForLoan(double amount);
   bool CalculateLoanEligibility();
}

// SavingsAccount subclass
class SavingsAccount : BankAccount
{
   private double InterestRate = 0.03; // 3% interest

   public SavingsAccount(string accountNumber, string holderName, double initialBalance)
       : base(accountNumber, holderName, initialBalance) { }

   public override double CalculateInterest()
   {
       return Balance * InterestRate;
   }
}

// CurrentAccount subclass
class CurrentAccount : BankAccount, ILoanable
{
   private double OverdraftLimit = 1000;

   public CurrentAccount(string accountNumber, string holderName, double initialBalance)
       : base(accountNumber, holderName, initialBalance) { }

   public override double CalculateInterest()
   {
       return 0; // No interest for current accounts
   }

   public void ApplyForLoan(double amount)
   {
       Console.WriteLine($"Loan of ${amount} applied for Current Account: {AccountNumber}");
   }

   public bool CalculateLoanEligibility()
   {
       return Balance >= OverdraftLimit;
   }
}

// Main program to test the system
class Program
{
   static void Main()
   {
       List<BankAccount> accounts = new List<BankAccount>
       {
           new SavingsAccount("SA12345", "Alice", 5000),
           new CurrentAccount("CA67890", "Bob", 2000)
       };

       foreach (var account in accounts)
       {
           Console.WriteLine($"Account Holder: {account.HolderName}, Account Number: {account.AccountNumber}");
           Console.WriteLine($"Interest Earned: ${account.CalculateInterest()}");
           
           if (account is ILoanable loanable)
           {
               loanable.ApplyForLoan(5000);
               Console.WriteLine($"Loan Eligibility: {loanable.CalculateLoanEligibility()}");
           }
           
           Console.WriteLine("--------------------------------");
       }
   }
}
	



________________


5. Library Management System
Description: Develop a library management system:
* Use an abstract class LibraryItem with fields like itemId, title, and author.
* Add an abstract method GetLoanDuration() and a concrete method GetItemDetails().
* Create subclasses Book, Magazine, and DVD, overriding GetLoanDuration() with specific logic.
* Implement an interface IReservable with methods ReserveItem() and CheckAvailability().
* Apply encapsulation to secure details like the borrower’s personal data.
* Use polymorphism to allow a general LibraryItem reference to manage all items.
using System;
using System.Collections.Generic;

namespace SimpleLibraryManagement
{
   // Interface for reservable items
   public interface IReservable
   {
       void Reserve();
       bool IsAvailable { get; }
   }

   // Abstract class LibraryItem
   public abstract class LibraryItem
   {
       public int Id { get; set; }
       public string Title { get; set; }
       public string Author { get; set; }

       // Abstract method to get loan duration
       public abstract int GetLoanDuration();

       // Display item details
       public void DisplayDetails()
       {
           Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, Loan Duration: {GetLoanDuration()} days");
       }
   }

   // Book class
   public class Book : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 14; // Books can be borrowed for 14 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"Book '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"Book '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // Magazine class
   public class Magazine : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 7; // Magazines can be borrowed for 7 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"Magazine '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"Magazine '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // DVD class
   public class DVD : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 3; // DVDs can be borrowed for 3 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"DVD '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"DVD '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // Main program
   class Program
   {
       static void Main(string[] args)
       {
           // Create a list of library items
           List<LibraryItem> items = new List<LibraryItem>
           {
               new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
               new Magazine { Id = 2, Title = "National Geographic", Author = "Various Authors" },
               new DVD { Id = 3, Title = "Inception", Author = "Christopher Nolan" }
           };

           // Display details and reserve items
           foreach (var item in items)
           {
               item.DisplayDetails();

               if (item is IReservable reservableItem)
               {
                   if (reservableItem.IsAvailable)
                   {
                       reservableItem.Reserve();
                   }
                   else
                   {
                       Console.WriteLine($"{item.Title} is not available for reservation.");
                   }
               }

               Console.WriteLine();
           }
       }
   }
}
	

________________


6. Online Food Delivery System
Description: Create an online food delivery system:
* Define an abstract class FoodItem with fields like itemName, price, and quantity.
* Add abstract methods CalculateTotalPrice() and concrete methods like GetItemDetails().
* Extend it into classes VegItem and NonVegItem, overriding CalculateTotalPrice() to include additional charges.
* Use an interface IDiscountable with methods ApplyDiscount() and GetDiscountDetails().
* Use polymorphism to handle different types of food items dynamically.
using System;
using System.Collections.Generic;

namespace SimpleLibraryManagement
{
   // Interface for reservable items
   public interface IReservable
   {
       void Reserve();
       bool IsAvailable { get; }
   }

   // Abstract class LibraryItem
   public abstract class LibraryItem
   {
       public int Id { get; set; }
       public string Title { get; set; }
       public string Author { get; set; }

       // Abstract method to get loan duration
       public abstract int GetLoanDuration();

       // Display item details
       public void DisplayDetails()
       {
           Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, Loan Duration: {GetLoanDuration()} days");
       }
   }

   // Book class
   public class Book : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 14; // Books can be borrowed for 14 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"Book '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"Book '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // Magazine class
   public class Magazine : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 7; // Magazines can be borrowed for 7 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"Magazine '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"Magazine '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // DVD class
   public class DVD : LibraryItem, IReservable
   {
       private bool _isReserved = false;

       public override int GetLoanDuration() => 3; // DVDs can be borrowed for 3 days

       public void Reserve()
       {
           if (!_isReserved)
           {
               _isReserved = true;
               Console.WriteLine($"DVD '{Title}' has been reserved.");
           }
           else
           {
               Console.WriteLine($"DVD '{Title}' is already reserved.");
           }
       }

       public bool IsAvailable => !_isReserved;
   }

   // Main program
   class Program
   {
       static void Main(string[] args)
       {
           // Create a list of library items
           List<LibraryItem> items = new List<LibraryItem>
           {
               new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
               new Magazine { Id = 2, Title = "National Geographic", Author = "Various Authors" },
               new DVD { Id = 3, Title = "Inception", Author = "Christopher Nolan" }
           };

           // Display details and reserve items
           foreach (var item in items)
           {
               item.DisplayDetails();

               if (item is IReservable reservableItem)
               {
                   if (reservableItem.IsAvailable)
                   {
                       reservableItem.Reserve();
                   }
                   else
                   {
                       Console.WriteLine($"{item.Title} is not available for reservation.");
                   }
               }

               Console.WriteLine();
           }
       }
   }
}
	



________________




7. Hospital Patient Management
Description: Design a system to manage patients in a hospital.
* Abstract Class:
   * Create an abstract class Patient with fields: patientId, name, and age.
   * Add an abstract method CalculateBill().
   * Implement a concrete method GetPatientDetails().
* Subclasses:
   * Extend Patient into InPatient and OutPatient.
   * Implement CalculateBill() differently for each subclass.
* Interface:
   * Implement an interface IMedicalRecord.
   * Define methods AddRecord() and ViewRecords().
* Encapsulation:
   * Protect sensitive patient data like diagnosis and medical history.
* Polymorphism:
   * Use a Patient reference to handle different patient types dynamically.
   * Display billing details based on polymorphic behavior.
using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
   // Interface for medical records
   public interface IMedicalRecord
   {
       void AddRecord(string record);
       void ViewRecords();
   }

   // Abstract class Patient
   public abstract class Patient
   {
       // Encapsulated fields
       private int _patientId;
       private string _name;
       private int _age;

       // Public properties with validation
       public int PatientId
       {
           get { return _patientId; }
           set
           {
               if (value > 0)
                   _patientId = value;
               else
                   throw new ArgumentException("Patient ID must be greater than 0.");
           }
       }

       public string Name
       {
           get { return _name; }
           set
           {
               if (!string.IsNullOrWhiteSpace(value))
                   _name = value;
               else
                   throw new ArgumentException("Name cannot be null or empty.");
           }
       }

       public int Age
       {
           get { return _age; }
           set
           {
               if (value > 0)
                   _age = value;
               else
                   throw new ArgumentException("Age must be greater than 0.");
           }
       }

       // Abstract method to calculate bill
       public abstract double CalculateBill();

       // Concrete method to display patient details
       public void GetPatientDetails()
       {
           Console.WriteLine($"Patient ID: {PatientId}");
           Console.WriteLine($"Name: {Name}");
           Console.WriteLine($"Age: {Age}");
           Console.WriteLine($"Total Bill: {CalculateBill():C}");
       }
   }

   // InPatient class
   public class InPatient : Patient, IMedicalRecord
   {
       private List<string> _medicalRecords = new List<string>();
       private double _roomCharges;
       private double _treatmentCharges;

       public double RoomCharges
       {
           get { return _roomCharges; }
           set
           {
               if (value >= 0)
                   _roomCharges = value;
               else
                   throw new ArgumentException("Room charges cannot be negative.");
           }
       }

       public double TreatmentCharges
       {
           get { return _treatmentCharges; }
           set
           {
               if (value >= 0)
                   _treatmentCharges = value;
               else
                   throw new ArgumentException("Treatment charges cannot be negative.");
           }
       }

       // Override abstract method to calculate bill
       public override double CalculateBill()
       {
           return RoomCharges + TreatmentCharges;
       }

       // Implementation of IMedicalRecord interface
       public void AddRecord(string record)
       {
           if (!string.IsNullOrWhiteSpace(record))
               _medicalRecords.Add(record);
           else
               throw new ArgumentException("Record cannot be null or empty.");
       }

       public void ViewRecords()
       {
           Console.WriteLine($"Medical Records for {Name}:");
           foreach (var record in _medicalRecords)
           {
               Console.WriteLine($"- {record}");
           }
       }
   }

   // OutPatient class
   public class OutPatient : Patient, IMedicalRecord
   {
       private List<string> _medicalRecords = new List<string>();
       private double _consultationFee;
       private double _medicationCharges;

       public double ConsultationFee
       {
           get { return _consultationFee; }
           set
           {
               if (value >= 0)
                   _consultationFee = value;
               else
                   throw new ArgumentException("Consultation fee cannot be negative.");
           }
       }

       public double MedicationCharges
       {
           get { return _medicationCharges; }
           set
           {
               if (value >= 0)
                   _medicationCharges = value;
               else
                   throw new ArgumentException("Medication charges cannot be negative.");
           }
       }

       // Override abstract method to calculate bill
       public override double CalculateBill()
       {
           return ConsultationFee + MedicationCharges;
       }

       // Implementation of IMedicalRecord interface
       public void AddRecord(string record)
       {
           if (!string.IsNullOrWhiteSpace(record))
               _medicalRecords.Add(record);
           else
               throw new ArgumentException("Record cannot be null or empty.");
       }

       public void ViewRecords()
       {
           Console.WriteLine($"Medical Records for {Name}:");
           foreach (var record in _medicalRecords)
           {
               Console.WriteLine($"- {record}");
           }
       }
   }

   // Main program
   class Program
   {
       static void Main(string[] args)
       {
           // Create a list of patients
           List<Patient> patients = new List<Patient>();

           // Create an in-patient
           InPatient inPatient = new InPatient
           {
               PatientId = 1,
               Name = "John Doe",
               Age = 35,
               RoomCharges = 500,
               TreatmentCharges = 1000
           };
           inPatient.AddRecord("Admitted for surgery.");
           inPatient.AddRecord("Recovering in Room 101.");
           patients.Add(inPatient);

           // Create an out-patient
           OutPatient outPatient = new OutPatient
           {
               PatientId = 2,
               Name = "Jane Smith",
               Age = 28,
               ConsultationFee = 200,
               MedicationCharges = 50
           };
           outPatient.AddRecord("Consulted for fever.");
           outPatient.AddRecord("Prescribed antibiotics.");
           patients.Add(outPatient);

           // Display details of all patients using polymorphism
           foreach (var patient in patients)
           {
               patient.GetPatientDetails();

               if (patient is IMedicalRecord medicalRecord)
               {
                   medicalRecord.ViewRecords();
               }

               Console.WriteLine();
           }
       }
   }
}
	

________________


8. Ride-Hailing Application
Description: Develop a ride-hailing application.
* Abstract Class:
   * Define an abstract class Vehicle with fields: vehicleId, driverName, and ratePerKm.
   * Add an abstract method CalculateFare(double distance).
   * Implement a concrete method GetVehicleDetails().
* Subclasses:
   * Extend Vehicle into Car, Bike, and Auto.
   * Override CalculateFare() based on type-specific rates.
* Interface:
   * Implement an interface IGPS.
   * Define methods GetCurrentLocation() and UpdateLocation().
* Encapsulation:
   * Secure driver and vehicle details using private fields and properties.
* Polymorphism:
   * Create a method that processes multiple vehicle types dynamically.
   * Calculate fares based on the Vehicle reference.
using System;
using System.Collections.Generic;

// Abstract class for Vehicle
abstract class Vehicle
{
   public int VehicleId { get; private set; }
   public string DriverName { get; private set; }
   public double RatePerKm { get; private set; }

   protected Vehicle(int vehicleId, string driverName, double ratePerKm)
   {
       VehicleId = vehicleId;
       DriverName = driverName;
       RatePerKm = ratePerKm;
   }

   public abstract double CalculateFare(double distance);

   public void GetVehicleDetails()
   {
       Console.WriteLine($"Vehicle ID: {VehicleId}, Driver: {DriverName}, Rate/km: ${RatePerKm}");
   }
}

// Interface for GPS functionality
interface IGPS
{
   string GetCurrentLocation();
   void UpdateLocation(string newLocation);
}

// Car subclass
class Car : Vehicle, IGPS
{
   private string CurrentLocation;

   public Car(int vehicleId, string driverName, double ratePerKm, string location)
       : base(vehicleId, driverName, ratePerKm)
   {
       CurrentLocation = location;
   }

   public override double CalculateFare(double distance)
   {
       return RatePerKm * distance;
   }

   public string GetCurrentLocation()
   {
       return CurrentLocation;
   }

   public void UpdateLocation(string newLocation)
   {
       CurrentLocation = newLocation;
   }
}

// Bike subclass
class Bike : Vehicle, IGPS
{
   private string CurrentLocation;

   public Bike(int vehicleId, string driverName, double ratePerKm, string location)
       : base(vehicleId, driverName, ratePerKm)
   {
       CurrentLocation = location;
   }

   public override double CalculateFare(double distance)
   {
       return RatePerKm * distance * 0.9; // Discounted fare for bikes
   }

   public string GetCurrentLocation()
   {
       return CurrentLocation;
   }

   public void UpdateLocation(string newLocation)
   {
       CurrentLocation = newLocation;
   }
}

// Auto subclass
class Auto : Vehicle, IGPS
{
   private string CurrentLocation;

   public Auto(int vehicleId, string driverName, double ratePerKm, string location)
       : base(vehicleId, driverName, ratePerKm)
   {
       CurrentLocation = location;
   }

   public override double CalculateFare(double distance)
   {
       return RatePerKm * distance * 1.1; // Slightly higher fare for autos
   }

   public string GetCurrentLocation()
   {
       return CurrentLocation;
   }

   public void UpdateLocation(string newLocation)
   {
       CurrentLocation = newLocation;
   }
}

// Main program to test the system
class Program
{
   static void Main()
   {
       List<Vehicle> vehicles = new List<Vehicle>
       {
           new Car(101, "Alice", 10, "Downtown"),
           new Bike(102, "Bob", 5, "Uptown"),
           new Auto(103, "Charlie", 7, "Suburbs")
       };

       double distance = 15; // Example distance

       foreach (var vehicle in vehicles)
       {
           vehicle.GetVehicleDetails();
           Console.WriteLine($"Fare for {distance} km: ${vehicle.CalculateFare(distance)}");
           
           if (vehicle is IGPS gpsEnabled)
           {
               Console.WriteLine($"Current Location: {gpsEnabled.GetCurrentLocation()}");
               gpsEnabled.UpdateLocation("New Destination");
               Console.WriteLine($"Updated Location: {gpsEnabled.GetCurrentLocation()}");
           }

           Console.WriteLine("--------------------------------");
       }
   }
}