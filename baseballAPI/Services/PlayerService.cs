using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IBaseballDBContext _database;
        private readonly IPlayerMapper _mapper;

        public PlayerService(IBaseballDBContext database, IPlayerMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public IEnumerable<Player> GetPlayerId(string name)
        {
            if (name == null)
            {
                return new List<Player>();
            }

            var data = _database.People;
            var names = name.Split(null);

           return MatchAllNames(data, names)
            .ToList()
            .Select<People, Player>(s =>
            {
                return _mapper.Map(s);
            });      
        }

        public Player GetPlayer(string id)
        {
            var person = _database.People
                .FirstOrDefault(s => s.PlayerId == id);

            return _mapper.Map(person);
        }


        private IQueryable<People> MatchAllNames(IQueryable<People> source, string[] names)
        {
            var player = WhereNameMatches(source, names[0]);
            IQueryable<People> players;

            if (names.Length > 1)
            {
                players = WhereNameMatches(player, names[1]);

                if (names.Length > 2)
                {
                    for (int i = 2; i < names.Length; i++)
                    {
                        players = WhereNameMatches(players, names[i]);
                    }
                }
                return players;
            }

            else
            {
                return player;
            }
        }

        private IQueryable<People> WhereNameMatches(IQueryable<People> source, string name)
        {
            return source.Where(s => s.NameFirst.StartsWith(name) || s.NameLast.StartsWith(name) || s.NameGiven.StartsWith(name));
        }
    }
}