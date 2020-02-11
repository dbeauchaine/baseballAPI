using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PitchingService : IPitchingService
    {
        private IBaseballDBContext _database;
        private IPitchingStatsMapper _mapper;

        public PitchingService(IBaseballDBContext database, IPitchingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<PitchingStats> GetPitchingStats(string id)
        {
            var stats = _database.Pitching
                .Where(e => e.PlayerId == id)
                .ToList()
                .Select<Pitching, PitchingStats>(e =>
                 {
                     return _mapper.Map(e);
                 });

            return stats;
        }

        public IEnumerable<PitchingStats> GetPitchingStatsByYear(int year)
        {
            var query = _database.Pitching
                .Include(e => e.Player)
                .Where(e => e.YearId == year && e.Ipouts >= 486)
                .ToList()
                .Select<Pitching, PitchingStats>(e =>
                {
                    return _mapper.Map(e);
                })
                .OrderBy(e => e.Era);

            return query;
        }

        public IEnumerable<PitchingPostStats> GetPitchingPostStats(string id)
        {
            var stats = _database.PitchingPost
                .Where(e => e.PlayerId == id)
                .ToList()
                .Select<PitchingPost, PitchingPostStats>(e =>
                {
                    return _mapper.Map(e);

                });

            return stats;
        }

        public IEnumerable<PitchingPostStats> GetPitchingPostStatsByYear(int year)
        {
            var query = _database.PitchingPost
                .Include(e => e.Player)
                .Where(e => e.YearId == year)
                .ToList()
                .Select<PitchingPost, PitchingPostStats>(e =>
                {
                    return _mapper.Map(e);

                })
                .OrderBy(e => e.Era);

            return query;
        }
    }
}