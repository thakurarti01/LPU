using System;

namespace LPU_Exceptions
{
    /// <summary>
    /// custom exception class created for LPU Project
    /// by arti date 29/12/2025
    /// </summary>
    public class LpuException : Exception
    {
        public LpuException() : base() //default constructor
        {
            
        }

        public LpuException(string errorMsg) : base(errorMsg)
        {
            
        }
    }
}