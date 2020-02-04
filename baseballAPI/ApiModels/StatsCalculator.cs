using BaseballAPI.Helpers;
using System;

namespace BaseballAPI.ApiModels
{
    public class StatsCalculator : IStatsCalculator
    {
        public void CalculateStats(PitchingStats pitchingStats)
        {
            pitchingStats.Era = CalculateEra(pitchingStats.Era);
            pitchingStats.Baopp = CalculateBaopp(pitchingStats.Baopp);
        }

        public void CalculateStats(PitchingPostStats pitchingStats)
        {
            pitchingStats.Era = CalculateEra(pitchingStats.Era);
            pitchingStats.Baopp = CalculateBaopp(pitchingStats.Baopp);
        }
        public void CalculateStats(TeamStats teamStats)
        {
            var calculatorStats = ConvertOptionalParamsToNonNullable(teamStats);

            teamStats.Pa = CalulatePa(calculatorStats.Ab, calculatorStats.Bb, calculatorStats.Hbp, calculatorStats.Sf, calculatorStats.Sh);

            teamStats.Singles = CalculateSingles(calculatorStats.H, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr);

            teamStats.Avg = CalculateAvg(calculatorStats.H, calculatorStats.Ab);

            teamStats.Obp = CalculateObp(calculatorStats.H, calculatorStats.Bb, calculatorStats.Ibb, calculatorStats.Ab);

            teamStats.Slg = CalculateSlg(teamStats.Singles, calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            teamStats.Ops = CalculateOps(teamStats.Obp, teamStats.Slg);

            teamStats.BbRate = CalculateBbRate(calculatorStats.Bb, teamStats.Pa);

            teamStats.KRate = CalculateKRate(calculatorStats.So, teamStats.Pa);

            teamStats.Iso = CalculateIso(calculatorStats.X2b, calculatorStats.X3b, calculatorStats.Hr, calculatorStats.Ab);

            teamStats.Babip = CalculateBabip(calculatorStats.H, calculatorStats.Hr, calculatorStats.Ab, calculatorStats.So, calculatorStats.Sf);
            
            teamStats.Era = CalculateEra(teamStats.Era);
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

        private double? CalculateEra(double? Era)
        {
            double localEra = Era ?? 0;

            return Math.Round(localEra/100, 2);
        }

        private double? CalculateBaopp(double? Baopp)
        {
            double localBaopp = Baopp ?? 0;

            return Math.Round(localBaopp / 100, 2);
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

            calculatorStats.Ab = battingStats.Ab ?? 0;

            calculatorStats.H = battingStats.H ?? 0;

            calculatorStats.X2b = battingStats.X2b ?? 0;

            calculatorStats.X3b = battingStats.X3b ?? 0;

            calculatorStats.Hr = battingStats.Hr ?? 0;

            calculatorStats.Bb = battingStats.Bb ?? 0;

            calculatorStats.So = battingStats.So ?? 0;

            calculatorStats.Hbp = battingStats.Hbp ?? 0;

            calculatorStats.Sf = battingStats.Sf ?? 0;

            calculatorStats.Ibb = battingStats.Ibb ?? 0;

            calculatorStats.Sh = battingStats.Sh ?? 0;

            return calculatorStats;
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(BattingPostStats battingStats)
        {
            var calculatorStats = new CalculatorStats();

            calculatorStats.Ab = battingStats.Ab ?? 0;

            calculatorStats.H = battingStats.H ?? 0;

            calculatorStats.X2b = battingStats.X2b ?? 0;

            calculatorStats.X3b = battingStats.X3b ?? 0;

            calculatorStats.Hr = battingStats.Hr ?? 0;

            calculatorStats.Bb = battingStats.Bb ?? 0;

            calculatorStats.So = battingStats.So ?? 0;

            calculatorStats.Hbp = battingStats.Hbp ?? 0;

            calculatorStats.Sf = battingStats.Sf ?? 0;

            calculatorStats.Ibb = battingStats.Ibb ?? 0;

            calculatorStats.Sh = battingStats.Sh ?? 0;

            return calculatorStats;
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(TeamStats teamStats)
        {
            var calculatorStats = new CalculatorStats();

            calculatorStats.Ab = teamStats.Ab ?? 0;

            calculatorStats.H = teamStats.H ?? 0;

            calculatorStats.X2b = teamStats.X2b ?? 0;

            calculatorStats.X3b = teamStats.X3b ?? 0;

            calculatorStats.Hr = teamStats.Hr ?? 0;

            calculatorStats.Bb = teamStats.Bb ?? 0;

            calculatorStats.So = teamStats.So ?? 0;

            calculatorStats.Hbp = teamStats.Hbp ?? 0;

            calculatorStats.Sf = teamStats.Sf ?? 0;

            calculatorStats.Ibb = 0;
            calculatorStats.Sh = 0;

            return calculatorStats;
        }
    }
}


