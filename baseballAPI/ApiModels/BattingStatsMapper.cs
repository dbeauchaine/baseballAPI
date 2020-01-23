using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsMapper : IBattingStatsMapper
    {
        private IStatsCalculator _calculator;
        public BattingStatsMapper(IStatsCalculator calculator)
        {
            _calculator = calculator;
        }

        public BattingStats Map(Batting batting)
        {
            var battingStats = new BattingStats()
            {
                PlayerId = batting.PlayerId,
                YearId = batting.YearId,
                Stint = batting.Stint,
                TeamId = batting.TeamId,
                LgId = batting.LgId,
            };

            CopyPlayerDataIfPlayerExists(batting, battingStats);
            CopyNullableStats(batting, battingStats);

            _calculator.CalculateStats(battingStats);

            return battingStats;
        }

        public BattingPostStats Map(BattingPost battingPost)
        {
            var battingPostStats = new BattingPostStats()
            {
                PlayerId = battingPost.PlayerId,
                YearId = battingPost.YearId,
                Round = battingPost.Round,
                TeamId = battingPost.TeamId,
                LgId = battingPost.LgId
            };

            CopyPlayerDataIfPlayerExists(battingPost, battingPostStats);
            CopyNullableStats(battingPost, battingPostStats);

            _calculator.CalculateStats(battingPostStats);

            return battingPostStats;
        }

        private void CopyPlayerDataIfPlayerExists(Batting batting, BattingStats battingStats)
        {
            if(batting.Player != null)
            {
                battingStats.NameFirst = batting.Player.NameFirst;
                battingStats.NameLast = batting.Player.NameLast;
                battingStats.NameGiven = batting.Player.NameGiven;
            }
        }

        private void CopyPlayerDataIfPlayerExists(BattingPost battingPost, BattingPostStats battingPostStats)
        {
            if (battingPost.Player != null)
            {
                battingPostStats.NameFirst = battingPost.Player.NameFirst;
                battingPostStats.NameLast = battingPost.Player.NameLast;
                battingPostStats.NameGiven = battingPost.Player.NameGiven;
            }
        }

        private void CopyNullableStats(Batting batting, BattingStats battingStats)
        {
                battingStats.G = batting.G;
                battingStats.GBatting = batting.GBatting;
                battingStats.Ab = batting.Ab;
                battingStats.R = batting.R;
                battingStats.H = batting.H;
                battingStats.X2b = batting.X2b;
                battingStats.X3b = batting.X3b;
                battingStats.Hr = batting.Hr;
                battingStats.Rbi = batting.Rbi;
                battingStats.Sb = batting.Sb;
                battingStats.Cs = batting.Cs;
                battingStats.Bb = batting.Bb;
                battingStats.So = batting.So;
                battingStats.Ibb = batting.Ibb;
                battingStats.Hbp = batting.Hbp;
                battingStats.Sh = batting.Sh;
                battingStats.Sf = batting.Sf;
                battingStats.Gidp = batting.Gidp;
        }

        private void CopyNullableStats(BattingPost batting, BattingPostStats battingStats)
        {
            battingStats.G = batting.G;
            battingStats.Ab = batting.Ab;
            battingStats.R = batting.R;
            battingStats.H = batting.H;
            battingStats.X2b = batting.X2b;
            battingStats.X3b = batting.X3b;
            battingStats.Hr = batting.Hr;
            battingStats.Rbi = batting.Rbi;
            battingStats.Sb = batting.Sb;
            battingStats.Cs = batting.Cs;
            battingStats.Bb = batting.Bb;
            battingStats.So = batting.So;
            battingStats.Ibb = batting.Ibb;
            battingStats.Hbp = batting.Hbp;
            battingStats.Sh = batting.Sh;
            battingStats.Sf = batting.Sf;
            battingStats.Gidp = batting.Gidp;
        }

    }

   

}


