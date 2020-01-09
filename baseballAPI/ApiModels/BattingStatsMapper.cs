using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsMapper : IBattingStatsMapper
    {
        private IBattingStatsCalculator _calculator;
        public BattingStatsMapper(IBattingStatsCalculator calculator)
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

        private void CopyPlayerDataIfPlayerExists(Batting batting, BattingStats battingStats)
        {
            if(batting.Player != null)
            {
                battingStats.NameFirst = batting.Player.NameFirst;
                battingStats.NameLast = batting.Player.NameLast;
                battingStats.NameGiven = batting.Player.NameGiven;
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

    }
}

