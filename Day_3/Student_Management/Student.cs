using System;

namespace Student_Management
{
    public class Student
    {
        int rollNo;
        int phy;
        int chem;
        int maths;
        int total;
        float percentage;

        // CLR Properties
        public int RollNo
        {
            set
            {
                rollNo = value;
            }
            get
            {
                return rollNo;
            }
        }

        // Auto Implicit Properties
        public string Name{get; set;}

        public string Address{get; set;}

        public int Total{get; set;}

        public float Perc{get; set;}

        public int Phy
        {
            get
            {
                return phy;
            }
            set
            {
                if(value>=0 && value<=100)
                {
                    phy = value;    
                }
                else
                {
                    throw new InvalidMarksExcepton("Invalid Marks");
                }
            }
        }

        public int Chem
        {
            get
            {
                return chem;
            }
            set
            {
                if(value>=0 && value<=100)
                {
                    chem = value;    
                }
                else
                {
                    throw new InvalidMarksExcepton("Invalid Marks");
                }
            }
        }

        public int Maths
        {
            get
            {
                return maths;
            }
            set
            {
                if(value>=0 && value<=100)
                {
                    maths = value;    
                }
                else
                {
                    throw new InvalidMarksExcepton("Invalid Marks");
                }
            }
        }
    }

    internal class InvalidMarksException : Exception
    {
        public InvalidMarksException()
        {
            
        }

        public InvalidMarksException(string? message) : base(message)
        {
            
        }

        public InvalidMarksException
    }
}
