Practice Problems on Reflection in C#
🔹 Basic Level
1. Get Class Information: Write a program to accept a class name as input and display its methods, fields, and constructors using Reflection.
using System;
using System.Reflection;

public class SampleClass
{
   public int Id;
   public string Name { get; set; }

   public SampleClass() { }
   public SampleClass(int id, string name) { Id = id; Name = name; }

   public void Display() => Console.WriteLine($"Id: {Id}, Name: {Name}");
}

public class Program
{
   public static void Main(string[] args)
   {
       Console.Write("Enter class name: ");
       string className = Console.ReadLine();

       Type type = Type.GetType(className);
       if (type != null)
       {
           Console.WriteLine("\nMethods:");
           foreach (var method in type.GetMethods()) Console.WriteLine(method.Name);

           Console.WriteLine("\nFields:");
           foreach (var field in type.GetFields()) Console.WriteLine(field.Name);

           Console.WriteLine("\nConstructors:");
           foreach (var constructor in type.GetConstructors()) Console.WriteLine(constructor);
       }
       else
       {
           Console.WriteLine("Class not found!");
       }
   }
}
	



2. Access Private Field: Create a class Person with a private field age. Use Reflection to modify and retrieve its value.
using System;
using System.Reflection;

public class Person
{
   private int age = 25;
}

public class Program
{
   public static void Main()
   {
       Person person = new Person();
       Type type = typeof(Person);

       FieldInfo fieldInfo = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
       fieldInfo.SetValue(person, 30); // Modify value

       Console.WriteLine("Updated Age: " + fieldInfo.GetValue(person));
   }
}
	

 
3. Invoke Private Method: Define a class Calculator with a private method Multiply(int a, int b). Use Reflection to invoke this method and display the result. 
using System;
using System.Reflection;

public class Calculator
{
   private int Multiply(int a, int b) => a * b;
}

public class Program
{
   public static void Main()
   {
       Calculator calc = new Calculator();
       Type type = typeof(Calculator);

       MethodInfo methodInfo = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
       object result = methodInfo.Invoke(calc, new object[] { 5, 4 });

       Console.WriteLine("Multiplication Result: " + result);
   }
}
	



4. Dynamically Create Objects: Write a program to create an instance of a Student class dynamically using Reflection without using the new keyword.
using System;

public class Student
{
   public string Name { get; set; }
   public int Age { get; set; }

   public Student() { }
   public void Show() => Console.WriteLine($"Student: {Name}, Age: {Age}");
}

public class Program
{
   public static void Main()
   {
       Type type = typeof(Student);
       object studentInstance = Activator.CreateInstance(type);

       type.GetProperty("Name").SetValue(studentInstance, "Alice");
       type.GetProperty("Age").SetValue(studentInstance, 22);

       type.GetMethod("Show").Invoke(studentInstance, null);
   }
}
	



🔹 Intermediate Level
5. Dynamic Method Invocation: Define a class MathOperations with multiple public methods (Add, Subtract, Multiply). Use Reflection to dynamically call any method based on user input. 
using System;
using System.Reflection;

public class MathOperations
{
   public int Add(int a, int b) => a + b;
   public int Subtract(int a, int b) => a - b;
   public int Multiply(int a, int b) => a * b;
}

public class Program
{
   public static void Main()
   {
       MathOperations math = new MathOperations();
       Type type = typeof(MathOperations);

       Console.Write("Enter method name (Add/Subtract/Multiply): ");
       string methodName = Console.ReadLine();

       MethodInfo method = type.GetMethod(methodName);
       if (method != null)
       {
           object result = method.Invoke(math, new object[] { 10, 5 });
           Console.WriteLine($"Result: {result}");
       }
       else
       {
           Console.WriteLine("Invalid method name!");
       }
   }
}
	



6. Retrieve Attributes at Runtime: Create a custom attribute [Author("Author Name")]. Apply it to a class and use Reflection to retrieve and display the attribute value at runtime. 
using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
   public string Name { get; }
   public AuthorAttribute(string name) => Name = name;
}

// Step 2: Apply the attribute to a class
[Author("John Doe")]
public class SampleClass { }

public class Program
{
   public static void Main()
   {
       Type type = typeof(SampleClass);
       AuthorAttribute attr = (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));

       if (attr != null)
       {
           Console.WriteLine($"Author: {attr.Name}");
       }
       else
       {
           Console.WriteLine("No Author Attribute found.");
       }
   }
}
	



7. Access and Modify Static Fields: Create a Configuration class with a private static field API_KEY. Use Reflection to modify its value and print it.
using System;
using System.Reflection;

public class Configuration
{
   private static string API_KEY = "DEFAULT_KEY";
}

public class Program
{
   public static void Main()
   {
       Type type = typeof(Configuration);
       FieldInfo fieldInfo = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

       // Modify the API_KEY value
       fieldInfo.SetValue(null, "NEW_SECRET_KEY");

       // Retrieve and print the modified value
       string updatedKey = (string)fieldInfo.GetValue(null);
       Console.WriteLine($"Updated API_KEY: {updatedKey}");
   }
}
	



🔹 Advanced Level
1. Create a Custom Object Mapper: Implement a method ToObject<T>(Type clazz, Dictionary<string, object> properties) that uses Reflection to set field values from a given dictionary. 
using System;
using System.Collections.Generic;
using System.Reflection;

public class ObjectMapper
{
   public static T ToObject<T>(Dictionary<string, object> properties) where T : new()
   {
       T obj = new T();
       Type type = typeof(T);

       foreach (var prop in properties)
       {
           PropertyInfo propertyInfo = type.GetProperty(prop.Key);
           if (propertyInfo != null && propertyInfo.CanWrite)
           {
               propertyInfo.SetValue(obj, Convert.ChangeType(prop.Value, propertyInfo.PropertyType));
           }
       }
       return obj;
   }
}

public class User
{
   public string Name { get; set; }
   public int Age { get; set; }
}

public class Program
{
   public static void Main()
   {
       var properties = new Dictionary<string, object>
       {
           { "Name", "Alice" },
           { "Age", 25 }
       };

       User user = ObjectMapper.ToObject<User>(properties);
       Console.WriteLine($"User: {user.Name}, Age: {user.Age}");
   }
}
	



2. Generate a JSON Representation: Write a program that converts an object to a JSON-like string using Reflection by inspecting its fields and values. 
using System;
using System.Text;
using System.Reflection;

public class JsonConverter
{
   public static string ToJson(object obj)
   {
       Type type = obj.GetType();
       StringBuilder json = new StringBuilder("{");

       PropertyInfo[] properties = type.GetProperties();
       for (int i = 0; i < properties.Length; i++)
       {
           var prop = properties[i];
           var value = prop.GetValue(obj);
           json.Append($"\"{prop.Name}\": \"{value}\"");

           if (i < properties.Length - 1) json.Append(", ");
       }
       json.Append("}");
       return json.ToString();
   }
}

public class Person
{
   public string Name { get; set; }
   public int Age { get; set; }
}

public class Program
{
   public static void Main()
   {
       Person person = new Person { Name = "John", Age = 30 };
       string json = JsonConverter.ToJson(person);
       Console.WriteLine(json);
   }
}
	



3. Custom Logging Proxy Using Reflection: Implement a Dynamic Proxy that intercepts method calls on an interface (e.g., IGreeting.SayHello()) and logs the method name before executing it. 
using System;
using System.Reflection;

public interface IGreeting
{
   void SayHello(string name);
}

public class Greeting : IGreeting
{
   public void SayHello(string name)
   {
       Console.WriteLine($"Hello, {name}!");
   }
}

public class LoggingProxy : DispatchProxy
{
   private IGreeting _target;

   public static IGreeting Create(IGreeting target)
   {
       var proxy = Create<IGreeting, LoggingProxy>();
       ((LoggingProxy)proxy)._target = target;
       return proxy;
   }

   protected override object Invoke(MethodInfo targetMethod, object[] args)
   {
       Console.WriteLine($"[LOG] Calling: {targetMethod.Name}");
       return targetMethod.Invoke(_target, args);
   }
}

public class Program
{
   public static void Main()
   {
       IGreeting greeting = LoggingProxy.Create(new Greeting());
       greeting.SayHello("Alice");
   }
}
	



4. Dependency Injection using Reflection: Implement a simple DI container that scans classes with [Inject] attribute and injects dependencies dynamically. 
using System;
using System.Linq;
using System.Reflection;

[AttributeUsage(AttributeTargets.Constructor)]
public class InjectAttribute : Attribute { }

public class Container
{
   public static T Resolve<T>()
   {
       ConstructorInfo constructor = typeof(T).GetConstructors()
           .FirstOrDefault(c => c.GetCustomAttribute<InjectAttribute>() != null);

       if (constructor == null) throw new Exception("No Inject constructor found");

       ParameterInfo[] parameters = constructor.GetParameters();
       object[] dependencies = parameters.Select(p => Activator.CreateInstance(p.ParameterType)).ToArray();

       return (T)constructor.Invoke(dependencies);
   }
}

public class ServiceA { public void Run() => Console.WriteLine("ServiceA Running!"); }
public class ServiceB { public void Execute() => Console.WriteLine("ServiceB Executing!"); }

public class App
{
   private readonly ServiceA _serviceA;
   private readonly ServiceB _serviceB;

   [Inject]
   public App(ServiceA serviceA, ServiceB serviceB)
   {
       _serviceA = serviceA;
       _serviceB = serviceB;
   }

   public void Start()
   {
       _serviceA.Run();
       _serviceB.Execute();
   }
}

public class Program
{
   public static void Main()
   {
       App app = Container.Resolve<App>();
       app.Start();
   }
}
	



5. Method Execution Timing: Use Reflection to measure the execution time of methods in a given class dynamically.
using System;
using System.Diagnostics;
using System.Reflection;

public class MethodTimer
{
   public static void MeasureExecutionTime(object instance, string methodName, object[] parameters)
   {
       Type type = instance.GetType();
       MethodInfo method = type.GetMethod(methodName);

       if (method != null)
       {
           Stopwatch stopwatch = Stopwatch.StartNew();
           method.Invoke(instance, parameters);
           stopwatch.Stop();

           Console.WriteLine($"{methodName} executed in {stopwatch.ElapsedMilliseconds} ms");
       }
       else
       {
           Console.WriteLine("Method not found!");
       }
   }
}

public class Operations
{
   public void Compute()
   {
       System.Threading.Thread.Sleep(500); // Simulating work
       Console.WriteLine("Compute method executed!");
   }
}

public class Program
{
   public static void Main()
   {
       Operations ops = new Operations();
       MethodTimer.MeasureExecutionTime(ops, "Compute", null);
   }
}