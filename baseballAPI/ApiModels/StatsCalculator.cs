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

            teamStats.Pa = calculatorStats.Pa;

            teamStats.Singles = calculatorStats.Singles;

            teamStats.Obp = calculatorStats.Obp;

            teamStats.Slg = calculatorStats.Slg;

            teamStats.BbRate = calculatorStats.BbRate;

            teamStats.KRate = calculatorStats.KRate;

            teamStats.Avg = CalculateAvg(calculatorStats);

            teamStats.Ops = CalculateOps(calculatorStats);

            teamStats.Iso = CalculateIso(calculatorStats);

            teamStats.Babip = CalculateBabip(calculatorStats);

        }
        public void CalculateStats(BattingStats batting)
        {
            var calculatorStats = ConvertOptionalParamsToNonNullable(batting);

            batting.Pa = calculatorStats.Pa;

            batting.Singles = calculatorStats.Singles;

            batting.Obp = calculatorStats.Obp;

            batting.Slg = calculatorStats.Slg;

            batting.BbRate = calculatorStats.BbRate;

            batting.KRate = calculatorStats.KRate;

            batting.Avg = CalculateAvg(calculatorStats);

            batting.Ops = CalculateOps(calculatorStats);

            batting.Iso = CalculateIso(calculatorStats);

            batting.Babip = CalculateBabip(calculatorStats);
        }

        public void CalculateStats(BattingPostStats battingPostStats)
        {
            var calculatorStats = ConvertOptionalParamsToNonNullable(battingPostStats);

            battingPostStats.Pa = calculatorStats.Pa;

            battingPostStats.Singles = calculatorStats.Singles;

            battingPostStats.Obp = calculatorStats.Obp;

            battingPostStats.Slg = calculatorStats.Slg;

            battingPostStats.BbRate = calculatorStats.BbRate;

            battingPostStats.KRate = calculatorStats.KRate;

            battingPostStats.Avg = CalculateAvg(calculatorStats);

            battingPostStats.Ops = CalculateOps(calculatorStats);

            battingPostStats.Iso = CalculateIso(calculatorStats);

            battingPostStats.Babip = CalculateBabip(calculatorStats);
        }

        private double CalculateEra(double? era)
        {
            var localEra = era ?? 0;

            return Math.Round(localEra / 100, 2);
        }

        private double? CalculateBaopp(double? Baopp)
        {
            double localBaopp = Baopp ?? 0;

            return Math.Round(localBaopp / 100, 2);
        }
        //BABIP - Batting Average On Balls In Play (http://www.fangraphs.com/library/offense/babip/)
        private double CalculateBabip(CalculatorStats stats)
        {
            var numerator = (double)stats.H - stats.Hr;
            var denominator = stats.Ab - stats.So - stats.Hr + stats.Sf;

            double babip = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(babip, 3);
        }

        //ISO - Isolated Power (http://www.fangraphs.com/library/offense/iso/)
        private double CalculateIso(CalculatorStats stats)
        {
            var numerator = (double)stats.X2b + (2 * stats.X3b) + (3 * stats.Hr);
            var denominator = stats.Ab;

            double iso = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(iso, 3);
        }

        //K% - Strikeout Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateKRate(CalculatorStats stats)
        {
            var numerator = (double)stats.So;
            var denominator = stats.Pa;

            double kRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(kRate, 3);
        }

        //BB% - Walk Percentage (http://www.fangraphs.com/library/offense/rate-stats/)
        private double CalculateBbRate(CalculatorStats stats)
        {
            var numerator = (double)stats.Bb;
            var denominator = stats.Pa;
            double bbRate = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(bbRate, 3);
        }

        //Pa - Plate Appearances
        private int CalulatePa(CalculatorStats stats)
        {
            return stats.Ab + stats.Bb + stats.Hbp + stats.Sf + stats.Sh;
        }

        //S - Singles
        private int CalculateSingles(CalculatorStats stats)
        {
            return stats.H - (stats.X2b + stats.X3b + stats.Hr);
        }

        //AVG - Batting Average
        private double CalculateAvg(CalculatorStats stats)
        {
            double avg = SafeDivide.divideDouble((double)stats.H, stats.Ab);

            return Math.Round(avg, 3);
        }

        //OBP - On Base Percentage (http://www.fangraphs.com/library/offense/obp/)
        private double CalculateObp(CalculatorStats stats)
        {
            var numerator = (double)stats.H + stats.Bb + stats.Ibb;
            var denominator = stats.Ab;

            double obp = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(obp, 3);
        }

        //SLG - Slugging Percentage
        private double CalculateSlg(CalculatorStats stats)
        {
            var numerator = (double)stats.Singles + stats.X2b * 2 + stats.X3b * 3 + stats.Hr * 4;
            var denominator = stats.Ab;

            double slg = SafeDivide.divideDouble(numerator, denominator);

            return Math.Round(slg, 3);
        }

        //OPS - On Base + Slugging (http://www.fangraphs.com/library/offense/ops/)
        private double CalculateOps(CalculatorStats stats)
        {
            return Math.Round(stats.Obp + stats.Slg, 3);
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(BattingStats battingStats)
        {
            var calculatorStats = new CalculatorStats
            {
                Ab = battingStats.Ab ?? 0,

                H = battingStats.H ?? 0,

                X2b = battingStats.X2b ?? 0,

                X3b = battingStats.X3b ?? 0,

                Hr = battingStats.Hr ?? 0,

                Bb = battingStats.Bb ?? 0,

                So = battingStats.So ?? 0,

                Ibb = battingStats.Ibb ?? 0,

                Hbp = battingStats.Hbp ?? 0,

                Sh = battingStats.Sh ?? 0,

                Sf = battingStats.Sf ?? 0
            };

            calculatorStats.Pa = CalulatePa(calculatorStats);
            calculatorStats.Singles = CalculateSingles(calculatorStats);
            calculatorStats.Obp = CalculateObp(calculatorStats);
            calculatorStats.Slg = CalculateSlg(calculatorStats);
            calculatorStats.KRate = CalculateKRate(calculatorStats);
            calculatorStats.BbRate = CalculateBbRate(calculatorStats);

            return calculatorStats;
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(BattingPostStats battingStats)
        {
            var calculatorStats = new CalculatorStats
            {
                Ab = battingStats.Ab ?? 0,

                H = battingStats.H ?? 0,

                X2b = battingStats.X2b ?? 0,

                X3b = battingStats.X3b ?? 0,

                Hr = battingStats.Hr ?? 0,

                Bb = battingStats.Bb ?? 0,

                So = battingStats.So ?? 0,


                Ibb = battingStats.Ibb ?? 0,

                Hbp = battingStats.Hbp ?? 0,

                Sh = battingStats.Sh ?? 0,

                Sf = battingStats.Sf ?? 0
            };

            calculatorStats.Pa = CalulatePa(calculatorStats);
            calculatorStats.Singles = CalculateSingles(calculatorStats);
            calculatorStats.Obp = CalculateObp(calculatorStats);
            calculatorStats.Slg = CalculateSlg(calculatorStats);
            calculatorStats.KRate = CalculateKRate(calculatorStats);
            calculatorStats.BbRate = CalculateBbRate(calculatorStats);

            return calculatorStats;
        }

        private CalculatorStats ConvertOptionalParamsToNonNullable(TeamStats teamStats)
        {
            var calculatorStats = new CalculatorStats
            {
                Ab = teamStats.Ab ?? 0,

                H = teamStats.H ?? 0,

                X2b = teamStats.X2b ?? 0,

                X3b = teamStats.X3b ?? 0,

                Hr = teamStats.Hr ?? 0,

                Bb = teamStats.Bb ?? 0,

                So = teamStats.So ?? 0,

                Hbp = teamStats.Hbp ?? 0,

                Sf = teamStats.Sf ?? 0,

                Ibb = 0,
                Sh = 0
            };
            calculatorStats.Pa = CalulatePa(calculatorStats);
            calculatorStats.Singles = CalculateSingles(calculatorStats);
            calculatorStats.Obp = CalculateObp(calculatorStats);
            calculatorStats.Slg = CalculateSlg(calculatorStats);
            calculatorStats.KRate = CalculateKRate(calculatorStats);
            calculatorStats.BbRate = CalculateBbRate(calculatorStats);

            return calculatorStats;
        }
    }
}


