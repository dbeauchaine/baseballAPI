using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class FieldingService : IFieldingService
    {
        private IBaseballDBContext _database;
        private IFieldingStatsMapper _mapper;

        public FieldingService(IBaseballDBContext database, IFieldingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<FieldingStats> GetFieldingStats(string id)
        {
            var stats = _database.Fielding
                .Where(s => s.PlayerId == id)
                .ToList()
                .Select<Fielding,FieldingStats>(stat=> 
                {
                    return _mapper.Map(stat);
                });

            return stats;
        }
    }
}