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
        private readonly ILogger<VoteController> _logger;
        private readonly IVoteService _voteService; 

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
                _voteService.AddVote(vote);
                this._voteService.Commit();
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