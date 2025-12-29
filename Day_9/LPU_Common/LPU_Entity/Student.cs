using System;

namespace LPU_Entity
{
    public enum CourseType
    {
        Mechanical = 10,
        Electrical = 20,
        Civil = 30,
        CSE = 40,
        IT = 50
    }
    class Student
    {
        // make 4 properties named id, name, address, course
        public int StudentId{get; set;}
        public string Name{get; set;}
        public CourseType Course{get; set;} //property of type enum

        public string Address{get; set;}

    }
}
