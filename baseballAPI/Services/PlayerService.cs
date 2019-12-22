using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private IBaseballDBContext _database;
        private IPlayerMapper _mapper;

        public PlayerService(IBaseballDBContext database, IPlayerMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public IEnumerable<Player> GetPlayerId(string firstName, string lastName)
        {
            var player = _database.People
            .Where(s => s.NameFirst == firstName && s.NameLast == lastName)
            .ToList()
            .Select<People, Player>(s => {
                return _mapper.Map(s);
            });

            return player;
        }

        public Player GetPlayer(string id)
        {
            var person = _database.People
                .FirstOrDefault(s => s.PlayerId == id);
           
            return _mapper.Map(person);
        }
    }
}