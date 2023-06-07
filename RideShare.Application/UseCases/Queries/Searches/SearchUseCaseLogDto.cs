﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.Queries.Searches
{
    public class SearchUseCaseLogDto
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string UseCaseName { get; set; }
        public string Fullname { get; set; }
    }
}
