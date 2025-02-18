Best Practices for C# Generics
Using Generics effectively ensures type safety, reusability, and maintainability in C# applications. Below are the key best practices to follow:
1. Use Generics to Ensure Type Safety
   * Prevents runtime exceptions due to invalid type casting.
   * Ensures compile-time type checking rather than runtime validation.
2. Prefer Generic Methods Over Method Overloading
   * Reduces redundancy by allowing a single method to handle multiple data types.
   * Improves code reusability without requiring multiple overloaded methods.
3. Use Covariant (out) for Read-Only Access
   * Allows reading elements from a collection without modification.
   * Ensures flexibility when working with inherited types.
4. Use Contravariant (in) for Write Operations
   * Enables modifying a collection while maintaining compatibility with base types.
   * Prevents unintended operations that could introduce type mismatches.
5. Avoid Using Non-Generic Collections 
   * Non-generic collections lack type safety and require explicit type casting.
   * Always prefer generic collections such as List<T>, Dictionary<TKey, TValue>.
6. Use Constraints (where T : SomeClass) to Restrict Type Parameters
   * Restricts type parameters to a specific class or interface.
   * Ensures only valid types can be used with a generic class or method.
7. Favor Generic Interfaces for Common Behaviors
   * Improves code reuse by defining common behavior for multiple implementations.
   * Helps in designing flexible APIs that work with different data types.
8. Minimize the Use of Wildcards (object) in Public APIs
   * Use generic constraints (where T : class) to improve API flexibility.
   * Avoid using object in method return types, as it complicates type inference.
9. Combine Generics with LINQ for Efficient Data Processing
   * Works well with LINQ for dynamic collection manipulation.
   * Improves readability and efficiency in functional-style programming.
10. Use Generic Constructors When Necessary
   * Allows creating type-safe instances in a flexible way.
   * Improves encapsulation while maintaining generic behavior.
11. Avoid Type Erasure Pitfalls
   * Remember that C# retains generic type information at runtime (unlike Java).
   * Can use typeof(T), default(T), and reflection to inspect generic types.
12. Favor Composition Over Inheritance in Generic Hierarchies
   * Reduces complexity by avoiding deep inheritance chains.
   * Enhances maintainability and flexibility by composing objects rather than inheriting them.
13. Keep Generics Simple and Understandable
   * Avoid overly complex generic hierarchies.
   * Use meaningful type parameter names (T, E, K, V) to improve code readability.
________________


Project Ideas Using C# Generics
1. Smart Warehouse Management System
   * Concepts: Generic Classes, Constraints, Variance
   * Problem Statement: Develop a warehouse system that manages different types of items (Electronics, Groceries, Furniture).
   * Hints: 
      * Create an abstract class WarehouseItem that all items extend (Electronics, Groceries, Furniture).
      * Implement a generic class Storage<T> where T : WarehouseItem to store items safely.
      * Implement a method to display all items using List<T>.
using System;
using System.Collections.Generic;

// Step 1: Create an abstract base class for warehouse items
public abstract class WarehouseItem
{
   public string Name { get; set; }
   public double Price { get; set; }

   public WarehouseItem(string name, double price)
   {
       Name = name;
       Price = price;
   }

   public override string ToString()
   {
       return $"{Name} - ${Price}";
   }
}

// Step 2: Define multiple item types
public class Electronics : WarehouseItem
{
   public Electronics(string name, double price) : base(name, price) { }
}

public class Groceries : WarehouseItem
{
   public Groceries(string name, double price) : base(name, price) { }
}

public class Furniture : WarehouseItem
{
   public Furniture(string name, double price) : base(name, price) { }
}

// Step 3: Implement a generic storage class
public class Storage<T> where T : WarehouseItem
{
   private List<T> items = new List<T>();

   public void AddItem(T item)
   {
       items.Add(item);
   }

   public void DisplayItems()
   {
       if (items.Count == 0)
       {
           Console.WriteLine("No items in storage.");
           return;
       }

       Console.WriteLine("Items in storage:");
       foreach (var item in items)
       {
           Console.WriteLine(item);
       }
   }
}

// Step 4: Test the warehouse system
class Program
{
   static void Main()
   {
       Storage<Electronics> electronicsStorage = new Storage<Electronics>();
       electronicsStorage.AddItem(new Electronics("Laptop", 1200));
       electronicsStorage.AddItem(new Electronics("Smartphone", 800));

       Storage<Groceries> groceriesStorage = new Storage<Groceries>();
       groceriesStorage.AddItem(new Groceries("Apples", 5));
       groceriesStorage.AddItem(new Groceries("Milk", 2.5));

       Storage<Furniture> furnitureStorage = new Storage<Furniture>();
       furnitureStorage.AddItem(new Furniture("Chair", 50));
       furnitureStorage.AddItem(new Furniture("Table", 150));

       Console.WriteLine("\nElectronics Storage:");
       electronicsStorage.DisplayItems();

       Console.WriteLine("\nGroceries Storage:");
       groceriesStorage.DisplayItems();

       Console.WriteLine("\nFurniture Storage:");
       furnitureStorage.DisplayItems();
   }
}
	



2. Dynamic Online Marketplace
   * Concepts: Type Parameters, Generic Methods, Constraints
   * Problem Statement: Build a generic product catalog for an online marketplace supporting various product types.
   * Hints: 
      * Define a generic class Product<T> where T is restricted to a category (BookCategory, ClothingCategory).
      * Implement a generic method void ApplyDiscount<T>(T product, double percentage) where T : Product.
      * Ensure type safety while allowing multiple product categories in the catalog.
using System;
using System.Collections.Generic;

// Step 1: Define category constraints
public abstract class ProductCategory
{
   public string CategoryName { get; set; }
}

public class BookCategory : ProductCategory
{
   public BookCategory() { CategoryName = "Books"; }
}

public class ClothingCategory : ProductCategory
{
   public ClothingCategory() { CategoryName = "Clothing"; }
}

// Step 2: Define a base product class (fixes the issue)
public abstract class BaseProduct
{
   public string Name { get; set; }
   public double Price { get; set; }
   
   protected BaseProduct(string name, double price)
   {
       Name = name;
       Price = price;
   }

   public override string ToString()
   {
       return $"{Name} - ${Price:F2}";
   }
}

// Step 3: Define a generic product class inheriting from BaseProduct
public class Product<T> : BaseProduct where T : ProductCategory
{
   public T Category { get; set; }

   public Product(string name, double price, T category) : base(name, price)
   {
       Category = category;
   }

   public override string ToString()
   {
       return $"{Name} - {Category.CategoryName} - ${Price:F2}";
   }
}

// Step 4: Implement a generic discount method
public static class DiscountManager
{
   public static void ApplyDiscount(BaseProduct product, double percentage)
   {
       if (percentage < 0 || percentage > 100)
       {
           throw new ArgumentException("Discount percentage must be between 0 and 100.");
       }

       product.Price -= product.Price * (percentage / 100);
   }
}

// Step 5: Test the marketplace system
class Program
{
   static void Main()
   {
       Product<BookCategory> book = new Product<BookCategory>("C# Programming", 50.00, new BookCategory());
       Product<ClothingCategory> shirt = new Product<ClothingCategory>("T-Shirt", 20.00, new ClothingCategory());
       
       Console.WriteLine("Before Discount:");
       Console.WriteLine(book);
       Console.WriteLine(shirt);

       DiscountManager.ApplyDiscount(book, 10);
       DiscountManager.ApplyDiscount(shirt, 15);
       
       Console.WriteLine("\nAfter Discount:");
       Console.WriteLine(book);
       Console.WriteLine(shirt);
   }
}
	



3. Multi-Level University Course Management System
   * Concepts: Generic Classes, Constraints, Variance
   * Problem Statement: Develop a university course management system where different departments offer courses with different evaluation types.
   * Hints: 
      * Create an abstract class CourseType (e.g., ExamCourse, AssignmentCourse).
      * Implement a generic class Course<T> where T : CourseType to manage different courses.
      * Use List<T> to handle any type of course dynamically.
using System;
using System.Collections.Generic;

// Step 1: Define an abstract base class for course types
public abstract class CourseType
{
   public string EvaluationMethod { get; set; }
   public CourseType(string evaluationMethod)
   {
       EvaluationMethod = evaluationMethod;
   }
}

public class ExamCourse : CourseType
{
   public ExamCourse() : base("Written Exam") { }
}

public class AssignmentCourse : CourseType
{
   public AssignmentCourse() : base("Assignments and Projects") { }
}

// Step 2: Implement a generic Course class
public class Course<T> where T : CourseType
{
   public string CourseName { get; set; }
   public string Department { get; set; }
   public T CourseEvaluation { get; set; }

   public Course(string courseName, string department, T courseEvaluation)
   {
       CourseName = courseName;
       Department = department;
       CourseEvaluation = courseEvaluation;
   }

   public override string ToString()
   {
       return $"Course: {CourseName} | Department: {Department} | Evaluation: {CourseEvaluation.EvaluationMethod}";
   }
}

// Step 3: Manage courses dynamically using List<T>
class UniversityCourseManager
{
   private List<BaseCourse> courses = new List<BaseCourse>();

   public void AddCourse<T>(Course<T> course) where T : CourseType
   {
       courses.Add(new BaseCourse(course.CourseName, course.Department, course.CourseEvaluation.EvaluationMethod));
   }

   public void DisplayCourses()
   {
       if (courses.Count == 0)
       {
           Console.WriteLine("No courses available.");
           return;
       }

       Console.WriteLine("Available Courses:");
       foreach (var course in courses)
       {
           Console.WriteLine(course);
       }
   }
}

// Step 4: Define a non-generic base class for storing courses
public class BaseCourse
{
   public string CourseName { get; set; }
   public string Department { get; set; }
   public string EvaluationMethod { get; set; }

   public BaseCourse(string courseName, string department, string evaluationMethod)
   {
       CourseName = courseName;
       Department = department;
       EvaluationMethod = evaluationMethod;
   }

   public override string ToString()
   {
       return $"{CourseName} - {Department} - {EvaluationMethod}";
   }
}

// Step 5: Test the system
class Program
{
   static void Main()
   {
       UniversityCourseManager courseManager = new UniversityCourseManager();

       Course<ExamCourse> mathCourse = new Course<ExamCourse>("Mathematics 101", "Science", new ExamCourse());
       Course<AssignmentCourse> csCourse = new Course<AssignmentCourse>("Intro to Programming", "Computer Science", new AssignmentCourse());

       courseManager.AddCourse(mathCourse);
       courseManager.AddCourse(csCourse);

       courseManager.DisplayCourses();
   }
}
	



4. Personalized Meal Plan Generator
   * Concepts: Generic Methods, Constraints, Interfaces
   * Problem Statement: Design a system where users can choose different meal categories like Vegetarian, Vegan, Keto, or High-Protein.
   * Hints: 
      * Define an interface IMealPlan with subtypes (VegetarianMeal, VeganMeal).
      * Implement a generic class Meal<T> where T : IMealPlan.
      * Use a generic method to validate and generate meal plans dynamically.
using System;
using System.Collections.Generic;

// Step 1: Define the IMealPlan interface
public interface IMealPlan
{
   string GetMealType();
}

// Step 2: Implement specific meal categories
public class VegetarianMeal : IMealPlan
{
   public string GetMealType() => "Vegetarian Meal";
}

public class VeganMeal : IMealPlan
{
   public string GetMealType() => "Vegan Meal";
}

public class KetoMeal : IMealPlan
{
   public string GetMealType() => "Keto Meal";
}

public class HighProteinMeal : IMealPlan
{
   public string GetMealType() => "High-Protein Meal";
}

// Step 3: Create a generic Meal class
public class Meal<T> where T : IMealPlan
{
   public string MealName { get; set; }
   public T MealType { get; set; }

   public Meal(string mealName, T mealType)
   {
       MealName = mealName;
       MealType = mealType;
   }

   public override string ToString()
   {
       return $"Meal: {MealName} | Type: {MealType.GetMealType()}";
   }
}

// Step 4: Manage meal plans dynamically
public class MealPlanManager
{
   private List<IMealPlan> meals = new List<IMealPlan>();

   public void AddMeal<T>(Meal<T> meal) where T : IMealPlan
   {
       meals.Add(meal.MealType);
   }

   public void DisplayMeals()
   {
       if (meals.Count == 0)
       {
           Console.WriteLine("No meals available.");
           return;
       }

       Console.WriteLine("Available Meal Plans:");
       foreach (var meal in meals)
       {
           Console.WriteLine(meal.GetMealType());
       }
   }
}

// Step 5: Test the system
class Program
{
   static void Main()
   {
       MealPlanManager mealManager = new MealPlanManager();

       // Create meal instances
       Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal>("Green Delight", new VegetarianMeal());
       Meal<VeganMeal> veganMeal = new Meal<VeganMeal>("Plant Power", new VeganMeal());
       Meal<KetoMeal> ketoMeal = new Meal<KetoMeal>("Keto Boost", new KetoMeal());
       Meal<HighProteinMeal> proteinMeal = new Meal<HighProteinMeal>("Protein Punch", new HighProteinMeal());

       // Add meals to the meal manager
       mealManager.AddMeal(vegMeal);
       mealManager.AddMeal(veganMeal);
       mealManager.AddMeal(ketoMeal);
       mealManager.AddMeal(proteinMeal);

       // Display all available meals
       mealManager.DisplayMeals();
   }
}
	





5. AI-Driven Resume Screening System
   * Concepts: Generic Classes, Generic Methods, Constraints
   * Problem Statement: Develop a resume screening system that can process resumes for different job roles while ensuring type safety.
   * Hints: 
      * Create an abstract class JobRole (SoftwareEngineer, DataScientist).
      * Implement a generic class Resume<T> where T : JobRole to process resumes dynamically.
      * Use List<T> to handle multiple job roles in the screening pipeline.
using System;
using System.Collections.Generic;

// Step 1: Define an abstract JobRole class
public abstract class JobRole
{
   public string RoleName { get; set; }
   public JobRole(string roleName)
   {
       RoleName = roleName;
   }

   public abstract string GetRequiredSkills();
}

// Step 2: Implement specific job roles
public class SoftwareEngineer : JobRole
{
   public SoftwareEngineer() : base("Software Engineer") { }

   public override string GetRequiredSkills()
   {
       return "C#, .NET, SQL, Problem-Solving";
   }
}

public class DataScientist : JobRole
{
   public DataScientist() : base("Data Scientist") { }

   public override string GetRequiredSkills()
   {
       return "Python, Machine Learning, Statistics, SQL";
   }
}

// Step 3: Create a generic Resume class
public class Resume<T> where T : JobRole
{
   public string CandidateName { get; set; }
   public int ExperienceYears { get; set; }
   public T AppliedRole { get; set; }

   public Resume(string candidateName, int experienceYears, T appliedRole)
   {
       CandidateName = candidateName;
       ExperienceYears = experienceYears;
       AppliedRole = appliedRole;
   }

   public override string ToString()
   {
       return $"Candidate: {CandidateName} | Experience: {ExperienceYears} years | Role: {AppliedRole.RoleName} | Required Skills: {AppliedRole.GetRequiredSkills()}";
   }
}

// Step 4: Manage resumes dynamically
public class ResumeScreeningManager
{
   private List<object> resumes = new List<object>();

   public void AddResume<T>(Resume<T> resume) where T : JobRole
   {
       resumes.Add(resume);
   }

   public void DisplayResumes()
   {
       if (resumes.Count == 0)
       {
           Console.WriteLine("No resumes available.");
           return;
       }

       Console.WriteLine("Screened Resumes:");
       foreach (var resume in resumes)
       {
           Console.WriteLine(resume);
       }
   }
}

// Step 5: Test the system
class Program
{
   static void Main()
   {
       ResumeScreeningManager screeningManager = new ResumeScreeningManager();

       // Create resumes for different job roles
       Resume<SoftwareEngineer> seResume = new Resume<SoftwareEngineer>("Alice Johnson", 5, new SoftwareEngineer());
       Resume<DataScientist> dsResume = new Resume<DataScientist>("Bob Smith", 3, new DataScientist());

       // Add resumes to the screening manager
       screeningManager.AddResume(seResume);
       screeningManager.AddResume(dsResume);

       // Display all screened resumes
       screeningManager.DisplayResumes();
   }
}