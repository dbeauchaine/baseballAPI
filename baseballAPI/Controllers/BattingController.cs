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
    public class BattingController : ControllerBase
    {
        private IBattingService _battingService;

        public BattingController(IBattingService battingService)
        {
            _battingService = battingService;
        }

        [HttpGet("{id}")]
        public IEnumerable<BattingStats> GetBattingStats(string id)
        {
            return _battingService.GetBattingStats(id);
        }

        [HttpGet("/batting/year/{year}")]
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            return _battingService.GetBattingStatsByYear(year);
        }
    
        [HttpGet("/batting/post/{id}")]
        public IEnumerable<BattingPostStats> GetBattingPostStats(string id)
        {
            return _battingService.GetBattingPostStats(id);
        }

        [HttpGet("/batting/post/year/{year}")]
        public IEnumerable<BattingPostStats> GetBattingPostStatsByYear(int year)
        {
            return _battingService.GetBattingPostStatsByYear(year);
        }

        [HttpGet("/batting/team/{year}/{team}")]
        public IEnumerable<BattingStats> GetBattingStatsByTeam(string team, int year)
        {
            return _battingService.GetBattingStatsByTeam(team, year);
        }

    }
}
