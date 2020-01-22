using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface ITeamService
    {       
        public IEnumerable<TeamStats> GetTeamStatsByYear(int year);
        public IEnumerable<TeamStats> GetTeamStats(string team);
    }
}
