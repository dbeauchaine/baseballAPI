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
    public class FieldingController : ControllerBase
    {
        private IFieldingService _fieldingService;

        public FieldingController(IFieldingService fieldingService)
        {
            _fieldingService = fieldingService;
        }

        [HttpGet("{id}")]
        public IEnumerable<FieldingStats> GetFieldingStats(string id)
        {
            var players = _fieldingService.GetFieldingStats(id);

            return players;
        }
    }
}
