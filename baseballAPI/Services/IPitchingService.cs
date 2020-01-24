using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IPitchingService
    {       
        public IEnumerable<PitchingStats> GetPitchingStats(string id);
        public IEnumerable<PitchingStats> GetPitchingStatsByYear(int year);
        public IEnumerable<PitchingPostStats> GetPitchingPostStats(string id);
        public IEnumerable<PitchingPostStats> GetPitchingPostStatsByYear(int year);
    }
}
