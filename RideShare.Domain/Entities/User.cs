using System;
using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<RideRequest> SentRideRequests { get; set; } = new HashSet<RideRequest>();
        public virtual ICollection<RideRequest> ReceivedRideRequests { get; set; } = new HashSet<RideRequest>();
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();

    }
}