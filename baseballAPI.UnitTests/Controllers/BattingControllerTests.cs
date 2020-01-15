using BaseballAPI.ApiModels;
using BaseballAPI.Controllers;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class BattingControllerTests
    {
        private Mock<IBattingService> _battingService;
        private BattingController _controller;

        [SetUp]
        public void SetUp()
        {
            _battingService = new Mock<IBattingService>();
            _controller = new BattingController(_battingService.Object);
        }

        [Test]
        public void GetBattingStatsReturnsEnumerableBattingRecords()
        {
            var firstPerson = new BattingStats
            {
                PlayerId = "personId"
            };

            var secondPerson = new BattingStats
            {
                PlayerId = "personId"
            };

            var expectedPeople = new List<BattingStats>()
            {
                firstPerson,
                secondPerson
            };

            _battingService.Setup(mockPlayerService => mockPlayerService.GetBattingStats(firstPerson.PlayerId)).Returns(expectedPeople);

            var actualReturn = _controller.GetBattingStats(firstPerson.PlayerId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }


        [Test]
        public void IfGetBattingFailsToFindEntryItReturnsEmptyList()
        {
            string badId = "badId";

            var emptyList = new List<BattingStats>();

            _battingService.Setup(mockBattingService => mockBattingService.GetBattingStats(badId)).Returns(emptyList);

            var badReturn = _controller.GetBattingStats(badId);

            Assert.That(!badReturn.Any());
        }

        [Test]
        public void GetBattingStatsByYearReturnsEnumerableBattingStatsWithNames()
        {
            var firstPerson = new BattingStats
            {
                PlayerId = "personId",
                NameLast = "last",
                YearId = 2000
            };

            var secondPerson = new BattingStats
            {
                PlayerId = "secondPersonId",
                NameLast = "secondLast",
                YearId = 2000
            };

            var expectedRecord = new List<BattingStats>()
            {
                firstPerson,
                secondPerson
            };

            _battingService.Setup(mockBattingService => mockBattingService.GetBattingStatsByYear(firstPerson.YearId)).Returns(expectedRecord);

            var actualReturn = _controller.GetBattingStatsByYear(firstPerson.YearId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }

        [Test]
        public void IfGetBattingByYearFailsToFindEntryItReturnsEmptyList()
        {
            int badId = 1;

            var emptyList = new List<BattingStats>();
            _battingService.Setup(mockBattingService => mockBattingService.GetBattingStatsByYear(badId)).Returns(emptyList);

            var actualReturn = _controller.GetBattingStatsByYear(badId);

            Assert.That(!actualReturn.Any());

        }
    }

}