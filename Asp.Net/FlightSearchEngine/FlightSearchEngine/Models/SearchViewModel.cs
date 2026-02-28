using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
		[Required]
		public string Source { get; set; }

		[Required]
		public string Destination { get; set; }

		[Range(1, 100)]
		public int NumberOfPersons { get; set; }

		public List<FlightResult> FlightResults { get; set; }
		public List<FlightHotelResult> FlightHotelResults { get; set; }
	}
}
