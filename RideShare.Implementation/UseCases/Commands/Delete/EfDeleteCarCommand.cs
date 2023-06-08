using RideShare.Application.UseCases.Commands.Delete;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Delete
{
    public class EfDeleteCarCommand : IDeleteCarCommand
    {
        private readonly RideshareContext _context;

        public EfDeleteCarCommand(RideshareContext context)
        {
            _context = context;
        }

        public int Id => 800;

        public string Name => "Delete car using Entity Framework";

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
