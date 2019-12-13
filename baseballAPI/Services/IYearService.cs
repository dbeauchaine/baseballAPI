using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IYearService 
    {
        public IEnumerable<BattingStats> GetBattingStatsByYear(int year);
    }
}
