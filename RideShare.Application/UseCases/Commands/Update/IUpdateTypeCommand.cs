using RideShare.Application.UseCases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Commands.Update
{
    public interface IUpdateTypeCommand : ICommand<UpdateNameDto>
    {
    }
}
