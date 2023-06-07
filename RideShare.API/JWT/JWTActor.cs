using RideShare.Application;
using System.Collections.Generic;

namespace RideShare.API.JWT
{
    public class JWTActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
