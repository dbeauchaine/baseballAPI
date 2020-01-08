using System;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsCalculator : IBattingStatsCalculator
    {
        public BattingStats CalculateStats(BattingStats batting)
        {
            batting.Singles = CalculateSingles(batting);

            batting.Avg = CalculateAvg(batting);

            batting.Obp = CalculateObp(batting);

            batting.Slg = CalculateSlg(batting);

            batting.Ops = CalculateOps(batting);

            return batting;
        }

        private int CalculateSingles(BattingStats batting)
        {
            return batting.H - (batting.X2b + batting.X3b + batting.Hr);
        }
        private double CalculateAvg(BattingStats batting)
        {
            if(batting.Ab == 0)
            {
                return 0;
            }

            double avg = (double)batting.H / batting.Ab;
            
            return Math.Round(avg, 3);
        }

        private double CalculateObp(BattingStats batting)
        {
            if (batting.Ab == 0)
            {
                return 0;
            }

            double obp = ((double)batting.H + batting.Bb + batting.Ibb) / batting.Ab;

            return Math.Round(obp, 3);
        }

        private double CalculateSlg(BattingStats batting)
        {
            if(batting.Ab == 0)
            {
                return 0;
            }

            double slg = ((double)batting.Singles + batting.X2b * 2 + batting.X3b * 3 + batting.Hr * 4) / batting.Ab;

            return Math.Round(slg, 3);
        }

        private double CalculateOps(BattingStats batting)
        {
            return batting.Obp + batting.Slg;
        }
    }
}

