using RideShare.Application.UseCases.DTOs;
using RideShare.Application.UseCases.DTOs.Read;
using RideShare.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries
{
    public interface IReadCarsQuery : IQuery<SearchCarDto, PagedResponse<ReadCarDto>>
    {
    }
}
