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
    public class TeamsController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamsController(ITeamService teamsService)
        {
            _teamService = teamsService;
        }

        [HttpGet("{id}")]
        public IEnumerable<TeamStats> GetTeamStats(string id)
        {
            var players = _teamService.GetTeamStats(id);

            return players;
        }

        [HttpGet("/teams/year/{year}")]
        public IEnumerable<TeamStats> GetTeamStatsByYear(int year)
        {
            var players = _teamService.GetTeamStatsByYear(year);

            return players;
        }
    }
}
