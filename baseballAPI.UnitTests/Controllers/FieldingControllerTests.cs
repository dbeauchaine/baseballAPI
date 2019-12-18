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
    public class FieldingControllerTests
    {
        private Mock<IFieldingService> _fieldingService;
        private FieldingController _controller;

        [SetUp]
        public void SetUp()
        {
            _fieldingService = new Mock<IFieldingService>();
            _controller = new FieldingController(_fieldingService.Object);
        }

        [Test]
        public void GetBattingStatsReturnsEnumerableBattingRecords()
        {
            var expectedPerson = new FieldingStats
            {
                Pos = "C",
                PlayerId = "personId"
            };

            var secondPerson = new FieldingStats
            {
                Pos = "P",
                PlayerId = "personId"
            };

            var expectedPeople = new List<FieldingStats>()
            {
                expectedPerson,
                secondPerson
            };

            _fieldingService.Setup(mockFieldingService => mockFieldingService.GetFieldingStats(expectedPerson.PlayerId)).Returns(expectedPeople);

            var actualPerson = _controller.GetFieldingStats(expectedPerson.PlayerId);

            Assert.That(actualPerson.ElementAt(0), Is.EqualTo(expectedPerson));
            Assert.That(actualPerson.ElementAt(1), Is.EqualTo(secondPerson));
        }

        [Test]
        public void IfGetPlayerFailsToFindEntryItThrowsNotFoundException()
        {
            string badId = "badId";
            var emptyList = new List<FieldingStats>();

            _fieldingService.Setup(mockPlayerService => mockPlayerService.GetFieldingStats(badId)).Returns(emptyList);

           var badReturn = _controller.GetFieldingStats(badId);

            Assert.That(!badReturn.Any());
        }
    }

}