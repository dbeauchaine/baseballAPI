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
        [SetUp]
        public void SetUp()
        {
            _calculator = new BattingStatsCalculator();
        }

        [Test]
        public void CalculateAvgReturnsCorrectValue()
        {
            var fakeBattingStats = new BattingStats() { H = 2, Ab = 10 };

            double expectedAvg = fakeBattingStats.H / fakeBattingStats.Ab;

            expectedAvg = Math.Round(expectedAvg, 4);

            fakeBattingStats = _calculator.CalculateStats(fakeBattingStats);

            var computedAvg = fakeBattingStats.Avg;

            Assert.That(expectedAvg, Is.EqualTo(computedAvg));
        }
    }
}