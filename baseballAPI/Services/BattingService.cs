using BaseballAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class BattingService : IBattingService
    {
        private IBaseballDBContext _database;

        public BattingService(IBaseballDBContext database)
        {
            _database = database;
        }

        public IEnumerable<Batting> GetBattingStats(string id)
        {
            var stats = _database.Batting
                .Where(s => s.PlayerId == id)
                .ToList();

            return stats;
        }
    }
}