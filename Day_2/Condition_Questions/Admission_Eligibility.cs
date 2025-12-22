using System;

class Admission_Eligibility()
{
    public static void AdmissionMain()
    {
        Console.WriteLine("Enter Maths marks: ");
        int maths = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Physics marks: ");
        int phy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Chemistry marks: ");
        int chem = Convert.ToInt32(Console.ReadLine());

        int total = Convert.ToInt32(maths+phy+chem);

        if((maths >= 65 && phy >= 55 && chem >=55) && ((total >= 180) || (maths + phy >= 140)))
        {
            Console.WriteLine("Eligible");
        }
        else
        {
            Console.WriteLine("Not Eligible");
        }

    }
}