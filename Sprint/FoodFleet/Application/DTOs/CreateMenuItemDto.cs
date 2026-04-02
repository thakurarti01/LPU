using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
	public class CreateMenuItemDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int RestaurantId { get; set; }
	}
}
