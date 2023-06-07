using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}