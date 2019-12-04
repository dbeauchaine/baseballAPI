using BaseballAPI.Models;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private IBaseballDBContext _database;

        public PlayerService(IBaseballDBContext database)
        {
            _database = database;
        }
        public string GetPlayerId(string firstName, string lastName)
        {
            var playerId = _database.People
                .FirstOrDefault(s => s.NameFirst == firstName && s.NameLast == lastName);

            return playerId.PlayerId;
        }

        public People GetPlayer(string id)
        {
            var player = _database.People
                .FirstOrDefault(s => s.PlayerId == id); 

            return player;
        }
    }
}