using System;
using System.Collections.Generic;

class Program
{
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
        Console.WriteLine("Creator registered successfully");
    }

    public Dictionary<string, int> GetTopPostCount(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        foreach(var creator in records)
        {
            int count = 0;
            foreach(var likes in creator.WeeklyLikes)
            {
                if(likes >= likeThreshold)
                {
                    count++;
                }
            }

            if(count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }
        return result;
    }

    public double CalculateAverageLikes()
    {
        double sum = 0;
        int count = 0;

        foreach(var creator in CreatorStats.EngagementBoard)
        {
            foreach(var likes in creator.WeeklyLikes)
            {
                sum += likes;
                count++;
            }
        }

        if(count == 0)
        {
            return 0;
        }
        return sum/count;
    }

    static void Main()
    {
        Program p = new Program();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    CreatorStats creator = new CreatorStats();
                    Console.Write("Enter Creator Name: ");
                    creator.CreatorName = Console.ReadLine();

                    creator.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for(int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }
                    p.RegisterCreator(creator);
                    break;
                }

                case 2:
                {
                    Console.WriteLine("Enter like threshold: ");
                    double threshold = Convert.ToDouble(Console.ReadLine());
                    var topPosts = p.GetTopPostCount(CreatorStats.EngagementBoard, threshold);

                    if(topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                       foreach(var item in topPosts)
                        {
                           Console.WriteLine(item.Key + " - " + item.Value);     
                        }     
                    }
                    break;
                }

                case 3:
                {
                   double avg = p.CalculateAverageLikes();
                   Console.WriteLine("Overall average weekly likes: " + avg); 
                   break;    
                }

                case 4:
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;    
                }

                default:
                Console.WriteLine("Invalid choice, try again!");
                break;
            }
        }
    }
}