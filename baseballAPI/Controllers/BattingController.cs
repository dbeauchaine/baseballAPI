using System.Collections.Generic;
using System.Net;
using BaseballAPI.Models;
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
        public IEnumerable<Batting> GetBattingStats(string id)
        {
            var players = _battingService.GetBattingStats(id);

            if (players == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }

            return players;
        }
    }
}
