using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Restaurant
	{
		public int RestaurantId { get; set; }
		public int OwnerId { get; set; }
		public string Name { get; set; }
		public string Cuisine { get; set; }
		public string Address { get; set; }
		public bool IsOpen { get; set; }
	}
}
