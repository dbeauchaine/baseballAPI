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
            ConvertOptionalParamsToNonNullable(batting, battingStats);

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
            ConvertOptionalParamsToNonNullable(battingPost, battingPostStats);

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

        private void ConvertOptionalParamsToNonNullable(Batting batting, BattingStats battingStats)
        {
            if (batting.G != null)
                battingStats.G = (short)batting.G;
            else
                battingStats.G = 0;

            if (batting.GBatting != null)
                battingStats.GBatting = (short)batting.GBatting;
            else
                battingStats.GBatting = 0;

            if (batting.Ab != null)
                battingStats.Ab = (short)batting.Ab;
            else
                battingStats.Ab = 0;

            if (batting.R != null)
                battingStats.R = (short)batting.R;
            else
                battingStats.R = 0;

            if (batting.H != null)
                battingStats.H = (short)batting.H;
            else
                battingStats.H = 0;

            if (batting.X2b != null)
                battingStats.X2b = (short)batting.X2b;
            else
                battingStats.X2b = 0;

            if (batting.X3b != null)
                battingStats.X3b = (short)batting.X3b;
            else
                battingStats.X3b = 0;

            if (batting.Hr != null)
                battingStats.Hr = (short)batting.Hr;
            else
                battingStats.Hr = 0;

            if (batting.Rbi != null)
                battingStats.Rbi = (short)batting.Rbi;
            else
                battingStats.Rbi = 0;

            if (batting.Sb != null)
                battingStats.Sb = (short)batting.Sb;
            else
                battingStats.Sb = 0;

            if (batting.Cs != null)
                battingStats.Cs = (short)batting.Cs;
            else
                battingStats.Cs = 0;

            if (batting.Bb != null)
                battingStats.Bb = (short)batting.Bb;
            else
                battingStats.Bb = 0;

            if (batting.So != null)
                battingStats.So = (short)batting.So;
            else
                battingStats.So = 0;

            if (batting.Ibb != null)
                battingStats.Ibb = (short)batting.Ibb;
            else
                battingStats.Ibb = 0;

            if (batting.Hbp != null)
                battingStats.Hbp = (short)batting.Hbp;
            else
                battingStats.Hbp = 0;

            if (batting.Sh != null)
                battingStats.Sh = (short)batting.Sh;
            else
                battingStats.Sh = 0;

            if (batting.Sf != null)
                battingStats.Sf = (short)batting.Sf;
            else
                battingStats.Sf = 0;

            if (batting.Gidp != null)
                battingStats.Gidp = (short)batting.Gidp;
            else
                battingStats.Gidp = 0;
        }

        private void ConvertOptionalParamsToNonNullable(BattingPost battingPost, BattingPostStats battingPostStats)
        {
            if (battingPost.G != null)
                battingPostStats.G = (short)battingPost.G;
            else
                battingPostStats.G = 0;

            if (battingPost.Ab != null)
                battingPostStats.Ab = (short)battingPost.Ab;
            else
                battingPostStats.Ab = 0;

            if (battingPost.R != null)
                battingPostStats.R = (short)battingPost.R;
            else
                battingPostStats.R = 0;

            if (battingPost.H != null)
                battingPostStats.H = (short)battingPost.H;
            else
                battingPostStats.H = 0;

            if (battingPost.X2b != null)
                battingPostStats.X2b = (short)battingPost.X2b;
            else
                battingPostStats.X2b = 0;

            if (battingPost.X3b != null)
                battingPostStats.X3b = (short)battingPost.X3b;
            else
                battingPostStats.X3b = 0;

            if (battingPost.Hr != null)
                battingPostStats.Hr = (short)battingPost.Hr;
            else
                battingPostStats.Hr = 0;

            if (battingPost.Rbi != null)
                battingPostStats.Rbi = (short)battingPost.Rbi;
            else
                battingPostStats.Rbi = 0;

            if (battingPost.Sb != null)
                battingPostStats.Sb = (short)battingPost.Sb;
            else
                battingPostStats.Sb = 0;

            if (battingPost.Cs != null)
                battingPostStats.Cs = (short)battingPost.Cs;
            else
                battingPostStats.Cs = 0;

            if (battingPost.Bb != null)
                battingPostStats.Bb = (short)battingPost.Bb;
            else
                battingPostStats.Bb = 0;

            if (battingPost.So != null)
                battingPostStats.So = (short)battingPost.So;
            else
                battingPostStats.So = 0;

            if (battingPost.Ibb != null)
                battingPostStats.Ibb = (short)battingPost.Ibb;
            else
                battingPostStats.Ibb = 0;

            if (battingPost.Hbp != null)
                battingPostStats.Hbp = (short)battingPost.Hbp;
            else
                battingPostStats.Hbp = 0;

            if (battingPost.Sh != null)
                battingPostStats.Sh = (short)battingPost.Sh;
            else
                battingPostStats.Sh = 0;

            if (battingPost.Sf != null)
                battingPostStats.Sf = (short)battingPost.Sf;
            else
                battingPostStats.Sf = 0;

            if (battingPost.Gidp != null)
                battingPostStats.Gidp = (short)battingPost.Gidp;
            else
                battingPostStats.Gidp = 0;
        }

    }

   

}


