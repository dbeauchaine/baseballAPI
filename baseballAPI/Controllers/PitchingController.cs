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
    public class PitchingController : ControllerBase
    {
        private IPitchingService _pitchingService;

        public PitchingController(IPitchingService pitchingService)
        {
            _pitchingService = pitchingService;
        }

        [HttpGet("{id}")]
        public IEnumerable<PitchingStats> GetPitchingStats(string id)
        {
            var players = _pitchingService.GetPitchingStats(id);

            return players;
        }

        [HttpGet("/pitching/year/{year}")]
        public IEnumerable<PitchingStats> GetPitchingStatsByYear(int year)
        {
            var players = _pitchingService.GetPitchingStatsByYear(year);

            return players;
        }
    }
}
