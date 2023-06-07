using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries.Searches
{
    public class SearchCarDto
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }    
        public string Type { get; set; }
    }
}
