using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Read
{
    public class ReadRideDto
    {
        public ReadCityDto StartCity { get; set; }
        public ReadCityDto DestinationCity { get; set; }
        public ReadDriverDto Driver { get; set; }
        public ReadDriverCarDto Car { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfAvailableSeats { get; set; }
    }
}
