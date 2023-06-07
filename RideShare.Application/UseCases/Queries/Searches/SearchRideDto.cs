using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries.Searches
{
    public class SearchRideDto
    {
        public DateTime? RideDate { get; set; }
        public string DestinationCity { get; set; }
        public string StartCity { get; set; }
    }
}
