using Departments_Core.Entities;
using Departments_Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Departments_Core.Services.Dto;

namespace Departments_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly ILogger<VoteController> _logger;

        public VoteController(IVoteService voteService, ILogger<VoteController> logger)
        {
            this._voteService = voteService;
            this._logger = logger;
        }

        [HttpPost]
        public ActionResult Add(Vote vote)
        {
            try
            {
                var hasToken = Request.Headers.TryGetValue("Auth-Token", out var token);
                if (!hasToken) { return BadRequest("Header='Auth-Token' not found"); }
                
                _voteService.AddVote(token, vote); 
                _logger.LogInformation("New vote submitted"); 
                return Ok("Vote successfully submitted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to submit vote: {}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Results()
        {
            try
            {
                var results = this._voteService.GetResults();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}