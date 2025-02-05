using System;

class Solution {
    // Method to generate a 6-digit OTP
    public static int GenerateOTP() {
        Random random = new Random();
        return random.Next(100000, 1000000); 
    }

    // Method to check if all OTPs in the array are unique
    public static bool CheckOTPsUnique(int[] otps) {
        for (int i = 0; i < otps.Length; i++) {
            for (int j = i + 1; j < otps.Length; j++) {
                if (otps[i] == otps[j]) {
                    return false; 
                }
            }
        }
        return true; 
    }

    public static void Main() {
        int[] otps = new int[10]; 

        // Generate 10 OTPs
        for (int i = 0; i < 10; i++) {
            otps[i] = GenerateOTP();
        }

        // Display the generated OTPs
        Console.WriteLine("Generated OTPs: {0}", string.Join(", ", otps));

        // Check if all OTPs are unique
        bool unique = CheckOTPsUnique(otps);

        Console.WriteLine("Are all OTPs unique? {0}" + unique);
    }
}
