using System;
using System.Collections.Generic;
using LPU_Common;
using LPU_Entity;
using LPU_DAL;
using LPU_Exceptions;

namespace LPU_BL
{
    public class StudentBL : IStudentCRUD
    {
        StudentDAO sDAO = null; //FIRST DECLARE AND INITIALIZE "NULL" TO THE OBJ ; THIS IS A GOOD PRACTICE --> (i)
        // Student s1 = new Student() --> this is a bad practice
        public StudentBL()
        {
            sDAO = new StudentDAO();// THEN INIT USE IT INSIDE CONSTRUCTOR --> (ii)
        }

       public bool DropStudentDetails(int id)
        {
            
        } 

        public bool EnrollStudent(Student sObj)
        {
            
        }

        public bool SearchStudentById(int rollNo)
        {
            Student s1 = null;
            try
            {
                s1 = sDAO.SearchStudentByID(rollNo);
            }
            catch(LPUException e)
            {
                throw e;
            }
            return s1;
        }


    }
}