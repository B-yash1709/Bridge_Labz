Best Practices for Runtime Analysis & Big O Notation
When designing algorithms, follow these best practices to ensure optimal time and space complexity.
🟢 General Algorithm Best Practices
1. Choose the right data structure
   * Use HashMap for O(1) lookups instead of ArrayList (O(N)).
   * Use TreeSet for ordered data retrieval with O(log N) complexity.
2. Optimize loops & conditions
   * Avoid unnecessary nested loops (O(N²) or worse).
   * Use break/return early to reduce iterations.
3. Use sorting efficiently
   * Prefer Merge Sort (O(N log N)) over Bubble Sort (O(N²)).
   * If frequent sorting is needed, consider TreeMap (O(log N) per operation).
4. Avoid excessive recursion
   * Recursive Fibonacci (O(2ⁿ)) is inefficient; use Memoization (O(N)).
   * Use Tail Recursion when applicable.
5. Reduce redundant computations
   * Store results of expensive operations using caching/memoization.
   * Example: Use Dynamic Programming to avoid recomputation.


🔵 Time & Space Complexity Optimization
1. Precompute values when possible
   * If computing the same value multiple times, store it in a lookup table.
2. Use efficient searching methods
   * Instead of Linear Search (O(N)), use Binary Search (O(log N)) for sorted data.
3. Use efficient iteration techniques
* Instead of for (int i = 0; i < list.Count; i++), use foreach loops. 
* foreach (string s in list)
4. Optimize memory usage
* Use StringBuilder instead of string for concatenation.
* Use primitive types (int, double) over wrapper classes (Int32, Double) when possible.


5. Profile & benchmark performance
* Use .NET Stopwatch to measure execution time.
________________


Problem Statements & Comparative Analysis
1. Search a Target in a Large Dataset
Objective
Compare the performance of Linear Search (O(N)) and Binary Search (O(log N)) on different dataset sizes.
Approach
* Linear Search: Scan each element until the target is found.
* Binary Search: Sort the data first (O(N log N)), then perform O(log N) search.
Dataset Size (N)
	Linear Search (O(N))
	Binary Search (O(log N))
	1,000
	1ms
	0.01ms
	10,000
	10ms
	0.02ms
	1,000,000
	1s
	0.1ms
	Expected Result
Binary Search performs much better for large datasets, provided data is sorted.
using System;
using System.Diagnostics;

class SearchComparison
{
   static void Main()
   {
       // Different dataset sizes for testing
       int[] datasetSizes = { 1000, 10000, 100000, 1000000 };
       Random random = new Random();
       
       foreach (int size in datasetSizes)
       {
           // Generate a random dataset
           int[] data = new int[size];
           for (int i = 0; i < size; i++)
               data[i] = random.Next(1, size * 10); // Random numbers in a large range
           
           // Pick a random target from the dataset
           int target = data[random.Next(size)];

           Console.WriteLine($"\nDataset Size: {size}");

           // Measure Linear Search Execution Time
           double linearTime = MeasureExecutionTime(() => LinearSearch(data, target));
           Console.WriteLine($"Linear Search Time: {linearTime} ms");

           // Measure Binary Search Execution Time (Including Sorting)
           double binaryTime = MeasureExecutionTime(() =>
           {
               Array.Sort(data); // Sorting required for Binary Search
               BinarySearch(data, target);
           });

           Console.WriteLine($"Binary Search (Sorting + Search) Time: {binaryTime} ms");
       }
   }

   // Linear Search: Scans each element until the target is found
   static int LinearSearch(int[] data, int target)
   {
       for (int i = 0; i < data.Length; i++)
       {
           if (data[i] == target)
               return i; // Target found
       }
       return -1; // Target not found
   }

   // Binary Search: Requires sorted data, then performs O(log N) search
   static int BinarySearch(int[] data, int target)
   {
       int left = 0, right = data.Length - 1;
       while (left <= right)
       {
           int mid = left + (right - left) / 2;
           if (data[mid] == target)
               return mid; // Target found
           else if (data[mid] < target)
               left = mid + 1;
           else
               right = mid - 1;
       }
       return -1; // Target not found
   }

   // Helper function to measure execution time of a function
   static double MeasureExecutionTime(Action action)
   {
       Stopwatch stopwatch = Stopwatch.StartNew();
       action();
       stopwatch.Stop();
       return stopwatch.Elapsed.TotalMilliseconds;
   }
}
	



________________


2. Sorting Large Data Efficiently
Objective
Compare sorting algorithms Bubble Sort (O(N²)), Merge Sort (O(N log N)), and Quick Sort (O(N log N)).
Approach
* Bubble Sort: Repeated swapping (inefficient for large data).
* Merge Sort: Divide & Conquer approach (stable).
* Quick Sort: Partition-based approach (fast but unstable).
Dataset Size (N)
	Bubble Sort (O(N²))
	Merge Sort (O(N log N))
	Quick Sort (O(N log N))
	1,000
	50ms
	5ms
	3ms
	10,000
	5s
	50ms
	30ms
	1,000,000
	Unfeasible (>1hr)
	3s
	2s
	Expected Result
Bubble Sort is impractical for large datasets. Merge Sort & Quick Sort perform well.
using System;
using System.Diagnostics;

class SortingComparison
{
   static void Main()
   {
       // Different dataset sizes for testing
       int[] datasetSizes = { 1000, 10000, 50000 };
       Random random = new Random();
       
       foreach (int size in datasetSizes)
       {
           // Generate a random dataset
           int[] data = new int[size];
           for (int i = 0; i < size; i++)
               data[i] = random.Next(1, size * 10); // Random numbers in a large range
           
           Console.WriteLine($"\nDataset Size: {size}");

           // Measure Bubble Sort Execution Time (Only for small datasets)
           if (size <= 10000)
           {
               int[] dataCopy = (int[])data.Clone();
               double bubbleTime = MeasureExecutionTime(() => BubbleSort(dataCopy));
               Console.WriteLine($"Bubble Sort Time: {bubbleTime} ms");
           }
           else
           {
               Console.WriteLine("Bubble Sort skipped for large datasets.");
           }

           // Measure Merge Sort Execution Time
           int[] mergeData = (int[])data.Clone();
           double mergeTime = MeasureExecutionTime(() => MergeSort(mergeData, 0, mergeData.Length - 1));
           Console.WriteLine($"Merge Sort Time: {mergeTime} ms");

           // Measure Quick Sort Execution Time
           int[] quickData = (int[])data.Clone();
           double quickTime = MeasureExecutionTime(() => QuickSort(quickData, 0, quickData.Length - 1));
           Console.WriteLine($"Quick Sort Time: {quickTime} ms");
       }
   }

   // Bubble Sort: Inefficient for large datasets (O(N²))
   static void BubbleSort(int[] data)
   {
       int n = data.Length;
       for (int i = 0; i < n - 1; i++)
       {
           for (int j = 0; j < n - i - 1; j++)
           {
               if (data[j] > data[j + 1])
               {
                   // Swap
                   int temp = data[j];
                   data[j] = data[j + 1];
                   data[j + 1] = temp;
               }
           }
       }
   }

   // Merge Sort: Efficient, stable (O(N log N))
   static void MergeSort(int[] data, int left, int right)
   {
       if (left < right)
       {
           int mid = left + (right - left) / 2;
           MergeSort(data, left, mid);
           MergeSort(data, mid + 1, right);
           Merge(data, left, mid, right);
       }
   }

   static void Merge(int[] data, int left, int mid, int right)
   {
       int n1 = mid - left + 1;
       int n2 = right - mid;

       int[] leftArray = new int[n1];
       int[] rightArray = new int[n2];

       Array.Copy(data, left, leftArray, 0, n1);
       Array.Copy(data, mid + 1, rightArray, 0, n2);

       int i = 0, j = 0, k = left;
       while (i < n1 && j < n2)
       {
           if (leftArray[i] <= rightArray[j])
               data[k++] = leftArray[i++];
           else
               data[k++] = rightArray[j++];
       }

       while (i < n1)
           data[k++] = leftArray[i++];
       while (j < n2)
           data[k++] = rightArray[j++];
   }

   // Quick Sort: Fast but unstable (O(N log N))
   static void QuickSort(int[] data, int low, int high)
   {
       if (low < high)
       {
           int pivotIndex = Partition(data, low, high);
           QuickSort(data, low, pivotIndex - 1);
           QuickSort(data, pivotIndex + 1, high);
       }
   }

   static int Partition(int[] data, int low, int high)
   {
       int pivot = data[high];
       int i = low - 1;
       for (int j = low; j < high; j++)
       {
           if (data[j] <= pivot)
           {
               i++;
               (data[i], data[j]) = (data[j], data[i]); // Swap using tuple
           }
       }
       (data[i + 1], data[high]) = (data[high], data[i + 1]); // Swap pivot
       return i + 1;
   }

   // Helper function to measure execution time of a function
   static double MeasureExecutionTime(Action action)
   {
       Stopwatch stopwatch = Stopwatch.StartNew();
       action();
       stopwatch.Stop();
       return stopwatch.Elapsed.TotalMilliseconds;
   }
}
	



________________


3. String Concatenation Performance
Objective
Compare the performance of string (O(N²)), StringBuilder (O(N)), and StringBuffer (O(N)) when concatenating a million strings.
Approach
* Using string (Immutable, creates a new object each time)
* Using StringBuilder (Fast, mutable, thread-unsafe)
Operations Count (N)
	string (O(N²))
	StringBuilder (O(N))
	1,000
	10ms
	1ms
	10,000
	1s
	10ms
	1,000,000
	30m (Unusable)
	50ms
	Expected Result
StringBuilder is much more efficient than string for concatenation.
using System;
using System.Diagnostics;
using System.Text;

class StringConcatenationPerformance
{
   static void Main()
   {
       // Define test sizes
       int[] testSizes = { 1000, 10000, 100000, 1000000 };

       foreach (int size in testSizes)
       {
           Console.WriteLine($"\nConcatenating {size} strings...");

           // String Concatenation Test (Immutable, slow)
           double stringTime = MeasureExecutionTime(() =>
           {
               string result = "";
               for (int i = 0; i < size; i++)
               {
                   result += "a"; // Creates a new string object every time
               }
           });
           Console.WriteLine($"String Concatenation Time: {stringTime} ms");

           // StringBuilder Concatenation Test (Mutable, fast)
           double stringBuilderTime = MeasureExecutionTime(() =>
           {
               StringBuilder sb = new StringBuilder();
               for (int i = 0; i < size; i++)
               {
                   sb.Append("a");
               }
           });
           Console.WriteLine($"StringBuilder Concatenation Time: {stringBuilderTime} ms");

           // Simulating StringBuffer (thread-safe alternative)
           double stringBufferTime = MeasureExecutionTime(() =>
           {
               lock (typeof(StringConcatenationPerformance))
               {
                   StringBuilder sb = new StringBuilder(); // C# doesn't have StringBuffer, but StringBuilder serves here
                   for (int i = 0; i < size; i++)
                   {
                       sb.Append("a");
                   }
               }
           });
           Console.WriteLine($"Simulated StringBuffer Time (Thread-Safe): {stringBufferTime} ms");
       }
   }

   // Helper function to measure execution time
   static double MeasureExecutionTime(Action action)
   {
       Stopwatch stopwatch = Stopwatch.StartNew();
       action();
       stopwatch.Stop();
       return stopwatch.Elapsed.TotalMilliseconds;
   }
}
	



________________


4. Large File Reading Efficiency
Objective
Compare StreamReader and FileStream when reading a large file (500MB).
Approach
* StreamReader: Reads character by character (slower for binary files).
* FileStream: Reads bytes and converts to characters (more efficient).
File Size
	StreamReader Time
	FileStream Time
	1MB
	50ms
	30ms
	100MB
	3s
	1.5s
	500MB
	10s
	5s
	Expected Result
FileStream is more efficient for large files. StreamReader is preferable for text-based data.
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class LargeFileReadingComparison
{
   static void Main()
   {
       string filePath = "largefile.txt"; // Ensure this file exists (500MB+ text file)

       if (!File.Exists(filePath))
       {
           Console.WriteLine($"Error: File '{filePath}' not found.");
           return;
       }

       try
       {
           // Test StreamReader (Character-Based Reading)
           double streamReaderTime = MeasureExecutionTime(() =>
           {
               using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8)) // Explicit UTF-8 encoding
               {
                   while (sr.ReadLine() != null) { } // Read each line
               }
           });
           Console.WriteLine($"StreamReader Time: {streamReaderTime} ms");
       }
       catch (Exception ex)
       {
           Console.WriteLine($"StreamReader Error: {ex.Message}");
       }

       try
       {
           // Test FileStream (Byte-Based Reading)
           double fileStreamTime = MeasureExecutionTime(() =>
           {
               using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
               {
                   byte[] buffer = new byte[8192]; // 8KB buffer for efficiency
                   while (fs.Read(buffer, 0, buffer.Length) > 0) { }
               }
           });
           Console.WriteLine($"FileStream Time: {fileStreamTime} ms");
       }
       catch (Exception ex)
       {
           Console.WriteLine($"FileStream Error: {ex.Message}");
       }
   }

   // Helper function to measure execution time
   static double MeasureExecutionTime(Action action)
   {
       Stopwatch stopwatch = Stopwatch.StartNew();
       action();
       stopwatch.Stop();
       return stopwatch.Elapsed.TotalMilliseconds;
   }
}
	



________________


5. Recursive vs Iterative Fibonacci Computation
Objective
Compare Recursive (O(2^N)) vs Iterative (O(N)) Fibonacci solutions.
Approach
Recursive:
public static int FibonacciRecursive(int n) {
    if (n <= 1) return n;
    return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}
Iterative:
public static int FibonacciIterative(int n) {
    int a = 0, b = 1, sum;
    for (int i = 2; i <= n; i++) {
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}
Fibonacci (N)
	Recursive (O(2^N))
	Iterative (O(N))
	10
	1ms
	0.01ms
	30
	5s
	0.05ms
	50
	Unfeasible (>1hr)
	0.1ms
	Expected Result
Recursive approach is infeasible for large values of N due to exponential growth. The iterative approach is significantly faster and memory-efficient.
using System;
using System.Diagnostics;

class FibonacciComparison
{
   static void Main()
   {
       int[] testCases = { 10, 30, 50 };

       foreach (int n in testCases)
       {
           Console.WriteLine($"\nComputing Fibonacci({n}):");

           // Recursive Fibonacci (Exponential Time Complexity O(2^N))
           double recursiveTime = MeasureExecutionTime(() =>
           {
               try
               {
                   Console.WriteLine($"Recursive Result: {FibonacciRecursive(n)}");
               }
               catch (StackOverflowException)
               {
                   Console.WriteLine("Recursive computation caused a stack overflow!");
               }
           });
           Console.WriteLine($"Recursive Fibonacci Time: {recursiveTime} ms");

           // Iterative Fibonacci (Linear Time Complexity O(N))
           double iterativeTime = MeasureExecutionTime(() =>
           {
               Console.WriteLine($"Iterative Result: {FibonacciIterative(n)}");
           });
           Console.WriteLine($"Iterative Fibonacci Time: {iterativeTime} ms");
       }
   }

   // Recursive Fibonacci (O(2^N)) - Extremely slow for large N
   public static int FibonacciRecursive(int n)
   {
       if (n <= 1) return n;
       return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
   }

   // Iterative Fibonacci (O(N)) - Fast and efficient
   public static int FibonacciIterative(int n)
   {
       if (n <= 1) return n;
       
       int a = 0, b = 1, sum = 0;
       for (int i = 2; i <= n; i++)
       {
           sum = a + b;
           a = b;
           b = sum;
       }
       return b;
   }

   // Helper function to measure execution time
   static double MeasureExecutionTime(Action action)
   {
       Stopwatch stopwatch = Stopwatch.StartNew();
       action();
       stopwatch.Stop();
       return stopwatch.Elapsed.TotalMilliseconds;
   }
}
	



________________