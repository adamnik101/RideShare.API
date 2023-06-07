using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Application.Logging
{
    public interface IErrorLogger
    {
        void Log(AppError error);
    }

    public class AppError
    {
        public Exception Exception { get; set; }
        public string Fullname { get; set; }
        public Guid ErrorId { get; set; }
    }
}
