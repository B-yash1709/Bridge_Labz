C# Unit Testing Practice Problems (NUnit / MSTest)
1. Basic NUnit Test: Testing a Calculator Class
Problem:
Create a Calculator class with methods:
* Add(int a, int b)
* Subtract(int a, int b)
* Multiply(int a, int b)
* Divide(int a, int b)
Write NUnit or MSTest test cases for each method.
👉 Bonus: Test for division by zero and handle exceptions properly.
using NUnit.Framework;
using System;

public class Calculator
{
   public int Add(int a, int b) => a + b;
   public int Subtract(int a, int b) => a - b;
   public int Multiply(int a, int b) => a * b;
   public double Divide(int a, int b) => b == 0 ? throw new DivideByZeroException() : (double)a / b;
}

[TestFixture]
public class CalculatorTests
{
   Calculator calc = new Calculator();

   [Test] public void AddTest() => Assert.AreEqual(8, calc.Add(5, 3));
   [Test] public void SubtractTest() => Assert.AreEqual(6, calc.Subtract(10, 4));
   [Test] public void MultiplyTest() => Assert.AreEqual(42, calc.Multiply(6, 7));
   [Test] public void DivideTest() => Assert.AreEqual(5.0, calc.Divide(10, 2)); // Compare to 5.0 instead of 5
   [Test] public void DivideByZeroTest() => Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
}
	

________________


2. Testing String Utility Methods
Problem:
Create a StringUtils class with the following methods:
* Reverse(string str): Returns the reverse of a given string.
* IsPalindrome(string str): Returns true if the string is a palindrome.
* ToUpperCase(string str): Converts a string to uppercase.
Write NUnit or MSTest test cases to verify that these methods work correctly.
using System;
using NUnit.Framework;

public class StringUtils
{
   public static string Reverse(string str) => new string(str?.ToCharArray().Reverse().ToArray());
   public static bool IsPalindrome(string str) => str?.ToLower() == Reverse(str)?.ToLower();
   public static string ToUpperCase(string str) => str?.ToUpper();
}

[TestFixture]
public class StringUtilsTests
{
   [Test]
   public void Reverse_ShouldReturnReversedString() => Assert.AreEqual("olleh", StringUtils.Reverse("hello"));

   [Test]
   public void Reverse_EmptyString_ShouldReturnEmptyString() => Assert.AreEqual("", StringUtils.Reverse(""));

   [Test]
   public void Reverse_NullString_ShouldReturnNull() => Assert.IsNull(StringUtils.Reverse(null));

   [Test]
   public void IsPalindrome_ShouldReturnTrue_ForPalindrome() => Assert.IsTrue(StringUtils.IsPalindrome("madam"));

   [Test]
   public void IsPalindrome_ShouldReturnFalse_ForNonPalindrome() => Assert.IsFalse(StringUtils.IsPalindrome("hello"));

   [Test]
   public void IsPalindrome_ShouldReturnTrue_ForEmptyString() => Assert.IsTrue(StringUtils.IsPalindrome(""));

   [Test]
   public void IsPalindrome_ShouldReturnTrue_ForCaseInsensitivePalindrome() => Assert.IsTrue(StringUtils.IsPalindrome("Racecar"));

   [Test]
   public void ToUpperCase_ShouldConvertStringToUppercase() => Assert.AreEqual("HELLO", StringUtils.ToUpperCase("hello"));

   [Test]
   public void ToUpperCase_EmptyString_ShouldReturnEmptyString() => Assert.AreEqual("", StringUtils.ToUpperCase(""));

   [Test]
   public void ToUpperCase_NullString_ShouldReturnNull() => Assert.IsNull(StringUtils.ToUpperCase(null));
}
	

________________


3. Testing List Operations
Problem:
Create a ListManager class that has the following methods:
* AddElement(List<int> list, int element): Adds an element to a list.
* RemoveElement(List<int> list, int element): Removes an element from a list.
* GetSize(List<int> list): Returns the size of the list.
Write NUnit or MSTest tests to verify that:
✅ Elements are correctly added.
✅ Elements are correctly removed.
✅ The size of the list is updated correctly.
using System.Collections.Generic;
using NUnit.Framework;

public class ListManager
{
   public void AddElement(List<int> list, int element) => list.Add(element);
   public bool RemoveElement(List<int> list, int element) => list.Remove(element);
   public int GetSize(List<int> list) => list.Count;
}

[TestFixture]
public class ListManagerTests
{
   private ListManager _listManager;
   private List<int> _list;

   [SetUp]
   public void Setup()
   {
       _listManager = new ListManager();
       _list = new List<int>();
   }

   [Test]
   public void AddElement_ShouldAddElementToList()
   {
       _listManager.AddElement(_list, 10);
       Assert.Contains(10, _list);
       Assert.AreEqual(1, _listManager.GetSize(_list));
   }

   [Test]
   public void RemoveElement_ShouldRemoveElementFromList()
   {
       _listManager.AddElement(_list, 10);
       _listManager.AddElement(_list, 20);
       bool result = _listManager.RemoveElement(_list, 10);
       Assert.IsTrue(result);
       Assert.IsFalse(_list.Contains(10));
       Assert.AreEqual(1, _listManager.GetSize(_list));
   }

   [Test]
   public void RemoveElement_ShouldReturnFalse_IfElementNotInList()
   {
       _listManager.AddElement(_list, 10);
       bool result = _listManager.RemoveElement(_list, 20);
       Assert.IsFalse(result);
       Assert.AreEqual(1, _listManager.GetSize(_list));
   }

   [Test]
   public void GetSize_ShouldReturnCorrectSize()
   {
       _listManager.AddElement(_list, 10);
       _listManager.AddElement(_list, 20);
       _listManager.AddElement(_list, 30);
       int size = _listManager.GetSize(_list);
       Assert.AreEqual(3, size);
   }

   [Test]
   public void GetSize_ShouldReturnZero_ForEmptyList()
   {
       int size = _listManager.GetSize(_list);
       Assert.AreEqual(0, size);
   }
}
	

________________


4. Testing Exception Handling
Problem:
Create a method Divide(int a, int b) that throws an ArithmeticException if b is zero. Write a unit test to verify that the exception is thrown properly.
using System;
using NUnit.Framework;

public class Calculator
{
   public int Divide(int a, int b)
   {
       if (b == 0)
       {
           throw new ArithmeticException("Division by zero is not allowed.");
       }
       return a / b;
   }
}

[TestFixture]
public class CalculatorTests
{
   private Calculator _calculator;

   [SetUp]
   public void Setup()
   {
       _calculator = new Calculator();
   }

   [Test]
   public void Divide_ShouldThrowArithmeticException_WhenDividingByZero()
   {
       var exception = Assert.Throws<ArithmeticException>(() => _calculator.Divide(10, 0));
       Assert.AreEqual("Division by zero is not allowed.", exception.Message);
   }

   [Test]
   public void Divide_ShouldReturnCorrectResult_WhenDividingNonZeroNumbers()
   {
       int result = _calculator.Divide(10, 2);
       Assert.AreEqual(5, result);
   }
}
	

________________


5. Testing Setup and Teardown (NUnit: [SetUp] & [TearDown])
Problem:
Create a class DatabaseConnection with methods:
* Connect()
* Disconnect()
Use [SetUp] (NUnit) or [TestInitialize] (MSTest) to initialize a database connection before each test.
Use [TearDown] (NUnit) or [TestCleanup] (MSTest) to close the connection after each test.
Write test cases to verify that the connection is established and closed correctly.
using System;
using NUnit.Framework;

public class DatabaseConnection
{
   public bool IsConnected { get; private set; }

   public void Connect()
   {
       // Simulate connecting to a database
       IsConnected = true;
       Console.WriteLine("Connected to database.");
   }

   public void Disconnect()
   {
       // Simulate disconnecting from a database
       IsConnected = false;
       Console.WriteLine("Disconnected from database.");
   }
}

[TestFixture]
public class DatabaseConnectionTests
{
   private DatabaseConnection _dbConnection;

   [SetUp]
   public void Setup()
   {
       // Initialize the database connection before each test
       _dbConnection = new DatabaseConnection();
       _dbConnection.Connect();
   }

   [TearDown]
   public void TearDown()
   {
       // Close the database connection after each test
       _dbConnection.Disconnect();
   }

   [Test]
   public void Connect_ShouldEstablishConnection()
   {
       // Assert
       Assert.IsTrue(_dbConnection.IsConnected);
   }

   [Test]
   public void Disconnect_ShouldCloseConnection()
   {
       // Act
       _dbConnection.Disconnect();

       // Assert
       Assert.IsFalse(_dbConnection.IsConnected);
   }
}
	

________________


6. Testing Parameterized Tests
Problem:
Create a method IsEven(int number) that returns true if a number is even.
Use NUnit [TestCase] or MSTest [DataRow] to test this method with multiple values like 2, 4, 6, 7, 9.
using NUnit.Framework;

public class NumberUtils
{
   public bool IsEven(int number)
   {
       return number % 2 == 0;
   }
}

[TestFixture]
public class NumberUtilsTests
{
   private NumberUtils _numberUtils;

   [SetUp]
   public void Setup()
   {
       _numberUtils = new NumberUtils();
   }

   [TestCase(2, ExpectedResult = true)]
   [TestCase(4, ExpectedResult = true)]
   [TestCase(6, ExpectedResult = true)]
   [TestCase(7, ExpectedResult = false)]
   [TestCase(9, ExpectedResult = false)]
   public bool IsEven_ShouldReturnCorrectResult(int number)
   {
       return _numberUtils.IsEven(number);
   }
}
	

________________




7. Performance Testing Using Timeout
Problem:
Create a method LongRunningTask() that sleeps for 3 seconds before returning a result.
Use NUnit [Timeout(2000)] or MSTest [Timeout(2000)] to fail the test if the method takes more than 2 seconds.
using System;
using System.Threading;
using NUnit.Framework;

public class TaskManager
{
   public string LongRunningTask()
   {
       // Simulate a long-running task by sleeping for 3 seconds
       Thread.Sleep(3000);
       return "Task completed.";
   }
}

[TestFixture]
public class TaskManagerTests
{
   private TaskManager _taskManager;

   [SetUp]
   public void Setup()
   {
       _taskManager = new TaskManager();
   }

   [Test, Timeout(2000)] // Fail if the test takes more than 2 seconds
   public void LongRunningTask_ShouldCompleteWithinTimeout()
   {
       // Act
       string result = _taskManager.LongRunningTask();

       // Assert
       Assert.AreEqual("Task completed.", result);
   }
}
	

________________


8. Testing File Handling Methods
Problem:
Create a class FileProcessor with the following methods:
* WriteToFile(string filename, string content): Writes content to a file.
* ReadFromFile(string filename): Reads content from a file.
Write unit tests to check if:
✅ The content is written and read correctly.
✅ The file exists after writing.
✅ Handling of IOException when the file does not exist.
using System;
using System.IO;
using NUnit.Framework;

public class FileProcessor
{
   public void WriteToFile(string filename, string content)
   {
       File.WriteAllText(filename, content);
   }

   public string ReadFromFile(string filename)
   {
       if (!File.Exists(filename))
       {
           throw new IOException("File does not exist.");
       }
       return File.ReadAllText(filename);
   }
}

[TestFixture]
public class FileProcessorTests
{
   private FileProcessor _fileProcessor;
   private string _testFilePath;

   [SetUp]
   public void Setup()
   {
       _fileProcessor = new FileProcessor();
       _testFilePath = Path.GetTempFileName(); // Create a temporary file for testing
   }

   [TearDown]
   public void TearDown()
   {
       // Clean up the temporary file after each test
       if (File.Exists(_testFilePath))
       {
           File.Delete(_testFilePath);
       }
   }

   [Test]
   public void WriteToFile_ShouldWriteContentToFile()
   {
       // Arrange
       string content = "Hello, World!";

       // Act
       _fileProcessor.WriteToFile(_testFilePath, content);

       // Assert
       Assert.IsTrue(File.Exists(_testFilePath));
       Assert.AreEqual(content, File.ReadAllText(_testFilePath));
   }

   [Test]
   public void ReadFromFile_ShouldReadContentFromFile()
   {
       // Arrange
       string content = "Hello, World!";
       File.WriteAllText(_testFilePath, content);

       // Act
       string result = _fileProcessor.ReadFromFile(_testFilePath);

       // Assert
       Assert.AreEqual(content, result);
   }

   [Test]
   public void ReadFromFile_ShouldThrowIOException_WhenFileDoesNotExist()
   {
       // Arrange
       string nonExistentFilePath = Path.Combine(Path.GetTempPath(), "nonexistentfile.txt");

       // Act & Assert
       var exception = Assert.Throws<IOException>(() => _fileProcessor.ReadFromFile(nonExistentFilePath));
       Assert.AreEqual("File does not exist.", exception.Message);
   }
}
	

________________


Advanced C# Unit Testing Practice Problems
1. Testing Banking Transactions
Problem:
Create a BankAccount class with:
* Deposit(double amount): Adds money to the balance.
* Withdraw(double amount): Reduces balance.
* GetBalance(): Returns the current balance.
✅ Write unit tests to check correct balance updates.
✅ Ensure withdrawals fail if funds are insufficient.
using System;
using NUnit.Framework;

public class BankAccount
{
   private double _balance;

   public BankAccount(double initialBalance = 0)
   {
       _balance = initialBalance;
   }

   public void Deposit(double amount)
   {
       if (amount <= 0)
       {
           throw new ArgumentException("Deposit amount must be positive.");
       }
       _balance += amount;
   }

   public void Withdraw(double amount)
   {
       if (amount <= 0)
       {
           throw new ArgumentException("Withdrawal amount must be positive.");
       }
       if (amount > _balance)
       {
           throw new InvalidOperationException("Insufficient funds.");
       }
       _balance -= amount;
   }

   public double GetBalance()
   {
       return _balance;
   }
}

[TestFixture]
public class BankAccountTests
{
   private BankAccount _bankAccount;

   [SetUp]
   public void Setup()
   {
       _bankAccount = new BankAccount(100); // Initialize with a balance of 100
   }

   [Test]
   public void Deposit_ShouldIncreaseBalance()
   {
       _bankAccount.Deposit(50);
       Assert.AreEqual(150, _bankAccount.GetBalance());
   }

   [Test]
   public void Deposit_ShouldThrowException_WhenAmountIsNegative()
   {
       var exception = Assert.Throws<ArgumentException>(() => _bankAccount.Deposit(-10));
       Assert.AreEqual("Deposit amount must be positive.", exception.Message);
   }

   [Test]
   public void Withdraw_ShouldDecreaseBalance()
   {
       _bankAccount.Withdraw(50);
       Assert.AreEqual(50, _bankAccount.GetBalance());
   }

   [Test]
   public void Withdraw_ShouldThrowException_WhenAmountIsNegative()
   {
       var exception = Assert.Throws<ArgumentException>(() => _bankAccount.Withdraw(-10));
       Assert.AreEqual("Withdrawal amount must be positive.", exception.Message);
   }

   [Test]
   public void Withdraw_ShouldThrowException_WhenInsufficientFunds()
   {
       var exception = Assert.Throws<InvalidOperationException>(() => _bankAccount.Withdraw(200));
       Assert.AreEqual("Insufficient funds.", exception.Message);
   }

   [Test]
   public void GetBalance_ShouldReturnCorrectBalance()
   {
       double balance = _bankAccount.GetBalance();
       Assert.AreEqual(100, balance);
   }
}
	

________________






2. Testing Password Strength Validator
Problem:
Create a PasswordValidator class with:
   * Passwords must have at least 8 characters, one uppercase letter, and one digit.
✅ Write unit tests for valid and invalid passwords.
using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class PasswordValidator
{
   public bool IsPasswordValid(string password)
   {
       if (string.IsNullOrEmpty(password))
       {
           return false;
       }

       // Check for at least 8 characters
       if (password.Length < 8)
       {
           return false;
       }

       // Check for at least one uppercase letter
       if (!Regex.IsMatch(password, "[A-Z]"))
       {
           return false;
       }

       // Check for at least one digit
       if (!Regex.IsMatch(password, "[0-9]"))
       {
           return false;
       }

       return true;
   }
}

[TestFixture]
public class PasswordValidatorTests
{
   private PasswordValidator _passwordValidator;

   [SetUp]
   public void Setup()
   {
       _passwordValidator = new PasswordValidator();
   }

   [Test]
   public void IsPasswordValid_ShouldReturnTrue_ForValidPassword()
   {
       string validPassword = "Password1";
       bool result = _passwordValidator.IsPasswordValid(validPassword);
       Assert.IsTrue(result);
   }

   [Test]
   public void IsPasswordValid_ShouldReturnFalse_ForShortPassword()
   {
       string invalidPassword = "Pass1";
       bool result = _passwordValidator.IsPasswordValid(invalidPassword);
       Assert.IsFalse(result);
   }

   [Test]
   public void IsPasswordValid_ShouldReturnFalse_ForPasswordWithoutUppercase()
   {
       string invalidPassword = "password1";
       bool result = _passwordValidator.IsPasswordValid(invalidPassword);
       Assert.IsFalse(result);
   }

   [Test]
   public void IsPasswordValid_ShouldReturnFalse_ForPasswordWithoutDigit()
   {
       string invalidPassword = "Password";
       bool result = _passwordValidator.IsPasswordValid(invalidPassword);
       Assert.IsFalse(result);
   }

   [Test]
   public void IsPasswordValid_ShouldReturnFalse_ForEmptyPassword()
   {
       string invalidPassword = "";
       bool result = _passwordValidator.IsPasswordValid(invalidPassword);
       Assert.IsFalse(result);
   }

   [Test]
   public void IsPasswordValid_ShouldReturnFalse_ForNullPassword()
   {
       string invalidPassword = null;
       bool result = _passwordValidator.IsPasswordValid(invalidPassword);
       Assert.IsFalse(result);
   }
}
	

________________


3. Testing Temperature Converter
Problem:
Create a TemperatureConverter class with:
      * CelsiusToFahrenheit(double celsius): Converts Celsius to Fahrenheit.
      * FahrenheitToCelsius(double fahrenheit): Converts Fahrenheit to Celsius.
✅ Write unit tests to validate conversions.
using NUnit.Framework;

public class TemperatureConverter
{
   public double CelsiusToFahrenheit(double celsius)
   {
       return (celsius * 9 / 5) + 32;
   }

   public double FahrenheitToCelsius(double fahrenheit)
   {
       return (fahrenheit - 32) * 5 / 9;
   }
}

[TestFixture]
public class TemperatureConverterTests
{
   private TemperatureConverter _temperatureConverter;

   [SetUp]
   public void Setup()
   {
       _temperatureConverter = new TemperatureConverter();
   }

   [Test]
   public void CelsiusToFahrenheit_ShouldConvertCorrectly()
   {
       double celsius = 25;
       double fahrenheit = _temperatureConverter.CelsiusToFahrenheit(celsius);
       Assert.AreEqual(77, fahrenheit);
   }

   [Test]
   public void FahrenheitToCelsius_ShouldConvertCorrectly()
   {
       double fahrenheit = 77;
       double celsius = _temperatureConverter.FahrenheitToCelsius(fahrenheit);
       Assert.AreEqual(25, celsius);
   }

   [Test]
   public void CelsiusToFahrenheit_ShouldHandleZero()
   {
       double celsius = 0;
       double fahrenheit = _temperatureConverter.CelsiusToFahrenheit(celsius);
       Assert.AreEqual(32, fahrenheit);
   }

   [Test]
   public void FahrenheitToCelsius_ShouldHandleFreezingPoint()
   {
       double fahrenheit = 32;
       double celsius = _temperatureConverter.FahrenheitToCelsius(fahrenheit);
       Assert.AreEqual(0, celsius);
   }

   [Test]
   public void CelsiusToFahrenheit_ShouldHandleNegativeValues()
   {
       double celsius = -10;
       double fahrenheit = _temperatureConverter.CelsiusToFahrenheit(celsius);
       Assert.AreEqual(14, fahrenheit);
   }

   [Test]
   public void FahrenheitToCelsius_ShouldHandleNegativeValues()
   {
       double fahrenheit = 14;
       double celsius = _temperatureConverter.FahrenheitToCelsius(fahrenheit);
       Assert.AreEqual(-10, celsius);
   }
}
	

________________


4. Testing Date Formatter
Problem:
Create a DateFormatter class with:
         * FormatDate(string inputDate): Converts yyyy-MM-dd format to dd-MM-yyyy.
✅ Write unit test cases for valid and invalid dates.
using System;
using System.Globalization;
using NUnit.Framework;

public class DateFormatter
{
   public string FormatDate(string inputDate)
   {
       if (string.IsNullOrEmpty(inputDate))
       {
           throw new ArgumentException("Input date cannot be null or empty.");
       }

       if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
       {
           throw new FormatException("Invalid date format. Expected format: yyyy-MM-dd.");
       }

       return date.ToString("dd-MM-yyyy");
   }
}

[TestFixture]
public class DateFormatterTests
{
   private DateFormatter _dateFormatter;

   [SetUp]
   public void Setup()
   {
       _dateFormatter = new DateFormatter();
   }

   [Test]
   public void FormatDate_ShouldFormatValidDate()
   {
       string inputDate = "2023-10-05";
       string formattedDate = _dateFormatter.FormatDate(inputDate);
       Assert.AreEqual("05-10-2023", formattedDate);
   }

   [Test]
   public void FormatDate_ShouldThrowException_ForInvalidDateFormat()
   {
       string invalidDate = "2023/10/05";
       var exception = Assert.Throws<FormatException>(() => _dateFormatter.FormatDate(invalidDate));
       Assert.AreEqual("Invalid date format. Expected format: yyyy-MM-dd.", exception.Message);
   }

   [Test]
   public void FormatDate_ShouldThrowException_ForEmptyInput()
   {
       string emptyDate = "";
       var exception = Assert.Throws<ArgumentException>(() => _dateFormatter.FormatDate(emptyDate));
       Assert.AreEqual("Input date cannot be null or empty.", exception.Message);
   }

   [Test]
   public void FormatDate_ShouldThrowException_ForNullInput()
   {
       string nullDate = null;
       var exception = Assert.Throws<ArgumentException>(() => _dateFormatter.FormatDate(nullDate));
       Assert.AreEqual("Input date cannot be null or empty.", exception.Message);
   }

   [Test]
   public void FormatDate_ShouldHandleLeapYear()
   {
       string leapYearDate = "2020-02-29";
       string formattedDate = _dateFormatter.FormatDate(leapYearDate);
       Assert.AreEqual("29-02-2020", formattedDate);
   }

   [Test]
   public void FormatDate_ShouldThrowException_ForInvalidDate()
   {
       string invalidDate = "2023-02-30";
       var exception = Assert.Throws<FormatException>(() => _dateFormatter.FormatDate(invalidDate));
       Assert.AreEqual("Invalid date format. Expected format: yyyy-MM-dd.", exception.Message);
   }
}
	

________________


5. Testing User Registration
Problem:
Create a UserRegistration class with:
            * RegisterUser(string username, string email, string password).
            * Throws ArgumentException for invalid inputs.
✅ Write unit tests to verify valid and invalid user registrations.
using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class UserRegistration
{
   public void RegisterUser(string username, string email, string password)
   {
       if (string.IsNullOrEmpty(username))
       {
           throw new ArgumentException("Username cannot be null or empty.");
       }

       if (string.IsNullOrEmpty(email))
       {
           throw new ArgumentException("Email cannot be null or empty.");
       }

       if (!IsValidEmail(email))
       {
           throw new ArgumentException("Invalid email format.");
       }

       if (string.IsNullOrEmpty(password))
       {
           throw new ArgumentException("Password cannot be null or empty.");
       }

       if (password.Length < 8)
       {
           throw new ArgumentException("Password must be at least 8 characters long.");
       }
   }

   private bool IsValidEmail(string email)
   {
       // Simple regex for email validation
       string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
       return Regex.IsMatch(email, pattern);
   }
}

[TestFixture]
public class UserRegistrationTests
{
   private UserRegistration _userRegistration;

   [SetUp]
   public void Setup()
   {
       _userRegistration = new UserRegistration();
   }

   [Test]
   public void RegisterUser_ShouldNotThrowException_ForValidInputs()
   {
       string username = "john_doe";
       string email = "john.doe@example.com";
       string password = "Password123";
       Assert.DoesNotThrow(() => _userRegistration.RegisterUser(username, email, password));
   }

   [Test]
   public void RegisterUser_ShouldThrowException_ForNullUsername()
   {
       string username = null;
       string email = "john.doe@example.com";
       string password = "Password123";
       var exception = Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
       Assert.AreEqual("Username cannot be null or empty.", exception.Message);
   }

   [Test]
   public void RegisterUser_ShouldThrowException_ForEmptyEmail()
   {
       string username = "john_doe";
       string email = "";
       string password = "Password123";
       var exception = Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
       Assert.AreEqual("Email cannot be null or empty.", exception.Message);
   }

   [Test]
   public void RegisterUser_ShouldThrowException_ForInvalidEmail()
   {
       string username = "john_doe";
       string email = "invalid-email";
       string password = "Password123";
       var exception = Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
       Assert.AreEqual("Invalid email format.", exception.Message);
   }

   [Test]
   public void RegisterUser_ShouldThrowException_ForNullPassword()
   {
       string username = "john_doe";
       string email = "john.doe@example.com";
       string password = null;
       var exception = Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
       Assert.AreEqual("Password cannot be null or empty.", exception.Message);
   }

   [Test]
   public void RegisterUser_ShouldThrowException_ForShortPassword()
   {
       string username = "john_doe";
       string email = "john.doe@example.com";
       string password = "pass";
       var exception = Assert.Throws<ArgumentException>(() => _userRegistration.RegisterUser(username, email, password));
       Assert.AreEqual("Password must be at least 8 characters long.", exception.Message);
   }
}