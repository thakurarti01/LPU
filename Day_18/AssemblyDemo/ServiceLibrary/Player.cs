using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLibrary
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerAddress { get; set; }
		public List<string> Skills { get; set; }
	}
}
