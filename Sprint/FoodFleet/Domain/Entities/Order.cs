using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public int RestaurantId { get; set; }
		public string Status { get; set; }
		public decimal TotalAmount { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
