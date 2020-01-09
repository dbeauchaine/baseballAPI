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
                .Where(s => s.PlayerId == id)
                .ToList()
                .Select<Batting, BattingStats>(s =>
                 {
                     return _mapper.Map(s);
                 });

            return stats;
        }

        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var query = _database.Batting
                .Include(b => b.Player)
                .Where(b => b.YearId == year)
                .OrderBy(b => b.Player.NameLast)
                .ToList()
                .Select<Batting, BattingStats>(b =>
                {
                    return _mapper.Map(b);
                });


                return query;
        }
    }
}