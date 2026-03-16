namespace ProjectManagementSystem.Entities
{
	public class Inventory
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }

		public int ReorderPoint { get; set; }

		public DateTime LastRestockedAt { get; set; }

		public Product? Product { get; set; }
	}
}