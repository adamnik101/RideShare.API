using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}