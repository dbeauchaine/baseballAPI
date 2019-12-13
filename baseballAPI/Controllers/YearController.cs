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
    public class YearController : ControllerBase
    {
        private IYearService _yearService;

        public YearController(IYearService yearService)
        {
            _yearService = yearService;
        }

        [HttpGet("{year}")]
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var players = _yearService.GetBattingStatsByYear(year);

            if (players == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return players;
        }
    }
}
