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
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> GetPlayerId(string firstName, string lastName)
        {
            var players = _playerService.GetPlayerId(firstName, lastName);

            return players;
        }

        [HttpGet("{id}")]
        public Player GetPlayer(string id)
        {
            var player = _playerService.GetPlayer(id);

            return player;
        }
    }
}
