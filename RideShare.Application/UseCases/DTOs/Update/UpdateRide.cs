using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Update
{
    public class UpdateRide
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public int? StartCityId { get; set; }
        public int? EndCityId { get; set; }
        public int? CarId { get; set; }
        public decimal? Price { get; set; }
    }
}
