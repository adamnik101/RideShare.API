using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Create
{
    public class CreateModelDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
