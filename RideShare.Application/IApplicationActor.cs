using System;
using System.Collections.Generic;

namespace RideShare.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Email { get; }
        string Fullname { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
