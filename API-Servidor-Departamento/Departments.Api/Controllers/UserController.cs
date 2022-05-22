using Departments_Core.Entities;
using Departments_Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Departments_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        
        public UserController(IUserService userService, ITokenService tokenService, ILogger<UserController> logger)
        {
            this._userService = userService;
            this._tokenService = tokenService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Verify(string ci)
        {
            try
            {
                var isValid = await _userService.VerifyUser(ci);
                if (!isValid) { return Unauthorized("User not able to vote"); }
                
                var token = _tokenService.CreateToken(ci);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to verify user: {}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<int> RemainingVotes()
        {
            try
            {
                var result = this._userService.CountRemainingVotes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}