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

            if (players == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }

            return players;
        }
        [HttpGet]
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var players = _battingService.GetBattingStatsByYear(year);

            if (players == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return players;
        }
    }
}
