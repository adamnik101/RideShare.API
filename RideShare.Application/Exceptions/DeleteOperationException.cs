using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.Exceptions
{
    public class DeleteOperationException : Exception
    {
        public DeleteOperationException(string message)
            : base(message)
        { }
    }
}
