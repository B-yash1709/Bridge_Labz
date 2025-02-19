C# Collections and System Design Problems
List Interface Problems
1. Reverse a List
Write a program to reverse the elements of a given list without using built-in reverse methods. Implement it for both ArrayList and LinkedList.
Example:
Input: [1, 2, 3, 4, 5]
Output: [5, 4, 3, 2, 1]
using System;
using System.Collections.Generic;

class ReverseList
{
   // Method to reverse an ArrayList
   public static void ReverseArrayList<T>(List<T> list)
   {
       int left = 0, right = list.Count - 1;
       while (left < right)
       {
           T temp = list[left];
           list[left] = list[right];
           list[right] = temp;
           left++;
           right--;
       }
   }

   // Method to reverse a LinkedList
   public static void ReverseLinkedList<T>(LinkedList<T> list)
   {
       LinkedListNode<T> left = list.First;
       LinkedListNode<T> right = list.Last;
       int count = list.Count / 2;
       while (count-- > 0)
       {
           T temp = left.Value;
           left.Value = right.Value;
           right.Value = temp;
           left = left.Next;
           right = right.Previous;
       }
   }

   static void Main()
   {
       List<int> arrayList = new List<int> { 1, 2, 3, 4, 5 };
       LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

       Console.WriteLine("Original ArrayList: " + string.Join(", ", arrayList));
       ReverseArrayList(arrayList);
       Console.WriteLine("Reversed ArrayList: " + string.Join(", ", arrayList));

       Console.WriteLine("Original LinkedList: " + string.Join(", ", linkedList));
       ReverseLinkedList(linkedList);
       Console.WriteLine("Reversed LinkedList: " + string.Join(", ", linkedList));
   }
}
	



________________


2. Find Frequency of Elements
Given a list of strings, count the frequency of each element and return the results in a Dictionary<string, int>.
Example:
Input: {"apple", "banana", "apple", "orange"}
Output: { "apple": 2, "banana": 1, "orange": 1 }
using System;
using System.Collections.Generic;

class FrequencyCounter
{
   // Method to count frequency of elements in a list
   public static Dictionary<string, int> CountFrequency(List<string> list)
   {
       Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
       foreach (var item in list)
       {
           if (frequencyMap.ContainsKey(item))
               frequencyMap[item]++;
           else
               frequencyMap[item] = 1;
       }
       return frequencyMap;
   }

   static void Main()
   {
       List<string> stringList = new List<string> { "apple", "banana", "apple", "orange" };
       Dictionary<string, int> frequency = CountFrequency(stringList);
       Console.WriteLine("Element Frequencies: ");
       foreach (var item in frequency)
       {
           Console.WriteLine(item.Key + ": " + item.Value);
       }
   }
}
	



________________


3. Rotate Elements in a List
Rotate the elements of a list by a given number of positions.
Example:
Input: [10, 20, 30, 40, 50], rotate by 2
Output: [30, 40, 50, 10, 20]
using System;
using System.Collections.Generic;

class ListRotator
{
   // Method to rotate a list by a given number of positions
   public static List<int> RotateList(List<int> list, int positions)
   {
       int n = list.Count;
       positions = positions % n; // Handle cases where positions > list size
       List<int> rotatedList = new List<int>();
       
       for (int i = positions; i < n; i++)
       {
           rotatedList.Add(list[i]);
       }
       for (int i = 0; i < positions; i++)
       {
           rotatedList.Add(list[i]);
       }
       return rotatedList;
   }

   static void Main()
   {
       List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
       int rotateBy = 2;

       List<int> rotatedNumbers = RotateList(numbers, rotateBy);
       Console.WriteLine("Rotated List: " + string.Join(", ", rotatedNumbers));
   }
}
	



________________


4. Remove Duplicates While Preserving Order
Remove duplicate elements from a list while maintaining the original order.
Example:
Input: [3, 1, 2, 2, 3, 4]
Output: [3, 1, 2, 4]
using System;
using System.Collections.Generic;

class RemoveDuplicates
{
   // Method to remove duplicates while preserving order
   public static List<int> RemoveDuplicatesPreserveOrder(List<int> list)
   {
       HashSet<int> seen = new HashSet<int>();
       List<int> result = new List<int>();
       
       foreach (var item in list)
       {
           if (!seen.Contains(item))
           {
               seen.Add(item);
               result.Add(item);
           }
       }
       return result;
   }

   static void Main()
   {
       List<int> numbers = new List<int> { 3, 1, 2, 2, 3, 4 };
       List<int> uniqueNumbers = RemoveDuplicatesPreserveOrder(numbers);
       Console.WriteLine("List after removing duplicates: " + string.Join(", ", uniqueNumbers));
   }
}
	



________________


5. Find the Nth Element from the End
Given a singly linked list (LinkedList), find the Nth element from the end without calculating its size.
Example:
Input: [A, B, C, D, E], N=2
Output: D
using System;
using System.Collections.Generic;

class LinkedListHelper
{
   // Method to find the Nth element from the end without calculating size
   public static T FindNthFromEnd<T>(LinkedList<T> list, int n)
   {
       LinkedListNode<T> mainPtr = list.First;
       LinkedListNode<T> refPtr = list.First;
       
       // Move refPtr n nodes ahead
       for (int i = 0; i < n; i++)
       {
           if (refPtr == null)
               throw new ArgumentException("N is larger than the size of the list");
           refPtr = refPtr.Next;
       }
       
       // Move both pointers one by one until refPtr reaches the end
       while (refPtr != null)
       {
           mainPtr = mainPtr.Next;
           refPtr = refPtr.Next;
       }
       
       return mainPtr.Value;
   }

   static void Main()
   {
       LinkedList<char> letters = new LinkedList<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });
       int n = 2;
       try
       {
           char result = FindNthFromEnd(letters, n);
           Console.WriteLine("The {0}th element from the end is: {1}", n, result);
       }
       catch (Exception e)
       {
           Console.WriteLine(e.Message);
       }
   }
}
	



________________


Set Interface Problems
1. Check if Two Sets Are Equal
Compare two sets and determine if they contain the same elements, regardless of order.
Example:
Set1: {1, 2, 3}, Set2: {3, 2, 1}
Output: true
using System;
using System.Collections.Generic;

class SetComparer
{
   // Method to check if two sets are equal
   public static bool AreSetsEqual<T>(HashSet<T> set1, HashSet<T> set2)
   {
       return set1.SetEquals(set2);
   }

   static void Main()
   {
       HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
       HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };
       
       bool result = AreSetsEqual(set1, set2);
       Console.WriteLine("Are sets equal? " + result);
   }
}
	



________________


2. Union and Intersection of Two Sets
Compute the union and intersection of two sets.
Example:
Set1: {1, 2, 3}, Set2: {3, 4, 5}
Output:
Union: {1, 2, 3, 4, 5}
Intersection: {3}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
   static void Main()
   {
       HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
       HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

       // Compute Union
       HashSet<int> unionSet = new HashSet<int>(set1);
       unionSet.UnionWith(set2);

       // Compute Intersection
       HashSet<int> intersectionSet = new HashSet<int>(set1);
       intersectionSet.IntersectWith(set2);

       // Display results
       Console.WriteLine("Union: " + string.Join(", ", unionSet));
       Console.WriteLine("Intersection: " + string.Join(", ", intersectionSet));
   }
}
	



________________


3. Symmetric Difference
Find the symmetric difference (elements present in either set but not both).
Example:
Input: {1, 2, 3}, {3, 4, 5}
Output: {1, 2, 4, 5}
using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       int[] set1 = { 1, 2, 3 };
       int[] set2 = { 3, 4, 5 };

       List<int> symmetricDifference = FindSymmetricDifference(set1, set2);

       Console.WriteLine("Symmetric Difference: " + string.Join(", ", symmetricDifference));
   }

   static List<int> FindSymmetricDifference(int[] set1, int[] set2)
   {
       List<int> result = new List<int>();

       // Add elements from set1 that are not in set2
       foreach (int num in set1)
       {
           if (!Contains(set2, num)) // Custom contains check
               result.Add(num);
       }

       // Add elements from set2 that are not in set1
       foreach (int num in set2)
       {
           if (!Contains(set1, num)) // Custom contains check
               result.Add(num);
       }

       return result;
   }

   // Custom method to check if an array contains an element
   static bool Contains(int[] array, int value)
   {
       foreach (int num in array)
       {
           if (num == value)
               return true;
       }
       return false;
   }
}
	



________________


4. Convert a Set to a Sorted List
Convert a HashSet<int> into a sorted list in ascending order.
Example:
Input: {5, 3, 9, 1}
Output: [1, 3, 5, 9]
using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };

       // Convert to List
       List<int> sortedList = ConvertToSortedList(set);

       // Display sorted list
       Console.WriteLine("Sorted List: [" + string.Join(", ", sortedList) + "]");
   }

   static List<int> ConvertToSortedList(HashSet<int> set)
   {
       // Convert HashSet to List
       List<int> list = new List<int>(set);

       // Sort using custom sorting (Bubble Sort)
       for (int i = 0; i < list.Count - 1; i++)
       {
           for (int j = 0; j < list.Count - i - 1; j++)
           {
               if (list[j] > list[j + 1]) // Swap if greater
               {
                   int temp = list[j];
                   list[j] = list[j + 1];
                   list[j + 1] = temp;
               }
           }
       }

       return list;
   }
}
	



________________


5. Find Subsets
Check if one set is a subset of another.
Example:
Input: {2, 3}, {1, 2, 3, 4}
Output: true
using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       HashSet<int> subset = new HashSet<int> { 2, 3 };
       HashSet<int> superset = new HashSet<int> { 1, 2, 3, 4 };

       bool isSubset = CheckSubset(subset, superset);

       Console.WriteLine("Is Subset: " + isSubset);
   }

   static bool CheckSubset(HashSet<int> subset, HashSet<int> superset)
   {
       foreach (int num in subset)
       {
           if (!Contains(superset, num)) // Custom contains check
               return false;
       }
       return true;
   }

   // Custom method to check if a set contains an element
   static bool Contains(HashSet<int> set, int value)
   {
       foreach (int num in set)
       {
           if (num == value)
               return true;
       }
       return false;
   }
}
	



________________


Queue Interface Problems
1. Reverse a Queue
Reverse the elements of a queue using only queue operations.
Example:
Input: [10, 20, 30]
Output: [30, 20, 10]
 using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       Queue<int> queue = new Queue<int>();
       queue.Enqueue(10);
       queue.Enqueue(20);
       queue.Enqueue(30);

       Console.WriteLine("Original Queue: " + string.Join(", ", queue));

       queue = ReverseQueue(queue);

       Console.WriteLine("Reversed Queue: " + string.Join(", ", queue));
   }

   static Queue<int> ReverseQueue(Queue<int> queue)
   {
       Stack<int> stack = new Stack<int>();

       // Dequeue all elements from the queue and push onto the stack
       while (queue.Count > 0)
       {
           stack.Push(queue.Dequeue());
       }

       // Pop all elements from the stack and enqueue back to the queue
       while (stack.Count > 0)
       {
           queue.Enqueue(stack.Pop());
       }

       return queue;
   }
}
	



________________


2. Generate Binary Numbers Using a Queue
Generate the first N binary numbers using a queue.
Example:
Input: N=5
Output: {"1", "10", "11", "100", "101"}
using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       int N = 5; // Change N as needed
       List<string> binaryNumbers = GenerateBinaryNumbers(N);

       Console.WriteLine("Binary Numbers: " + string.Join(", ", binaryNumbers));
   }

   static List<string> GenerateBinaryNumbers(int N)
   {
       List<string> result = new List<string>();
       Queue<string> queue = new Queue<string>();

       queue.Enqueue("1"); // Start with "1"

       for (int i = 0; i < N; i++)
       {
           string current = queue.Dequeue();
           result.Add(current);

           // Generate next two binary numbers
           queue.Enqueue(current + "0");
           queue.Enqueue(current + "1");
       }

       return result;
   }
}
	



________________


3. Hospital Triage System
Simulate a hospital triage system using a PriorityQueue where patients with higher severity are treated first.
Example:
Patients: [ ("John", 3), ("Alice", 5), ("Bob", 2) ]
Order: Alice, John, Bob
using System;
using System.Collections.Generic;

class Patient
{
   public string Name { get; }
   public int Severity { get; }

   public Patient(string name, int severity)
   {
       Name = name;
       Severity = severity;
   }
}

class HospitalTriage
{
   private List<Patient> priorityQueue = new List<Patient>();

   // Insert patient into priority queue
   public void Enqueue(string name, int severity)
   {
       Patient newPatient = new Patient(name, severity);
       priorityQueue.Add(newPatient);
       priorityQueue.Sort((a, b) => b.Severity.CompareTo(a.Severity)); // Higher severity first
   }

   // Treat patient with highest severity
   public Patient Dequeue()
   {
       if (priorityQueue.Count == 0) return null;
       Patient patient = priorityQueue[0];
       priorityQueue.RemoveAt(0);
       return patient;
   }

   public bool IsEmpty()
   {
       return priorityQueue.Count == 0;
   }
}

class Program
{
   static void Main()
   {
       HospitalTriage triage = new HospitalTriage();

       triage.Enqueue("John", 3);
       triage.Enqueue("Alice", 5);
       triage.Enqueue("Bob", 2);

       Console.WriteLine("Order of Treatment:");
       while (!triage.IsEmpty())
       {
           Patient treated = triage.Dequeue();
           Console.WriteLine(treated.Name);
       }
   }
}
	



________________


Map Interface Problems
1. Word Frequency Counter
Read a text file and count the frequency of each word using a Dictionary<string, int>.
Example:
Input: "Hello world, hello Java!"
Output: { "hello": 2, "world": 1, "java": 1 }
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
   static void Main()
   {
       string text = "Hello world, hello Java!"; // Example input
       Dictionary<string, int> wordCount = CountWordFrequency(text);

       // Display word frequencies
       Console.WriteLine("Word Frequencies:");
       foreach (var pair in wordCount)
       {
           Console.WriteLine($"\"{pair.Key}\": {pair.Value}");
       }
   }

   static Dictionary<string, int> CountWordFrequency(string text)
   {
       Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

       // Convert text to lowercase and remove punctuation using regex
       string cleanedText = Regex.Replace(text.ToLower(), "[^a-z0-9 ]", "");

       // Split words by spaces
       string[] words = cleanedText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

       // Count word occurrences
       foreach (string word in words)
       {
           if (wordFrequency.ContainsKey(word))
               wordFrequency[word]++;
           else
               wordFrequency[word] = 1;
       }

       return wordFrequency;
   }
}
	



________________


2. Invert a Map
Invert a Dictionary<K, V> to produce a Dictionary<V, List<K>>.
Example:
Input: { A=1, B=2, C=1 }
Output: { 1=[A, C], 2=[B] }
using System;
using System.Collections.Generic;

class Program
{
   static void Main()
   {
       Dictionary<string, int> inputMap = new Dictionary<string, int>
       {
           { "A", 1 },
           { "B", 2 },
           { "C", 1 }
       };

       Dictionary<int, List<string>> invertedMap = InvertDictionary(inputMap);

       // Display the inverted dictionary
       Console.WriteLine("Inverted Dictionary:");
       foreach (var pair in invertedMap)
       {
           Console.WriteLine($"{pair.Key} = [{string.Join(", ", pair.Value)}]");
       }
   }

   static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> original)
   {
       Dictionary<V, List<K>> inverted = new Dictionary<V, List<K>>();

       foreach (var pair in original)
       {
           if (!inverted.ContainsKey(pair.Value))
           {
               inverted[pair.Value] = new List<K>();
           }
           inverted[pair.Value].Add(pair.Key);
       }

       return inverted;
   }
}
	



________________


Real-World System Design Problems
Insurance Policy Management System
1. Store Unique Policies using:
   * HashSet for quick lookups.
   * LinkedHashSet to maintain the order of insertion.
   * SortedSet (TreeSet equivalent) to maintain policies sorted by expiry date.
2. Retrieve Policies:
   * All unique policies.
   * Policies expiring soon (within the next 30 days).
   * Policies with a specific coverage type.
   * Duplicate policies based on policy numbers.
using System;
using System.Collections.Generic;
using System.Linq;

class Policy : IComparable<Policy>
{
   public string PolicyNumber { get; }
   public string HolderName { get; }
   public string CoverageType { get; }
   public DateTime ExpiryDate { get; }

   public Policy(string policyNumber, string holderName, string coverageType, DateTime expiryDate)
   {
       PolicyNumber = policyNumber;
       HolderName = holderName;
       CoverageType = coverageType;
       ExpiryDate = expiryDate;
   }

   public override bool Equals(object obj)
   {
       return obj is Policy policy && PolicyNumber == policy.PolicyNumber;
   }

   public override int GetHashCode()
   {
       return PolicyNumber.GetHashCode();
   }

   public int CompareTo(Policy other)
   {
       return ExpiryDate.CompareTo(other.ExpiryDate);
   }

   public override string ToString()
   {
       return $"{PolicyNumber} - {HolderName}, {CoverageType}, Expiry: {ExpiryDate:yyyy-MM-dd}";
   }
}

class PolicyManagementSystem
{
   private HashSet<Policy> uniquePolicies = new HashSet<Policy>();
   private LinkedList<Policy> orderedPolicies = new LinkedList<Policy>();
   private SortedSet<Policy> sortedPolicies = new SortedSet<Policy>();
   private Dictionary<string, List<Policy>> policyLookup = new Dictionary<string, List<Policy>>();

   public void AddPolicy(Policy policy)
   {
       if (uniquePolicies.Add(policy))
       {
           orderedPolicies.AddLast(policy);
           sortedPolicies.Add(policy);

           if (!policyLookup.ContainsKey(policy.CoverageType))
               policyLookup[policy.CoverageType] = new List<Policy>();

           policyLookup[policy.CoverageType].Add(policy);
       }
   }

   public List<Policy> GetAllUniquePolicies()
   {
       return uniquePolicies.ToList();
   }

   public List<Policy> GetPoliciesExpiringSoon()
   {
       DateTime threshold = DateTime.Now.AddDays(30);
       return sortedPolicies.Where(p => p.ExpiryDate <= threshold).ToList();
   }

   public List<Policy> GetPoliciesByCoverageType(string coverageType)
   {
       return policyLookup.ContainsKey(coverageType) ? policyLookup[coverageType] : new List<Policy>();
   }

   public List<Policy> GetDuplicatePolicies()
   {
       var duplicates = uniquePolicies.GroupBy(p => p.PolicyNumber)
                                      .Where(g => g.Count() > 1)
                                      .SelectMany(g => g)
                                      .ToList();
       return duplicates;
   }
}

class Program
{
   static void Main()
   {
       PolicyManagementSystem system = new PolicyManagementSystem();

       system.AddPolicy(new Policy("P1001", "Alice", "Health", DateTime.Now.AddDays(45)));
       system.AddPolicy(new Policy("P1002", "Bob", "Auto", DateTime.Now.AddDays(15)));
       system.AddPolicy(new Policy("P1003", "Charlie", "Home", DateTime.Now.AddDays(10)));
       system.AddPolicy(new Policy("P1004", "Alice", "Health", DateTime.Now.AddDays(5)));
       system.AddPolicy(new Policy("P1001", "Alice", "Health", DateTime.Now.AddDays(45))); // Duplicate

       Console.WriteLine("\nAll Unique Policies:");
       foreach (var policy in system.GetAllUniquePolicies())
           Console.WriteLine(policy);

       Console.WriteLine("\nPolicies Expiring Within 30 Days:");
       foreach (var policy in system.GetPoliciesExpiringSoon())
           Console.WriteLine(policy);

       Console.WriteLine("\nHealth Insurance Policies:");
       foreach (var policy in system.GetPoliciesByCoverageType("Health"))
           Console.WriteLine(policy);

       Console.WriteLine("\nDuplicate Policies:");
       foreach (var policy in system.GetDuplicatePolicies())
           Console.WriteLine(policy);
   }
}
	



________________


Design a Voting System
* Dictionary<string, int> to store votes.
* SortedDictionary to display results in order.
* LinkedHashMap to maintain the order of votes.
using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
   private Dictionary<string, int> voteCount = new Dictionary<string, int>();
   private SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>();
   private LinkedList<string> voteOrder = new LinkedList<string>(); // To maintain order of votes

   public void CastVote(string candidate)
   {
       // Store votes in Dictionary
       if (voteCount.ContainsKey(candidate))
           voteCount[candidate]++;
       else
           voteCount[candidate] = 1;

       // Store votes in SortedDictionary
       if (sortedVotes.ContainsKey(candidate))
           sortedVotes[candidate]++;
       else
           sortedVotes[candidate] = 1;

       // Maintain order in LinkedList
       voteOrder.AddLast(candidate);
   }

   public void DisplayVoteCount()
   {
       Console.WriteLine("\nTotal Vote Count:");
       foreach (var entry in voteCount)
           Console.WriteLine($"{entry.Key}: {entry.Value}");
   }

   public void DisplaySortedResults()
   {
       Console.WriteLine("\nSorted Vote Results (Alphabetically):");
       foreach (var entry in sortedVotes)
           Console.WriteLine($"{entry.Key}: {entry.Value}");
   }

   public void DisplayVotingOrder()
   {
       Console.WriteLine("\nVoting Order:");
       foreach (var candidate in voteOrder)
           Console.Write($"{candidate} -> ");
       Console.WriteLine("End");
   }
}

class Program
{
   static void Main()
   {
       VotingSystem system = new VotingSystem();

       // Simulate votes
       system.CastVote("Alice");
       system.CastVote("Bob");
       system.CastVote("Alice");
       system.CastVote("Charlie");
       system.CastVote("Bob");
       system.CastVote("Alice");

       // Display results
       system.DisplayVoteCount();
       system.DisplaySortedResults();
       system.DisplayVotingOrder();
   }
}
	



________________


Implement a Shopping Cart
* Dictionary<string, double> to store product prices.
* LinkedDictionary to maintain order.
* SortedDictionary to display items sorted by price.
using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
   private Dictionary<string, double> productPrices = new Dictionary<string, double>();
   private LinkedList<KeyValuePair<string, double>> orderedProducts = new LinkedList<KeyValuePair<string, double>>();
   private SortedDictionary<double, List<string>> sortedProducts = new SortedDictionary<double, List<string>>();

   public void AddProduct(string product, double price)
   {
       if (!productPrices.ContainsKey(product))
       {
           // Store product price in Dictionary
           productPrices[product] = price;

           // Maintain order in LinkedList
           orderedProducts.AddLast(new KeyValuePair<string, double>(product, price));

           // Store products sorted by price
           if (!sortedProducts.ContainsKey(price))
               sortedProducts[price] = new List<string>();
           
           sortedProducts[price].Add(product);
       }
       else
       {
           Console.WriteLine($"Product '{product}' already exists in the cart.");
       }
   }

   public void DisplayCart()
   {
       Console.WriteLine("\nShopping Cart (Original Order):");
       foreach (var item in orderedProducts)
           Console.WriteLine($"{item.Key}: ${item.Value:F2}");
   }

   public void DisplaySortedCart()
   {
       Console.WriteLine("\nShopping Cart (Sorted by Price):");
       foreach (var price in sortedProducts.Keys)
       {
           foreach (var product in sortedProducts[price])
               Console.WriteLine($"{product}: ${price:F2}");
       }
   }

   public double CalculateTotal()
   {
       return productPrices.Values.Sum();
   }
}

class Program
{
   static void Main()
   {
       ShoppingCart cart = new ShoppingCart();

       // Adding products to the cart
       cart.AddProduct("Laptop", 1200.00);
       cart.AddProduct("Phone", 800.00);
       cart.AddProduct("Headphones", 150.00);
       cart.AddProduct("Monitor", 300.00);
       cart.AddProduct("Mouse", 50.00);

       // Display cart details
       cart.DisplayCart();
       cart.DisplaySortedCart();
       
       Console.WriteLine($"\nTotal Price: ${cart.CalculateTotal():F2}");
   }
}
	



________________


Implement a Banking System
* Dictionary<int, double> to store account balances.
* SortedDictionary to sort customers by balance.
* Queue to process withdrawal requests.
using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
   private Dictionary<int, double> accountBalances = new Dictionary<int, double>();
   private SortedDictionary<double, List<int>> sortedAccounts = new SortedDictionary<double, List<int>>();
   private Queue<Tuple<int, double>> withdrawalQueue = new Queue<Tuple<int, double>>();

   // Add a new account with an initial balance
   public void AddAccount(int accountId, double balance)
   {
       if (!accountBalances.ContainsKey(accountId))
       {
           accountBalances[accountId] = balance;
           UpdateSortedAccounts(accountId, balance);
       }
       else
       {
           Console.WriteLine($"Account {accountId} already exists.");
       }
   }

   // Deposit money into an account
   public void Deposit(int accountId, double amount)
   {
       if (accountBalances.ContainsKey(accountId))
       {
           double oldBalance = accountBalances[accountId];
           accountBalances[accountId] += amount;
           UpdateSortedAccounts(accountId, oldBalance, accountBalances[accountId]);

           Console.WriteLine($"Deposited ${amount:F2} into Account {accountId}. New Balance: ${accountBalances[accountId]:F2}");
       }
       else
       {
           Console.WriteLine($"Account {accountId} does not exist.");
       }
   }

   // Request a withdrawal (added to queue)
   public void RequestWithdrawal(int accountId, double amount)
   {
       if (accountBalances.ContainsKey(accountId))
       {
           withdrawalQueue.Enqueue(new Tuple<int, double>(accountId, amount));
           Console.WriteLine($"Withdrawal request of ${amount:F2} for Account {accountId} added to queue.");
       }
       else
       {
           Console.WriteLine($"Account {accountId} does not exist.");
       }
   }

   // Process all withdrawal requests
   public void ProcessWithdrawals()
   {
       while (withdrawalQueue.Count > 0)
       {
           var request = withdrawalQueue.Dequeue();
           int accountId = request.Item1;
           double amount = request.Item2;

           if (accountBalances[accountId] >= amount)
           {
               double oldBalance = accountBalances[accountId];
               accountBalances[accountId] -= amount;
               UpdateSortedAccounts(accountId, oldBalance, accountBalances[accountId]);

               Console.WriteLine($"Processed withdrawal of ${amount:F2} for Account {accountId}. New Balance: ${accountBalances[accountId]:F2}");
           }
           else
           {
               Console.WriteLine($"Insufficient funds for Account {accountId}. Withdrawal of ${amount:F2} denied.");
           }
       }
   }

   // Display account balances in sorted order
   public void DisplaySortedBalances()
   {
       Console.WriteLine("\nAccounts Sorted by Balance:");
       foreach (var balance in sortedAccounts.Keys)
       {
           foreach (var accountId in sortedAccounts[balance])
           {
               Console.WriteLine($"Account {accountId}: ${balance:F2}");
           }
       }
   }

   // Update the sorted accounts structure
   private void UpdateSortedAccounts(int accountId, double oldBalance, double newBalance = -1)
   {
       // Remove old balance entry
       if (sortedAccounts.ContainsKey(oldBalance))
       {
           sortedAccounts[oldBalance].Remove(accountId);
           if (sortedAccounts[oldBalance].Count == 0)
               sortedAccounts.Remove(oldBalance);
       }

       // Add new balance entry
       double updatedBalance = (newBalance == -1) ? oldBalance : newBalance;
       if (!sortedAccounts.ContainsKey(updatedBalance))
           sortedAccounts[updatedBalance] = new List<int>();

       sortedAccounts[updatedBalance].Add(accountId);
   }
}

class Program
{
   static void Main()
   {
       BankingSystem bank = new BankingSystem();

       // Adding accounts
       bank.AddAccount(101, 5000);
       bank.AddAccount(102, 3000);
       bank.AddAccount(103, 7000);
       bank.AddAccount(104, 1000);

       // Depositing money
       bank.Deposit(102, 2000);
       bank.Deposit(101, 500);

       // Display sorted balances
       bank.DisplaySortedBalances();

       // Request withdrawals
       bank.RequestWithdrawal(101, 1000);
       bank.RequestWithdrawal(104, 1500); // Should fail due to insufficient funds
       bank.RequestWithdrawal(103, 2000);

       // Process withdrawals
       Console.WriteLine("\nProcessing Withdrawals...");
       bank.ProcessWithdrawals();

       // Display sorted balances after processing withdrawals
       bank.DisplaySortedBalances();
   }
}
	



________________


This document provides a structured approach to solving problems related to Lists, Sets, Queues, Maps, and real-world System Designs in C#.