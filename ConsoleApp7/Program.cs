using System;


class Patient
{
 
    private string name;
    private DateTime dateOfBirth;
    private string insuranceNumber;
    protected MedicalRecord medicalRecord;

  
    public string Name
    {
        get { return name; }
    }

    
    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    
    public string InsuranceNumber
    {
        get { return insuranceNumber; }
        set { insuranceNumber = value; }
    }

  
    public Patient(string name, DateTime dateOfBirth, string insuranceNumber)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        this.insuranceNumber = insuranceNumber;
        this.medicalRecord = new MedicalRecord();
    }

  
    public virtual void WriteDiagnosis(string diagnosis)
    {
        medicalRecord.AddDiagnosis(diagnosis);
    }

    
    public void ShowMedicalRecord()
    {
        Console.WriteLine($"Patient: {name}");
        Console.WriteLine($"Date of Birth: {dateOfBirth}");
        Console.WriteLine($"Insurance Number: {insuranceNumber}");
        Console.WriteLine("Medical Record:");
        medicalRecord.ShowDiagnoses();
    }
}


class Doctor : Patient
{
  
    private string specialization;

  
    public Doctor(string name, DateTime dateOfBirth, string insuranceNumber, string specialization)
        : base(name, dateOfBirth, insuranceNumber)
    {
        this.specialization = specialization;
    }

 
    public void SetDiagnosis(Patient patient, string diagnosis)
    {
        patient.WriteDiagnosis(diagnosis);
    }
}


class MedicalRecord
{
    
    private string[] diagnoses;
    private int count;

   
    public MedicalRecord()
    {
        diagnoses = new string[100]; 
        count = 0;
    }

   
    public void AddDiagnosis(string diagnosis)
    {
        diagnoses[count] = diagnosis;
        count++;
    }

  
    public void ShowDiagnoses()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Diagnosis  {i + 1}: {diagnoses[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Patient patient = new Patient("John", new DateTime(1990, 5, 15), "123456789");
        Doctor doctor = new Doctor("Dr. Smith", new DateTime(1975, 10, 20), "987654321", "Cardiologist");

        doctor.SetDiagnosis(patient, "Flu");
        doctor.SetDiagnosis(patient, "Heart disease");

        patient.ShowMedicalRecord();
    }
}
