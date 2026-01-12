// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Data.Common;

namespace LINQConsoleApp
{
	class Program
	{
		public static void LinqObjectDemo()
		{
			int[] numArray = { 10, 2, 12, 34, 45, 65, 23, 66, 48, 8, 27 };
			string[] nameArray = { "Alok", "Rajat", "Sumeet", "Priya", "Ayush", "Harshita", "Himanshu", "Mani", "Mani", "Mandabi", "Gaurav", "Yash", "Mahesh", "Teja", "Sai" };

			//foreach(var item in numArray)
			//{
			//	if(item%2 == 0)
			//	{
			//		Console.WriteLine(item);
			//	}
			//}

			// LINQ Query
			var result = from data in numArray //(data-> variable)
						 where data % 2 == 0 && data>20
						 select data;

			foreach(var item in result)
			{
				Console.WriteLine(item);
			}
		}
		static void Main(string[] args)
		{
			LinqObjectDemo();
		}
	}
}
