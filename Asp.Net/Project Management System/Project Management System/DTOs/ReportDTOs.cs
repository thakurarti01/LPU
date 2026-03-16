namespace ProjectManagementSystem.DTOs
{
	public class SalesReportDto
	{
		public string ProductName { get; set; } = string.Empty;
		public int TotalSold { get; set; }
		public decimal TotalRevenue { get; set; }
	}

	public class InventoryReportDto
	{
		public string ProductName { get; set; } = string.Empty;
		public int Quantity { get; set; }
		public bool NeedsRestock { get; set; }
	}
}