using GroupManagement.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Services
{
    public class ActionResultService : ControllerBase, IActionResultService
    {
        private readonly ILoggerService _logger;
        public ActionResultService(ILoggerService logger)
        {
            _logger = logger;
        }

        public ObjectResult InternalError(Exception e)
        {
            var message = $"{e.Message} - {e.InnerException}";
            return InternalError(message);
        }

        public ObjectResult InternalError(string message)
        {
            _logger.Error(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }

    }
}
