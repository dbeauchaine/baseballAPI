using BaseballAPI.Models;
using System.Collections.Generic;

namespace BaseballAPI.Services
{
    public interface IBattingService
    {       
        public IEnumerable<Batting> GetBattingStats(string id);
    }
}
