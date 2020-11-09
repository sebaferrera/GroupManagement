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
    [Route("api/users")]
    public class Users : Controller
    {
        private readonly IUserManagement _userManagement;
        public Users(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userManagement.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userManagement.GetUserById(id));
        }
    }
}
