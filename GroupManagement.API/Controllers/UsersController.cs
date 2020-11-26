using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupManagement.Contracts;
using GroupManagement.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GroupManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerService _logger;
        private readonly IActionResultService _actionResultService;
        public UsersController(IUserService userService, ILoggerService logger, IActionResultService actionResultService)
        {
            _userService = userService;
            _logger = logger;
            _actionResultService = actionResultService;
        }

        /// <summary>
        /// User Login EndPoint
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            try
            {
                var location = GetControllerActionNames();
                _logger.Info($"{location}: Loggin attempt from user {userDTO.UserName}");
                var result = await _userService.LogIn(userDTO);
                if (result.LoggedIn)
                {
                    _logger.Info($"{location}: {userDTO.UserName} successfully authenticated");
                    return Ok(result);
                }
                _logger.Info($"{location}: {userDTO.UserName} not authenticated");
                return Unauthorized(userDTO);
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
    }
}