using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries.Searches
{
    public class SearchRideDto : PagedSearch
    {
        public DateTime RideDate { get; set; }
        public int DestinationCity { get; set; }
        public int StartCity { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}
