using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IPitchingService
    {       
        public IEnumerable<PitchingStats> GetPitchingStats(string id);
        public IEnumerable<PitchingLeaderBoardStats> GetPitchingStatsByYear(int year);
    }
}
