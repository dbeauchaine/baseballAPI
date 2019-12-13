using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
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
        public IEnumerable<People> GetPlayerId(string firstName, string lastName)
        {

            var player = _database.People
            .Where(s => s.NameFirst == firstName && s.NameLast == lastName)
            .ToList();

            return player;
        }

        public People GetPlayer(string id)
        {
            var player = _database.People
                .FirstOrDefault(s => s.PlayerId == id);

            return player;
        }
    }
}