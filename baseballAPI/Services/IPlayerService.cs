using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IPlayerService
    {
        public IEnumerable<People> GetPlayerId(string firstName, string lastName);

        public People GetPlayer(string id);
    }
}
