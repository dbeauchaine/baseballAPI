using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public interface IBattingStatsCalculator
    {
        public BattingStats CalculateStats(BattingStats batting);
    }
}
