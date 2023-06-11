using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Read
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public IEnumerable<ReadCarDto> Cars { get; set; }
        public IEnumerable<ReadRideDto> Rides { get; set; }
    }
}
