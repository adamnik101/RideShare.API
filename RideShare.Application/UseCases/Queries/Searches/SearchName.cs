using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries.Searches
{
    public class SearchName : PagedSearch
    {
        public string Name { get; set; }
    }
}
