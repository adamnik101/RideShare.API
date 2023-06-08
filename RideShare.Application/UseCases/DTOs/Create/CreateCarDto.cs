using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Create
{
    public class CreateCarDto
    {
        public int FirstRegistration { get; set; }
        public string LicencePlate { get; set; }   
        public int NumberOfSeats { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }
        //public IEnumerable<int> Restrictions { get; set; }
    }
}
