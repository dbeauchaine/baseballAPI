using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class TeamService : ITeamService
    {
        private IBaseballDBContext _database;
        private ITeamStatsMapper _mapper;

        public TeamService(IBaseballDBContext database, ITeamStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<TeamStats> GetTeamStats(string id)
        {
            var stats = _database.Teams
                .Where(e => e.TeamId == id)
                .ToList()
                .Select<Teams, TeamStats>(e =>
                 {
                     return _mapper.Map(e);
                 });

            return stats;
        }

        public IEnumerable<TeamStats> GetTeamStatsByYear(int year)
        {
            var query = _database.Teams
                .Where(e => e.YearId == year)
                .ToList()
                .Select<Teams, TeamStats>(e =>
                {
                    return _mapper.Map(e);
                });

            return query;
        }
    }
}