﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Read
{
    public class ReadBrandDto
    {
        public string Name { get; set; }
        public IEnumerable<ReadModelDto> Models { get; set; }
    }
}