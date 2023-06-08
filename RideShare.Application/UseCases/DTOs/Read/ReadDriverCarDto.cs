using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Read
{
    public class ReadDriverCarDto
    {
        public string LicencePlate { get; set; }
        public int NumberOfSeats { get; set; }
        public string ModelBrand { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int FirstRegistration { get; set; }
        public string ImagePath { get; set; }
    }
}
