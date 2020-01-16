using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface ITeamService
    {       
        public IEnumerable<TeamStats> GetTeamStats(string id);
        public IEnumerable<TeamStats> GetTeamStatsByYear(int year);
        public IEnumerable<TeamStats> GetTeamStatsByTeam(string team);
    }
}
