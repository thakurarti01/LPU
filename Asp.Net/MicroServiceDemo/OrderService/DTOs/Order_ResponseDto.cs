namespace OrderServiceAPI.DTOs
{
    public class Order_ResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }
}
