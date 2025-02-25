C# Regular Expressions (Regex) Practice Problems
Here are practice problems for C# Regular Expressions (Regex). These problems will help you validate, extract, replace, and manipulate strings using regex in C#.
Basic Regex Problems
1. Validate a Username
A valid username:
* Can only contain letters (a-z, A-Z), numbers (0-9), and underscores (_)
* Must start with a letter
* Must be between 5 to 15 characters long
Example Inputs & Outputs:
* ✅ "user_123" → Valid
* ❌ "123user" → Invalid (starts with a number)
* ❌ "us" → Invalid (too short)
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] usernames = { "user_123", "123user", "us", "valid_user_123", "invalid@user" };

       foreach (var username in usernames)
       {
           Console.WriteLine($"{username} → {IsValidUsername(username) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidUsername(string username)
   {
       string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";
       return Regex.IsMatch(username, pattern);
   }
}
	



2. Validate a License Plate Number
License plate format: Starts with two uppercase letters, followed by four digits.
Example: "AB1234" is valid, but "A12345" is invalid.
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] licensePlates = { "AB1234", "A12345", "XY5678", "123XYZ", "ZZ9999" };

       foreach (var plate in licensePlates)
       {
           Console.WriteLine($"{plate} → {IsValidLicensePlate(plate) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidLicensePlate(string plate)
   {
       string pattern = @"^[A-Z]{2}\d{4}$";
       return Regex.IsMatch(plate, pattern);
   }
}
	



3. Validate a Hex Color Code
A valid hex color:
* Starts with a #
* Followed by 6 hexadecimal characters (0-9, A-F, a-f).
Example Inputs & Outputs:
* ✅ "#FFA500" → Valid
* ✅ "#ff4500" → Valid
* ❌ "#123" → Invalid (too short)
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] hexCodes = { "#FFA500", "#ff4500", "#123", "#G12345", "#ABCDEF" };

       foreach (var code in hexCodes)
       {
           Console.WriteLine($"{code} → {IsValidHexColor(code) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidHexColor(string code)
   {
       string pattern = @"^#[0-9A-Fa-f]{6}$";
       return Regex.IsMatch(code, pattern);
   }
}
	

________________


Extraction Problems
4. Extract All Email Addresses from a Text
Example Text: "Contact us at support@example.com and info@company.org"
Expected Output:
* support@example.com
* info@company.org
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "Contact us at support@example.com and info@company.org";
       string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	



5. Extract All Capitalized Words from a Sentence
Example Text: "The Eiffel Tower is in Paris and the Statue of Liberty is in New York."
Expected Output:
* Eiffel, Tower, Paris, Statue, Liberty, New, York
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";
       string pattern = @"\b[A-Z][a-z]*\b";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	



6. Extract Dates in dd/mm/yyyy Format
Example Text: "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020."
Expected Output:
* 12/05/2023, 15/08/2024, 29/02/2020
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.";
       string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	



7. Extract Links from a Web Page
Example Text: "Visit https://www.google.com and http://example.org for more info."
Expected Output:
* https://www.google.com, http://example.org
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "Visit https://www.google.com and http://example.org for more info.";
       string pattern = @"https?://[^\s]+";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	

________________


Replace and Modify Strings
8. Replace Multiple Spaces with a Single Space
Example Input: "This is an example with multiple spaces."
Expected Output: "This is an example with multiple spaces."
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string input = "This is an example with multiple spaces.";
       string pattern = @"\s+";
       string replacement = " ";

       string result = Regex.Replace(input, pattern, replacement);
       Console.WriteLine(result);
   }
}
	



9. Censor Bad Words in a Sentence
Given a list of bad words, replace them with ****.
Example Input: "This is a damn bad example with some stupid words."
Expected Output: "This is a **** bad example with some **** words."
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string input = "This is a damn bad example with some stupid words.";
       string[] badWords = { "damn", "stupid" };

       foreach (var word in badWords)
       {
           string pattern = $@"\b{word}\b"; // Match whole words only
           input = Regex.Replace(input, pattern, "****", RegexOptions.IgnoreCase);
       }

       Console.WriteLine(input);
   }
}
	

________________


Advanced Problems
10. Validate an IP Address
A valid IPv4 address consists of four groups of numbers (0-255) separated by dots.
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] ipAddresses = { "192.168.1.1", "256.0.0.1", "127.0.0.1", "0.0.0.0" };

       foreach (var ip in ipAddresses)
       {
           Console.WriteLine($"{ip} → {IsValidIPAddress(ip) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidIPAddress(string ip)
   {
       string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
       return Regex.IsMatch(ip, pattern);
   }
}
	

11. Validate a Credit Card Number (Visa, MasterCard, etc.)
* A Visa card number starts with 4 and has 16 digits.
* A MasterCard starts with 5 and has 16 digits.
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] cardNumbers = { "4123456789012345", "5123456789012345", "412345678901234", "6123456789012345" };

       foreach (var card in cardNumbers)
       {
           Console.WriteLine($"{card} → {IsValidCreditCard(card) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidCreditCard(string card)
   {
       string visaPattern = @"^4[0-9]{15}$";
       string masterCardPattern = @"^5[0-9]{15}$";

       return Regex.IsMatch(card, visaPattern) || Regex.IsMatch(card, masterCardPattern);
   }
}
	

12. Extract Programming Language Names from a Text
Example Text: "I love Java, Python, and JavaScript, but I haven't tried Go yet."
Expected Output:
* Java, Python, JavaScript, Go
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";
       string pattern = @"\b(Java|Python|JavaScript|Go)\b";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	

13. Extract Currency Values from a Text
Example Text: "The price is $45.99, and the discount is $ 10.50."
Expected Output:
* $45.99, 10.50
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "The price is $45.99, and the discount is $ 10.50.";
       string pattern = @"\$\d+\.\d{2}|\d+\.\d{2}";

       MatchCollection matches = Regex.Matches(text, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Value);
       }
   }
}
	

14. Find Repeating Words in a Sentence
Example Input: "This is is a repeated repeated word test."
Expected Output:
* is, repeated
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string input = "This is is a repeated repeated word test.";
       string pattern = @"\b(\w+)\s+\1\b";

       MatchCollection matches = Regex.Matches(input, pattern);

       foreach (Match match in matches)
       {
           Console.WriteLine(match.Groups[1].Value);
       }
   }
}
	

15. Validate a Social Security Number (SSN)
Example Input: "My SSN is 123-45-6789."
Expected Output:
* ✅ "123-45-6789" is valid
* ❌ "123456789" is invalid
using System;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string[] ssns = { "123-45-6789", "123456789", "123-45-678", "123-45-67890" };

       foreach (var ssn in ssns)
       {
           Console.WriteLine($"{ssn} → {IsValidSSN(ssn) ? "Valid" : "Invalid"}");
       }
   }

   static bool IsValidSSN(string ssn)
   {
       string pattern = @"^\d{3}-\d{2}-\d{4}$";
       return Regex.IsMatch(ssn, pattern);
   }
}
	

________________