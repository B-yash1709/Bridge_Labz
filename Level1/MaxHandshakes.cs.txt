// Maximum Number of Handshakes
using System;

class Solution {
    // Method to calculate maximum number of handshakes
    public static int CalculateHandshakes(int n) {
        return (n * (n - 1)) / 2;
    }

    public static void Main() {
		// prompt user for number of students input
        Console.Write("Enter the number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = CalculateHandshakes(n);
        Console.WriteLine("Maximum number of handshakes among {0} students is {1}", n, handshakes);
    }
}
