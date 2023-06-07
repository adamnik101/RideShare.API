using Newtonsoft.Json;
using RideShare.Application.Logging;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly RideshareContext _context;

        public EfUseCaseLogger(RideshareContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new LogEntry
            {
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                ActorId = entry.ActorId,
                UseCaseName = entry.UseCaseName
            });

            _context.SaveChanges();
        }
    }
}
