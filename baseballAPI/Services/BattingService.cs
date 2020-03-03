using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class BattingService : IBattingService
    {
        private readonly IBaseballDBContext _database;
        private readonly IBattingStatsMapper _mapper;

        public BattingService(IBaseballDBContext database, IBattingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<BattingStats> GetBattingStats(string id)
        {
            return _database.Batting
                  .Where(e => e.PlayerId == id)
                  .OrderByDescending(e => e.YearId)
                  .ToList()
                  .Select(e =>
                   {
                       return _mapper.Map(e);
                   });
        }

        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            return _database.Batting
                 .Include(e => e.Player)
                 .Where(e => e.YearId == year && e.Ab > 100)
                 .ToList()
                 .Select(e =>
                 {
                     return _mapper.Map(e);
                 })
                 .OrderByDescending(e => e.Avg);
        }

        public IEnumerable<BattingPostStats> GetBattingPostStats(string id)
        {
            return _database.BattingPost
                  .Where(e => e.PlayerId == id)
                  .OrderByDescending(e => e.YearId)
                  .ToList()
                  .Select(e =>
                  {
                      return _mapper.Map(e);
                  });

        }

        public IEnumerable<BattingPostStats> GetBattingPostStatsByYear(int year)
        {
            return _database.BattingPost
                .Include(e => e.Player)
                .Where(e => e.YearId == year)
                .ToList()
                .Select(e =>
                {
                    return _mapper.Map(e);
                })
                .OrderByDescending(e => e.Avg);
        }

        public IEnumerable<BattingStats> GetBattingStatsByTeam(string team, int year)
        {
            return _database.Batting
                .Include(e => e.Player)
                .Where(e => e.TeamId == team && e.YearId == year)
                .ToList()
                .Select(e =>
               {
                   return _mapper.Map(e);
               });
        }
    }
}