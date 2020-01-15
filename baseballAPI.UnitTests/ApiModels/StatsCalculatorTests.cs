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
        public BattingStats _computedBattingStats;
        public TeamStats _fakeTeamStats;
        public TeamStats _computedTeamStats;

        [SetUp]
        public void SetUp()
        {
            _calculator = new StatsCalculator();
            _fakeBattingStats = GenerateFakeBattingStats();
            _computedBattingStats = _calculator.CalculateStats(_fakeBattingStats);

            _fakeTeamStats = GenerateFakeTeamStats();
            _computedTeamStats = _calculator.CalculateStats(_fakeTeamStats);

        }

        [Test]
        public void CalculateBattingStatsReturnsCorrectValues()
        {
            //singles = H - 2B - 3B - HR
            int expectedSingles = (_fakeBattingStats.H - _fakeBattingStats.X2b - _fakeBattingStats.X3b - _fakeBattingStats.Hr);
            Assert.That(_computedBattingStats.Singles, Is.EqualTo(expectedSingles));

            //AVG = H / Ab
            double expectedAvg = (double)_fakeBattingStats.H / _fakeBattingStats.Ab;
            Assert.That(_computedBattingStats.Avg, Is.EqualTo(expectedAvg));

            //OBP = (H + BB + IBB)/Ab
            double expectedObp = ((double)_fakeBattingStats.H + _fakeBattingStats.Bb + _fakeBattingStats.Ibb) / _fakeBattingStats.Ab;
            Assert.That(_computedBattingStats.Obp, Is.EqualTo(expectedObp));

            //SLG = (Singles + 2B*2 + 3B*3 + HR*4)/Ab
            double expectedSlg = ((double)_fakeBattingStats.Singles + (_fakeBattingStats.X2b * 2) + (_fakeBattingStats.X3b * 3) + (_fakeBattingStats.Hr * 4)) / _fakeBattingStats.Ab;
            Assert.That(_computedBattingStats.Slg, Is.EqualTo(expectedSlg));

            //OPS = (OBP + SLG)
            double expectedOps = ((double)_fakeBattingStats.Obp + _fakeBattingStats.Slg);
            Assert.That(_computedBattingStats.Ops, Is.EqualTo(expectedOps));

            //Pa = AB + BB + HBP + SF + SH
            int expectedPa = _fakeBattingStats.Ab + _fakeBattingStats.Bb + _fakeBattingStats.Hbp + _fakeBattingStats.Sf + _fakeBattingStats.Sh;
            Assert.That(_computedBattingStats.Pa, Is.EqualTo(expectedPa));

            //BABIP = (H - HR) / (Ab - K -Hr + Sf)
            double expectedBabip = ((double)_fakeBattingStats.H - _fakeBattingStats.Hr) / (_fakeBattingStats.Ab - _fakeBattingStats.So - _fakeBattingStats.Hr + _fakeBattingStats.Sf);
            Assert.That(_computedBattingStats.Babip, Is.EqualTo(Math.Round(expectedBabip, 3)));

            //ISO = (2B + 2 * 3B + 3 * HR) / Ab
            double expectedIso = ((double)_fakeBattingStats.X2b + 2 * _fakeBattingStats.X3b + 3 * _fakeBattingStats.Hr) / _fakeBattingStats.Ab;
            Assert.That(_computedBattingStats.Iso, Is.EqualTo(expectedIso));

            //K% = K / PA
            double expectedKRate = (double)_fakeBattingStats.So / _fakeBattingStats.Pa;
            Assert.That(_computedBattingStats.KRate, Is.EqualTo(expectedKRate));

            //BB% = BB / PA
            double expectedBbRate = (double)_fakeBattingStats.Bb / _fakeBattingStats.Pa;
            Assert.That(_computedBattingStats.BbRate, Is.EqualTo(expectedBbRate));
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

    }
}