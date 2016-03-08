using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement.Services
{
    public class ConsoleLogService : ILogService
    {
        public void LogError(string message, Exception ex)
        {
            Console.WriteLine("{0} {1}", message, ex);
        }
    }
}
