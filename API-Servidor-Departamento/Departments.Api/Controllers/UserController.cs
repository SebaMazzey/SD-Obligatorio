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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Verify(string ci)
        {
            try
            {
                var isValid = await _userService.VerifyUser(ci);
                if (isValid)
                {
                    string token = _tokenService.CreateToken(ci);
                    this._tokenService.SaveChanges();
                    return Ok(token);                    
                }

                return Unauthorized("User not able to vote");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}