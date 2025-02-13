Best Practices for Stacks and Queues
Stacks
* Use for Reversible or Nested Problems: 
   * Stacks are ideal for problems involving recursion, backtracking, or nested structures (e.g., balanced parentheses, undo functionality).
* Optimize Stack Size: 
   * Avoid memory overflows by setting a proper size for stacks in fixed-size implementations, or use dynamic structures for scalability.
* Avoid Infinite Loops in Recursive Algorithms: 
   * Ensure a clear base case in recursive stack operations to prevent stack overflow errors.
* Push and Pop Atomically: 
   * When dealing with multi-threaded environments, ensure stack operations are atomic to avoid race conditions.
* Check Stack Underflow and Overflow: 
   * Always validate operations to avoid popping an empty stack or pushing into a full stack.
* Use Collections Framework for Robustness: 
   * Instead of implementing stacks from scratch, use robust implementations like Deque or LinkedList.
* Track the Minimum or Maximum Value: 
   * Maintain an auxiliary stack to store these values for O(1) retrieval.


Queues
* Use for FIFO (First In, First Out) Problems: 
   * Queues are well-suited for sequential processing problems like task scheduling, BFS, and producer-consumer scenarios.
* Choose the Right Type of Queue: 
   * Simple Queue: For basic FIFO needs.
   * Deque (Double-Ended Queue): For flexibility to add/remove from both ends.
   * Priority Queue: When elements must be processed based on priority rather than order.
* Optimize Memory Usage: 
   * Keep track of head and tail pointers efficiently to avoid wasting memory in circular queues.
* Handle Concurrency with Thread-Safe Queues: 
   * In multi-threaded environments, use thread-safe implementations like BlockingQueue or ConcurrentLinkedQueue.
* Validate Queue Underflow and Overflow: 
   * Ensure proper handling of empty and full queues.
* Lazy Deletion for Priority Queues: 
   * Mark elements as deleted and process cleanup later to avoid immediate restructuring costs.
* Avoid Polling Empty Queues: 
   * Always check if the queue is empty before dequeue operations to avoid exceptions or errors.


Sample Problems for Stacks and Queues
Implement a Queue Using Stacks
* Problem: Design a queue using two stacks such that enqueue and dequeue operations are performed efficiently.
* Hint: Use one stack for enqueue and another stack for dequeue. Transfer elements between stacks as needed.
using System;

class Stack
{
   private int[] arr;
   private int top;
   private int capacity;

   public Stack(int size)
   {
       arr = new int[size];
       capacity = size;
       top = -1;
   }

   public void Push(int item)
   {
       if (top == capacity - 1) throw new InvalidOperationException("Stack overflow");
       arr[++top] = item;
   }

   public int Pop()
   {
       if (top == -1) throw new InvalidOperationException("Stack underflow");
       return arr[top--];
   }

   public bool IsEmpty() => top == -1;
}

class QueueUsingStacks
{
   private Stack stack1;
   private Stack stack2;

   public QueueUsingStacks(int size)
   {
       stack1 = new Stack(size);
       stack2 = new Stack(size);
   }

   public void Enqueue(int item)
   {
       stack1.Push(item);
   }

   public int Dequeue()
   {
       if (stack2.IsEmpty())
       {
           while (!stack1.IsEmpty())
           {
               stack2.Push(stack1.Pop());
           }
       }
       return stack2.Pop();
   }
}

class Program
{
   static void Main()
   {
       QueueUsingStacks queue = new QueueUsingStacks(5);
       queue.Enqueue(10);
       queue.Enqueue(20);
       queue.Enqueue(30);
       Console.WriteLine(queue.Dequeue()); // Output: 10
       queue.Enqueue(40);
       Console.WriteLine(queue.Dequeue()); // Output: 20
   }
}
	





Sort a Stack Using Recursion
* Problem: Given a stack, sort its elements in ascending order using recursion.
* Hint: Pop elements recursively, sort the remaining stack, and insert the popped element back at the correct position.
using System;

class StackManual
{
   private int[] arr;
   private int top;

   public StackManual(int size)
   {
       arr = new int[size];
       top = -1;
   }

   public void Push(int item)
   {
       if (top == arr.Length - 1) throw new InvalidOperationException("Stack overflow");
       arr[++top] = item;
   }

   public int Pop()
   {
       if (top == -1) throw new InvalidOperationException("Stack underflow");
       return arr[top--];
   }

   public int Peek()
   {
       if (top == -1) throw new InvalidOperationException("Stack is empty");
       return arr[top];
   }

   public bool IsEmpty() => top == -1;

   public void PrintStack()
   {
       for (int i = 0; i <= top; i++)
       {
           Console.Write(arr[i] + " ");
       }
       Console.WriteLine();
   }
}

class SortStackRecursively
{
   public static void SortStack(StackManual stack)
   {
       if (!stack.IsEmpty())
       {
           int temp = stack.Pop();
           SortStack(stack);
           InsertSorted(stack, temp);
       }
   }

   private static void InsertSorted(StackManual stack, int value)
   {
       if (stack.IsEmpty() || stack.Peek() <= value)
       {
           stack.Push(value);
           return;
       }

       int temp = stack.Pop();
       InsertSorted(stack, value);
       stack.Push(temp);
   }
}

class Program
{
   static void Main()
   {
       StackManual stack = new StackManual(5);
       stack.Push(30);
       stack.Push(10);
       stack.Push(50);
       stack.Push(20);
       stack.Push(40);

       Console.WriteLine("Original Stack:");
       stack.PrintStack();

       SortStackRecursively.SortStack(stack);

       Console.WriteLine("Sorted Stack:");
       stack.PrintStack();
   }
}
	





Stock Span Problem
* Problem: For each day in a stock price array, calculate the span (number of consecutive days the price was less than or equal to the current day's price).
* Hint: Use a stack to keep track of indices of prices in descending order.


using System;
using System.Collections.Generic;

class StockSpan
{
   public static int[] CalculateSpan(int[] prices)
   {
       int n = prices.Length;
       int[] span = new int[n];
       Stack<int> stack = new Stack<int>(); // Stores indices

       for (int i = 0; i < n; i++)
       {
           // Remove elements from stack that are smaller than or equal to the current price
           while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
           {
               stack.Pop();
           }

           // Compute span
           span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

           // Push current index onto stack
           stack.Push(i);
       }

       return span;
   }
}

class Program
{
   static void Main()
   {
       int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
       int[] span = StockSpan.CalculateSpan(prices);

       Console.WriteLine("Stock Span for each day:");
       Console.WriteLine(string.Join(" ", span));
   }
}
	



Sliding Window Maximum
* Problem: Given an array and a window size k, find the maximum element in each sliding window of size k.
* Hint: Use a deque (double-ended queue) to maintain indices of useful elements in each window.
using System;
using System.Collections.Generic;

class SlidingWindow
{
   public static int[] MaxSlidingWindow(int[] nums, int k)
   {
       if (nums.Length == 0) return new int[0];

       List<int> result = new List<int>();
       LinkedList<int> deque = new LinkedList<int>(); // Stores indices

       for (int i = 0; i < nums.Length; i++)
       {
           // Remove elements out of the window (leftmost)
           if (deque.Count > 0 && deque.First.Value < i - k + 1)
           {
               deque.RemoveFirst();
           }

           // Remove elements smaller than current one (they are useless)
           while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
           {
               deque.RemoveLast();
           }

           // Add current index to deque
           deque.AddLast(i);

           // Store the max value once window size reaches k
           if (i >= k - 1)
           {
               result.Add(nums[deque.First.Value]);
           }
       }

       return result.ToArray();
   }
}

class Program
{
   static void Main()
   {
       int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
       int k = 3;

       int[] maxSlidingWindow = SlidingWindow.MaxSlidingWindow(nums, k);

       Console.WriteLine("Sliding Window Maximum:");
       Console.WriteLine(string.Join(" ", maxSlidingWindow));
   }
}
	



Circular Tour Problem
* Problem: Given a set of petrol pumps with petrol and distance to the next pump, determine the starting point for completing a circular tour.
* Hint: Use a queue to simulate the tour, keeping track of surplus petrol at each pump.
using System;

class CircularTour
{
   public static int FindStartingPump(int[] petrol, int[] distance)
   {
       int totalSurplus = 0; // Total surplus petrol
       int currentSurplus = 0; // Surplus in current journey
       int startIndex = 0; // Possible starting point

       for (int i = 0; i < petrol.Length; i++)
       {
           int balance = petrol[i] - distance[i];
           totalSurplus += balance;
           currentSurplus += balance;

           // If at any point currentSurplus is negative, reset start index
           if (currentSurplus < 0)
           {
               startIndex = i + 1; // Move start to the next pump
               currentSurplus = 0; // Reset surplus
           }
       }

       return (totalSurplus >= 0) ? startIndex : -1;
   }
}

class Program
{
   static void Main()
   {
       int[] petrol = { 4, 6, 7, 4 };
       int[] distance = { 6, 5, 3, 5 };

       int startPump = CircularTour.FindStartingPump(petrol, distance);

       Console.WriteLine(startPump == -1 ? "No circular tour possible" : $"Start at petrol pump {startPump}");
   }
}
	





Sample Problems for Hash Maps & Hash Functions
Find All Subarrays with Zero Sum
* Problem: Given an array, find all subarrays whose elements sum up to zero.
* Hint: Use a hash map to store the cumulative sum and its frequency. If a sum repeats, a zero-sum subarray exists.
using System;
using System.Collections.Generic;

class TwoSumWithHashMap
{
   public static bool HasPairWithSum(int[] arr, int target)
   {
       Dictionary<int, bool> map = new Dictionary<int, bool>();

       for (int i = 0; i < arr.Length; i++)
       {
           int complement = target - arr[i];

           if (map.ContainsKey(complement))
           {
               return true;
           }

           map[arr[i]] = true;
       }
       return false;
   }
}

class Program
{
   static void Main()
   {
       int[] arr = { 1, 4, 7, 12, 15 };
       int target = 11;

       bool result = TwoSumWithHashMap.HasPairWithSum(arr, target);
       Console.WriteLine(result ? "Pair exists" : "No pair found");
   }
}

	





Check for a Pair with Given Sum in an Array
* Problem: Given an array and a target sum, find if there exists a pair of elements whose sum is equal to the target.
* Hint: Store visited numbers in a hash map and check if target - current_number exists in the map.


using System;
using System.Collections.Generic;

class TwoSumWithHashMap
{
   public static bool HasPairWithSum(int[] arr, int target)
   {
       Dictionary<int, bool> map = new Dictionary<int, bool>();

       for (int i = 0; i < arr.Length; i++)
       {
           int complement = target - arr[i];

           if (map.ContainsKey(complement))
           {
               Console.WriteLine($"Pair found: ({arr[i]}, {complement})");
               return true;
           }

           // Store the current number in the map
           map[arr[i]] = true;
       }
       return false;
   }
}

class Program
{
   static void Main()
   {
       int[] arr = { 2, 7, 11, 15, 4, 8 };
       int target = 9;

       bool result = TwoSumWithHashMap.HasPairWithSum(arr, target);
       Console.WriteLine(result ? "Pair exists" : "No pair found");
   }
}
	



Longest Consecutive Sequence
* Problem: Given an unsorted array, find the length of the longest consecutive elements sequence.
* Hint: Use a hash map to store elements and check for consecutive elements efficiently.
using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
   public static int FindLongestConsecutiveSequence(int[] nums)
   {
       if (nums.Length == 0)
           return 0;

       HashSet<int> numSet = new HashSet<int>();
       foreach (int num in nums)
       {
           numSet.Add(num);
       }

       int longestStreak = 0;

       foreach (int num in nums)
       {
           // Check if num is the start of a sequence
           if (!numSet.Contains(num - 1))
           {
               int currentNum = num;
               int currentStreak = 1;

               while (numSet.Contains(currentNum + 1))
               {
                   currentNum++;
                   currentStreak++;
               }

               longestStreak = Math.Max(longestStreak, currentStreak);
           }
       }

       return longestStreak;
   }
}

class Program
{
   static void Main()
   {
       int[] arr = { 100, 4, 200, 1, 3, 2 };
       int result = LongestConsecutiveSequence.FindLongestConsecutiveSequence(arr);
       Console.WriteLine("Longest Consecutive Sequence Length: " + result);
   }
}
	



Implement a Custom Hash Map
* Problem: Design and implement a basic hash map class with operations for insertion, deletion, and retrieval.
* Hint: Use an array of linked lists to handle collisions using separate chaining.
using System;
using System.Collections.Generic;

class HashNode
{
   public int Key;
   public int Value;
   public HashNode Next;

   public HashNode(int key, int value)
   {
       Key = key;
       Value = value;
       Next = null;
   }
}

class CustomHashMap
{
   private int size;
   private HashNode[] buckets;

   public CustomHashMap(int capacity)
   {
       size = capacity;
       buckets = new HashNode[size];
   }

   private int GetHash(int key)
   {
       return key % size;
   }

   public void Insert(int key, int value)
   {
       int index = GetHash(key);
       HashNode newNode = new HashNode(key, value);

       if (buckets[index] == null)
       {
           buckets[index] = newNode;
       }
       else
       {
           HashNode current = buckets[index];
           while (current != null)
           {
               if (current.Key == key)
               {
                   current.Value = value; // Update value if key exists
                   return;
               }
               if (current.Next == null)
                   break;
               current = current.Next;
           }
           current.Next = newNode; // Add new node at the end
       }
   }

   public int Get(int key)
   {
       int index = GetHash(key);
       HashNode current = buckets[index];

       while (current != null)
       {
           if (current.Key == key)
               return current.Value;
           current = current.Next;
       }

       throw new KeyNotFoundException("Key not found");
   }

   public void Remove(int key)
   {
       int index = GetHash(key);
       HashNode current = buckets[index];
       HashNode prev = null;

       while (current != null)
       {
           if (current.Key == key)
           {
               if (prev == null)
                   buckets[index] = current.Next; // Remove first node
               else
                   prev.Next = current.Next; // Bypass the node

               return;
           }
           prev = current;
           current = current.Next;
       }
   }

   public void Display()
   {
       for (int i = 0; i < size; i++)
       {
           Console.Write($"Bucket {i}: ");
           HashNode current = buckets[i];

           while (current != null)
           {
               Console.Write($"[{current.Key} -> {current.Value}] ");
               current = current.Next;
           }
           Console.WriteLine();
       }
   }
}

class Program
{
   static void Main()
   {
       CustomHashMap map = new CustomHashMap(10);

       map.Insert(1, 100);
       map.Insert(11, 110);
       map.Insert(21, 120);
       map.Insert(2, 200);

       Console.WriteLine("HashMap after insertions:");
       map.Display();

       Console.WriteLine("\nGet value for key 11: " + map.Get(11));

       map.Remove(11);
       Console.WriteLine("\nHashMap after removing key 11:");
       map.Display();
   }
}
	



Two Sum Problem
* Problem: Given an array and a target sum, find two indices such that their values add up to the target.
* Hint: Use a hash map to store the index of each element as you iterate. Check if target - current_element exists in the map.
using System;
using System.Collections.Generic;

class TwoSumHashMap
{
   public static int[] FindTwoSum(int[] nums, int target)
   {
       Dictionary<int, int> map = new Dictionary<int, int>();

       for (int i = 0; i < nums.Length; i++)
       {
           int complement = target - nums[i];

           if (map.ContainsKey(complement))
           {
               return new int[] { map[complement], i };
           }

           // Store current number with its index
           if (!map.ContainsKey(nums[i]))
           {
               map[nums[i]] = i;
           }
       }

       return new int[] { -1, -1 }; // No valid pair found
   }
}

class Program
{
   static void Main()
   {
       int[] arr = { 2, 7, 11, 15 };
       int target = 9;

       int[] result = TwoSumHashMap.FindTwoSum(arr, target);
       if (result[0] != -1)
       {
           Console.WriteLine($"Pair found at indices: {result[0]}, {result[1]}");
       }
       else
       {
           Console.WriteLine("No valid pair found.");
       }
   }
}