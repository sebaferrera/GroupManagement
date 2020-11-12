using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Contracts
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
