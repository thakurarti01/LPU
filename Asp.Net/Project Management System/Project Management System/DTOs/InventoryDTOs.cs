namespace ProjectManagementSystem.DTOs
{
	public class InventoryDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public int ReorderPoint { get; set; }
		public DateTime LastRestockedAt { get; set; }
	}

	public class UpdateInventoryDto
	{
		public int Quantity { get; set; }
		public int ReorderPoint { get; set; }
	}
}