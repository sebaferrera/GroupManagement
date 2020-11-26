using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Contracts
{
    public interface ILoggerService
    {
        void Info(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
