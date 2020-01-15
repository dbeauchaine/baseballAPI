using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IBattingService
    {       
        public IEnumerable<BattingStats> GetBattingStats(string id);
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year);
        public IEnumerable<BattingPostStats> GetBattingPostStats(string id);
    }
}
