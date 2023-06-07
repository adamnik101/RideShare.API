using RideShare.Application.UseCases.DTOs.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Commands.Create
{
    public interface ICreateRideCommand : ICommand<CreateRideDto>
    {
    }
}
