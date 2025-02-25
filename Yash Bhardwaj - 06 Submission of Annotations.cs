Exercise 1: Use Method Overriding Correctly
Problem Statement: Create a parent class Animal with a method MakeSound(). Then, create a Dog class that overrides this method using override.
Steps to Follow:
1. Define a MakeSound() method in the Animal class.
2. Override it in the Dog class with override.
3. Instantiate Dog and call MakeSound().
using System;

// Parent class
public class Animal
{
   // Virtual method to allow overriding
   public virtual void MakeSound()
   {
       Console.WriteLine("Animal makes a sound");
   }
}

// Child class that overrides the method
public class Dog : Animal
{
   // Override the MakeSound() method
   public override void MakeSound()
   {
       Console.WriteLine("Dog barks: Woof! Woof!");
   }
}

// Main program
public class Program
{
   public static void Main(string[] args)
   {
       Animal myAnimal = new Animal();
       myAnimal.MakeSound();  // Calls the Animal version

       Dog myDog = new Dog();
       myDog.MakeSound();  // Calls the overridden Dog version
   }
}
	



________________


Exercise 2: Use Obsolete Attribute to Mark an Old Method
Problem Statement: Create a class LegacyAPI with an old method OldFeature(), which should not be used anymore. Instead, introduce a new method NewFeature().
Steps to Follow:
1. Define a class LegacyAPI.
2. Mark OldFeature() as [Obsolete].
3. Call both methods and observe the warning.
using System;

public class LegacyAPI
{
   // Marking OldFeature() as Obsolete
   [Obsolete("OldFeature() is deprecated. Use NewFeature() instead.")]
   public void OldFeature()
   {
       Console.WriteLine("This is the old feature. It should not be used.");
   }

   // New method replacing the old one
   public void NewFeature()
   {
       Console.WriteLine("This is the new and improved feature.");
   }
}

public class Program
{
   public static void Main(string[] args)
   {
       LegacyAPI api = new LegacyAPI();

       // Calling the old method (Will show a warning)
       api.OldFeature();

       // Calling the new method
       api.NewFeature();
   }
}
	



________________


Exercise 3: Suppress Warnings for Unchecked Operations
Problem Statement: Create an ArrayList without generics and use #pragma warning disables to hide compilation warnings.
using System;
using System.Collections;

public class Program
{
   public static void Main(string[] args)
   {
       #pragma warning disable CS8602 // Disables "Dereference of a possibly null reference" warning

       // Creating an ArrayList without generics
       ArrayList list = new ArrayList();
       list.Add(10);
       list.Add("Hello");
       list.Add(3.14);

       // Displaying values
       foreach (var item in list)
       {
           Console.WriteLine(item);
       }

       #pragma warning restore CS8602 // Re-enables the warning after usage
   }
}
	



________________


Exercise 4: Create a Custom Attribute and Use It
Problem Statement: Create a custom attribute TaskInfo to mark tasks with priority and assigned person.
Steps to Follow:
1. Define an attribute TaskInfo with fields Priority and AssignedTo.
2. Apply this attribute to a method in TaskManager class.
3. Retrieve the attribute details using Reflection.
using System;
using System.Reflection;

// Step 1: Define a custom attribute with Priority and AssignedTo
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TaskInfoAttribute : Attribute
{
   public int Priority { get; }
   public string AssignedTo { get; }

   public TaskInfoAttribute(int priority, string assignedTo)
   {
       Priority = priority;
       AssignedTo = assignedTo;
   }
}

// Step 2: Apply the custom attribute to a method
public class TaskManager
{
   [TaskInfo(1, "Alice")]
   public void CompleteTask()
   {
       Console.WriteLine("Task completed!");
   }
}

// Step 3: Retrieve attribute details using Reflection
public class Program
{
   public static void Main(string[] args)
   {
       Type type = typeof(TaskManager);
       MethodInfo method = type.GetMethod("CompleteTask");

       if (method != null)
       {
           TaskInfoAttribute attribute = (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

           if (attribute != null)
           {
               Console.WriteLine($"Task Priority: {attribute.Priority}");
               Console.WriteLine($"Assigned To: {attribute.AssignedTo}");
           }
       }

       // Call the method
       TaskManager taskManager = new TaskManager();
       taskManager.CompleteTask();
   }
}
	



________________




Exercise 5: Create and Use a Repeatable Attribute
Problem Statement: Define an attribute BugReport that can be applied multiple times on a method.
Steps to Follow:
1. Define BugReport with a Description field.
2. Use AllowMultiple = true to allow multiple bug reports.
3. Apply it twice on a method.
4. Retrieve and print all bug reports.
using System;
using System.Reflection;

// Step 1: Define a repeatable attribute with a Description field
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
   public string Description { get; }

   public BugReportAttribute(string description)
   {
       Description = description;
   }
}

// Step 2: Apply the attribute multiple times on a method
public class Software
{
   [BugReport("Bug #101: Null reference exception occurs.")]
   [BugReport("Bug #102: Performance issue with large datasets.")]
   public void ProcessData()
   {
       Console.WriteLine("Processing data...");
   }
}

// Step 3: Retrieve and print all bug reports using Reflection
public class Program
{
   public static void Main(string[] args)
   {
       Type type = typeof(Software);
       MethodInfo method = type.GetMethod("ProcessData");

       if (method != null)
       {
           // Retrieve all BugReport attributes
           object[] attributes = method.GetCustomAttributes(typeof(BugReportAttribute), false);

           Console.WriteLine("Bug Reports:");
           foreach (BugReportAttribute bug in attributes)
           {
               Console.WriteLine($"- {bug.Description}");
           }
       }

       // Execute the method
       Software software = new Software();
       software.ProcessData();
   }
}
	



________________


Practice Problems for Custom Attributes in C#
Beginner Level
1️⃣ Create an Attribute to Mark Important Methods
Problem Statement: Define a custom attribute ImportantMethod that can be applied to methods to indicate their importance.
Requirements:
1. Define ImportantMethod with an optional Level parameter (default: "HIGH").
2. Apply it to at least two methods.
3. Retrieve and print annotated methods using Reflection.
using System;
using System.Reflection;

// Step 1: Define the ImportantMethod attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ImportantMethodAttribute : Attribute
{
   public string Level { get; }

   // Constructor with default level as "HIGH"
   public ImportantMethodAttribute(string level = "HIGH")
   {
       Level = level;
   }
}

// Step 2: Apply the attribute to important methods
public class SystemOperations
{
   [ImportantMethod] // Default level is "HIGH"
   public void CriticalTask()
   {
       Console.WriteLine("Executing a critical task...");
   }

   [ImportantMethod("MEDIUM")]
   public void RoutineCheck()
   {
       Console.WriteLine("Performing a routine check...");
   }

   public void NormalTask()
   {
       Console.WriteLine("This is a normal task with no special importance.");
   }
}

// Step 3: Retrieve and print annotated methods using Reflection
public class Program
{
   public static void Main(string[] args)
   {
       Type type = typeof(SystemOperations);
       MethodInfo[] methods = type.GetMethods();

       Console.WriteLine("Important Methods:");
       foreach (MethodInfo method in methods)
       {
           ImportantMethodAttribute attribute = (ImportantMethodAttribute)Attribute.GetCustomAttribute(method, typeof(ImportantMethodAttribute));
           
           if (attribute != null)
           {
               Console.WriteLine($"- {method.Name} (Level: {attribute.Level})");
           }
       }

       // Call methods to show functionality
       SystemOperations operations = new SystemOperations();
       operations.CriticalTask();
       operations.RoutineCheck();
       operations.NormalTask();
   }
}
	



________________


2️⃣ Create a Todo Attribute for Pending Tasks
Problem Statement: Define an attribute Todo to mark pending features in a project.
Requirements:
* The attribute should have fields: 
   * Task (string) → Description of the task
   * AssignedTo (string) → Developer responsible
   * Priority (default: "MEDIUM")
* Apply it to multiple methods.
* Retrieve and print all pending tasks using Reflection.
using System;
using System.Reflection;

// Step 1: Define the Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TodoAttribute : Attribute
{
   public string Task { get; }
   public string AssignedTo { get; }
   public string Priority { get; }

   // Constructor with default priority as "MEDIUM"
   public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
   {
       Task = task;
       AssignedTo = assignedTo;
       Priority = priority;
   }
}

// Step 2: Apply the Todo attribute to multiple methods
public class Project
{
   [Todo("Implement login feature", "Alice", "HIGH")]
   [Todo("Fix security vulnerability", "Bob", "CRITICAL")]
   public void Authentication()
   {
       Console.WriteLine("Authentication module.");
   }

   [Todo("Optimize database queries", "Charlie")]
   public void DataProcessing()
   {
       Console.WriteLine("Data processing module.");
   }

   public void CompletedFeature()
   {
       Console.WriteLine("This feature is already completed.");
   }
}

// Step 3: Retrieve and print all pending tasks using Reflection
public class Program
{
   public static void Main(string[] args)
   {
       Type type = typeof(Project);
       MethodInfo[] methods = type.GetMethods();

       Console.WriteLine("Pending Tasks:");
       foreach (MethodInfo method in methods)
       {
           object[] attributes = method.GetCustomAttributes(typeof(TodoAttribute), false);

           foreach (TodoAttribute todo in attributes)
           {
               Console.WriteLine($"- {method.Name}: {todo.Task} (Assigned to: {todo.AssignedTo}, Priority: {todo.Priority})");
           }
       }

       // Call a method to show functionality
       Project project = new Project();
       project.Authentication();
       project.DataProcessing();
       project.CompletedFeature();
   }
}
	



________________


Intermediate Level
3️⃣ Create an Attribute for Logging Method Execution Time
Problem Statement: Define an attribute LogExecutionTime to measure method execution time.
Requirements:
* Apply LogExecutionTime to a method.
* Use Stopwatch before and after execution.
* Print execution time.
* Apply it to different methods and compare the time taken.
using System;
using System.Diagnostics;
using System.Reflection;

// Step 1: Define the LogExecutionTime attribute
[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
}

// Step 2: Define a helper to execute methods and log execution time
public class MethodTimer
{
   public static void ExecuteWithTiming(object obj, string methodName)
   {
       MethodInfo method = obj.GetType().GetMethod(methodName);
       if (method == null)
       {
           Console.WriteLine($"Method {methodName} not found.");
           return;
       }

       // Check if the method has the LogExecutionTime attribute
       if (Attribute.IsDefined(method, typeof(LogExecutionTimeAttribute)))
       {
           Stopwatch stopwatch = Stopwatch.StartNew();
           method.Invoke(obj, null);
           stopwatch.Stop();

           Console.WriteLine($"Execution time for {methodName}: {stopwatch.ElapsedMilliseconds} ms");
       }
       else
       {
           method.Invoke(obj, null);
       }
   }
}

// Step 3: Apply LogExecutionTime to different methods
public class Operations
{
   [LogExecutionTime]
   public void FastOperation()
   {
       for (int i = 0; i < 1000; i++) ; // Simulate a quick task
       Console.WriteLine("Fast operation completed.");
   }

   [LogExecutionTime]
   public void SlowOperation()
   {
       System.Threading.Thread.Sleep(500); // Simulate a slow task
       Console.WriteLine("Slow operation completed.");
   }

   public void NormalOperation()
   {
       Console.WriteLine("Normal operation executed.");
   }
}

// Step 4: Test and compare execution times
public class Program
{
   public static void Main(string[] args)
   {
       Operations ops = new Operations();

       MethodTimer.ExecuteWithTiming(ops, "FastOperation");
       MethodTimer.ExecuteWithTiming(ops, "SlowOperation");
       MethodTimer.ExecuteWithTiming(ops, "NormalOperation");
   }
}
	



________________


4️⃣ Create a MaxLength Attribute for Field Validation
Problem Statement: Define a field-level attribute MaxLength(int value) that restricts the maximum length of a string field.
Requirements:
* Apply it to a User class field (Username).
* Validate length in the constructor.
* Throw ArgumentException if the limit is exceeded.
using System;
using System.Reflection;

// Step 1: Define the MaxLength attribute
[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
   public int Length { get; }

   public MaxLengthAttribute(int length)
   {
       Length = length;
   }
}

// Step 2: Apply MaxLength to a field in the User class
public class User
{
   [MaxLength(10)] // Restricting username length to 10 characters
   public string Username { get; private set; }

   public User(string username)
   {
       ValidateMaxLength(this, nameof(Username), username);
       Username = username;
   }

   private void ValidateMaxLength(object obj, string propertyName, string value)
   {
       PropertyInfo property = obj.GetType().GetProperty(propertyName);
       if (property != null)
       {
           MaxLengthAttribute attribute = (MaxLengthAttribute)Attribute.GetCustomAttribute(property, typeof(MaxLengthAttribute));
           if (attribute != null && value.Length > attribute.Length)
           {
               throw new ArgumentException($"Error: {propertyName} exceeds max length of {attribute.Length} characters.");
           }
       }
   }
}

// Step 3: Test the validation
public class Program
{
   public static void Main(string[] args)
   {
       try
       {
           User user1 = new User("JohnDoe");  // Valid
           Console.WriteLine($"User created: {user1.Username}");

           User user2 = new User("VeryLongUsername");  // Invalid, exceeds 10 characters
           Console.WriteLine($"User created: {user2.Username}");
       }
       catch (Exception ex)
       {
           Console.WriteLine(ex.Message);
       }
   }
}

	

________________


Advanced Level
5️⃣ Implement Role-Based Access Control with RoleAllowed
Problem Statement: Define a class-level attribute RoleAllowed to restrict method access based on roles.
Requirements:
* [RoleAllowed("ADMIN")] should only allow ADMIN users to execute the method.
* Simulate user roles and validate access before invoking the method.
* If a non-admin tries to access it, print Access Denied!
using System;
using System.Reflection;

// Step 1: Define the RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method)]
public class RoleAllowedAttribute : Attribute
{
   public string Role { get; }

   public RoleAllowedAttribute(string role)
   {
       Role = role;
   }
}

// Step 2: Define a User class to store the current user role
public class User
{
   public string Role { get; }

   public User(string role)
   {
       Role = role;
   }
}

// Step 3: Define a SecureService with restricted methods
public class SecureService
{
   [RoleAllowed("ADMIN")]
   public void AdminTask()
   {
       Console.WriteLine("Admin task executed successfully!");
   }

   [RoleAllowed("USER")]
   public void UserTask()
   {
       Console.WriteLine("User task executed successfully!");
   }

   public void OpenTask()
   {
       Console.WriteLine("Open task executed. No role restriction.");
   }
}

// Step 4: Implement Role-Based Access Control (RBAC)
public class RoleValidator
{
   public static void ExecuteIfAuthorized(object obj, string methodName, User user)
   {
       MethodInfo method = obj.GetType().GetMethod(methodName);
       if (method == null)
       {
           Console.WriteLine($"Method {methodName} not found.");
           return;
       }

       // Check if the method has the RoleAllowed attribute
       RoleAllowedAttribute roleAttribute = (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));

       if (roleAttribute == null || roleAttribute.Role == user.Role)
       {
           method.Invoke(obj, null);
       }
       else
       {
           Console.WriteLine($"Access Denied! {user.Role} role is not allowed to access {methodName}.");
       }
   }
}

// Step 5: Test with different user roles
public class Program
{
   public static void Main(string[] args)
   {
       SecureService service = new SecureService();
       User adminUser = new User("ADMIN");
       User normalUser = new User("USER");
       User guestUser = new User("GUEST");

       Console.WriteLine("\nAdmin User Access:");
       RoleValidator.ExecuteIfAuthorized(service, "AdminTask", adminUser);  //  Allowed
       RoleValidator.ExecuteIfAuthorized(service, "UserTask", adminUser);   //  Denied

       Console.WriteLine("\nNormal User Access:");
       RoleValidator.ExecuteIfAuthorized(service, "AdminTask", normalUser); //  Denied
       RoleValidator.ExecuteIfAuthorized(service, "UserTask", normalUser);  //  Allowed

       Console.WriteLine("\nGuest User Access:");
       RoleValidator.ExecuteIfAuthorized(service, "AdminTask", guestUser);  // Denied
       RoleValidator.ExecuteIfAuthorized(service, "UserTask", guestUser);   //  Denied
       RoleValidator.ExecuteIfAuthorized(service, "OpenTask", guestUser);   // Allowed (no restriction)
   }
}
	



________________




6️⃣ Implement a Custom Serialization Attribute JsonField
Problem Statement: Define an attribute JsonField to mark fields for JSON serialization.
Requirements:
* [JsonField(Name = "user_name")] should map field names to custom JSON keys.
* Apply it on a User class.
* Write a method to convert an object to a JSON string by reading the attributes.
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

// Step 1: Define the JsonField attribute
[AttributeUsage(AttributeTargets.Property)]
public class JsonFieldAttribute : Attribute
{
   public string Name { get; }

   public JsonFieldAttribute(string name)
   {
       Name = name;
   }
}

// Step 2: Create a User class with JsonField attributes
public class User
{
   [JsonField(Name = "user_name")]
   public string Username { get; set; }

   [JsonField(Name = "user_email")]
   public string Email { get; set; }

   [JsonField(Name = "user_age")]
   public int Age { get; set; }

   public string Country { get; set; } // No attribute, will not be serialized
}

// Step 3: Implement a method to convert an object to a JSON string
public static class JsonSerializerHelper
{
   public static string SerializeToJson(object obj)
   {
       Dictionary<string, object> jsonData = new Dictionary<string, object>();

       PropertyInfo[] properties = obj.GetType().GetProperties();
       foreach (PropertyInfo property in properties)
       {
           JsonFieldAttribute attribute = (JsonFieldAttribute)Attribute.GetCustomAttribute(property, typeof(JsonFieldAttribute));
           if (attribute != null)
           {
               jsonData[attribute.Name] = property.GetValue(obj);
           }
       }

       return JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });
   }
}

// Step 4: Test serialization
public class Program
{
   public static void Main(string[] args)
   {
       User user = new User
       {
           Username = "JohnDoe",
           Email = "john.doe@example.com",
           Age = 30,
           Country = "USA" // This field is ignored in JSON output
       };

       string jsonOutput = JsonSerializerHelper.SerializeToJson(user);
       Console.WriteLine(jsonOutput);
   }
}
	



________________


7️⃣ Implement a Custom Caching System with CacheResult
Problem Statement: Define CacheResult to store method return values and avoid repeated execution.
Requirements:
* Apply CacheResult to a computationally expensive method.
* Implement a cache (Dictionary) to store previously computed results.
* If a method is called with the same input, return the cached result instead of recomputation.
using System;
using System.Collections.Generic;
using System.Reflection;

// Step 1: Define the CacheResult attribute
[AttributeUsage(AttributeTargets.Method)]
public class CacheResultAttribute : Attribute { }

// Step 2: Implement a caching mechanism
public class MethodCache
{
   private static readonly Dictionary<string, object> cache = new Dictionary<string, object>();

   public static object InvokeWithCache(object instance, string methodName, params object[] parameters)
   {
       MethodInfo method = instance.GetType().GetMethod(methodName);
       if (method == null)
       {
           throw new ArgumentException($"Method {methodName} not found.");
       }

       // Check if the method has CacheResult attribute
       if (method.GetCustomAttribute(typeof(CacheResultAttribute)) == null)
       {
           return method.Invoke(instance, parameters);
       }

       // Generate a cache key based on method name and parameters
       string key = methodName + "_" + string.Join("_", parameters);
       if (cache.ContainsKey(key))
       {
           Console.WriteLine($"[CACHE HIT] Returning cached result for {methodName}({string.Join(", ", parameters)})");
           return cache[key];
       }

       Console.WriteLine($"[CACHE MISS] Computing result for {methodName}({string.Join(", ", parameters)})");
       object result = method.Invoke(instance, parameters);
       cache[key] = result; // Store result in cache
       return result;
   }
}

// Step 3: Create a class with a computationally expensive method
public class MathOperations
{
   [CacheResult]
   public int ExpensiveComputation(int number)
   {
       // Simulating an expensive computation
       Console.WriteLine($"Performing heavy computation for {number}...");
       System.Threading.Thread.Sleep(2000); // Simulate delay
       return number * number;
   }
}

// Step 4: Test caching mechanism
public class Program
{
   public static void Main(string[] args)
   {
       MathOperations math = new MathOperations();

       // First call (computation happens)
       Console.WriteLine("Result: " + MethodCache.InvokeWithCache(math, "ExpensiveComputation", 5));

       // Second call with the same input (should return cached result)
       Console.WriteLine("Result: " + MethodCache.InvokeWithCache(math, "ExpensiveComputation", 5));

       // Call with a different input (computation happens)
       Console.WriteLine("Result: " + MethodCache.InvokeWithCache(math, "ExpensiveComputation", 10));
   }
}