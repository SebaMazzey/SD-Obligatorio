using System;
using System.Collections.Generic;
using Central.Core.Interfaces.Services;
using Central.Core.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Central.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ElectionController : ControllerBase
    {
        private readonly IElectionService _electionService;
        private readonly ILogger<ElectionController> _logger;

        public ElectionController(IElectionService electionService, ILogger<ElectionController> logger)
        {
            _electionService = electionService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Create(Election election)
        {
            try
            {
                this._electionService.CreateElection(election);
                return Ok("New Election created");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ElectionInfo>> GetAll()
        {
            try
            {
                return Ok(this._electionService.GetAllElections());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public ActionResult<ElectionResults> Results(int electionId)
        {
            try
            {
                var hasForceUpdate = Request.Headers.TryGetValue("Force-Update-Votes", out var forceUpdate);
                var electionResults = hasForceUpdate ? 
                    _electionService.GetElectionResults(electionId, bool.Parse(forceUpdate)) : 
                    _electionService.GetElectionResults(electionId);
                return Ok(electionResults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}