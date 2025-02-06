using System;
using System.Collections.Generic;

// Patient class
class Patient
{
    public string name;
    public int age;
    
    public Patient(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    
    public void DisplayPatient()
    {
        Console.WriteLine("Patient: {0}, age: {1}", this.name, this.age);
    }
}

// Doctor class
class Doctor
{
    public string name;
    public string specialty;
    private List<Patient> patients;
    
    // constructor
    public Doctor(string name, string specialty)
    {
        this.name = name;
        this.specialty = specialty;
        this.patients = new List<Patient>();
    }
    
    // method to add Patient
    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }
    
    public void Consult(Patient patient)
    {
        Console.WriteLine("Doctor {0} ({1}) is consulting with Patient {2}", name, specialty, patient.name);
    }
    
    // Display Doctor Details
    public void DisplayDoctor()
    {
        Console.WriteLine("Doctor: {0}, specialty: {1}", name, specialty);
        Console.WriteLine("Patients:");
        foreach (var patient in patients)
        {
            patient.DisplayPatient();
        }
    }
}

// Hospital class
class Hospital
{
    public string name;
    private List<Doctor> doctors;
    private List<Patient> patients;
    
    // constructor
    public Hospital(string name)
    {
        this.name = name;
        this.doctors = new List<Doctor>();
        this.patients = new List<Patient>();
    }
    
    // method to add Doctor
    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
    }
    
    // method to add Patient
    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }
    
    // Display Hospital Details
    public void DisplayHospital()
    {
        Console.WriteLine("Hospital: {0}", name);
        Console.WriteLine("Doctors:");
        foreach (var doctor in doctors)
        {
            doctor.DisplayDoctor();
        }
        Console.WriteLine("Patients:");
        foreach (var patient in patients)
        {
            patient.DisplayPatient();
        }
    }
}

// Main Class
class Program
{
    public static void Main()
    {
        Hospital hospital = new Hospital("Maxx Hospital");
        
        Doctor doctor1 = new Doctor("Dr. Abhay", "Radiologist");
        Doctor doctor2 = new Doctor("Dr. Shiv kumar", "Dentist");
        
        Patient patient = new Patient("Vansh", 25);
                
        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);
        hospital.AddPatient(patient);
        
        doctor1.AddPatient(patient);
        
        doctor1.Consult(patient);
        
        hospital.DisplayHospital();
    }
}
