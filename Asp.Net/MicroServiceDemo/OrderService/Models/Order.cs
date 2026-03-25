using System.ComponentModel.DataAnnotations;
using System.Net;

namespace OrderServiceAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderItem> Items { get; set; }
        public Address ShippingAddress { get; set; }
    }

}
