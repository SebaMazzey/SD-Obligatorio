using Departments_Core.Entities;
using Departments_Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Departments_Core.Services.Dto;

namespace Departments_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly ITokenService _tokenService;

        public VoteController(IVoteService voteService, ITokenService tokenService)
        {
            this._voteService = voteService;
            this._tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult Add(Vote vote)
        {
            try
            {
                var hasToken = Request.Headers.TryGetValue("Auth-Token", out var token);
                if (hasToken)
                {
                    _tokenService.VerifyToken(token, vote.Ci);
                    _voteService.AddVote(vote);
                    return Ok("El voto fue emitido con exito");
                }

                return BadRequest("Header=Auth-Token not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Results()
        {
            try
            {
                return Ok("El Cuquito gano!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}