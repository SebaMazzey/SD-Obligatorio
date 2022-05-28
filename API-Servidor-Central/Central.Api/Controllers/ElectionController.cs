using System;
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

        [HttpGet]
        public ActionResult<ElectionResults> Results(int id)
        {
            try
            {
                var hasForceUpdate = Request.Headers.TryGetValue("Force-Update-Votes", out var forceUpdate);
                return Ok(hasForceUpdate ? _electionService.GetElectionResults(id, bool.Parse(forceUpdate)) : _electionService.GetElectionResults(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}