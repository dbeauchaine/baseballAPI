using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class YearService : IYearService
    {
        private IBaseballDBContext _database;
        private IBattingStatsMapper _mapper;

        public YearService(IBaseballDBContext database, IBattingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year)
        {
            var stats = _database.Batting
                .Where(s => s.YearId == year)
                .ToList()
                .Select<Batting, BattingStats>(stat =>
                {
                    return _mapper.Map(stat);
                });

            return stats;
        }
    }
}