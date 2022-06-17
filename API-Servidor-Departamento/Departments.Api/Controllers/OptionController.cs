using Departments_Core.Entities;
using Departments_Core.Interfaces.Services;
using Departments_Core.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Departments_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OptionController : ControllerBase
    {
        private readonly ILogger<OptionController> _logger;
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService, ILogger<OptionController> logger)
        {
            this._optionService = optionService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Option>> Options()
        {
            try
            {
                var results = _optionService.VotingOptions();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to get voting options: {}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}