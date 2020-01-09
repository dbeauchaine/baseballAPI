using BaseballAPI.Helpers;
using System;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsCalculator : IBattingStatsCalculator
    {
        public BattingStats CalculateStats(BattingStats batting)
        {
            var localBatting = batting;

            localBatting.Singles = CalculateSingles(localBatting);

            localBatting.Avg = CalculateAvg(localBatting);

            localBatting.Obp = CalculateObp(localBatting);

            localBatting.Slg = CalculateSlg(localBatting);

            localBatting.Ops = CalculateOps(localBatting);

            return localBatting;
        }

     

        private int CalculateSingles(BattingStats batting)
        {
            return batting.H - (batting.X2b + batting.X3b + batting.Hr);
        }

        private double CalculateAvg(BattingStats batting)
        {
            double avg = SafeDivide.divideDouble((double)batting.H, batting.Ab);
            
            return Math.Round(avg, 3);
        }

        private double CalculateObp(BattingStats batting)
        {
            var numerator = (double)batting.H + batting.Bb + batting.Ibb;
            var denominator = batting.Ab;

            double obp = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(obp, 3);
        }

        private double CalculateSlg(BattingStats batting)
        {
            var numerator = (double)batting.Singles + batting.X2b * 2 + batting.X3b * 3 + batting.Hr * 4;
            var denominator = batting.Ab;

            double slg = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(slg, 3);
        }

        private double CalculateOps(BattingStats batting)
        {
            return Math.Round(batting.Obp + batting.Slg, 3);
        }
    }
}

