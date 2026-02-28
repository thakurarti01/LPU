using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightSearchEngine.Models
{
    public class SearchViewModel
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int NumberOfPersons { get; set; }

        public IEnumerable<SelectListItem> SourceList { get; set; }
        public IEnumerable<SelectListItem> DestinationList { get; set; }
        
        public List<FlightResult> FlightResults { get; set; }
        public List<FlightHotelResult> FlightHotelResults { get; set; }
    }
}