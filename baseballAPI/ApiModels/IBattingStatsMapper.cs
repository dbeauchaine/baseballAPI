using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public interface IBattingStatsMapper
    {
        public BattingStats Map(Batting batting);

        public BattingLeaderBoardStats MapYear(Batting batting);
    }
}
