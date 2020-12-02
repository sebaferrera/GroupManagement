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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.Info($"{location}: Loggin attempt from user {userDTO.EmailAddress}");
                var result = await _userService.LogIn(userDTO);
                if (result.LoggedIn)
                {
                    _logger.Info($"{location}: {userDTO.EmailAddress} successfully authenticated");
                    return Ok(result);
                }
                _logger.Info($"{location}: {userDTO.EmailAddress} not authenticated");
                return Unauthorized(result);
            }
            catch (Exception e)
            {
                return _actionResultService.InternalError(e);
            }
        }

        /// <summary>
        /// User Registration EndPoint
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.Info($"{location}: Registration attempt from user {userDTO.EmailAddress}");
                if (!ModelState.IsValid)
                {
                    _logger.Warning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var user = await _userService.Register(userDTO);
                if (user.HasRegistrationErrors)
                {
                    foreach (var error in user.RegistrationErrors)
                    {
                        _logger.Error($"{location}: {error}");
                    }
                    return BadRequest(user);
                }

                return Ok(user);
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