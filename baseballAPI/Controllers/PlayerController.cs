using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baseballAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace baseballAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public string GetPlayerId(string firstname, string lastname)
        {
            return _playerService.GetPlayerId();
        }
    }
}
