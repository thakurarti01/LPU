// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;
namespace UILogic
{
	class Program
	{
		public static void Main(string[] args)
		{
			int num1;
			int num2;

			Console.Write("Enter 1st number:");
			num1 = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter 2nd number:");
			num2 = Convert.ToInt32(Console.ReadLine());

			SomeLogic logic = new SomeLogic();
			int numResult = logic.AddMe(num1, num2);
			Console.WriteLine($"The sum of {num1} and {num2} is {numResult}");
			Console.ReadLine();


		}
	}
}