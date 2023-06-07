using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.DTOs.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Create
{
    public class EfCreateRideCommand : ICreateRideCommand
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public void Execute(CreateRideDto request)
        {
            throw new NotImplementedException();
        }
    }
}
