using System;
using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Car : Entity
    {
        public int FirstRegistration { get; set; }
        public string LicencePlate { get; set; }
        public int NumberOfSeats { get; set; }

        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public int OwnerId { get; set; }

        public virtual Model Model { get; set; }
        public virtual Color Color { get; set; }
        public virtual Type Type { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();
        public virtual ICollection<CarRestriction> CarRestrictions { get; set; } = new HashSet<CarRestriction>();
    }
}