using System;
using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Ride : Entity
    {
        public DateTime StartDate { get; set; }
        public int StartCityId { get; set; }
        public int EndCityId { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public virtual City StartCity { get; set; }
        public virtual City EndCity { get; set; }
        public virtual User Driver { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<RideRequest> RideRequests { get; set; } = new HashSet<RideRequest>();
    }
}