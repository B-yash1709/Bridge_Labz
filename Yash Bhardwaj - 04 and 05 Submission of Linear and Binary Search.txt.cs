Best Practices in C#
1. StringBuilder
Use when: You need to perform many string manipulations (e.g., concatenation, insertion) inside a loop or in a performance-sensitive scenario.
Best Practices:
* Preferred over string for mutable strings in performance-critical code.
* Use its Append() method instead of concatenation using + for efficiency.
* Initialize with a reasonable capacity to avoid resizing when the size is known in advance.


2. StreamReader
Use when: You need to read character files (text files) efficiently.
Best Practices:
* Always wrap StreamReader in a using statement to ensure proper disposal.
* Handle IOException properly.
* Use StreamReader for small files; for larger files, consider using FileStream.


3. StreamReader with Encoding
Use when: You need to convert byte streams into character streams (e.g., reading from non-text files or working with encodings).
Best Practices:
* Wrap StreamReader with BufferedStream if needed for performance.
* Always specify the correct encoding to avoid issues, especially for non-ASCII text.
* Always close the reader using using to avoid resource leakage.


Problem Statements
StringBuilder Problem 1: Reverse a String Using StringBuilder
Problem: Write a program that uses StringBuilder to reverse a given string. For example, if the input is "hello", the output should be "olleh".
using System;
using System.Text;

class Program
{
   static void Main()
   {
       string input = "hello";
       StringBuilder sb = new StringBuilder(input);
       int len = sb.Length;

       for (int i = 0; i < len / 2; i++)
       {
           char temp = sb[i];
            sb[i] = sb[len - 1 - i];
           sb[len - 1 - i] = temp;
       }

       Console.WriteLine("Reversed String: " + sb.ToString());
    }
}
	





StringBuilder Problem 2: Remove Duplicates from a String Using StringBuilder
Problem: Write a program that uses StringBuilder to remove all duplicate characters from a given string while maintaining the original order.


using System;
using System.Text;

class Program
{
   static void Main()
   {
       string input = "programming";
       StringBuilder sb = new StringBuilder();
       bool[] seen = new bool[256];  // Assuming ASCII characters

       for (int i = 0; i < input.Length; i++)
       {
           if (!seen[input[i]])
           {
               sb.Append(input[i]);
               seen[input[i]] = true;
           }
       }

       Console.WriteLine("String without duplicates: " + sb.ToString());
   }
}
	











Problem 1: Concatenate Strings Efficiently Using StringBuilder
Problem: You are given an array of strings. Write a program that uses StringBuilder to concatenate all the strings in the array efficiently.
using System;
using System.Text;

class Program
{
   static void Main()
   {
       string[] words = { "Hello", " ", "World", " ", "from", " ", "C#" };
       StringBuilder sb = new StringBuilder();

       for (int i = 0; i < words.Length; i++)
       {
           sb.Append(words[i]);
       }

       Console.WriteLine("Concatenated String: " + sb.ToString());
   }
}
	





 Problem 2: Compare StringBuilder Performance
Problem: Write a program that compares the performance of StringBuilder for concatenating strings multiple times.
using System;
using System.Diagnostics;
using System.Text;

class Program
{
   static void Main()
   {
       int iterations = 100000;
       string text = "Hello";

       // Measure performance of string concatenation
       Stopwatch stopwatch1 = Stopwatch.StartNew();
       string result = "";
       for (int i = 0; i < iterations; i++)
       {
           result += text; // Inefficient string concatenation
       }
       stopwatch1.Stop();
       Console.WriteLine($"String Concatenation Time: {stopwatch1.ElapsedMilliseconds} ms");

       // Measure performance of StringBuilder
       Stopwatch stopwatch2 = Stopwatch.StartNew();
       StringBuilder sb = new StringBuilder();
       for (int i = 0; i < iterations; i++)
       {
           sb.Append(text); // Efficient string appending
       }
       stopwatch2.Stop();
       Console.WriteLine($"StringBuilder Time: {stopwatch2.ElapsedMilliseconds} ms");
   }
}
	





Problem 1: Read a File Line by Line Using StreamReader
Problem: Write a program that uses StreamReader to read a text file line by line and print each line to the console.
using System;
using System.IO;

class Program
{
   static void Main()
   {
       string filePath = "test.txt";
       using (StreamReader reader = new StreamReader(filePath))
       {
           while (true)
           {
               string line = reader.ReadLine();
               if (line == null) break;
               Console.WriteLine(line);
           }
       }
   }
}
	



Problem 2: Count the Occurrence of a Word in a File Using StreamReader
Problem: Write a program that reads a file and counts how many times a specific word appears in the file.
using System;
using System.IO;

class Program
{
   static int CountWordOccurrences(string filePath, string targetWord)
   {
       int count = 0;

       using (StreamReader reader = new StreamReader(filePath))
       {
           string line;
           while ((line = reader.ReadLine()) != null)
           {
               count += CountWordInLine(line, targetWord);
           }
       }

       return count;
   }

   static int CountWordInLine(string line, string targetWord)
   {
       int count = 0;
       int lineLength = line.Length;
       int wordLength = targetWord.Length;

       for (int i = 0; i <= lineLength - wordLength; i++)
       {
           int j;
           for (j = 0; j < wordLength; j++)
           {
               if (line[i + j] != targetWord[j])
                   break;
           }

           // Ensure it's a standalone word (check spaces or start/end of line)
           if (j == wordLength && 
              (i + wordLength == lineLength || line[i + wordLength] == ' ') && 
              (i == 0 || line[i - 1] == ' '))
           {
               count++;
           }
       }

       return count;
   }

   static void Main()
   {
       string filePath = "sample.txt";
       string targetWord = "hello";

       // Step 1: Write sample text to the file
       using (StreamWriter writer = new StreamWriter(filePath))
       {
           writer.WriteLine("hello world");
           writer.WriteLine("hello again, hello everyone!");
           writer.WriteLine("say hello to programming");
       }

       // Step 2: Count occurrences
       int occurrences = CountWordOccurrences(filePath, targetWord);
       Console.WriteLine($"The word '{targetWord}' appears {occurrences} times in the file.");
   }
}
	



Problem 1: Convert Byte Stream to Character Stream Using StreamReader
Problem: Write a program that uses StreamReader to read binary data from a file and print it as characters.
using System;
using System.IO;
using System.Text;

class Program
{
   static void Main()
   {
       string filePath = "sample.bin";

       // Step 1: Write text to a binary file (as bytes)
       using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
       {
           byte[] data = Encoding.UTF8.GetBytes("Hello, this is binary data!");
           fileStream.Write(data, 0, data.Length);
       }

       // Step 2: Read the binary file and interpret it as text
       using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
       using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
       {
           Console.WriteLine("Reading from binary file as characters:");
           string content = reader.ReadToEnd();
           Console.WriteLine(content);
       }
   }
}
	



 Problem 2: Read User Input and Write to File Using StreamReader
Problem: Write a program that reads user input from the console and writes it to a file.
using System;
using System.IO;

class Program
{
   static void Main()
   {
       string filePath = "UserInput.txt";

       // Step 1: Get user input
       Console.WriteLine("Enter text to write to the file (Type 'exit' to finish):");
       using (StreamWriter writer = new StreamWriter(filePath))
       {
           while (true)
           {
               string userInput = Console.ReadLine();
               if (userInput.ToLower() == "exit")
                   break;
               writer.WriteLine(userInput);
           }
       }

       // Step 2: Read and display file content
       Console.WriteLine("\nContents of the file:");
       using (StreamReader reader = new StreamReader(filePath))
       {
           string line;
           while ((line = reader.ReadLine()) != null)
           {
               Console.WriteLine(line);
           }
       }
   }
}
	







Linear Search Problem 1: Search for the First Negative Number
Problem: You are given an integer array. Write a program that performs Linear Search to find the first negative number in the array.
using System;

class Program
{
   static void Main()
   {
       int[] numbers = { 5, 3, -1, 7, -8, 10 };

       for (int i = 0; i < numbers.Length; i++)
       {
           if (numbers[i] < 0)
           {
               Console.WriteLine("First negative number: " + numbers[i]);
               return;
           }
       }

       Console.WriteLine("No negative numbers found.");
   }
}
	





Linear Search Problem 2: Search for a Specific Word in a List of Sentences
Problem: You are given an array of sentences. Write a program that performs Linear Search to find the first sentence containing a specific word.
using System;

class Program
{
   static string SearchSentence(string[] sentences, string targetWord)
   {
       foreach (string sentence in sentences)
       {
           if (WordExists(sentence, targetWord))
           {
               return sentence;
           }
       }
       return "Not Found";
   }

   static bool WordExists(string sentence, string targetWord)
   {
       int sentenceLength = sentence.Length;
       int targetLength = targetWord.Length;

       for (int i = 0; i <= sentenceLength - targetLength; i++)
       {
           int j;
           for (j = 0; j < targetLength; j++)
           {
               if (sentence[i + j] != targetWord[j])
               {
                   break;
               }
           }

           // Check if it's a complete word match
           if (j == targetLength && 
              (i + targetLength == sentenceLength || sentence[i + targetLength] == ' ') && 
              (i == 0 || sentence[i - 1] == ' '))
           {
               return true;
           }
       }
       return false;
   }

   static void Main()
   {
       string[] sentences = {
           "The quick brown fox jumps over the lazy dog",
           "A journey of a thousand miles begins with a single step",
           "Hello world! Welcome to programming",
           "This is a simple search problem"
       };

       string targetWord = "world";
       string result = SearchSentence(sentences, targetWord);

       Console.WriteLine("First sentence containing the word: " + result);
   }
}
	





Binary Search Problem 1: Find the Rotation Point in a Rotated Sorted Array
Problem: You are given a rotated sorted array. Write a program that performs Binary Search to find the index of the smallest element in the array.
using System;

class Program
{
   static int FindRotationPoint(int[] arr)
   {
       int left = 0, right = arr.Length - 1;

       while (left < right)
       {
           int mid = left + (right - left) / 2;
           if (arr[mid] > arr[right])
           {
               left = mid + 1;
           }
           else
           {
               right = mid;
           }
       }

       return left;
   }

   static void Main()
   {
       int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
       Console.WriteLine("Rotation Point Index: " + FindRotationPoint(arr));
   }
}
	





Binary Search Problem 2: Find the Peak Element in an Array
Problem: A peak element is an element that is greater than its neighbors. Write a program that performs Binary Search to find a peak element in an array.
using System;

class Program
{
   static int FindPeakElement(int[] nums)
   {
       int left = 0, right = nums.Length - 1;

       while (left < right)
       {
           int mid = left + (right - left) / 2;
           if (nums[mid] > nums[mid + 1])
           {
               right = mid;
           }
           else
           {
               left = mid + 1;
           }
       }

       return left;
   }

   static void Main()
   {
       int[] arr = { 1, 3, 7, 8, 5, 2 };
       Console.WriteLine("Peak Element Index: " + FindPeakElement(arr));
   }
}
	





Binary Search Problem 3: Search for a Target Value in a 2D Sorted Matrix
Problem: You are given a 2D matrix where each row is sorted in ascending order. Write a program that performs Binary Search to find a target value in the matrix.
using System;

class Program
{
   static bool SearchMatrix(int[,] matrix, int target)
   {
       int rows = matrix.GetLength(0);
       int cols = matrix.GetLength(1);
       int left = 0, right = rows * cols - 1;

       while (left <= right)
       {
           int mid = left + (right - left) / 2;
           int row = mid / cols;
           int col = mid % cols;
           int midValue = matrix[row, col];

           if (midValue == target)
               return true;
           else if (midValue < target)
               left = mid + 1;
           else
               right = mid - 1;
       }

       return false;
   }

   static void Main()
   {
       int[,] matrix = {
           { 1,  3,  5,  7 },
           { 10, 11, 16, 20 },
           { 23, 30, 34, 60 }
       };

       int target = 16;

       if (SearchMatrix(matrix, target))
           Console.WriteLine("Target found in matrix.");
       else
           Console.WriteLine("Target not found.");
   }
}
	





Binary Search Problem 4: Find the First and Last Occurrence of an Element in a Sorted Array
Problem: Given a sorted array and a target element, write a program that uses Binary Search to find the first and last occurrence of the target element in the array.
using System;

class Program
{
   static int FindFirstOccurrence(int[] arr, int target)
   {
       int left = 0, right = arr.Length - 1;
       int firstIndex = -1;

       while (left <= right)
       {
           int mid = left + (right - left) / 2;

           if (arr[mid] == target)
           {
               firstIndex = mid;  // Possible first occurrence found
               right = mid - 1;    // Keep searching in the left half
           }
           else if (arr[mid] < target)
           {
               left = mid + 1;
           }
           else
           {
               right = mid - 1;
           }
       }

       return firstIndex;
   }

   static int FindLastOccurrence(int[] arr, int target)
   {
       int left = 0, right = arr.Length - 1;
       int lastIndex = -1;

       while (left <= right)
       {
           int mid = left + (right - left) / 2;

           if (arr[mid] == target)
           {
               lastIndex = mid;   // Possible last occurrence found
               left = mid + 1;    // Keep searching in the right half
           }
           else if (arr[mid] < target)
           {
               left = mid + 1;
           }
           else
           {
               right = mid - 1;
           }
       }

       return lastIndex;
   }

   static void Main()
   {
       int[] sortedArray = { 1, 2, 2, 2, 3, 4, 4, 5, 6 };
       int target = 2;

       int first = FindFirstOccurrence(sortedArray, target);
       int last = FindLastOccurrence(sortedArray, target);

       Console.WriteLine("First Occurrence of " + target + ": " + first);
       Console.WriteLine("Last Occurrence of " + target + ": " + last);
   }
}
	







Challenge Problem (for both Linear and Binary Search)


Problem:
You are given a list of integers. Write a program that uses Linear Search to find the first missing positive integer in the list and Binary Search to find the index of a given target number.
Approach:
1. Linear Search for the first missing positive integer:
   * Iterate through the list and mark each number in the list as visited (you can use negative marking or a separate array).
   * Traverse the array again to find the first positive integer that is not marked.
using System;

class Program
{
   static int FindMissingPositive(int[] nums)
   {
       bool[] seen = new bool[nums.Length + 1];

       for (int i = 0; i < nums.Length; i++)
       {
           if (nums[i] > 0 && nums[i] <= nums.Length)
           {
               seen[nums[i]] = true;
           }
       }

       for (int i = 1; i <= nums.Length; i++)
       {
           if (!seen[i])
           {
               return i;
           }
       }

       return nums.Length + 1;
   }

   static void Main()
   {
       int[] arr = { 3, 4, -1, 1 };
       Console.WriteLine("First Missing Positive: " + FindMissingPositive(arr));
   }
}
	



2. Binary Search for the target index:
   * After sorting the array, perform binary search to find the index of the given target number.
   * Return the index if found, otherwise return -1.
using System;

class Program
{
   static int BinarySearch(int[] arr, int target)
   {
       int left = 0, right = arr.Length - 1;

       while (left <= right)
       {
           int mid = left + (right - left) / 2;

           if (arr[mid] == target)
           {
               return mid;
           }
           else if (arr[mid] < target)
           {
               left = mid + 1;
           }
           else
           {
               right = mid - 1;
           }
       }

       return -1;
   }

   static void Main()
   {
       int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
       Console.WriteLine("Index of 5: " + BinarySearch(arr, 5));
   }
}