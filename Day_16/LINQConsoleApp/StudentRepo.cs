using System;
using System.Collections.Generic;
using System.Text;

namespace LINQConsoleApp
{
    public class StudentRepo
    {
        static List<Student> studList = null;

        public StudentRepo()
        {
            if(studList == null)
            {

                studList = new List<Student>()
                {
                    new Student(){RollNo = 1, Name = "Amit", Gender = "Male", Marks=80, Fees = 1500},
					new Student(){RollNo = 2, Name = "Aman", Gender = "Male", Marks=80, Fees = 1000},
					new Student(){RollNo = 3, Name = "Amrita", Gender = "Female", Marks=80, Fees = 2000},
					new Student(){RollNo = 4,Name = "Amey", Gender = "Male", Marks=80, Fees= 500},
					new Student(){RollNo = 5, Name = "Amit", Gender = "Male", Marks=80, Fees = 1000},
					new Student(){RollNo = 6, Name = "Amita", Gender = "Female", Marks=80, Fees = 1000},
				};
            }
        }

        public List<Student> GetAllStudents()
        {
            return studList;
		}
    }
}
