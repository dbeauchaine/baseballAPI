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
        public void IfGetBattingFailsToFindEntryItThrowsNotFoundException()
        {
            string badId = "badId";
            _battingService.Setup(mockPlayerService => mockPlayerService.GetBattingStats(badId)).Returns((IEnumerable<BattingStats>)null);

            HttpResponseException exception = Assert.Throws<HttpResponseException>(() => _controller.GetBattingStats(badId));

            Assert.That(exception.Status, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void GetBattingStatsByYearReturnsEnumerableLeagueBattingStats()
        {
            var firstPerson = new BattingLeaderBoardStats
            {
                PlayerId = "personId",
                NameLast = "last"
            };

            var secondPerson = new BattingLeaderBoardStats
            {
                PlayerId = "personId",
                NameLast ="last"
            };

            var expectedRecord = new List<BattingLeaderBoardStats>()
            {
                firstPerson,
                secondPerson
            };

            _battingService.Setup(mockPlayerService => mockPlayerService.GetBattingStatsByYear(firstPerson.YearId)).Returns(expectedRecord);

            var actualReturn = _controller.GetBattingStats(firstPerson.PlayerId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }

    }

}