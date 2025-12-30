using System;
using LPU_Common;
using LPU_Exceptions;
using LPU_Entity;

namespace LPU_DAL
{

    ///<summary>
    /// Student DAO class is used for CRUD operation
    /// </summary>
        
    public class StudentDAO : IStudentCRUD
    {
        static List<Student> studentList = null;

        public StudentDAO()
        {
            //collection initializer
            studentList = new List<Student>()
            {
                new Student() {StudentID = 101, Name = "arti", Course=CourseType.CSE, Address = "pune"},
                new Student() {StudentID = 102, Name = "aman", Course=CourseType.CSE, Address = "agra"},
                new Student() {StudentID = 103, Name = "riya", Course=CourseType.CSE, Address = "goa"},
                new Student() {StudentID = 104, Name = "aliya", Course=CourseType.CSE, Address = "delhi"},
                new Student() {StudentID = 105, Name = "rajat", Course=CourseType.CSE, Address = "kochi"},
            };
        }

        public bool DropStudentDetail(int id)
        {
            
        }

        public bool EnrollStudent(Student sObj)
        {
            bool flag = false;

            if(sObj != null)
            {
                studentlist.Add(sObj);
                flag = true;
            }

            return flag;
        }

        public bool SearchStudentByID(int rollNo)
        {
            Student myStud = null;

            if(rollNo != 0)
            {
               myStud = studentList.Find(s=>s.StudentId == rollNo); 
               if(myStud == null)
                {
                    throw new LPUException("student record not found");
                }
            }
            else
            {
                throw new LPUException("error generated...");
            }
            return myStud;

        }

        public List<Student> SearchStudentByName(string name)
        {
            List <Student> data = StudentList.FindAll( p => p.Name == name);
            return data;
        }
    }
}