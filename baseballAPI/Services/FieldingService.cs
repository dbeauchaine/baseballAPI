using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class FieldingService : IFieldingService
    {
        private readonly IBaseballDBContext _database;
        private readonly IFieldingStatsMapper _mapper;

        public FieldingService(IBaseballDBContext database, IFieldingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<FieldingStats> GetFieldingStats(string id)
        {
            return _database.Fielding
                .Where(e => e.PlayerId == id)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<Fielding, FieldingStats>(stat =>
                 {
                     return _mapper.Map(stat);
                 });
        }

        public IEnumerable<FieldingPostStats> GetFieldingPostStats(string id)
        {
            return _database.FieldingPost
                .Where(e => e.PlayerId == id)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<FieldingPost, FieldingPostStats>(stat =>
                {
                    return _mapper.Map(stat);
                });
        }
    }
}