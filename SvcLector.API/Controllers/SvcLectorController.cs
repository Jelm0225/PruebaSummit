using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SvcLector.Domain;
using SvcLector.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SvcLector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SvcLectorController : ControllerBase
    {

        private readonly ILogger<SvcLectorController> _logger;

        public SvcLectorController(ILogger<SvcLectorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ApiResponse Get([Required] int numItems, [Required] string itemName, [Required] string sort)
        {
            IGitHubRankingsDomain gitHubRankingsDomain = new GitHubRankingsDomain();

            return gitHubRankingsDomain.GetGitHubRankings(numItems, itemName, sort);
        }

    }
}
