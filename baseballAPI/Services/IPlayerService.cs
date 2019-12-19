using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> GetPlayerId(string firstName, string lastName);

        public Player GetPlayer(string id);
    }
}
