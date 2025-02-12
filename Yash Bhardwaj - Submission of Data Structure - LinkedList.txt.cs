Best Practices for Data Structure - LinkedList
Head & Tail Management:
Always maintain the head (and tail in doubly and circular lists) to avoid traversing the entire list when accessing the first or last elements.
Null Checks:
Before performing operations like deletion or traversal, check if the list is empty to prevent errors.
Efficient Insertion/Deletion:
Insert at the beginning or end for O(1) time complexity. For operations in the middle, ensure proper pointer updates to maintain list integrity.
Memory Management:
Properly nullify pointers (next, prev) when deleting nodes to prevent memory leaks, especially in languages without garbage collection.
Boundary Handling:
Carefully handle edge cases like inserting/deleting at the head, tail, or middle of the list, ensuring correct pointer updates.
Avoid Infinite Loops (Circular Lists):
Implement conditions to stop traversal after one complete cycle to avoid infinite loops.
Modular Code:
Break operations into small, reusable functions for better readability and maintainability.
Keep Code Simple:
Focus on clarity over complexity. Avoid unnecessary traversals and complex logic unless required for your use case.
________________


1. Singly Linked List: Student Record Management
Problem Statement: Create a program to manage student records using a singly linked list. Each node will store information about a student, including their Roll Number, Name, Age, and Grade. Implement the following operations:
* Add a new student record at the beginning, end, or at a specific position.
* Delete a student record by Roll Number.
* Search for a student record by Roll Number.
* Display all student records.
* Update a student's grade based on their Roll Number.
using System;

class Student
{
   public int RollNumber;
   public string Name;
   public int Age;
   public char Grade;
   public Student Next;

   public Student(int rollNumber, string name, int age, char grade)
   {
       RollNumber = rollNumber;
       Name = name;
       Age = age;
       Grade = grade;
       Next = null;
   }
}

class StudentLinkedList
{
   private Student head;

   public void AddStudentAtBeginning(int rollNumber, string name, int age, char grade)
   {
       Student newStudent = new Student(rollNumber, name, age, grade);
       newStudent.Next = head;
       head = newStudent;
   }

   public void AddStudentAtEnd(int rollNumber, string name, int age, char grade)
   {
       Student newStudent = new Student(rollNumber, name, age, grade);
       if (head == null)
       {
           head = newStudent;
           return;
       }
       Student temp = head;
       while (temp.Next != null)
       {
           temp = temp.Next;
       }
       temp.Next = newStudent;
   }

   public void DeleteStudentByRollNumber(int rollNumber)
   {
       if (head == null)
       {
           Console.WriteLine("List is empty.");
           return;
       }
       if (head.RollNumber == rollNumber)
       {
           head = head.Next;
           return;
       }
       Student temp = head;
       while (temp.Next != null && temp.Next.RollNumber != rollNumber)
       {
           temp = temp.Next;
       }
       if (temp.Next == null)
       {
           Console.WriteLine("Student not found.");
           return;
       }
       temp.Next = temp.Next.Next;
   }

   public Student SearchStudent(int rollNumber)
   {
       Student temp = head;
       while (temp != null)
       {
           if (temp.RollNumber == rollNumber)
           {
               return temp;
           }
           temp = temp.Next;
       }
       return null;
   }

   public void DisplayAllStudents()
   {
       if (head == null)
       {
           Console.WriteLine("No students available.");
           return;
       }
       Student temp = head;
       while (temp != null)
       {
           Console.WriteLine($"Roll No: {temp.RollNumber}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
           temp = temp.Next;
       }
   }

   public void UpdateStudentGrade(int rollNumber, char newGrade)
   {
       Student student = SearchStudent(rollNumber);
       if (student != null)
       {
           student.Grade = newGrade;
           Console.WriteLine("Grade updated successfully.");
       }
       else
       {
           Console.WriteLine("Student not found.");
       }
   }
}

class Program
{
   static void Main()
   {
       StudentLinkedList studentList = new StudentLinkedList();
       
       studentList.AddStudentAtEnd(101, "Alice", 20, 'A');
       studentList.AddStudentAtEnd(102, "Bob", 22, 'B');
       studentList.AddStudentAtBeginning(100, "Charlie", 21, 'C');

       Console.WriteLine("All Students:");
       studentList.DisplayAllStudents();

       Console.WriteLine("\nUpdating Grade:");
       studentList.UpdateStudentGrade(102, 'A');

       Console.WriteLine("\nDeleting Student:");
       studentList.DeleteStudentByRollNumber(100);

       Console.WriteLine("\nAll Students after deletion:");
       studentList.DisplayAllStudents();
   }
}
	



________________


2. Doubly Linked List: Movie Management System
Problem Statement: Implement a movie management system using a doubly linked list. Each node will represent a movie and contain Movie Title, Director, Year of Release, and Rating. Implement the following functionalities:
* Add a movie record at the beginning, end, or at a specific position.
* Remove a movie record by Movie Title.
* Search for a movie record by Director or Rating.
* Display all movie records in both forward and reverse order.
* Update a movie's Rating based on the Movie Title.
using System;

class MovieNode
{
   public string MovieTitle;
   public string Director;
   public int YearOfRelease;
   public double Rating;
   public MovieNode Prev;
   public MovieNode Next;

   public MovieNode(string title, string director, int year, double rating)
   {
       MovieTitle = title;
       Director = director;
       YearOfRelease = year;
       Rating = rating;
       Prev = null;
       Next = null;
   }
}

class MovieManagementSystem
{
   private MovieNode head;

   public MovieManagementSystem()
   {
       head = null;
   }

   // Add a movie at the beginning
   public void AddMovieAtBeginning(string title, string director, int year, double rating)
   {
       MovieNode newNode = new MovieNode(title, director, year, rating);
       if (head != null)
       {
           newNode.Next = head;
           head.Prev = newNode;
       }
       head = newNode;
   }

   // Add a movie at the end
   public void AddMovieAtEnd(string title, string director, int year, double rating)
   {
       MovieNode newNode = new MovieNode(title, director, year, rating);
       if (head == null)
       {
           head = newNode;
           return;
       }
       MovieNode temp = head;
       while (temp.Next != null)
       {
           temp = temp.Next;
       }
       temp.Next = newNode;
       newNode.Prev = temp;
   }

   // Add a movie at a specific position (1-based index)
   public void AddMovieAtPosition(string title, string director, int year, double rating, int position)
   {
       MovieNode newNode = new MovieNode(title, director, year, rating);
       if (position <= 1 || head == null)
       {
           AddMovieAtBeginning(title, director, year, rating);
           return;
       }
       MovieNode temp = head;
       int count = 1;
       while (temp.Next != null && count < position - 1)
       {
           temp = temp.Next;
           count++;
       }
       newNode.Next = temp.Next;
       if (temp.Next != null)
       {
           temp.Next.Prev = newNode;
       }
       temp.Next = newNode;
       newNode.Prev = temp;
   }

   // Remove a movie by title
   public void RemoveMovieByTitle(string title)
   {
       MovieNode temp = head;
       while (temp != null)
       {
           if (temp.MovieTitle == title)
           {
               if (temp.Prev != null)
                   temp.Prev.Next = temp.Next;
               if (temp.Next != null)
                   temp.Next.Prev = temp.Prev;
               if (temp == head)
                   head = temp.Next;
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Movie not found!");
   }

   // Search for a movie by Director or Rating
   public void SearchMovie(string director, double rating)
   {
       MovieNode temp = head;
       while (temp != null)
       {
           if (temp.Director == director || temp.Rating == rating)
           {
               Console.WriteLine($"Title: {temp.MovieTitle}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
           }
           temp = temp.Next;
       }
   }

   // Update movie rating based on title
   public void UpdateMovieRating(string title, double newRating)
   {
       MovieNode temp = head;
       while (temp != null)
       {
           if (temp.MovieTitle == title)
           {
               temp.Rating = newRating;
               Console.WriteLine("Rating updated successfully!");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Movie not found!");
   }

   // Display all movies in forward order
   public void DisplayMoviesForward()
   {
       MovieNode temp = head;
       while (temp != null)
       {
           Console.WriteLine($"Title: {temp.MovieTitle}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
           temp = temp.Next;
       }
   }

   // Display all movies in reverse order
   public void DisplayMoviesReverse()
   {
       if (head == null)
       {
           Console.WriteLine("No movies to display.");
           return;
       }
       MovieNode temp = head;
       while (temp.Next != null)
       {
           temp = temp.Next;
       }
       while (temp != null)
       {
           Console.WriteLine($"Title: {temp.MovieTitle}, Director: {temp.Director}, Year: {temp.YearOfRelease}, Rating: {temp.Rating}");
           temp = temp.Prev;
       }
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       MovieManagementSystem movieList = new MovieManagementSystem();
       movieList.AddMovieAtEnd("Inception", "Christopher Nolan", 2010, 8.8);
       movieList.AddMovieAtEnd("Interstellar", "Christopher Nolan", 2014, 8.6);
       movieList.AddMovieAtBeginning("The Dark Knight", "Christopher Nolan", 2008, 9.0);
       movieList.AddMovieAtPosition("Dunkirk", "Christopher Nolan", 2017, 7.9, 2);
       
       Console.WriteLine("Movies in forward order:");
       movieList.DisplayMoviesForward();
       
       Console.WriteLine("\nMovies in reverse order:");
       movieList.DisplayMoviesReverse();

       Console.WriteLine("\nSearching for movies directed by 'Christopher Nolan':");
       movieList.SearchMovie("Christopher Nolan", -1);

       Console.WriteLine("\nUpdating rating of 'Interstellar' to 9.0:");
       movieList.UpdateMovieRating("Interstellar", 9.0);
       movieList.DisplayMoviesForward();

       Console.WriteLine("\nRemoving 'Dunkirk':");
       movieList.RemoveMovieByTitle("Dunkirk");
       movieList.DisplayMoviesForward();
   }
}
	



________________


3. Circular Linked List: Task Scheduler
Problem Statement: Create a task scheduler using a circular linked list. Each node in the list represents a task with Task ID, Task Name, Priority, and Due Date. Implement the following functionalities:
* Add a task at the beginning, end, or at a specific position in the circular list.
* Remove a task by Task ID.
* View the current task and move to the next task in the circular list.
* Display all tasks in the list starting from the head node.
* Search for a task by Priority.
using System;

class TaskNode
{
   public int TaskID;
   public string TaskName;
   public int Priority;
   public DateTime DueDate;
   public TaskNode Next;

   public TaskNode(int id, string name, int priority, DateTime dueDate)
   {
       TaskID = id;
       TaskName = name;
       Priority = priority;
       DueDate = dueDate;
       Next = this; // Circular link (points to itself initially)
   }
}

class TaskScheduler
{
   private TaskNode head;
   private TaskNode currentTask;

   public TaskScheduler()
   {
       head = null;
       currentTask = null;
   }

   // Add task at the beginning
   public void AddTaskAtBeginning(int id, string name, int priority, DateTime dueDate)
   {
       TaskNode newNode = new TaskNode(id, name, priority, dueDate);
       if (head == null)
       {
           head = newNode;
           newNode.Next = head;
       }
       else
       {
           TaskNode temp = head;
           while (temp.Next != head)
           {
               temp = temp.Next;
           }
           newNode.Next = head;
           temp.Next = newNode;
           head = newNode;
       }
   }

   // Add task at the end
   public void AddTaskAtEnd(int id, string name, int priority, DateTime dueDate)
   {
       TaskNode newNode = new TaskNode(id, name, priority, dueDate);
       if (head == null)
       {
           head = newNode;
           newNode.Next = head;
       }
       else
       {
           TaskNode temp = head;
           while (temp.Next != head)
           {
               temp = temp.Next;
           }
           temp.Next = newNode;
           newNode.Next = head;
       }
   }

   // Add task at a specific position (1-based index)
   public void AddTaskAtPosition(int id, string name, int priority, DateTime dueDate, int position)
   {
       if (position <= 1 || head == null)
       {
           AddTaskAtBeginning(id, name, priority, dueDate);
           return;
       }
       TaskNode newNode = new TaskNode(id, name, priority, dueDate);
       TaskNode temp = head;
       int count = 1;
       while (temp.Next != head && count < position - 1)
       {
           temp = temp.Next;
           count++;
       }
       newNode.Next = temp.Next;
       temp.Next = newNode;
   }

   // Remove a task by Task ID
   public void RemoveTaskByID(int id)
   {
       if (head == null)
       {
           Console.WriteLine("No tasks to remove.");
           return;
       }

       TaskNode temp = head, prev = null;
       do
       {
           if (temp.TaskID == id)
           {
               if (prev != null)
                   prev.Next = temp.Next;
               else
               {
                   TaskNode last = head;
                   while (last.Next != head)
                       last = last.Next;
                   if (head == head.Next) // Only one node in the list
                       head = null;
                   else
                   {
                       head = head.Next;
                       last.Next = head;
                   }
               }
               Console.WriteLine($"Task {id} removed.");
               return;
           }
           prev = temp;
           temp = temp.Next;
       } while (temp != head);

       Console.WriteLine("Task not found!");
   }

   // View current task and move to the next task
   public void ViewCurrentTask()
   {
       if (head == null)
       {
           Console.WriteLine("No tasks available.");
           return;
       }
       if (currentTask == null)
           currentTask = head;

       Console.WriteLine($"Current Task: ID: {currentTask.TaskID}, Name: {currentTask.TaskName}, Priority: {currentTask.Priority}, Due Date: {currentTask.DueDate}");
       currentTask = currentTask.Next;
   }

   // Display all tasks starting from head
   public void DisplayAllTasks()
   {
       if (head == null)
       {
           Console.WriteLine("No tasks available.");
           return;
       }
       TaskNode temp = head;
       do
       {
           Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate}");
           temp = temp.Next;
       } while (temp != head);
   }

   // Search for a task by priority
   public void SearchTaskByPriority(int priority)
   {
       if (head == null)
       {
           Console.WriteLine("No tasks available.");
           return;
       }
       TaskNode temp = head;
       bool found = false;
       do
       {
           if (temp.Priority == priority)
           {
               Console.WriteLine($"Task ID: {temp.TaskID}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due Date: {temp.DueDate}");
               found = true;
           }
           temp = temp.Next;
       } while (temp != head);

       if (!found)
           Console.WriteLine("No tasks found with the given priority.");
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       TaskScheduler scheduler = new TaskScheduler();
       scheduler.AddTaskAtEnd(101, "Complete Project", 1, new DateTime(2025, 2, 20));
       scheduler.AddTaskAtEnd(102, "Submit Report", 2, new DateTime(2025, 2, 25));
       scheduler.AddTaskAtBeginning(103, "Prepare Presentation", 1, new DateTime(2025, 2, 18));
       scheduler.AddTaskAtPosition(104, "Team Meeting", 3, new DateTime(2025, 2, 15), 2);

       Console.WriteLine("All tasks in the scheduler:");
       scheduler.DisplayAllTasks();

       Console.WriteLine("\nViewing tasks one by one:");
       scheduler.ViewCurrentTask();
       scheduler.ViewCurrentTask();
       scheduler.ViewCurrentTask();

       Console.WriteLine("\nSearching for tasks with priority 1:");
       scheduler.SearchTaskByPriority(1);

       Console.WriteLine("\nRemoving task with ID 102:");
       scheduler.RemoveTaskByID(102);
       scheduler.DisplayAllTasks();
   }
}
	



________________










4. Singly Linked List: Inventory Management System
Problem Statement: Design an inventory management system using a singly linked list where each node stores information about an item such as Item Name, Item ID, Quantity, and Price. Implement the following functionalities:
* Add an item at the beginning, end, or at a specific position.
* Remove an item based on Item ID.
* Update the quantity of an item by Item ID.
* Search for an item based on Item ID or Item Name.
* Calculate and display the total value of inventory (Sum of Price * Quantity for each item).
* Sort the inventory based on Item Name or Price in ascending or descending order.
using System;

class ItemNode
{
   public string ItemName;
   public int ItemID;
   public int Quantity;
   public double Price;
   public ItemNode Next;

   public ItemNode(string name, int id, int qty, double price)
   {
       ItemName = name;
       ItemID = id;
       Quantity = qty;
       Price = price;
       Next = null;
   }
}

class InventoryManagement
{
   private ItemNode head;

   public InventoryManagement()
   {
       head = null;
   }

   // Add item at the beginning
   public void AddItemAtBeginning(string name, int id, int qty, double price)
   {
       ItemNode newNode = new ItemNode(name, id, qty, price);
       newNode.Next = head;
       head = newNode;
   }

   // Add item at the end
   public void AddItemAtEnd(string name, int id, int qty, double price)
   {
       ItemNode newNode = new ItemNode(name, id, qty, price);
       if (head == null)
       {
           head = newNode;
           return;
       }
       ItemNode temp = head;
       while (temp.Next != null)
       {
           temp = temp.Next;
       }
       temp.Next = newNode;
   }

   // Add item at a specific position (1-based index)
   public void AddItemAtPosition(string name, int id, int qty, double price, int position)
   {
       if (position <= 1 || head == null)
       {
           AddItemAtBeginning(name, id, qty, price);
           return;
       }
       ItemNode newNode = new ItemNode(name, id, qty, price);
       ItemNode temp = head;
       int count = 1;
       while (temp.Next != null && count < position - 1)
       {
           temp = temp.Next;
           count++;
       }
       newNode.Next = temp.Next;
       temp.Next = newNode;
   }

   // Remove item by Item ID
   public void RemoveItemByID(int id)
   {
       if (head == null)
       {
           Console.WriteLine("No items in inventory.");
           return;
       }

       if (head.ItemID == id)
       {
           head = head.Next;
           Console.WriteLine($"Item {id} removed.");
           return;
       }

       ItemNode temp = head, prev = null;
       while (temp != null && temp.ItemID != id)
       {
           prev = temp;
           temp = temp.Next;
       }

       if (temp == null)
       {
           Console.WriteLine("Item not found.");
           return;
       }

       prev.Next = temp.Next;
       Console.WriteLine($"Item {id} removed.");
   }

   // Update quantity of an item by Item ID
   public void UpdateItemQuantity(int id, int newQty)
   {
       ItemNode temp = head;
       while (temp != null)
       {
           if (temp.ItemID == id)
           {
               temp.Quantity = newQty;
               Console.WriteLine($"Quantity updated for Item {id}.");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Item not found.");
   }

   // Search for an item by ID or Name
   public void SearchItem(int id, string name)
   {
       ItemNode temp = head;
       while (temp != null)
       {
           if (temp.ItemID == id || temp.ItemName == name)
           {
               Console.WriteLine($"Item Found - ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price}");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Item not found.");
   }

   // Calculate and display total inventory value
   public void CalculateTotalInventoryValue()
   {
       double totalValue = 0;
       ItemNode temp = head;
       while (temp != null)
       {
           totalValue += temp.Price * temp.Quantity;
           temp = temp.Next;
       }
       Console.WriteLine($"Total Inventory Value: {totalValue}");
   }

   // Sort inventory based on Item Name (ascending order)
   public void SortByItemName()
   {
       if (head == null || head.Next == null)
           return;

       for (ItemNode i = head; i != null; i = i.Next)
       {
           for (ItemNode j = i.Next; j != null; j = j.Next)
           {
               if (string.Compare(i.ItemName, j.ItemName) > 0)
               {
                   Swap(i, j);
               }
           }
       }
       Console.WriteLine("Inventory sorted by Item Name.");
   }

   // Sort inventory based on Price (ascending order)
   public void SortByPrice()
   {
       if (head == null || head.Next == null)
           return;

       for (ItemNode i = head; i != null; i = i.Next)
       {
           for (ItemNode j = i.Next; j != null; j = j.Next)
           {
               if (i.Price > j.Price)
               {
                   Swap(i, j);
               }
           }
       }
       Console.WriteLine("Inventory sorted by Price.");
   }

   // Swap two nodes' data
   private void Swap(ItemNode a, ItemNode b)
   {
       string tempName = a.ItemName;
       int tempID = a.ItemID;
       int tempQty = a.Quantity;
       double tempPrice = a.Price;

       a.ItemName = b.ItemName;
       a.ItemID = b.ItemID;
       a.Quantity = b.Quantity;
       a.Price = b.Price;

       b.ItemName = tempName;
       b.ItemID = tempID;
       b.Quantity = tempQty;
       b.Price = tempPrice;
   }

   // Display inventory
   public void DisplayInventory()
   {
       if (head == null)
       {
           Console.WriteLine("Inventory is empty.");
           return;
       }
       ItemNode temp = head;
       while (temp != null)
       {
           Console.WriteLine($"ID: {temp.ItemID}, Name: {temp.ItemName}, Quantity: {temp.Quantity}, Price: {temp.Price}");
           temp = temp.Next;
       }
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       InventoryManagement inventory = new InventoryManagement();
       inventory.AddItemAtEnd("Laptop", 101, 5, 1500);
       inventory.AddItemAtEnd("Mouse", 102, 20, 25);
       inventory.AddItemAtBeginning("Keyboard", 103, 10, 50);
       inventory.AddItemAtPosition("Monitor", 104, 8, 300, 2);

       Console.WriteLine("\nInitial Inventory:");
       inventory.DisplayInventory();

       Console.WriteLine("\nUpdating quantity of Item ID 102:");
       inventory.UpdateItemQuantity(102, 25);
       inventory.DisplayInventory();

       Console.WriteLine("\nSearching for item with ID 104:");
       inventory.SearchItem(104, "");

       Console.WriteLine("\nCalculating total inventory value:");
       inventory.CalculateTotalInventoryValue();

       Console.WriteLine("\nSorting inventory by Item Name:");
       inventory.SortByItemName();
       inventory.DisplayInventory();

       Console.WriteLine("\nSorting inventory by Price:");
       inventory.SortByPrice();
       inventory.DisplayInventory();

       Console.WriteLine("\nRemoving item with ID 103:");
       inventory.RemoveItemByID(103);
       inventory.DisplayInventory();
   }
}
	



________________


5. Doubly Linked List: Library Management System
Problem Statement: Design a library management system using a doubly linked list. Each node represents a book and contains the following attributes: Book Title, Author, Genre, Book ID, and Availability Status. Implement the following functionalities:
* Add a new book at the beginning, end, or at a specific position.
* Remove a book by Book ID.
* Search for a book by Book Title or Author.
* Update a book’s Availability Status.
* Display all books in forward and reverse order.
* Count the total number of books in the library.
using System;

class BookNode
{
   public string BookTitle;
   public string Author;
   public string Genre;
   public int BookID;
   public bool IsAvailable;
   public BookNode Next;
   public BookNode Prev;

   public BookNode(string title, string author, string genre, int id, bool available)
   {
       BookTitle = title;
       Author = author;
       Genre = genre;
       BookID = id;
       IsAvailable = available;
       Next = null;
       Prev = null;
   }
}

class LibraryManagement
{
   private BookNode head;
   private BookNode tail;
   private int bookCount;

   public LibraryManagement()
   {
       head = null;
       tail = null;
       bookCount = 0;
   }

   // Add book at the beginning
   public void AddBookAtBeginning(string title, string author, string genre, int id, bool available)
   {
       BookNode newNode = new BookNode(title, author, genre, id, available);
       if (head == null)
       {
           head = tail = newNode;
       }
       else
       {
           newNode.Next = head;
           head.Prev = newNode;
           head = newNode;
       }
       bookCount++;
   }

   // Add book at the end
   public void AddBookAtEnd(string title, string author, string genre, int id, bool available)
   {
       BookNode newNode = new BookNode(title, author, genre, id, available);
       if (head == null)
       {
           head = tail = newNode;
       }
       else
       {
           tail.Next = newNode;
           newNode.Prev = tail;
           tail = newNode;
       }
       bookCount++;
   }

   // Add book at a specific position (1-based index)
   public void AddBookAtPosition(string title, string author, string genre, int id, bool available, int position)
   {
       if (position <= 1 || head == null)
       {
           AddBookAtBeginning(title, author, genre, id, available);
           return;
       }
       BookNode newNode = new BookNode(title, author, genre, id, available);
       BookNode temp = head;
       int count = 1;

       while (temp.Next != null && count < position - 1)
       {
           temp = temp.Next;
           count++;
       }

       newNode.Next = temp.Next;
       newNode.Prev = temp;
       if (temp.Next != null)
           temp.Next.Prev = newNode;
       temp.Next = newNode;

       if (newNode.Next == null)
           tail = newNode;

       bookCount++;
   }

   // Remove book by Book ID
   public void RemoveBookByID(int id)
   {
       if (head == null)
       {
           Console.WriteLine("No books in the library.");
           return;
       }

       BookNode temp = head;

       while (temp != null && temp.BookID != id)
           temp = temp.Next;

       if (temp == null)
       {
           Console.WriteLine("Book not found.");
           return;
       }

       if (temp == head)
           head = head.Next;
       if (temp == tail)
           tail = tail.Prev;
       if (temp.Prev != null)
           temp.Prev.Next = temp.Next;
       if (temp.Next != null)
           temp.Next.Prev = temp.Prev;

       bookCount--;
       Console.WriteLine($"Book {id} removed.");
   }

   // Search for a book by Title or Author
   public void SearchBook(string title, string author)
   {
       BookNode temp = head;
       while (temp != null)
       {
           if (temp.BookTitle == title || temp.Author == author)
           {
               Console.WriteLine($"Book Found - ID: {temp.BookID}, Title: {temp.BookTitle}, Author: {temp.Author}, Genre: {temp.Genre}, Available: {temp.IsAvailable}");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Book not found.");
   }

   // Update a book's Availability Status
   public void UpdateBookAvailability(int id, bool available)
   {
       BookNode temp = head;
       while (temp != null)
       {
           if (temp.BookID == id)
           {
               temp.IsAvailable = available;
               Console.WriteLine($"Availability updated for Book {id}.");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("Book not found.");
   }

   // Display books in forward order
   public void DisplayBooksForward()
   {
       if (head == null)
       {
           Console.WriteLine("Library is empty.");
           return;
       }
       BookNode temp = head;
       while (temp != null)
       {
           Console.WriteLine($"ID: {temp.BookID}, Title: {temp.BookTitle}, Author: {temp.Author}, Genre: {temp.Genre}, Available: {temp.IsAvailable}");
           temp = temp.Next;
       }
   }

   // Display books in reverse order
   public void DisplayBooksReverse()
   {
       if (tail == null)
       {
           Console.WriteLine("Library is empty.");
           return;
       }
       BookNode temp = tail;
       while (temp != null)
       {
           Console.WriteLine($"ID: {temp.BookID}, Title: {temp.BookTitle}, Author: {temp.Author}, Genre: {temp.Genre}, Available: {temp.IsAvailable}");
           temp = temp.Prev;
       }
   }

   // Count total books in the library
   public void CountBooks()
   {
       Console.WriteLine($"Total books in library: {bookCount}");
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       LibraryManagement library = new LibraryManagement();
       library.AddBookAtEnd("The Hobbit", "J.R.R. Tolkien", "Fantasy", 101, true);
       library.AddBookAtEnd("1984", "George Orwell", "Dystopian", 102, true);
       library.AddBookAtBeginning("To Kill a Mockingbird", "Harper Lee", "Classic", 103, true);
       library.AddBookAtPosition("Brave New World", "Aldous Huxley", "Science Fiction", 104, false, 2);

       Console.WriteLine("\nLibrary Books (Forward Order):");
       library.DisplayBooksForward();

       Console.WriteLine("\nUpdating availability of Book ID 102:");
       library.UpdateBookAvailability(102, false);
       library.DisplayBooksForward();

       Console.WriteLine("\nSearching for book by Author 'Aldous Huxley':");
       library.SearchBook("", "Aldous Huxley");

       Console.WriteLine("\nLibrary Books (Reverse Order):");
       library.DisplayBooksReverse();

       Console.WriteLine("\nCounting total books:");
       library.CountBooks();

       Console.WriteLine("\nRemoving book with ID 103:");
       library.RemoveBookByID(103);
       library.DisplayBooksForward();

       Console.WriteLine("\nCounting total books after removal:");
       library.CountBooks();
   }
}
	________________


6. Circular Linked List: Round Robin Scheduling Algorithm
Problem Statement: Implement a round-robin CPU scheduling algorithm using a circular linked list. Each node will represent a process and contain Process ID, Burst Time, and Priority. Implement the following functionalities:
* Add a new process at the end of the circular list.
* Remove a process by Process ID after its execution.
* Simulate the scheduling of processes in a round-robin manner with a fixed time quantum.
* Display the list of processes in the circular queue after each round.
* Calculate and display the average waiting time and turn-around time for all processes.
using System;

class Process
{
   public int ProcessID;
   public int BurstTime;
   public int Priority;
   public int WaitingTime;
   public int TurnAroundTime;
   public Process Next;

   public Process(int processID, int burstTime, int priority)
   {
       ProcessID = processID;
       BurstTime = burstTime;
       Priority = priority;
       WaitingTime = 0;
       TurnAroundTime = 0;
       Next = null;
   }
}

class CircularLinkedList
{
   private Process head;
   private Process tail;
   private int timeQuantum;

   public CircularLinkedList(int quantum)
   {
       head = null;
       tail = null;
       timeQuantum = quantum;
   }

   // Add a new process at the end of the circular list
   public void AddProcess(int processID, int burstTime, int priority)
   {
       Process newProcess = new Process(processID, burstTime, priority);
       if (head == null)
       {
           head = newProcess;
           tail = newProcess;
           tail.Next = head; // Circular link
       }
       else
       {
           tail.Next = newProcess;
           tail = newProcess;
           tail.Next = head; // Circular link
       }
   }

   // Remove a process by Process ID after its execution
   public void RemoveProcess(int processID)
   {
       if (head == null)
       {
           Console.WriteLine("No processes to remove.");
           return;
       }

       Process current = head;
       Process previous = null;

       do
       {
           if (current.ProcessID == processID)
           {
               if (current == head)
               {
                   if (head == tail) // Only one process in the list
                   {
                       head = null;
                       tail = null;
                   }
                   else
                   {
                       head = head.Next;
                       tail.Next = head;
                   }
               }
               else
               {
                   previous.Next = current.Next;
                   if (current == tail)
                   {
                       tail = previous;
                   }
               }
               Console.WriteLine($"Process {processID} removed.");
               return;
           }
           previous = current;
           current = current.Next;
       } while (current != head);

       Console.WriteLine($"Process {processID} not found.");
   }

   // Simulate the scheduling of processes in a round-robin manner
   public void SimulateRoundRobin()
   {
       if (head == null)
       {
           Console.WriteLine("No processes to schedule.");
           return;
       }

       int totalWaitingTime = 0;
       int totalTurnAroundTime = 0;
       int totalProcesses = 0;

       Process current = head;
       do
       {
           totalProcesses++;
           current = current.Next;
       } while (current != head);

       while (head != null)
       {
           current = head;
           do
           {
               if (current.BurstTime > 0)
               {
                   Console.WriteLine($"Executing Process {current.ProcessID} with Burst Time {current.BurstTime}");
                   int executionTime = Math.Min(timeQuantum, current.BurstTime);
                   current.BurstTime -= executionTime;

                   // Update waiting and turn-around times for other processes
                   Process temp = current.Next;
                   while (temp != current)
                   {
                       if (temp.BurstTime > 0)
                       {
                           temp.WaitingTime += executionTime;
                       }
                       temp = temp.Next;
                   }

                   if (current.BurstTime == 0)
                   {
                       current.TurnAroundTime = current.WaitingTime + executionTime;
                       totalWaitingTime += current.WaitingTime;
                       totalTurnAroundTime += current.TurnAroundTime;
                       Console.WriteLine($"Process {current.ProcessID} completed. Waiting Time: {current.WaitingTime}, Turn-Around Time: {current.TurnAroundTime}");
                       RemoveProcess(current.ProcessID);
                   }
               }
               current = current.Next;
           } while (current != head);

           DisplayProcesses();
       }

       Console.WriteLine($"Average Waiting Time: {(double)totalWaitingTime / totalProcesses}");
       Console.WriteLine($"Average Turn-Around Time: {(double)totalTurnAroundTime / totalProcesses}");
   }

   // Display the list of processes in the circular queue
   public void DisplayProcesses()
   {
       if (head == null)
       {
           Console.WriteLine("No processes in the queue.");
           return;
       }

       Process current = head;
       Console.WriteLine("Processes in the queue:");
       do
       {
           Console.WriteLine($"Process ID: {current.ProcessID}, Burst Time: {current.BurstTime}, Priority: {current.Priority}, Waiting Time: {current.WaitingTime}, Turn-Around Time: {current.TurnAroundTime}");
           current = current.Next;
       } while (current != head);
   }
}

class Program
{
   static void Main(string[] args)
   {
       CircularLinkedList scheduler = new CircularLinkedList(4); // Time quantum = 4

       // Add processes
       scheduler.AddProcess(1, 10, 2);
       scheduler.AddProcess(2, 5, 1);
       scheduler.AddProcess(3, 8, 3);

       // Display initial processes
       scheduler.DisplayProcesses();

       // Simulate round-robin scheduling
       scheduler.SimulateRoundRobin();
   }
}
	







________________


7. Singly Linked List: Social Media Friend Connections
Problem Statement: Create a system to manage social media friend connections using a singly linked list. Each node represents a user with User ID, Name, Age, and List of Friend IDs. Implement the following operations:
* Add a friend connection between two users.
* Remove a friend connection.
* Find mutual friends between two users.
* Display all friends of a specific user.
* Search for a user by Name or User ID.
* Count the number of friends for each user.
using System;
using System.Collections.Generic;


class UserNode
{
   public int UserID;
   public string Name;
   public int Age;
   public List<int> FriendIDs;
   public UserNode Next;

   public UserNode(int id, string name, int age)
   {
       UserID = id;
       Name = name;
       Age = age;
       FriendIDs = new List<int>();
       Next = null;
   }
}

class SocialMedia
{
   private UserNode head;

   public SocialMedia()
   {
       head = null;
   }

   // Add a new user
   public void AddUser(int id, string name, int age)
   {
       UserNode newUser = new UserNode(id, name, age);
       if (head == null)
       {
           head = newUser;
       }
       else
       {
           UserNode temp = head;
           while (temp.Next != null)
               temp = temp.Next;
           temp.Next = newUser;
       }
   }

   // Find user by ID
   private UserNode FindUser(int id)
   {
       UserNode temp = head;
       while (temp != null)
       {
           if (temp.UserID == id)
               return temp;
           temp = temp.Next;
       }
       return null;
   }

   // Add friend connection between two users
   public void AddFriend(int userId1, int userId2)
   {
       UserNode user1 = FindUser(userId1);
       UserNode user2 = FindUser(userId2);

       if (user1 == null || user2 == null)
       {
           Console.WriteLine("One or both users not found.");
           return;
       }

       if (!user1.FriendIDs.Contains(userId2))
           user1.FriendIDs.Add(userId2);
       if (!user2.FriendIDs.Contains(userId1))
           user2.FriendIDs.Add(userId1);

       Console.WriteLine($"Friend connection added between {user1.Name} and {user2.Name}");
   }

   // Remove friend connection
   public void RemoveFriend(int userId1, int userId2)
   {
       UserNode user1 = FindUser(userId1);
       UserNode user2 = FindUser(userId2);

       if (user1 == null || user2 == null)
       {
           Console.WriteLine("One or both users not found.");
           return;
       }

       user1.FriendIDs.Remove(userId2);
       user2.FriendIDs.Remove(userId1);

       Console.WriteLine($"Friend connection removed between {user1.Name} and {user2.Name}");
   }

   // Find mutual friends between two users
   public void FindMutualFriends(int userId1, int userId2)
   {
       UserNode user1 = FindUser(userId1);
       UserNode user2 = FindUser(userId2);

       if (user1 == null || user2 == null)
       {
           Console.WriteLine("One or both users not found.");
           return;
       }

       List<int> mutualFriends = new List<int>();
       foreach (int id in user1.FriendIDs)
       {
           if (user2.FriendIDs.Contains(id))
               mutualFriends.Add(id);
       }

       if (mutualFriends.Count == 0)
       {
           Console.WriteLine($"No mutual friends between {user1.Name} and {user2.Name}");
       }
       else
       {
           Console.WriteLine($"Mutual friends between {user1.Name} and {user2.Name}:");
           foreach (int id in mutualFriends)
           {
               UserNode friend = FindUser(id);
               Console.WriteLine($"- {friend.Name} (ID: {friend.UserID})");
           }
       }
   }

   // Display all friends of a specific user
   public void DisplayFriends(int userId)
   {
       UserNode user = FindUser(userId);
       if (user == null)
       {
           Console.WriteLine("User not found.");
           return;
       }

       Console.WriteLine($"Friends of {user.Name}:");
       if (user.FriendIDs.Count == 0)
       {
           Console.WriteLine("No friends.");
           return;
       }

       foreach (int id in user.FriendIDs)
       {
           UserNode friend = FindUser(id);
           Console.WriteLine($"- {friend.Name} (ID: {friend.UserID})");
       }
   }

   // Search for a user by Name or ID
   public void SearchUser(string name, int id = -1)
   {
       UserNode temp = head;
       while (temp != null)
       {
           if (temp.Name == name || temp.UserID == id)
           {
               Console.WriteLine($"User Found - ID: {temp.UserID}, Name: {temp.Name}, Age: {temp.Age}, Friends Count: {temp.FriendIDs.Count}");
               return;
           }
           temp = temp.Next;
       }
       Console.WriteLine("User not found.");
   }

   // Count the number of friends for each user
   public void CountFriends()
   {
       UserNode temp = head;
       while (temp != null)
       {
           Console.WriteLine($"{temp.Name} (ID: {temp.UserID}) has {temp.FriendIDs.Count} friend(s).");
           temp = temp.Next;
       }
   }

   // Display all users
   public void DisplayAllUsers()
   {
       if (head == null)
       {
           Console.WriteLine("No users in the system.");
           return;
       }

       UserNode temp = head;
       Console.WriteLine("All Users:");
       while (temp != null)
       {
           Console.WriteLine($"ID: {temp.UserID}, Name: {temp.Name}, Age: {temp.Age}, Friends: {temp.FriendIDs.Count}");
           temp = temp.Next;
       }
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       SocialMedia network = new SocialMedia();

       network.AddUser(1, "Alice", 25);
       network.AddUser(2, "Bob", 27);
       network.AddUser(3, "Charlie", 22);
       network.AddUser(4, "David", 29);

       Console.WriteLine("\nAdding friend connections:");
       network.AddFriend(1, 2);
       network.AddFriend(1, 3);
       network.AddFriend(2, 3);
       network.AddFriend(3, 4);

       Console.WriteLine("\nDisplaying all users:");
       network.DisplayAllUsers();

       Console.WriteLine("\nDisplaying Alice's friends:");
       network.DisplayFriends(1);

       Console.WriteLine("\nFinding mutual friends between Alice and Bob:");
       network.FindMutualFriends(1, 2);

       Console.WriteLine("\nSearching for user Bob:");
       network.SearchUser("Bob");

       Console.WriteLine("\nCounting friends:");
       network.CountFriends();

       Console.WriteLine("\nRemoving friend connection between Alice and Bob:");
       network.RemoveFriend(1, 2);
       network.DisplayFriends(1);

       Console.WriteLine("\nCounting friends after removal:");
       network.CountFriends();
   }
}
	





________________


8. Doubly Linked List: Undo/Redo Functionality for Text Editor
Problem Statement: Design an undo/redo functionality for a text editor using a doubly linked list. Each node represents a state of the text content (e.g., after typing a word or performing a command). Implement the following:
* Add a new text state at the end of the list every time the user types or performs an action.
* Implement the undo functionality (revert to the previous state).
* Implement the redo functionality (revert back to the next state after undo).
* Display the current state of the text.
* Limit the undo/redo history to a fixed size (e.g., last 10 states).
using System;

class TextState
{
   public string Content; // Represents the text content at this state
   public TextState Previous; // Pointer to the previous state
   public TextState Next; // Pointer to the next state

   public TextState(string content)
   {
       Content = content;
       Previous = null;
       Next = null;
   }
}

class TextEditor
{
   private TextState currentState; // Current state of the text
   private int historySize; // Maximum number of states to keep in history
   private int stateCount; // Current number of states in history

   public TextEditor(int maxHistorySize)
   {
       currentState = new TextState(""); // Initialize with empty text
       historySize = maxHistorySize;
       stateCount = 1;
   }

   // Add a new text state to the history
   public void AddState(string newContent)
   {
       TextState newState = new TextState(newContent);
       newState.Previous = currentState;
       currentState.Next = newState;
       currentState = newState;
       stateCount++;

       // If history exceeds the limit, remove the oldest state
       if (stateCount > historySize)
       {
           RemoveOldestState();
       }
   }

   // Remove the oldest state from the history
   private void RemoveOldestState()
   {
       TextState oldestState = currentState;
       while (oldestState.Previous != null)
       {
           oldestState = oldestState.Previous;
       }
       oldestState.Next.Previous = null; // Detach the oldest state
       stateCount--;
   }

   // Undo: Revert to the previous state
   public void Undo()
   {
       if (currentState.Previous != null)
       {
           currentState = currentState.Previous;
           Console.WriteLine("Undo performed. Current state:");
           DisplayCurrentState();
       }
       else
       {
           Console.WriteLine("Nothing to undo.");
       }
   }

   // Redo: Revert to the next state after undo
   public void Redo()
   {
       if (currentState.Next != null)
       {
           currentState = currentState.Next;
           Console.WriteLine("Redo performed. Current state:");
           DisplayCurrentState();
       }
       else
       {
           Console.WriteLine("Nothing to redo.");
       }
   }

   // Display the current state of the text
   public void DisplayCurrentState()
   {
       Console.WriteLine(currentState.Content);
   }
}

class Program
{
   static void Main(string[] args)
   {
       TextEditor editor = new TextEditor(10); // Limit history to 10 states

       // Simulate user actions
       editor.AddState("Hello");
       editor.AddState("Hello, world!");
       editor.AddState("Hello, world! How are you?");
       editor.AddState("Hello, world! How are you? I'm fine.");

       // Display current state
       Console.WriteLine("Initial state:");
       editor.DisplayCurrentState();

       // Perform undo
       editor.Undo();
       editor.Undo();

       // Perform redo
       editor.Redo();

       // Add more states
       editor.AddState("Hello, world! How are you? I'm fine. Thank you!");
       editor.AddState("Hello, world! How are you? I'm fine. Thank you! And you?");

       // Display current state
       Console.WriteLine("Final state:");
       editor.DisplayCurrentState();
   }
}
	



________________






9. Circular Linked List: Online Ticket Reservation System
Problem Statement: Design an online ticket reservation system using a circular linked list, where each node represents a booked ticket. Each node will store the following information: Ticket ID, Customer Name, Movie Name, Seat Number, and Booking Time. Implement the following functionalities:
* Add a new ticket reservation at the end of the circular list.
* Remove a ticket by Ticket ID.
* Display the current tickets in the list.
* Search for a ticket by Customer Name or Movie Name.
* Calculate the total number of booked tickets.
using System;

class TicketNode
{
   public int TicketID;
   public string CustomerName;
   public string MovieName;
   public string SeatNumber;
   public DateTime BookingTime;
   public TicketNode Next;

   public TicketNode(int id, string customer, string movie, string seat)
   {
       TicketID = id;
       CustomerName = customer;
       MovieName = movie;
       SeatNumber = seat;
       BookingTime = DateTime.Now;
       Next = null;
   }
}

class TicketReservationSystem
{
   private TicketNode last;

   public TicketReservationSystem()
   {
       last = null;
   }

   // Add a new ticket reservation at the end of the circular list
   public void AddTicket(int id, string customer, string movie, string seat)
   {
       TicketNode newTicket = new TicketNode(id, customer, movie, seat);

       if (last == null)
       {
           last = newTicket;
           last.Next = last;
       }
       else
       {
           newTicket.Next = last.Next;
           last.Next = newTicket;
           last = newTicket;
       }
       Console.WriteLine($"Ticket booked successfully! Ticket ID: {id}, Customer: {customer}, Movie: {movie}, Seat: {seat}");
   }

   // Remove a ticket by Ticket ID
   public void RemoveTicket(int id)
   {
       if (last == null)
       {
           Console.WriteLine("No tickets booked.");
           return;
       }

       TicketNode current = last.Next, previous = last;
       do
       {
           if (current.TicketID == id)
           {
               if (current == last && current.Next == last)
               {
                   last = null;
               }
               else
               {
                   previous.Next = current.Next;
                   if (current == last)
                       last = previous;
               }
               Console.WriteLine($"Ticket with ID {id} has been removed.");
               return;
           }
           previous = current;
           current = current.Next;
       } while (current != last.Next);

       Console.WriteLine($"Ticket with ID {id} not found.");
   }

   // Display all tickets
   public void DisplayTickets()
   {
       if (last == null)
       {
           Console.WriteLine("No tickets booked.");
           return;
       }

       TicketNode current = last.Next;
       Console.WriteLine("Current Booked Tickets:");
       do
       {
           Console.WriteLine($"Ticket ID: {current.TicketID}, Customer: {current.CustomerName}, Movie: {current.MovieName}, Seat: {current.SeatNumber}, Booking Time: {current.BookingTime}");
           current = current.Next;
       } while (current != last.Next);
   }

   // Search for a ticket by Customer Name or Movie Name
   public void SearchTicket(string customer = null, string movie = null)
   {
       if (last == null)
       {
           Console.WriteLine("No tickets booked.");
           return;
       }

       TicketNode current = last.Next;
       bool found = false;
       do
       {
           if ((customer != null && current.CustomerName == customer) || (movie != null && current.MovieName == movie))
           {
               Console.WriteLine($"Ticket Found - ID: {current.TicketID}, Customer: {current.CustomerName}, Movie: {current.MovieName}, Seat: {current.SeatNumber}, Booking Time: {current.BookingTime}");
               found = true;
           }
           current = current.Next;
       } while (current != last.Next);

       if (!found)
           Console.WriteLine("No matching tickets found.");
   }

   // Calculate total number of booked tickets
   public int CountTickets()
   {
       if (last == null)
           return 0;

       int count = 0;
       TicketNode current = last.Next;
       do
       {
           count++;
           current = current.Next;
       } while (current != last.Next);

       return count;
   }
}

// Test the implementation
class Program
{
   static void Main()
   {
       TicketReservationSystem system = new TicketReservationSystem();

       system.AddTicket(101, "Alice", "Avengers", "A1");
       system.AddTicket(102, "Bob", "Inception", "B2");
       system.AddTicket(103, "Charlie", "Avengers", "C3");

       Console.WriteLine("\nDisplaying all booked tickets:");
       system.DisplayTickets();

       Console.WriteLine("\nSearching for tickets booked by Alice:");
       system.SearchTicket(customer: "Alice");

       Console.WriteLine("\nSearching for tickets for the movie 'Avengers':");
       system.SearchTicket(movie: "Avengers");

       Console.WriteLine("\nTotal booked tickets: " + system.CountTickets());

       Console.WriteLine("\nRemoving ticket with ID 102:");
       system.RemoveTicket(102);
       system.DisplayTickets();

       Console.WriteLine("\nTotal booked tickets after removal: " + system.CountTickets());
   }
}