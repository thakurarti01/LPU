// using System;

// class Desk
// {
//     public static double DesktopPriceCalculation()
//     {

//         // -------- TAKING USER INPUT FOR SPECIFICATIONS -----------

//         Console.Write("Select device(laptop/desktop): ");
//         string device = (Console.ReadLine() ?? "").ToUpper();

//         Console.Write("Enter processor name: ");
//         string? processor = Console.ReadLine();

//         Console.Write("Enter RAM size in gb: ");
//         int ram_size = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter hard disk size in tb: ");
//         int hard_disk_size = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter graphic card size in gb: ");
//         int graphic_card_size = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter monitor size in inch: ");
//         int monitor_size = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter power supply in volt: ");
//         int power_supply = Convert.ToInt32(Console.ReadLine());

//         // CALCULATING PRICE WITHOUT PROCESSOR

//         int price_before_processor = 0;
//         price_before_processor = ((ram_size*200) + (hard_disk_size*1500) + (graphic_card_size*2500) + (power_supply*20) + (monitor_size*250));
//         int price_after_processor = 0;

//         // CHOOSING DEVICE FOR FINAL PRICE CALCULATION

//         if(device == "DESKTOP")
//         {
//             switch (processor)
//             {
//                 case "i3":
//                 price_after_processor = 1500 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 case "i5":
//                 price_after_processor = 3000 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 case "i7":
//                 price_after_processor = 4500 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 default:
//                 Console.WriteLine("Invalid!");
//                 break;
//             }
//         }
//         else if(device == "LAPTOP")
//         {
//             switch (processor)
//             {
//                 case "i3":
//                 price_after_processor = 2500 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 case "i5":
//                 price_after_processor = 5000 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 case "i7":
//                 price_after_processor = 6500 + price_before_processor;
//                 Console.WriteLine("Your desktop price is: " + price_after_processor);
//                 break;

//                 default:
//                 Console.WriteLine("Invalid!");
//                 break;
//             }
//         }
//         else
//         {
//             Console.WriteLine("Invalid Device!");
//         }

//         return;
//     } 
// }