using System.Collections.Generic;
using System.Linq;
using System.Net;
using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseballAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamsService)
        {
            _teamService = teamsService;
        }

        [HttpGet("{id}")]
        public IEnumerable<TeamStats> GetTeamStats(string teamId)
        {
            var players = _teamService.GetTeamStats(teamId);

            return players;
        }

        [HttpGet("team/year/{year}")]
        public IEnumerable<TeamStats> GetTeamStatsByYear(int year)
        {
            var players = _teamService.GetTeamStatsByYear(year);

            return players;
        }

    }
}
