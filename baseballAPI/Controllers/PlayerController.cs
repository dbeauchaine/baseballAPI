using System.Net;
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
