using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using NUnit.Framework;
using System;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class StatsCalculatorTests
    {
        public StatsCalculator _calculator;
        public BattingStats _fakeBattingStats;
        public TeamStats _fakeTeamStats;
        public TeamStats _computedTeamStats;
        public BattingPostStats _fakeBattingPostStats;
        public CalculatorStats _fakeCalculatorStats;
        public CalculatorStats _fakePostCalculatorStats;


        [SetUp]
        public void SetUp()
        {
            _calculator = new StatsCalculator();
            _fakeBattingStats = GenerateFakeBattingStats();
            _fakeCalculatorStats = ConvertOptionalParamsToNonNullable(_fakeBattingStats);
            _calculator.CalculateStats(_fakeBattingStats);

            _fakeTeamStats = GenerateFakeTeamStats();
            _computedTeamStats = _calculator.CalculateStats(_fakeTeamStats);

            _fakeBattingPostStats = GenerateFakeBattingPostStats();
            _fakePostCalculatorStats = ConvertOptionalParamsToNonNullable(_fakeBattingPostStats);
            _calculator.CalculateStats(_fakeBattingPostStats);
        }

        [Test]
        public void CalculateBattingStatsReturnsCorrectValues()
        {
            //singles = H - 2B - 3B - HR
            int expectedSingles = (_fakeCalculatorStats.H - _fakeCalculatorStats.X2b - _fakeCalculatorStats.X3b - _fakeCalculatorStats.Hr);
            Assert.That(_fakeBattingStats.Singles, Is.EqualTo(expectedSingles));

            //AVG = H / Ab
            double expectedAvg = (double)_fakeCalculatorStats.H / _fakeCalculatorStats.Ab;
            Assert.That(_fakeBattingStats.Avg, Is.EqualTo(expectedAvg));

            //OBP = (H + BB + IBB)/Ab
            double expectedObp = ((double)_fakeCalculatorStats.H + _fakeCalculatorStats.Bb + _fakeCalculatorStats.Ibb) / _fakeCalculatorStats.Ab;
            Assert.That(_fakeBattingStats.Obp, Is.EqualTo(expectedObp));

            //SLG = (Singles + 2B*2 + 3B*3 + HR*4)/Ab
            double expectedSlg = ((double)_fakeBattingStats.Singles + (_fakeCalculatorStats.X2b * 2) + (_fakeCalculatorStats.X3b * 3) + (_fakeCalculatorStats.Hr * 4)) / _fakeCalculatorStats.Ab;
            Assert.That(_fakeBattingStats.Slg, Is.EqualTo(expectedSlg));

            //OPS = (OBP + SLG)
            double expectedOps = ((double)_fakeBattingStats.Obp + _fakeBattingStats.Slg);
            Assert.That(_fakeBattingStats.Ops, Is.EqualTo(expectedOps));

            //Pa = AB + BB + HBP + SF + SH
            int expectedPa = _fakeCalculatorStats.Ab + _fakeCalculatorStats.Bb + _fakeCalculatorStats.Hbp + _fakeCalculatorStats.Sf + _fakeCalculatorStats.Sh;
            Assert.That(_fakeBattingStats.Pa, Is.EqualTo(expectedPa));

            //BABIP = (H - HR) / (Ab - K -Hr + Sf)
            double expectedBabip = ((double)_fakeCalculatorStats.H - _fakeCalculatorStats.Hr) / (_fakeCalculatorStats.Ab - _fakeCalculatorStats.So - _fakeCalculatorStats.Hr + _fakeCalculatorStats.Sf);
            Assert.That(_fakeBattingStats.Babip, Is.EqualTo(Math.Round(expectedBabip, 3)));

            //ISO = (2B + 2 * 3B + 3 * HR) / Ab
            double expectedIso = ((double)_fakeCalculatorStats.X2b + 2 * _fakeCalculatorStats.X3b + 3 * _fakeCalculatorStats.Hr) / _fakeCalculatorStats.Ab;
            Assert.That(_fakeBattingStats.Iso, Is.EqualTo(expectedIso));

            //K% = K / PA
            double expectedKRate = (double)_fakeCalculatorStats.So / _fakeBattingStats.Pa;
            Assert.That(_fakeBattingStats.KRate, Is.EqualTo(expectedKRate));

            //BB% = BB / PA
            double expectedBbRate = (double)_fakeCalculatorStats.Bb / _fakeBattingStats.Pa;
            Assert.That(_fakeBattingStats.BbRate, Is.EqualTo(expectedBbRate));
        }

        [Test]
        public void CalculateTeamStatsReturnsCorrectValues()
        {
            //singles = H - 2B - 3B - HR
            int expectedSingles = (_fakeTeamStats.H - _fakeTeamStats.X2b - _fakeTeamStats.X3b - _fakeTeamStats.Hr);
            Assert.That(_computedTeamStats.Singles, Is.EqualTo(expectedSingles));

            //AVG = H / Ab
            double expectedAvg = (double)_fakeTeamStats.H / _fakeTeamStats.Ab;
            Assert.That(_computedTeamStats.Avg, Is.EqualTo(expectedAvg));

            //OBP = (H + BB + IBB)/Ab
            double expectedObp = ((double)_fakeTeamStats.H + _fakeTeamStats.Bb + _fakeTeamStats.Ibb) / _fakeTeamStats.Ab;
            Assert.That(_computedTeamStats.Obp, Is.EqualTo(expectedObp));

            //SLG = (Singles + 2B*2 + 3B*3 + HR*4)/Ab
            double expectedSlg = ((double)_fakeTeamStats.Singles + (_fakeTeamStats.X2b * 2) + (_fakeTeamStats.X3b * 3) + (_fakeTeamStats.Hr * 4)) / _fakeTeamStats.Ab;
            Assert.That(_computedTeamStats.Slg, Is.EqualTo(expectedSlg));

            //OPS = (OBP + SLG)
            double expectedOps = ((double)_fakeTeamStats.Obp + _fakeTeamStats.Slg);
            Assert.That(_computedTeamStats.Ops, Is.EqualTo(expectedOps));

            //Pa = AB + BB + HBP + SF + SH
            int expectedPa = _fakeTeamStats.Ab + _fakeTeamStats.Bb + _fakeTeamStats.Hbp + _fakeTeamStats.Sf + _fakeTeamStats.Sh;
            Assert.That(_computedTeamStats.Pa, Is.EqualTo(expectedPa));

            //BABIP = (H - HR) / (Ab - K -Hr + Sf)
            double expectedBabip = ((double)_fakeTeamStats.H - _fakeTeamStats.Hr) / (_fakeTeamStats.Ab - _fakeTeamStats.So - _fakeTeamStats.Hr + _fakeTeamStats.Sf);
            Assert.That(_computedTeamStats.Babip, Is.EqualTo(Math.Round(expectedBabip, 3)));

            //ISO = (2B + 2 * 3B + 3 * HR) / Ab
            double expectedIso = ((double)_fakeTeamStats.X2b + 2 * _fakeTeamStats.X3b + 3 * _fakeTeamStats.Hr) / _fakeTeamStats.Ab;
            Assert.That(_computedTeamStats.Iso, Is.EqualTo(expectedIso));

            //K% = K / PA
            double expectedKRate = (double)_fakeTeamStats.So / _fakeTeamStats.Pa;
            Assert.That(_computedTeamStats.KRate, Is.EqualTo(expectedKRate));

            //BB% = BB / PA
            double expectedBbRate = (double)_fakeTeamStats.Bb / _fakeTeamStats.Pa;
            Assert.That(_computedTeamStats.BbRate, Is.EqualTo(expectedBbRate));
        }

        [Test]
        public void CalculateBattingPostStatsReturnsCorrectValues()
        {
            //singles = H - 2B - 3B - HR
            int expectedSingles = (_fakePostCalculatorStats.H - _fakePostCalculatorStats.X2b - _fakePostCalculatorStats.X3b - _fakePostCalculatorStats.Hr);
            Assert.That(_fakeBattingPostStats.Singles, Is.EqualTo(expectedSingles));

            //AVG = H / Ab
            double expectedAvg = (double)_fakePostCalculatorStats.H / _fakePostCalculatorStats.Ab;
            Assert.That(_fakeBattingPostStats.Avg, Is.EqualTo(expectedAvg));

            //OBP = (H + BB + IBB)/Ab
            double expectedObp = ((double)_fakePostCalculatorStats.H + _fakePostCalculatorStats.Bb + _fakePostCalculatorStats.Ibb) / _fakePostCalculatorStats.Ab;
            Assert.That(_fakeBattingPostStats.Obp, Is.EqualTo(expectedObp));

            //SLG = (Singles + 2B*2 + 3B*3 + HR*4)/Ab
            double expectedSlg = ((double)_fakeBattingPostStats.Singles + (_fakePostCalculatorStats.X2b * 2) + (_fakePostCalculatorStats.X3b * 3) + (_fakePostCalculatorStats.Hr * 4)) / _fakePostCalculatorStats.Ab;
            Assert.That(_fakeBattingPostStats.Slg, Is.EqualTo(expectedSlg));

            //OPS = (OBP + SLG)
            double expectedOps = ((double)_fakeBattingPostStats.Obp + _fakeBattingPostStats.Slg);
            Assert.That(_fakeBattingPostStats.Ops, Is.EqualTo(expectedOps));

            //Pa = AB + BB + HBP + SF + SH
            int expectedPa = _fakePostCalculatorStats.Ab + _fakePostCalculatorStats.Bb + _fakePostCalculatorStats.Hbp + _fakePostCalculatorStats.Sf + _fakePostCalculatorStats.Sh;
            Assert.That(_fakeBattingPostStats.Pa, Is.EqualTo(expectedPa));

            //BABIP = (H - HR) / (Ab - K -Hr + Sf)
            double expectedBabip = ((double)_fakePostCalculatorStats.H - _fakePostCalculatorStats.Hr) / (_fakePostCalculatorStats.Ab - _fakePostCalculatorStats.So - _fakePostCalculatorStats.Hr + _fakePostCalculatorStats.Sf);
            Assert.That(_fakeBattingPostStats.Babip, Is.EqualTo(Math.Round(expectedBabip, 3)));

            //ISO = (2B + 2 * 3B + 3 * HR) / Ab
            double expectedIso = ((double)_fakePostCalculatorStats.X2b + 2 * _fakePostCalculatorStats.X3b + 3 * _fakePostCalculatorStats.Hr) / _fakePostCalculatorStats.Ab;
            Assert.That(_fakeBattingPostStats.Iso, Is.EqualTo(expectedIso));

            //K% = K / PA
            double expectedKRate = (double)_fakePostCalculatorStats.So / _fakeBattingPostStats.Pa;
            Assert.That(_fakeBattingPostStats.KRate, Is.EqualTo(expectedKRate));

            //BB% = BB / PA
            double expectedBbRate = (double)_fakePostCalculatorStats.Bb / _fakeBattingPostStats.Pa;
            Assert.That(_fakeBattingPostStats.BbRate, Is.EqualTo(expectedBbRate));
        }

        public BattingStats GenerateFakeBattingStats()
        {
            return new BattingStats()
            {
                H = 5,
                X2b = 2,
                X3b = 1,
                Hr = 1,
                Ab = 10,
                Ibb = 1,
                Bb = 2,
                Hbp = 1,
                Sf = 2,
                Sh = 1
            };
        }

        private TeamStats GenerateFakeTeamStats()
        {
            return new TeamStats()
            {
                H = 5,
                X2b = 2,
                X3b = 1,
                Hr = 1,
                Ab = 10,
                Ibb = 1,
                Bb = 2,
                Hbp = 1,
                Sf = 2,
                Sh = 1
            };
        }

        private BattingPostStats GenerateFakeBattingPostStats()
        {
            return new BattingPostStats()
            {
                H = 5,
                X2b = 2,
                X3b = 1,
                Hr = 1,
                Ab = 10,
                Ibb = 1,
                Bb = 2,
                Hbp = 1,
                Sf = 2,
                Sh = 1
            };
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
