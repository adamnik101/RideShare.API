using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Update
{
    public class UpdateModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int? BrandId { get; set; }
    }
}
