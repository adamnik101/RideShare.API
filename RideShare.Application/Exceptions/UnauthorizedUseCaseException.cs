using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(string fullname, string useCaseName)
            :base($"There was an unauthorized access attempt by {fullname} for {useCaseName} usecase.")
        { }
    }
}
