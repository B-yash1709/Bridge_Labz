using System;

class Solution {
    // Calculate the sum of heights
    public static int CalculateSum(int[] heights) {
        int sum = 0;
        foreach (int height in heights) {
            sum += height;
        }
        return sum;
    }

    // Calculate the mean height
    public static double CalculateMean(int[] heights) {
        if (heights.Length == 0) return 0; 
		
        int sum = CalculateSum(heights);
		
        return (double)sum / heights.Length;
    }

    // Find the shortest height
    public static int FindShortest(int[] heights) {
        if (heights.Length == 0) return 0; 
		
        int shortest = Int32.MaxValue;
		
        foreach (int height in heights) {
            if (height < shortest) {
                shortest = height;
            }
        }
        return shortest;
    }

    // Find the tallest height
    public static int FindTallest(int[] heights) {
        if (heights.Length == 0) return 0;
		
        int tallest = Int32.MinValue;
		
        foreach (int height in heights) {
            if (height > tallest) {
                tallest = height;
            }
        }
        return tallest;
    }

    public static void Main() {
        // Constants for height range and number of players
        const int MinHeight = 150;
        const int MaxHeight = 250;
        const int PlayerCount = 11;

        // Generate random heights
        Random random = new Random();
        int[] heights = new int[PlayerCount];
        for (int i = 0; i < PlayerCount; i++) {
            heights[i] = random.Next(MinHeight, MaxHeight + 1);
        }

        // Display results
        Console.WriteLine("Heights of players: " + string.Join(", ", heights));
        Console.WriteLine("Shortest: {0} cm", FindShortest(heights));
        Console.WriteLine("Tallest: {0} cm", FindTallest(heights));
        Console.WriteLine("Mean: {0:F2} cm", CalculateMean(heights));
    }
}
