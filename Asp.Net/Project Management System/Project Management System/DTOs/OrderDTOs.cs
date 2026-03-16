namespace ProjectManagementSystem.DTOs
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string Status { get; set; } = string.Empty;
	}

	public class CreateOrderDto
	{
		public List<CreateOrderItemDto> Items { get; set; } = new();
	}

	public class CreateOrderItemDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}