using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Ride> StartRides { get; set; } = new HashSet<Ride>();
        public virtual ICollection<Ride> EndRides { get; set; } = new HashSet<Ride>();
    }
}