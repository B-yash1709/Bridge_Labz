using System;

class Solution {
    public static string GetMonthName(int month) {
        string[] monthNames = { "January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December" };
								
        return monthNames[month - 1];
    }
	
	public static bool CheckLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
	
    public static int GetDaysInMonth(int month, int year) {
        if (month == 2) {
            return CheckLeapYear(year) ? 29 : 28;
        }
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		
        return days[month - 1];
    }


    public static int GetFirstDayOfMonth(int month, int year) {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
		
        return (1 + x + (31 * m0) / 12) % 7;
    }

    public static void DisplayCalendar(int month, int year) {
        Console.WriteLine("{0} {1}" , GetMonthName(month) , year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int days = GetDaysInMonth(month, year);
        int firstDay = GetFirstDayOfMonth(month, year);

        for (int i = 0; i < firstDay; i++) {
            Console.Write("    ");
        }

        for (int day = 1; day <= days; day++) {
            Console.Write("{0,3} ", day);
            if ((day + firstDay) % 7 == 0) Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args) {
        Console.WriteLine("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        DisplayCalendar(month, year);
    }
}
