using BaseballAPI.Helpers;
using System;

namespace BaseballAPI.ApiModels
{
    public class BattingStatsCalculator : IBattingStatsCalculator
    {
        public BattingStats CalculateStats(BattingStats batting)
        {
            var localBatting = batting;

            localBatting.Pa = CalulatePa(localBatting);

            localBatting.Singles = CalculateSingles(localBatting);

            localBatting.Avg = CalculateAvg(localBatting);

            localBatting.Obp = CalculateObp(localBatting);

            localBatting.Slg = CalculateSlg(localBatting);

            localBatting.Ops = CalculateOps(localBatting);

            localBatting.BbRate = CalculateBbRate(localBatting);

            localBatting.KRate = CalculateKRate(localBatting);

            localBatting.Iso = CalculateIso(localBatting);

            localBatting.Babip = CalculateBabip(localBatting);

            return localBatting;
        }

        //BABIP - Batting Average On Balls In Play (http://www.fangraphs.com/library/offense/babip/)
        private double CalculateBabip(BattingStats batting)
        {
            var numerator = (double)batting.H - batting.Hr;
            var denominator = batting.Ab - batting.So - batting.Hr + batting.Sf;

            double babip = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(babip, 3);
        }

        //ISO - Isolated Power (http://www.fangraphs.com/library/offense/iso/)
        private double CalculateIso(BattingStats batting)
        {
            var numerator = (double)batting.X2b + (2 * batting.X3b) + (3 * batting.Hr);
            var denominator = (double)batting.Ab;

            double iso = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(iso, 3);
        }

        //K% - Strikeout Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateKRate(BattingStats batting)
        {
            var numerator = (double)batting.So;
            var denominator = batting.Pa;

            double kRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(kRate, 3);
        }

        //BB% - Walk Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateBbRate(BattingStats batting)
        {
            var numerator = (double)batting.Bb;
            var denominator = batting.Pa;
            double bbRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(bbRate, 3);
        }

        //Pa - Plate Appearances
        private int CalulatePa(BattingStats batting)
        {
            return batting.Ab + batting.Bb + batting.Hbp + batting.Sf + batting.Sh;
        }

        //S - Singles
        private int CalculateSingles(BattingStats batting)
        {
            return batting.H - (batting.X2b + batting.X3b + batting.Hr);
        }

        //AVG - Batting Average
        private double CalculateAvg(BattingStats batting)
        {
            double avg = SafeDivide.divideDouble((double)batting.H, batting.Ab);

            return Math.Round(avg, 3);
        }

        //OBP - On Base Percentage (http://www.fangraphs.com/library/offense/obp/)
        private double CalculateObp(BattingStats batting)
        {
            var numerator = (double)batting.H + batting.Bb + batting.Ibb;
            var denominator = batting.Ab;

            double obp = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(obp, 3);
        }

        //SLG - Slugging Percentage
        private double CalculateSlg(BattingStats batting)
        {
            var numerator = (double)batting.Singles + batting.X2b * 2 + batting.X3b * 3 + batting.Hr * 4;
            var denominator = batting.Ab;

            double slg = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(slg, 3);
        }

        //OPS - On Base + Slugging (http://www.fangraphs.com/library/offense/ops/)
        private double CalculateOps(BattingStats batting)
        {
            return Math.Round(batting.Obp + batting.Slg, 3);
        }
    }
}

