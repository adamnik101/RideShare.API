﻿using RideShare.Application.UseCases.DTOs.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries
{
    public interface IFindTypeQuery : IQuery<int, ReadTypeDto>
    {
    }
}
