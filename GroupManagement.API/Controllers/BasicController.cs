using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagement.API.Controllers
{
    public class BasicController : ControllerBase
    {
        private readonly ILoggerService _logger;
        public BasicController(ILoggerService logger)
        {
            _logger = logger;
        }

        public ObjectResult InternalError(Exception e)
        {
            return InternalError($"{e.Message} - {e.InnerException}");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}