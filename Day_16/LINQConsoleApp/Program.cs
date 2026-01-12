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
			// int dataToSearch = 12;
			// string dataToSearch = "";
			//Console.WriteLine("Enter name to search: ");
			//string dataToSearch = Console.ReadLine();
			//var result = from data in numArray //(data-> variable)
			//								   // where data % 2 == 0 && data>20 //(EVEN-ODD)
			//								   // where data == 12 //(COMPARISON)
			//								   // where data.Contains("a"); || dataToSearch.Contains("A"); // some library need to add
			//			 where data == dataToSearch //some error
			//			 select data;

			// var result = nameArray.Where(n=>n==dataToSearch);
			
			var result = from data in nameArray
						 // orderby data // gives result in ascending order starts with A to Z
						 orderby data descending // gives result in descending order starts with Z to A
						 select data;

			foreach (var item in result)
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
