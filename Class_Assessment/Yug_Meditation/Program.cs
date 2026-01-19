using System;
using System.Collections;

class Program
{
    public static ArrayList memberList = new ArrayList();

    public void AddYogaMember(int memberId, int age, double weight, string goal)
    {
        MeditationCenter member = new MeditationCenter();
        member.MemberId = memberId;
        member.Age = age;
        member.Weight = weight;
        member.Goal = goal;

        memberList.Add(member);
    }

    public double CalculateBMI(int memberId)
    {
        foreach(MeditationCenter member in memberList)
        {
            if(member.MemberId == memberId)
            {
                Console.WriteLine("Enter height in meter: ");
                double height = double.Parse(Console.ReadLine());

                double bmi = member.Weight / (height * height);
                member.BMI = bmi;
                return bmi;
            }
        }
        return 0;
    }

    public int CalculateYogaFee(int memberId)
    {
        foreach(MeditationCenter member in memberList)
        {
            if(member.MemberId == memberId)
            {
                if(member.Goal == "WeightLoss")
                {
                    return 3000;
                }
                else if(member.Goal == "Flexibility")
                {
                    return 2500;
                }
                else
                {
                    return 2000;
                }
            }
        }
        return 0;
    }
    static void Main()
    {
        Program p = new Program();

        p.AddYogaMember(1, 25, 70, "WeightLoss");
        Console.WriteLine("BMI: " + p.CalculateBMI(1));
        Console.WriteLine("Fee: " + p.CalculateYogaFee(1));
    }

}