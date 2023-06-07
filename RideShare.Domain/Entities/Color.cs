using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Color : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}