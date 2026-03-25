namespace ShippingServiceAPI.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public ShipmentStatus Status { get; set; }
        public string FailureReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public Address ShippingAddress { get; set; }
    }

    public enum ShipmentStatus
    {
        Pending,
        Processed,
        Failed
    }

    public class Address
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Shipment Shipment { get; set; }
    }
}