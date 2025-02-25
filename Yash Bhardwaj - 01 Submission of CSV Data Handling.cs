Practice Problems on CSV Data Handling in C#
Basic Problems
1️⃣ Read a CSV File and Print Data
* Read a CSV file containing student details (ID, Name, Age, Marks).
* Print each record in a structured format.
using System;
using System.IO;

class Program
{
   static void Main()
   {
       string filePath = "students.csv"; // Ensure the file exists in the project directory

       if (File.Exists(filePath))
       {
           string[] lines = File.ReadAllLines(filePath);
           
           Console.WriteLine("Student Details:");
           Console.WriteLine("ID\tName\tAge\tMarks");
           
           for (int i = 1; i < lines.Length; i++) // Skipping the header
           {
               string[] data = lines[i].Split(',');
               Console.WriteLine($"{data[0]}\t{data[1]}\t{data[2]}\t{data[3]}");
           }
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



2️⃣ Write Data to a CSV File
* Create a CSV file with employee details (ID, Name, Department, Salary).
* Write at least 5 records to the file.
using System;
using System.IO;

class Program
{
   static void Main()
   {
       string filePath = "employees.csv";

       string[] employees = {
           "ID,Name,Department,Salary",
           "1,John,IT,60000",
           "2,Alice,HR,50000",
           "3,Bob,Finance,70000",
           "4,Eve,Marketing,55000",
           "5,David,Engineering,75000"
       };

       File.WriteAllLines(filePath, employees);

       Console.WriteLine("Employee data written to employees.csv successfully!");
   }
}
	



3️⃣ Read and Count Rows in a CSV File
* Read a CSV file and count the number of records (excluding the header row).
using System;
using System.IO;
using System.Linq;

class Program
{
   static void Main()
   {
       string filePath = "students.csv"; // Change file name as needed

       if (File.Exists(filePath))
       {
           int rowCount = File.ReadLines(filePath).Skip(1).Count(); // Skipping the header row
           Console.WriteLine($"Total Records (excluding header): {rowCount}");
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



________________


Intermediate Problems
4️⃣ Filter Records from CSV
* Read a CSV file and filter students who have scored more than 80 marks.
* Print only the qualifying records.
using System;
using System.IO;
using System.Linq;

class Program
{
   static void Main()
   {
       string filePath = "students.csv";

       if (File.Exists(filePath))
       {
           var lines = File.ReadAllLines(filePath).Skip(1); // Skipping the header
           Console.WriteLine("Students with Marks > 80:");
           Console.WriteLine("ID\tName\tMarks");

           foreach (var line in lines)
           {
               var data = line.Split(',');
               int marks = int.Parse(data[3]); // Assuming marks are in the 4th column

               if (marks > 80)
               {
                   Console.WriteLine($"{data[0]}\t{data[1]}\t{marks}");
               }
           }
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



5️⃣ Search for a Record in CSV
* Read an employees.csv file and search for an employee by name.
* Print their department and salary.
using System;
using System.IO;
using System.Linq;

class Program
{
   static void Main()
   {
       string filePath = "employees.csv";
       Console.Write("Enter employee name to search: ");
       string searchName = Console.ReadLine();

       if (File.Exists(filePath))
       {
           var lines = File.ReadAllLines(filePath).Skip(1);
           var employee = lines
               .Select(line => line.Split(','))
               .FirstOrDefault(data => data[1].Equals(searchName, StringComparison.OrdinalIgnoreCase));

           if (employee != null)
           {
               Console.WriteLine($"Department: {employee[2]}, Salary: {employee[3]}");
           }
           else
           {
               Console.WriteLine("Employee not found!");
           }
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



6️⃣ Modify a CSV File (Update a Value)
* Read a CSV file and increase the salary of employees from the "IT" department by 10%.
* Save the updated records back to a new CSV file.
using System;
using System.IO;
using System.Linq;
using System.Globalization;

class Program
{
   static void Main()
   {
       string filePath = "employees.csv";
       string newFilePath = "updated_employees.csv";

       if (File.Exists(filePath))
       {
           var lines = File.ReadAllLines(filePath).ToList();
           for (int i = 1; i < lines.Count; i++) // Skip header
           {
               var data = lines[i].Split(',');
               if (data[2] == "IT") // Assuming department is in the 3rd column
               {
                   double salary = double.Parse(data[3], CultureInfo.InvariantCulture);
                   salary *= 1.10; // Increase by 10%
                   data[3] = salary.ToString("F2", CultureInfo.InvariantCulture);
                   lines[i] = string.Join(",", data);
               }
           }

           File.WriteAllLines(newFilePath, lines);
           Console.WriteLine("Salaries updated. Check updated_employees.csv");
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



7️⃣ Sort CSV Records by a Column
* Read a CSV file and sort the records by Salary in descending order.
* Print the top 5 highest-paid employees.
using System;
using System.IO;
using System.Linq;
using System.Globalization;

class Program
{
   static void Main()
   {
       string filePath = "employees.csv";

       if (File.Exists(filePath))
       {
           var employees = File.ReadAllLines(filePath)
               .Skip(1) // Skip header
               .Select(line => line.Split(','))
               .OrderByDescending(data => double.Parse(data[3], CultureInfo.InvariantCulture)) // Sort by salary
               .Take(5) // Top 5 highest salaries
               .ToList();

           Console.WriteLine("Top 5 Highest Paid Employees:");
           Console.WriteLine("ID\tName\tDepartment\tSalary");
           foreach (var emp in employees)
           {
               Console.WriteLine($"{emp[0]}\t{emp[1]}\t{emp[2]}\t{emp[3]}");
           }
       }
       else
       {
           Console.WriteLine("File not found!");
       }
   }
}
	



________________


Advanced Problems
8️⃣ Validate CSV Data Before Processing
* Ensure that the "Email" column follows a valid email format using regex.
* Ensure that "Phone Numbers" contain exactly 10 digits.
* Print any invalid rows with an error message.
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string filePath = "data.csv"; // Format: Name, Email, Phone
       string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
       string phonePattern = @"^\d{10}$";

       var lines = File.ReadAllLines(filePath).Skip(1);

       foreach (var line in lines)
       {
           var parts = line.Split(',');
           if (!Regex.IsMatch(parts[1], emailPattern) || !Regex.IsMatch(parts[2], phonePattern))
           {
               Console.WriteLine($"Invalid data: {line}");
           }
       }
   }
}
	



9️⃣ Convert CSV Data into Java Objects
* Read a CSV file and convert each row into a Student Java object.
* Store the objects in a List<Student> and print them.
using System;
using System.Collections.Generic;
using System.IO;

class Student
{
   public string ID { get; set; }
   public string Name { get; set; }
   public int Age { get; set; }
}

class Program
{
   static void Main()
   {
       string filePath = "students.csv"; // Format: ID, Name, Age
       var students = new List<Student>();

       foreach (var line in File.ReadLines(filePath).Skip(1))
       {
           var parts = line.Split(',');
           students.Add(new Student { ID = parts[0], Name = parts[1], Age = int.Parse(parts[2]) });
       }

       foreach (var student in students)
       {
           Console.WriteLine($"{student.ID} - {student.Name} - {student.Age}");
       }
   }
}
	



🔟 Merge Two CSV Files
* You have two CSV files:
   * students1.csv (contains ID, Name, Age)
   * students2.csv (contains ID, Marks, Grade)
* Merge both files based on ID and create a new file containing all details.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
   static void Main()
   {
       string file1 = "students1.csv"; // ID, Name, Age
       string file2 = "students2.csv"; // ID, Marks, Grade
       string outputFile = "merged_students.csv";

       var dict = File.ReadLines(file1).Skip(1)
           .Select(line => line.Split(','))
           .ToDictionary(parts => parts[0], parts => string.Join(",", parts));

       var merged = new List<string> { "ID,Name,Age,Marks,Grade" };

       foreach (var line in File.ReadLines(file2).Skip(1))
       {
           var parts = line.Split(',');
           if (dict.ContainsKey(parts[0]))
           {
               merged.Add(dict[parts[0]] + "," + string.Join(",", parts.Skip(1)));
           }
       }

       File.WriteAllLines(outputFile, merged);
       Console.WriteLine("Merged file created: " + outputFile);
   }
}
	



1️⃣1️⃣ Read Large CSV File Efficiently
* Given a large CSV file (500MB+), implement a memory-efficient way to read it in chunks.
* Process only 100 lines at a time and display the count of records processed.
using System;
using System.IO;

class Program
{
   static void Main()
   {
       string filePath = "large.csv";
       int batchSize = 100;
       int count = 0;

       using (var reader = new StreamReader(filePath))
       {
           while (!reader.EndOfStream)
           {
               for (int i = 0; i < batchSize && !reader.EndOfStream; i++)
               {
                   Console.WriteLine(reader.ReadLine());
                   count++;
               }
               Console.WriteLine($"Processed {count} records so far...");
           }
       }
   }
}
	



1️⃣2️⃣ Detect Duplicates in a CSV File
* Read a CSV file and detect duplicate entries based on the ID column.
* Print all duplicate records.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
   static void Main()
   {
       string filePath = "data.csv"; // Format: ID, Name, ...
       var seen = new HashSet<string>();
       var duplicates = new List<string>();

       foreach (var line in File.ReadLines(filePath).Skip(1))
       {
           var id = line.Split(',')[0];
           if (!seen.Add(id))
           {
               duplicates.Add(line);
           }
       }

       Console.WriteLine("Duplicate Records:");
       duplicates.ForEach(Console.WriteLine);
   }
}
	





1️⃣3️⃣ Generate a CSV Report from Database
* Fetch employee records from a database and write them into a CSV file.
* Include headers: Employee ID, Name, Department, Salary.
using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
   static void Main()
   {
       string connectionString = "your_connection_string_here"; 
       string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";
       string filePath = "employees_report.csv";

       using (SqlConnection conn = new SqlConnection(connectionString))
       {
           conn.Open();
           using (SqlCommand cmd = new SqlCommand(query, conn))
           using (SqlDataReader reader = cmd.ExecuteReader())
           using (StreamWriter writer = new StreamWriter(filePath))
           {
               writer.WriteLine("Employee ID,Name,Department,Salary"); // Headers

               while (reader.Read())
               {
                   writer.WriteLine($"{reader["EmployeeID"]},{reader["Name"]},{reader["Department"]},{reader["Salary"]}");
               }
           }
       }

       Console.WriteLine($"CSV Report generated: {filePath}");
   }
}
	



1️⃣4️⃣ Convert JSON to CSV and Vice Versa
* Read a JSON file containing a list of students.
* Convert it into CSV format and save it.
* Implement another method to read CSV and convert it back to JSON.
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Student
{
   public int ID { get; set; }
   public string Name { get; set; }
   public int Age { get; set; }
}

class Program
{
   static void Main()
   {
       string jsonFile = "students.json";
       string csvFile = "students.csv";

       // Convert JSON to CSV
       List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(jsonFile));

       using (StreamWriter writer = new StreamWriter(csvFile))
       {
           writer.WriteLine("ID,Name,Age");
           foreach (var student in students)
           {
               writer.WriteLine($"{student.ID},{student.Name},{student.Age}");
           }
       }

       Console.WriteLine($"Converted JSON to CSV: {csvFile}");

       // Convert CSV back to JSON
       var lines = File.ReadAllLines(csvFile);
       var studentList = new List<Student>();

       foreach (var line in lines[1..]) // Skip header
       {
           var parts = line.Split(',');
           studentList.Add(new Student { ID = int.Parse(parts[0]), Name = parts[1], Age = int.Parse(parts[2]) });
       }

       string jsonOutput = JsonConvert.SerializeObject(studentList, Formatting.Indented);
       File.WriteAllText("converted_students.json", jsonOutput);

       Console.WriteLine("Converted CSV back to JSON: converted_students.json");
   }
}
	



1️⃣5️⃣ Encrypt and Decrypt CSV Data
* Encrypt the sensitive fields (e.g., Salary, Email) while writing to a CSV file.
* Decrypt them when reading the file.
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Employee
{
   public string Name { get; set; }
   public string Email { get; set; }
   public double Salary { get; set; }
}

class Program
{
   private static readonly string encryptionKey = "your_secret_key"; // Use a secure key

   static void Main()
   {
       string csvFile = "employees_encrypted.csv";
       var employees = new List<Employee>
       {
           new Employee { Name = "Alice", Email = "alice@example.com", Salary = 60000 },
           new Employee { Name = "Bob", Email = "bob@example.com", Salary = 75000 }
       };

       // Encrypt and write to CSV
       using (StreamWriter writer = new StreamWriter(csvFile))
       {
           writer.WriteLine("Name,Email,Salary");
           foreach (var emp in employees)
           {
               string encryptedEmail = Encrypt(emp.Email);
               string encryptedSalary = Encrypt(emp.Salary.ToString());
               writer.WriteLine($"{emp.Name},{encryptedEmail},{encryptedSalary}");
           }
       }
       Console.WriteLine($"Encrypted data written to {csvFile}");

       // Read and decrypt CSV
       using (StreamReader reader = new StreamReader(csvFile))
       {
           string header = reader.ReadLine(); // Skip header
           while (!reader.EndOfStream)
           {
               var parts = reader.ReadLine().Split(',');
               string decryptedEmail = Decrypt(parts[1]);
               string decryptedSalary = Decrypt(parts[2]);

               Console.WriteLine($"Name: {parts[0]}, Email: {decryptedEmail}, Salary: {decryptedSalary}");
           }
       }
   }

   static string Encrypt(string input)
   {
       byte[] inputBytes = Encoding.UTF8.GetBytes(input);
       using (Aes aes = Aes.Create())
       {
           aes.Key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(32)); // Ensure 32-byte key
           aes.IV = new byte[16]; // Zero IV for simplicity (use a better IV strategy)
           using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
           {
               return Convert.ToBase64String(encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length));
           }
       }
   }

   static string Decrypt(string encryptedInput)
   {
       byte[] inputBytes = Convert.FromBase64String(encryptedInput);
       using (Aes aes = Aes.Create())
       {
           aes.Key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(32));
           aes.IV = new byte[16];
           using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
           {
               return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length));
           }
       }
   }
}