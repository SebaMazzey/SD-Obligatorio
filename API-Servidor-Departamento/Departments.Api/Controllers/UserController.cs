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

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> Verify(string ci)
        {
            try
            {
                var result = await _userService.VerifyUser(ci);
                return Ok(result);
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