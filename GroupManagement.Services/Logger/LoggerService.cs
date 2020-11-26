using GroupManagement.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Services
{
    public class LoggerService : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void Info(string message)
        {
            logger.Info(message);
        }
        public void Warning(string message)
        {
            logger.Warn(message);
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}