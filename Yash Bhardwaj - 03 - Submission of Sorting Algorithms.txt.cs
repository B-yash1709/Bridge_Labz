Sorting Algorithm Problems in C#
1. Bubble Sort - Sort Student Marks
Problem Statement:
A school maintains student marks in an array. Implement Bubble Sort in C# to sort the student marks in ascending order.
Hint:
* Traverse through the array multiple times.
* Compare adjacent elements and swap them if needed.
* Repeat the process until no swaps are required.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler


using System;

public class BubbleSort
{
   public static void Main(string[] args){
       Console.WriteLine("Enter the number of students: ");
       int num = int.Parse(Console.ReadLine());
       int [] arr = new int [num];
       Console.WriteLine("Enter the marks: ");
       for(int i=0; i<num; i++){
       Console.Write($"Marks of student {i + 1}: ");
        arr[i] = int.Parse(Console.ReadLine());
       }
       
       
       // Comparing two elements
       int temp =0;
       for (int i=0; i<num -1; i++){
           for (int j=0; j<num -i-1; j++){
               if(arr[j]>arr[j+1]){
                   temp= arr[j];
                   arr[j]=arr[j+1];
                   arr[j+1]=temp;
               }
               
           }
              
       } 
        Console.WriteLine("\nSorted marks in ascending order:");
         Console.WriteLine(string.Join( " ", arr));   

   }
}
	        
        
    


________________


2. Insertion Sort - Sort Employee IDs
Problem Statement:
A company stores employee IDs in an unsorted array. Implement Insertion Sort in C# to sort the employee IDs in ascending order.
Hint:
* Divide the array into sorted and unsorted parts.
* Pick an element from the unsorted part and insert it into its correct position in the sorted part.
* Repeat for all elements.
using System;

class Program
{
   static void Main()
   {
       Console.Write("Enter the number of employees: ");
       int n = int.Parse(Console.ReadLine());

       int[] empIDs = new int[n];
       Console.WriteLine("Enter Employee IDs:");

       // Taking input
       for (int i = 0; i < n; i++)
           empIDs[i] = int.Parse(Console.ReadLine());

       // Insertion Sort
       for (int i = 1; i < n; i++)
       {
           int key = empIDs[i], j = i - 1;
           while (j >= 0 && empIDs[j] > key)
           {
               empIDs[j + 1] = empIDs[j];
               j--;
           }
           empIDs[j + 1] = key;
       }

       // Output sorted array
       Console.WriteLine("\nSorted Employee IDs:");
       Console.WriteLine(string.Join(" ", empIDs));
   }
}
	



________________


3. Merge Sort - Sort an Array of Book Prices
Problem Statement:
A bookstore maintains a list of book prices in an array. Implement Merge Sort in C# to sort the prices in ascending order.
Hint:
* Divide the array into two halves recursively.
* Sort both halves individually.
* Merge the sorted halves by comparing elements.
using System;

class MergeSortExample
{
   static void Main()
   {
       Console.Write("Enter the number of books: ");
       int n = int.Parse(Console.ReadLine());

       double[] prices = new double[n];
       Console.WriteLine("Enter the book prices:");

       // Taking input
       for (int i = 0; i < n; i++)
           prices[i] = double.Parse(Console.ReadLine());

       // Apply Merge Sort
       MergeSort(prices, 0, n - 1);

       // Output sorted prices
       Console.WriteLine("\nSorted book prices:");
       Console.WriteLine(string.Join(" ", prices));
   }

   // Merge Sort function
   static void MergeSort(double[] arr, int left, int right)
   {
       if (left < right)
       {
           int mid = (left + right) / 2;

           // Sort first and second halves
           MergeSort(arr, left, mid);
           MergeSort(arr, mid + 1, right);

           // Merge the sorted halves
           Merge(arr, left, mid, right);
       }
   }

   // Merge function
   static void Merge(double[] arr, int left, int mid, int right)
   {
       int n1 = mid - left + 1;
       int n2 = right - mid;

       // Create temporary arrays
       double[] leftArr = new double[n1];
       double[] rightArr = new double[n2];

       // Copy data to temp arrays
       Array.Copy(arr, left, leftArr, 0, n1);
       Array.Copy(arr, mid + 1, rightArr, 0, n2);

       // Merge the two arrays
       int i = 0, j = 0, k = left;
       while (i < n1 && j < n2)
       {
           if (leftArr[i] <= rightArr[j])
               arr[k++] = leftArr[i++];
           else
               arr[k++] = rightArr[j++];
       }

       // Copy remaining elements
       while (i < n1)
           arr[k++] = leftArr[i++];
       while (j < n2)
           arr[k++] = rightArr[j++];
   }
}
	



________________






4. Quick Sort - Sort Product Prices
Problem Statement:
An e-commerce company wants to display product prices in ascending order. Implement Quick Sort in C# to sort the product prices.
Hint:
* Pick a pivot element (first, last, or random).
* Partition the array such that elements smaller than the pivot are on the left and larger ones are on the right.
* Recursively apply Quick Sort on left and right partitions.
using System;

class QuickSortExample
{
   static void Main()
   {
       Console.Write("Enter the number of products: ");
       int n = int.Parse(Console.ReadLine());

       double[] prices = new double[n];
       Console.WriteLine("Enter the product prices:");

       // Taking input
       for (int i = 0; i < n; i++)
           prices[i] = double.Parse(Console.ReadLine());

       // Apply Quick Sort
       QuickSort(prices, 0, n - 1);

       // Output sorted prices
       Console.WriteLine("\nSorted product prices:");
       Console.WriteLine(string.Join(" ", prices));
   }

   // Quick Sort function
   static void QuickSort(double[] arr, int low, int high)
   {
       if (low < high)
       {
           int pivotIndex = Partition(arr, low, high);

           // Recursively sort elements before and after partition
           QuickSort(arr, low, pivotIndex - 1);
           QuickSort(arr, pivotIndex + 1, high);
       }
   }

   // Partition function
   static int Partition(double[] arr, int low, int high)
   {
       double pivot = arr[high]; // Choosing last element as pivot
       int i = low - 1;

       for (int j = low; j < high; j++)
       {
           if (arr[j] <= pivot) // Place smaller elements to the left
           {
               i++;
               (arr[i], arr[j]) = (arr[j], arr[i]); // Swap
           }
       }

       // Swap pivot into correct position
       (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
       return i + 1;
   }
}
	



________________


5. Selection Sort - Sort Exam Scores
Problem Statement:
A university needs to sort students’ exam scores in ascending order. Implement Selection Sort in C# to achieve this.
Hint:
* Find the minimum element in the array.
* Swap it with the first unsorted element.
* Repeat the process for the remaining elements.
________________


6. Heap Sort - Sort Job Applicants by Salary
Problem Statement:
A company receives job applications with different expected salary demands. Implement Heap Sort in C# to sort these salary demands in ascending order.
Hint:
* Build a Max Heap from the array.
* Extract the largest element (root) and place it at the end.
* Reheapify the remaining elements and repeat until sorted.
using System;

class SelectionSortExample
{
   static void Main()
   {
       Console.Write("Enter the number of students: ");
       int n = int.Parse(Console.ReadLine());

       int[] scores = new int[n];
       Console.WriteLine("Enter the exam scores:");

       // Taking input
       for (int i = 0; i < n; i++)
           scores[i] = int.Parse(Console.ReadLine());

       // Apply Selection Sort
       SelectionSort(scores, n);

       // Output sorted scores
       Console.WriteLine("\nSorted exam scores:");
       Console.WriteLine(string.Join(" ", scores));
   }

   // Selection Sort function
   static void SelectionSort(int[] arr, int n)
   {
       for (int i = 0; i < n - 1; i++)
       {
           int minIndex = i;
           for (int j = i + 1; j < n; j++)
           {
               if (arr[j] < arr[minIndex]) // Find the minimum element
                   minIndex = j;
           }

           // Swap minimum element with the first unsorted element
           (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
       }
   }
}
	



________________






7. Counting Sort - Sort Student Ages
Problem Statement:
A school collects students’ ages (ranging from 10 to 18) and wants them sorted. Implement Counting Sort in C# for this task.
Hint:
* Create a count array to store the frequency of each age.
* Compute cumulative frequencies to determine positions.
* Place elements in their correct positions in the output array.
using System;

class CountingSortExample
{
   static void Main()
   {
       Console.Write("Enter the number of students: ");
       int n = int.Parse(Console.ReadLine());

       int[] ages = new int[n];
       Console.WriteLine("Enter the student ages (between 10 and 18):");

       // Taking input
       for (int i = 0; i < n; i++)
           ages[i] = int.Parse(Console.ReadLine());

       // Apply Counting Sort
       int[] sortedAges = CountingSort(ages, 10, 18);

       // Output sorted ages
       Console.WriteLine("\nSorted student ages:");
       Console.WriteLine(string.Join(" ", sortedAges));
   }

   // Counting Sort function
   static int[] CountingSort(int[] arr, int min, int max)
   {
       int range = max - min + 1;
       int[] count = new int[range];
       int[] output = new int[arr.Length];

       // Count occurrences
       foreach (int age in arr)
           count[age - min]++;

       // Compute cumulative frequency
       for (int i = 1; i < range; i++)
           count[i] += count[i - 1];

       // Place elements in correct positions
       for (int i = arr.Length - 1; i >= 0; i--)
       {
           output[count[arr[i] - min] - 1] = arr[i];
           count[arr[i] - min]--;
       }

       return output;
   }
}
	



________________