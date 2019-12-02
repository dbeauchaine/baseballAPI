using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BaseballAPI.Models;
using BaseballAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaseballAPI.Controllers
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
        public string GetPlayerId(string firstName, string lastName)
        {
            return _playerService.GetPlayerId(firstName, lastName);
        }

        [HttpGet("{id}")]
        public People GetPlayer(string id)
        {
            var player = _playerService.GetPlayer(id);

            if (player == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }

            return player;
        }
    }
}
