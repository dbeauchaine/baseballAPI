using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsCalculator : IBattingStatsCalculator
    {
        public BattingStats CalculateStats(BattingStats batting)
        {
            batting.Avg = CalculateAvg(batting);

            return batting;
        }

        private double CalculateAvg(BattingStats batting)
        {
            if(batting.Ab == 0)
            {
                return 0;
            }

            double avg = batting.H / batting.Ab;
            avg = Math.Round(avg, 4);

            return avg;
        }
    }
}

