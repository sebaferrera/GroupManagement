using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using GroupManagement.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        IUserManagement _userManagement;
        public UsersController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {
            return Ok(_userManagement.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser(int id)
        {
            return Ok(_userManagement.GetUserById(id));
        }
    }
}