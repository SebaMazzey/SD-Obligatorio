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

        public VoteController(IVoteService voteService)
        {
            this._voteService = voteService;
        }

        [HttpPost]
        public ActionResult Add(Vote vote)
        {
            try
            {
                _voteService.AddVote(vote);
                return Ok("El voto fue emitido con exito");
            }
            catch (Exception ex)
            {
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