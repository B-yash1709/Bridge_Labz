// Check Spring Season
using System;

class Solution {
    // Method to determine if a date falls in spring season
    public static bool IsSpringSeason(int month, int day) {
        return ((month == 3 && day >= 20 && day <= 31) || (month == 4 && day >= 20 && day <= 30) || (month == 5 && day >= 20 && day <= 31) || (month == 6 && day <= 20)) ;
    }

    public static void Main() {
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter day (1-31): ");
        int day = Convert.ToInt32(Console.ReadLine());

        if (IsSpringSeason(month, day)) {
            Console.WriteLine("It's a Spring Season.");
        }
        else {
            Console.WriteLine("Not a Spring Season.");
        }
    }
}
