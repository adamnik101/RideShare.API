using System.Collections.Generic;

namespace RideShare.Domain.Entities
{
    public class Gender : Entity
    {
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}