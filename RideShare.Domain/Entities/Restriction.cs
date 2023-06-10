using System.Collections;
using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Restriction : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<CarRestriction> CarRestrictions { get; set; } = new List<CarRestriction>();
    }
}