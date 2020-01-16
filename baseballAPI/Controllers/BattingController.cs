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
            var players = _battingService.GetBattingStats(id);
            return players;
        }

        [HttpGet("/batting/year/{year}")]
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var players = _battingService.GetBattingStatsByYear(year);
            return players;
        }

        [HttpGet("/batting/post/{id}")]
        public IEnumerable<BattingPostStats> GetBattingPostStats(string id)
        {
            var players = _battingService.GetBattingPostStats(id);
            return players;
        }

        [HttpGet("/batting/post/year/{year}")]
        public IEnumerable<BattingPostStats> GetBattingPostStatsByYear(int year)
        {
            var players = _battingService.GetBattingPostStatsByYear(year);
            return players;
        }
    }
}
