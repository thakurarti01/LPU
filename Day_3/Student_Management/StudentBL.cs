using System;
namespace Student_Management
{
    public class StudentBL
    {
        Student sObj = null;
        public StudentBL()
        {
            sObj = new Student();
        }

        public void AcceptStudentDetails()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("student management system");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("enter roll no");
            sObj.RollNo = Int32.Parse(Console.ReadLine());

            Console.WriteLine("enter name");
            sObj.Name = Console.ReadLine();


            Console.WriteLine("enter address");
            sObj.Address = Console.ReadLine();

            Console.WriteLine("enter phy marks");
            sObj.Phy = Int32.Parse(Console.ReadLine());

            Console.WriteLine("enter chem marks");
            sObj.Chem = Int32.Parse(Console.ReadLine());

            Console.WriteLine("enter maths marks");
            sObj.Maths = Int32.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;




        }
    }
}