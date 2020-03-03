using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PitchingService : IPitchingService
    {
        private readonly IBaseballDBContext _database;
        private readonly IPitchingStatsMapper _mapper;

        public PitchingService(IBaseballDBContext database, IPitchingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<PitchingStats> GetPitchingStats(string id)
        {
           return _database.Pitching
                .Where(e => e.PlayerId == id)
                .ToList()
                .Select<Pitching, PitchingStats>(e =>
                 {
                     return _mapper.Map(e);
                 });

        }

        public IEnumerable<PitchingStats> GetPitchingStatsByYear(int year)
        {
          return _database.Pitching
                .Include(e => e.Player)
                .Where(e => e.YearId == year && e.Ipouts >= 486)
                .ToList()
                .Select<Pitching, PitchingStats>(e =>
                {
                    return _mapper.Map(e);
                })
                .OrderBy(e => e.Era);
        }

        public IEnumerable<PitchingPostStats> GetPitchingPostStats(string id)
        {
           return _database.PitchingPost
                .Where(e => e.PlayerId == id)
                .ToList()
                .Select<PitchingPost, PitchingPostStats>(e =>
                {
                    return _mapper.Map(e);

                });
        }

        public IEnumerable<PitchingPostStats> GetPitchingPostStatsByYear(int year)
        {
           return _database.PitchingPost
                .Include(e => e.Player)
                .Where(e => e.YearId == year)
                .ToList()
                .Select<PitchingPost, PitchingPostStats>(e =>
                {
                    return _mapper.Map(e);

                })
                .OrderBy(e => e.Era);
        }
    }
}