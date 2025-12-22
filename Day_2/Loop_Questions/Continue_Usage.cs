using System;

class Continue_Usage
{
    public static void ContMain()
    {
        for(int i = 1; i<=50; i++)
        {
            Console.WriteLine(i);
            if(i%3 == 0)
            {
                continue;
            }
        }
    }
}