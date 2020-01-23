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
        public void CalculateStats(BattingStats batting)
        {
            var calculatorStats = ConvertOptionalParamsToNonNullable(batting);

            batting.Pa = CalulatePa(calculatorStats.Ab, calculatorStats.Bb, calculatorStats.Hbp, calculatorStats.Sf, calculatorStats.Sh);

            batting.Singles = CalculateSingles(calculatorStats.H, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr);

            batting.Avg = CalculateAvg(calculatorStats.H, calculatorStats.Ab);

            batting.Obp = CalculateObp(calculatorStats.H, calculatorStats.Bb, calculatorStats.Ibb, calculatorStats.Ab);

            batting.Slg = CalculateSlg(batting.Singles, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            batting.Ops = CalculateOps(batting.Obp, batting.Slg);

            batting.BbRate = CalculateBbRate(calculatorStats.Bb, batting.Pa);

            batting.KRate = CalculateKRate(calculatorStats.So, batting.Pa);

            batting.Iso = CalculateIso(calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            batting.Babip = CalculateBabip(calculatorStats.H, calculatorStats.Hr, calculatorStats.Ab, calculatorStats.So, calculatorStats.Sf);

        }

        public void CalculateStats(BattingPostStats battingPostStats)
        {
            var calculatorStats = ConvertOptionalParamsToNonNullable(battingPostStats);

            battingPostStats.Pa = CalulatePa(calculatorStats.Ab, calculatorStats.Bb, calculatorStats.Hbp, calculatorStats.Sf, calculatorStats.Sh);

            battingPostStats.Singles = CalculateSingles(calculatorStats.H, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr);

            battingPostStats.Avg = CalculateAvg(calculatorStats.H, calculatorStats.Ab);

            battingPostStats.Obp = CalculateObp(calculatorStats.H, calculatorStats.Bb, calculatorStats.Ibb, calculatorStats.Ab);

            battingPostStats.Slg = CalculateSlg(battingPostStats.Singles, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            battingPostStats.Ops = CalculateOps(battingPostStats.Obp, battingPostStats.Slg);

            battingPostStats.BbRate = CalculateBbRate(calculatorStats.Bb, battingPostStats.Pa);

            battingPostStats.KRate = CalculateKRate(calculatorStats.So, battingPostStats.Pa);

            battingPostStats.Iso = CalculateIso(calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            battingPostStats.Babip = CalculateBabip(calculatorStats.H, calculatorStats.Hr, calculatorStats.Ab, calculatorStats.So, calculatorStats.Sf);
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

        private CalculatorStats ConvertOptionalParamsToNonNullable(BattingStats battingStats)
        {
            var calculatorStats = new CalculatorStats();
    
            if (battingStats.Ab != null)
                calculatorStats.Ab = (short)battingStats.Ab;
            else
                calculatorStats.Ab = 0;

            if (battingStats.H != null)
                calculatorStats.H = (short)battingStats.H;
            else
                calculatorStats.H = 0;

            if (battingStats.X2b != null)
                calculatorStats.X2b = (short)battingStats.X2b;
            else
                calculatorStats.X2b = 0;

            if (battingStats.X3b != null)
                calculatorStats.X3b = (short)battingStats.X3b;
            else
                calculatorStats.X3b = 0;

            if (battingStats.Hr != null)
                calculatorStats.Hr = (short)battingStats.Hr;
            else
                calculatorStats.Hr = 0;


            if (battingStats.Bb != null)
                calculatorStats.Bb = (short)battingStats.Bb;
            else
                calculatorStats.Bb = 0;

            if (battingStats.So != null)
                calculatorStats.So = (short)battingStats.So;
            else
                calculatorStats.So = 0;

            if (battingStats.Ibb != null)
                calculatorStats.Ibb = (short)battingStats.Ibb;
            else
                calculatorStats.Ibb = 0;

            if (battingStats.Hbp != null)
                calculatorStats.Hbp = (short)battingStats.Hbp;
            else
                calculatorStats.Hbp = 0;

            if (battingStats.Sh != null)
                calculatorStats.Sh = (short)battingStats.Sh;
            else
                calculatorStats.Sh = 0;

            if (battingStats.Sf != null)
                calculatorStats.Sf = (short)battingStats.Sf;
            else
                calculatorStats.Sf = 0;

            return calculatorStats;
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(BattingPostStats battingStats)
        {
            var calculatorStats = new CalculatorStats();

            if (battingStats.Ab != null)
                calculatorStats.Ab = (short)battingStats.Ab;
            else
                calculatorStats.Ab = 0;

            if (battingStats.H != null)
                calculatorStats.H = (short)battingStats.H;
            else
                calculatorStats.H = 0;

            if (battingStats.X2b != null)
                calculatorStats.X2b = (short)battingStats.X2b;
            else
                calculatorStats.X2b = 0;

            if (battingStats.X3b != null)
                calculatorStats.X3b = (short)battingStats.X3b;
            else
                calculatorStats.X3b = 0;

            if (battingStats.Hr != null)
                calculatorStats.Hr = (short)battingStats.Hr;
            else
                calculatorStats.Hr = 0;


            if (battingStats.Bb != null)
                calculatorStats.Bb = (short)battingStats.Bb;
            else
                calculatorStats.Bb = 0;

            if (battingStats.So != null)
                calculatorStats.So = (short)battingStats.So;
            else
                calculatorStats.So = 0;

            if (battingStats.Ibb != null)
                calculatorStats.Ibb = (short)battingStats.Ibb;
            else
                calculatorStats.Ibb = 0;

            if (battingStats.Hbp != null)
                calculatorStats.Hbp = (short)battingStats.Hbp;
            else
                calculatorStats.Hbp = 0;

            if (battingStats.Sh != null)
                calculatorStats.Sh = (short)battingStats.Sh;
            else
                calculatorStats.Sh = 0;

            if (battingStats.Sf != null)
                calculatorStats.Sf = (short)battingStats.Sf;
            else
                calculatorStats.Sf = 0;

            return calculatorStats;
        }

    }
}


