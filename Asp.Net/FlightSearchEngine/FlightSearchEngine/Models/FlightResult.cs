namespace FlightSearchEngine.Models
{
    public class FlightResult
    {
		public int FlightId { get; set; }
		public string FlightName { get; set; }
		public string FlightType { get; set; }
		public string FlightSource { get; set; }
		public string FlightDestination { get; set; }
		public decimal TotalCost { get; set; }
	}
}
