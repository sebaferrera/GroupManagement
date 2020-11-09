using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroupManagement.RestAPI.Controllers
{
    [ApiController]
    [Route("api/entities")]
    public class EntitiesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("ASDF");
        }
    }
}
