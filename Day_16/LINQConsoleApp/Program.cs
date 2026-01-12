// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Data.Common;

namespace LINQConsoleApp
{
	class Program
	{
		//public static void LinqObjectDemo()
		//{
		//	int[] numArray = { 10, 2, 12, 34, 45, 65, 23, 66, 48, 8, 27 };
		//	string[] nameArray = { "Alok", "Rajat", "Sumeet", "Priya", "Ayush", "Harshita", "Himanshu", "Mani", "Mani", "Mandabi", "Gaurav", "Yash", "Mahesh", "Teja", "Sai" };

		//	//foreach(var item in numArray)
		//	//{
		//	//	if(item%2 == 0)
		//	//	{
		//	//		Console.WriteLine(item);
		//	//	}
		//	//}

		//	// LINQ Query
		//	// int dataToSearch = 12;
		//	// string dataToSearch = "";
		//	//Console.WriteLine("Enter name to search: ");
		//	//string dataToSearch = Console.ReadLine();
		//	//var result = from data in numArray //(data-> variable)
		//	//								   // where data % 2 == 0 && data>20 //(EVEN-ODD)
		//	//								   // where data == 12 //(COMPARISON)
		//	//								   // where data.Contains("a"); || dataToSearch.Contains("A"); // some library need to add
		//	//			 where data == dataToSearch //some error
		//	//			 select data;

		//	// var result = nameArray.Where(n=>n==dataToSearch);
			
		//	var result = from data in nameArray
		//				 // orderby data // gives result in ascending order starts with A to Z
		//				 orderby data descending // gives result in descending order starts with Z to A
		//				 select data;

		//	foreach (var item in result)
		//	{
		//		Console.WriteLine(item);
		//	}
		//}
		//static void Main(string[] args)
		//{
		//	LinqObjectDemo();
		//}


		public static void LinqToObjectDemoOnCustomType()
		{
			List<Customer> custList = new List<Customer>()
			{
				new Customer{ CustomerId=101, Name="Alok", City="Pune"}, //without () will alo work
				new Customer(){ CustomerId=102, Name="Rajat", City="Mumbai"},
				new Customer{ CustomerId=103, Name="Sumeet", City="Pune"},
				new Customer{ CustomerId=104, Name="Priya", City="Delhi"},
				new Customer{ CustomerId=105, Name="Ayush", City="Mumbai"},
				new Customer{ CustomerId=106, Name="Smita", City="Agra"},
				new Customer{ CustomerId=107, Name="Navneen", City="Mumbai"},
				new Customer{ CustomerId=108, Name="Aliya", City="Pune"},
			};
			//annonymous object
			var data = new { OrderID = 1100, OrderDate = "12/10/2025", TotalAmount = 14000 };

			var result = custList.Where(cust => cust.City == "Mumbai");
			var result1 = custList.FindAll(cust => cust.City == "Delhi");

			//foreach(var item in result)
			//{
			//	Console.WriteLine($"{item.CustomerId}\t {item.Name}\t{item.City}");
			//}

			foreach (var item in result1) //does not work with "Find" bit will work with "FindAll" [for non primary use WHERE and FINDALL, for primary use FIND
			{
				Console.WriteLine($"{item.CustomerId}\t {item.Name}\t{item.City}");
			}


		}

		//IMPORTANT

		//public static void LambdaLookup()
		//{
		//	int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		//	var query = numbers.ToLookup(i => i % 2);
		//	foreach (IGrouping<int, int> group in query)
		//	{
		//		Console.WriteLine("Key: {0}", group.Key);
		//	}
		//}

		public static void LambdaLookupStudentList()
		{
			StudentRepo sRepo = new StudentRepo();
			List<Student> tempList = sRepo.GetAllStudents();

			var query = tempList.ToLookup(s => s.Gender == "Male");

			foreach(IGrouping<bool, Student> group in query)
			{
				int totFees = 0;
				//Console.WriteLine("Key: {0}", group.Key);
				if(group.Key == true)
				{
					Console.WriteLine("Make students details below");
				}
				else
				{
					Console.WriteLine("Female student details below");
				}
					foreach (Student std in group)
					{
						Console.WriteLine($"\t{std.Name}");
					totFees += std.Fees;
					}
				Console.WriteLine("Total fees paid : " + totFees);
			}

		//	var maleFeesPaid = tempList.ToLookup(s => s.Gender == "Male").Sum();
		}

		static void Main()
		{
			//LinqToObjectDemoOnCustomType();
			LambdaLookupStudentList();
		}
	}
}
