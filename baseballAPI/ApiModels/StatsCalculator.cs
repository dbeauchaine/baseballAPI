using BaseballAPI.Helpers;
using System;

namespace BaseballAPI.ApiModels
{
    public class StatsCalculator : IStatsCalculator
    {
        public TeamStats CalculateStats(TeamStats teamStats)
        {
            var copy = teamStats;

            copy.Pa = CalulatePa(copy.Ab, copy.Bb, copy.Hbp, copy.Sf, copy.Sh);

            copy.Singles = CalculateSingles(copy.H, copy.X2b, copy.X3b, copy.Hr);

            copy.Avg = CalculateAvg(copy.H, copy.Ab);

            copy.Obp = CalculateObp(copy.H, copy.Bb, copy.Ibb, copy.Ab);

            copy.Slg = CalculateSlg(copy.Singles, copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Ops = CalculateOps(copy.Obp, copy.Slg);

            copy.BbRate = CalculateBbRate(copy.Bb, copy.Pa);

            copy.KRate = CalculateKRate(copy.So, copy.Pa);

            copy.Iso = CalculateIso(copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Babip = CalculateBabip(copy.H, copy.Hr, copy.Ab, copy.So, copy.Sf);

            return copy;
        }
        public BattingStats CalculateStats(BattingStats batting)
        {
            var copy = batting;

            copy.Pa = CalulatePa(copy.Ab, copy.Bb, copy.Hbp, copy.Sf, copy.Sh);

            copy.Singles = CalculateSingles(copy.H, copy.X2b, copy.X3b, copy.Hr);

            copy.Avg = CalculateAvg(copy.H, copy.Ab);

            copy.Obp = CalculateObp(copy.H, copy.Bb, copy.Ibb, copy.Ab);

            copy.Slg = CalculateSlg(copy.Singles, copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Ops = CalculateOps(copy.Obp, copy.Slg);

            copy.BbRate = CalculateBbRate(copy.Bb, copy.Pa);

            copy.KRate = CalculateKRate(copy.So, copy.Pa);

            copy.Iso = CalculateIso(copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Babip = CalculateBabip(copy.H, copy.Hr, copy.Ab, copy.So, copy.Sf);

            return copy;
        }

        public BattingPostStats CalculateStats(BattingPostStats battingPostStats)
        {
            var copy = battingPostStats;

            copy.Pa = CalulatePa(copy.Ab, copy.Bb, copy.Hbp, copy.Sf, copy.Sh);

            copy.Singles = CalculateSingles(copy.H, copy.X2b, copy.X3b, copy.Hr);

            copy.Avg = CalculateAvg(copy.H, copy.Ab);

            copy.Obp = CalculateObp(copy.H, copy.Bb, copy.Ibb, copy.Ab);

            copy.Slg = CalculateSlg(copy.Singles, copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Ops = CalculateOps(copy.Obp, copy.Slg);

            copy.BbRate = CalculateBbRate(copy.Bb, copy.Pa);

            copy.KRate = CalculateKRate(copy.So, copy.Pa);

            copy.Iso = CalculateIso(copy.X2b, copy.X3b, copy.Hr, copy.Ab);

            copy.Babip = CalculateBabip(copy.H, copy.Hr, copy.Ab, copy.So, copy.Sf);

            return copy;
        }

        //BABIP - Batting Average On Balls In Play (http://www.fangraphs.com/library/offense/babip/)
        private double CalculateBabip(short H, short Hr, short Ab, short So, short Sf)
        {
            var numerator = (double)H - Hr;
            var denominator = Ab - So - Hr + Sf;

            double babip = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(babip, 3);
        }

        //ISO - Isolated Power (http://www.fangraphs.com/library/offense/iso/)
        private double CalculateIso(short X2b, short X3b, short Hr, short Ab)
        {
            var numerator = (double)X2b + (2 * X3b) + (3 * Hr);
            var denominator = Ab;

            double iso = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(iso, 3);
        }

        //K% - Strikeout Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateKRate(short So, int Pa)
        {
            var numerator = (double)So;
            var denominator = Pa;

            double kRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(kRate, 3);
        }

        //BB% - Walk Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateBbRate(short Bb, int Pa)
        {
            var numerator = (double)Bb;
            var denominator = Pa;
            double bbRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(bbRate, 3);
        }

        //Pa - Plate Appearances
        private int CalulatePa(short Ab, short Bb, short Hbp, short Sf, short Sh)
        {
            return Ab + Bb + Hbp + Sf + Sh;
        }

        //S - Singles
        private int CalculateSingles(short H, short X2b, short X3b, short Hr)
        {
            return H - (X2b + X3b + Hr);
        }

        //AVG - Batting Average
        private double CalculateAvg(short H, short Ab)
        {
            double avg = SafeDivide.divideDouble((double)H, Ab);

            return Math.Round(avg, 3);
        }

        //OBP - On Base Percentage (http://www.fangraphs.com/library/offense/obp/)
        private double CalculateObp(short H, short Bb, short Ibb, short Ab)
        {
            var numerator = (double)H + Bb + Ibb;
            var denominator = Ab;

            double obp = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(obp, 3);
        }

        //SLG - Slugging Percentage
        private double CalculateSlg(int Singles, short X2b, short X3b, short Hr, short Ab)
        {
            var numerator = (double)Singles + X2b * 2 + X3b * 3 + Hr * 4;
            var denominator = Ab;

            double slg = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(slg, 3);
        }

        //OPS - On Base + Slugging (http://www.fangraphs.com/library/offense/ops/)
        private double CalculateOps(double Obp, double Slg)
        {
            return Math.Round(Obp + Slg, 3);
        }
    }
}

