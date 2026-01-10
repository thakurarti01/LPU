using System;
using System.IO;

public class DirectoryDemo
{
    public void DirectoryDemoFunc(string directoryName)
    {
        if (Directory.Exists(directoryName))
        {
            Console.WriteLine("Folder already exists");
        }
        else
        {
            Directory.CreateDirectory(directoryName);
            Console.WriteLine("Folder created...");
        }
    }

    public void DriveInfoFunc(string driveName)
    {
        DriveInfo dInfo = new DriveInfo(driveName);
        Console.WriteLine($"Drive name {dInfo.DriveType}");
        Console.WriteLine($"Drive size {dInfo.TotalSize}");
        Console.WriteLine($"Drive FreeSpace {dInfo.AvailableFreeSpace}");
    }

    public void PathDemoFunc()
    {
        string s = @"C:\temp\MyData.text\machone.config";
        Console.WriteLine(Path.GetFileName(s));
        Console.WriteLine(Path.GetTempPath());
    }
}