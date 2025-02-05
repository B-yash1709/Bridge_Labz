using System;

class Patient
{
    // Static variable shared among all patients
    public static string HospitalName = "Aims Hospital";

    // Static variable to count total patients
    private static int totalPatients = 0;

    // Readonly variable for unique patient ID
    public readonly int PatientID;

    // Instance variables
    public string Name;
    public int Age;
    public string Ailment;

    // Constructor 
    public Patient(int id, string name, int age, string ailment)
    {
        this.PatientID = id;
        this.Name = name;
        this.Age = age;
        this.Ailment = ailment;
        totalPatients++;  
    }

    // Method to display patient details
    public void DisplayPatientDetails()
    {
        Console.WriteLine("Patient ID: "+PatientID+", Name: "+Name+", Age: "+Age+", Ailment: "+Ailment+", Hospital: "+HospitalName);
    }

    // Static method to get total patients
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients Admitted: "+totalPatients);
    }
}

class Program
{
    static void Main()
    {
        // Creating patient objects
        Patient p1 = new Patient(101, "Aman", 30, "Flu");
        Patient p2 = new Patient(102, "Rahul", 45, "Fever");

        // Checking if patient1 is an instance of Patient class using 'is' operator
        if (p1 is Patient)
        {
            p1.DisplayPatientDetails();
        }

        if (p2 is Patient)
        {
            p2.DisplayPatientDetails();
        }

        // Display total patients admitted
        Patient.GetTotalPatients();
    }
}
