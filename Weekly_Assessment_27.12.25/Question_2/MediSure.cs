using System;

class PatientBill
{
    static string BillId;
    static string PatientName;
    static bool HasInsurance;
    static double ConsultationFee;
    static double LabCharges;
    static double MedicineCharges;
    static double GrossAmount;
    static double DiscountAmount;
    static double FinalPayable;

    public static void CreateMethod()
    {
        Console.Write("Enter Bill Id: ");
        BillId = Console.ReadLine();

        if (BillId == null)
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        PatientName = Console.ReadLine();

        Console.Write("Has Insurance? (Y/N): ");
        string Insurance = Console.ReadLine().ToUpper();

        if (Insurance == "Y")
            HasInsurance = true;
        else if (Insurance == "N")
            HasInsurance = false;
        else
        {
            Console.WriteLine("Invalid insurance option.");
            return;
        }

        Console.Write("Enter Consultation Fee: ");
        ConsultationFee = Convert.ToDouble(Console.ReadLine());

        if (ConsultationFee <= 0)
        {
            Console.WriteLine("Consultation Fee must be greater than 0.");
            return;
        }

        Console.Write("Enter Lab Charges: ");
        LabCharges = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Medicine Charges: ");
        MedicineCharges = Convert.ToDouble(Console.ReadLine());

        if (LabCharges < 0 || MedicineCharges < 0)
        {
            Console.WriteLine("Charges cannot be negative.");
            return;
        }

        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

        if (HasInsurance)
        {
            DiscountAmount = GrossAmount * 0.10;
        }
        else
        {
            DiscountAmount = 0;   
        }

        FinalPayable = GrossAmount - DiscountAmount;

        Console.WriteLine("Bill created successfully.");
        Console.WriteLine("Gross Amount: " + Math.Round(GrossAmount, 2));
        Console.WriteLine("Discount Amount: " + Math.Round(DiscountAmount, 2));
        Console.WriteLine("Final Payable: " + Math.Round(FinalPayable, 2));
    }
    // ----------------------- 2nd method ----------------
    public static void ViewMethod()
    {
        if (BillId == null)
        {
            Console.WriteLine("No bill available. Please create a bill first.");
            return;
        }

        Console.WriteLine("----------- Last Bill -----------");
        Console.WriteLine("BillId: " + BillId);
        Console.WriteLine("Patient: " + PatientName);
        Console.WriteLine("Insured: " + (HasInsurance ? "Yes" : "No"));
        Console.WriteLine("Consultation Fee: " + ConsultationFee);
        Console.WriteLine("Lab Charges: " + LabCharges);
        Console.WriteLine("Medicine Charges: " + MedicineCharges);
        Console.WriteLine("Gross Amount: " + GrossAmount);
        Console.WriteLine("Discount Amount: " + DiscountAmount);
        Console.WriteLine("Final Payable: " + FinalPayable);
        Console.WriteLine("--------------------------------");
    }

    // -------------------- 3rd method ------------------------------

    public static void ClearMethod()
    {
        BillId = null;
        PatientName = null;
        HasInsurance = false;
        ConsultationFee = 0;
        LabCharges = 0;
        MedicineCharges = 0;
        GrossAmount = 0;
        DiscountAmount = 0;
        FinalPayable = 0;

        Console.WriteLine("Last bill cleared.");
    }

}
