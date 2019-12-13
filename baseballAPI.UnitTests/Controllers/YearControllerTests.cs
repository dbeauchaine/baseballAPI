using BaseballAPI.ApiModels;
using BaseballAPI.Controllers;
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
    public class YearControllerTests
    {
        private Mock<IYearService> yearService;
        private YearController _controller;

        [SetUp]
        public void SetUp()
        {
            yearService = new Mock<IYearService>();
            _controller = new YearController(yearService.Object);
        }


        [Test]
        public void GetBattingStatsByYearReturnsEnumerableBattingRecords()
        {
            var firstPerson = new BattingStats
            {
                PlayerId = "personId",
                YearId = 2000
            };

            var secondPerson = new BattingStats
            {
                PlayerId = "personId",
                YearId = 2000
            };

            var expectedPeople = new List<BattingStats>()
            {
                firstPerson,
                secondPerson
            };

            yearService.Setup(mockPlayerService => mockPlayerService.GetBattingStatsByYear(firstPerson.YearId)).Returns(expectedPeople);

            var actualPerson = _controller.GetBattingStatsByYear(firstPerson.YearId);

            Assert.That(actualPerson.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualPerson.ElementAt(1), Is.EqualTo(secondPerson));
        }


        [Test]
        public void IfGetBattingByYearFailsToFindEntryItThrowsNotFoundException()
        {
            int badYear = 1;
            yearService.Setup(mockPlayerService => mockPlayerService.GetBattingStatsByYear(badYear)).Returns((IEnumerable<BattingStats>)null);

            HttpResponseException exception = Assert.Throws<HttpResponseException>(() => _controller.GetBattingStatsByYear(badYear));

            Assert.That(exception.Status, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }

}