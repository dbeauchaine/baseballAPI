using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerId(string name);

        public Player GetPlayer(string id);
    }
}
