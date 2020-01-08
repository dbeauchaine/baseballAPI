using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using NUnit.Framework;
using System;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class BattingStatsCalculatorTests
    {
        public BattingStatsCalculator _calculator;
        public BattingStats _fakeBattingStats;
        public BattingStats _computedBattingStats;

        [SetUp]
        public void SetUp()
        {
            _calculator = new BattingStatsCalculator();
            _fakeBattingStats = GenerateFakeBattingStats();
            _computedBattingStats = _calculator.CalculateStats(_fakeBattingStats);

        }

        [Test]
        public void CalculateStatsReturnsCorrectValues()
        {
            double expectedSingles = (5 - 2 - 1 - 1);
            Assert.That(_computedBattingStats.Singles, Is.EqualTo(expectedSingles));
            
            double expectedAvg = 5 / 10.0;
            Assert.That(_computedBattingStats.Avg, Is.EqualTo(expectedAvg));
        
            double expectedObp = ((5 + 0 + 0) / 10.0);
            Assert.That(_computedBattingStats.Obp, Is.EqualTo(expectedObp));

            double expectedSlg = (1 + 2 * 2 + 3 * 1 + 4 * 1) / 10.0;
            Assert.That(_computedBattingStats.Slg, Is.EqualTo(expectedSlg));
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
                Ibb = 0,
                Bb = 0,
            };
        }
    }
}