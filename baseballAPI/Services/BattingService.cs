using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class BattingService : IBattingService
    {
        private IBaseballDBContext _database;
        private IBattingStatsMapper _mapper;

        public BattingService(IBaseballDBContext database, IBattingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<BattingStats> GetBattingStats(string id)
        {
            var stats = _database.Batting
                .Where(e => e.PlayerId == id)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<Batting, BattingStats>(e =>
                 {
                     return _mapper.Map(e);
                 });

            return stats;
        }

        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var query = _database.Batting
                .Include(e => e.Player)
                .Where(e => e.YearId == year && e.Ab > 100)
                .OrderBy(e => e.Player.NameLast)
                .ToList()
                .Select<Batting, BattingStats>(e =>
                {
                    return _mapper.Map(e);
                });

            return query;
        }

        public IEnumerable<BattingPostStats> GetBattingPostStats(string id)
        {
            var stats = _database.BattingPost
                .Where(e => e.PlayerId == id)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<BattingPost, BattingPostStats>(e =>
                {
                    return _mapper.Map(e);
                });

            return stats;
        }

        public IEnumerable<BattingPostStats> GetBattingPostStatsByYear(int year)
        {
            var stats = _database.BattingPost
                .Include(e => e.Player)
                .Where(e => e.YearId == year)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<BattingPost, BattingPostStats>(e =>
                {
                    return _mapper.Map(e);
                });
            return stats;
        }
    }
}