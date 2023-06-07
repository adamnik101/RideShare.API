using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string name, string entityName) 
            :base($"{entityName} already exists with the name {name}.") 
        {
        
        }
    }
}
