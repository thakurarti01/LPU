using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Entities
{
	public class Order
	{
		public int Id { get; set; }

		public string OrderNumber { get; set; } = string.Empty;

		public DateTime OrderDate { get; set; }

		public decimal TotalAmount { get; set; }

		public string Status { get; set; } = string.Empty;

		public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
	}
}