using System;

public class FriendsDetails
{
    // Method to find the youngest friend
    public static int FindYoungest(int[] ages)
    {
        int youngestIndex = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }
        }

        return youngestIndex;
    }

    // Method to find the tallest friend
    public static int FindTallest(float[] heights)
    {
        int tallestIndex = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }

        return tallestIndex;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Arrays to store ages and heights of the 3 friends
        int[] ages = new int[3];
        float[] heights = new float[3];

        string[] friends = { "Amar", "Akbar", "Anthony" };

        Console.WriteLine("Enter the age and height for the friends:");

        // Loop to take user input for ages and heights
        for (int i = 0; i < friends.Length; i++)
        {
            Console.Write("Enter age of " + friends[i] + ": ");
            ages[i] = int.Parse(Console.ReadLine());

            Console.Write("Enter height (in cm) of " + friends[i] + ": ");
            heights[i] = float.Parse(Console.ReadLine());
        }

        // Find the youngest friend
        int youngestIndex = FriendsDetails.FindYoungest(ages);

        // Find the tallest friend
        int tallestIndex = FriendsDetails.FindTallest(heights);

        // Display the results
        Console.WriteLine("Youngest Friend: " + friends[youngestIndex] + " (Age: " + ages[youngestIndex] + ")");
        Console.WriteLine("Tallest Friend: " + friends[tallestIndex] + " (Height: " + heights[tallestIndex] + " cm)");
    }
}
