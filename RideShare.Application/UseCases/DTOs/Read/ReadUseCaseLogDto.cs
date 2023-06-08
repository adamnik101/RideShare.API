using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.UseCases.DTOs.Read
{
    public class ReadUseCaseLogDto
    {
        public int Id { get; set; }
        public string UseCaseName { get; set; }
        public object Data { get; set; }
        public DateTime ExecutedAt { get; set; }
        public int UserId { get; set; }

    }
}
