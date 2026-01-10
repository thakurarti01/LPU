using System;
using System.IO;

class FileStreamDemo
{
    FileStream fs = null;
    public void CreateFile(string fileName)
    {
        StreamWriter sw = null;
        try
        {
            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine("This is just a sample file for file Io Demo");
        }
        catch(FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(FileLoadException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sw.Close();
            fs.Close();
        }
        
    }

    public void ReadFile(string FileName)
    {
        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        Console.WriteLine(sr.ReadToEnd());  

        sr.Close();
        fs.Close(); 
    }
}