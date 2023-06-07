using RideShare.Application.Logging;
using System.Text;
using System;

namespace RideShare.API.ErrorLogging
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Log(AppError error)
        {
            var errorDate = DateTime.UtcNow;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Error code: " + error.ErrorId.ToString());
            builder.AppendLine("User: " + error.Fullname != null ? error.Fullname : "/");
            builder.AppendLine("Error time:" + errorDate.ToLongDateString());
            builder.AppendLine("Ex message:" + error.Exception.Message);
            builder.AppendLine("Ex stack trace:");
            builder.AppendLine(error.Exception.StackTrace);

            Console.WriteLine(builder.ToString());
        }
    }
}
