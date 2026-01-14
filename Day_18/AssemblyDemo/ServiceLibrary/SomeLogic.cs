using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class SomeLogic
    {
		#region Attributes
			int id;
			string name;
			string addr;
		#endregion

		#region Properties 
		//these properties are CLR properties
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Address
		{
			get { return addr; }
			set { addr = value; }
		}
		#endregion

		public SomeLogic()
		{

		}

		public SomeLogic(int yourID, string yourName, string yourAddress)
		{

		}

		#region Methods
		public int AddMe(int num1, int num2) 
		{ 
			return num1 + num2;
		}

		public List<object> ShowAll() 
		{
			return new List<object>();
		}

		public List<Player> ShowAllPlayers()
		{
			return new List<Player>()
			{
				new Player() { PlayerID = 1, PlayerName = "Virat Kohli", Skills = new List<string>{"Batsmen", "Fielder"}},
				new Player() { PlayerID = 1, PlayerName = "Rohit Sharma", Skills = new List<string>{"Batsmen", "Fielder"}},
				new Player() { PlayerID = 1, PlayerName = "Bumraah", Skills = new List<string>{"Fast Bowler", "Fielder"}},

			};
		}
		#endregion
	}
}
