namespace OrderServiceAPI.DTOs
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }  
}