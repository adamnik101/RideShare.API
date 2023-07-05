using RideShare.Application;
using System.Collections.Generic;

namespace RideShare.API.JWT
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Email => "";

        public string Fullname => "Unauthorized actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 12, 99, 100, 101, 301, 900}; // login, register, search rides
    }
}
