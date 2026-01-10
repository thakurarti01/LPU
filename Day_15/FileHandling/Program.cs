// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.IO;

class Program
{
    static void Main()
    {
        DirectoryDemo dObj = new DirectoryDemo();
        // dObj.DirectoryDemoFunc("LPU");

        // dObj.DriveInfoFunc("D:\\");

        // dObj.PathDemoFunc();

        FileStreamDemo fsDemoObj = new FileSreamDemo();
        fsDemoObj.CreateFile(@"E:\LPU\SampleData.txt"); //Cg_LPU will not work, need to write our own folder's name
    }
}