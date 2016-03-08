using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement.Services
{
    public interface ILogService
    {
        void LogError(string message, Exception ex);
    }
}
