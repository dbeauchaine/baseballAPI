﻿using BaseballAPI.Controllers;
using BaseballAPI.Models;
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
            var expectedPerson = new Batting
            {
                PlayerId = "personId"
            };

            var secondPerson = new Batting
            {
                PlayerId = "personId"
            };

            var expectedPeople = new List<Batting>()
            {
                expectedPerson,
                secondPerson
            };

            _battingService.Setup(mockPlayerService => mockPlayerService.GetBattingStats(expectedPerson.PlayerId)).Returns(expectedPeople);

            var actualPerson = _controller.GetBattingStats(expectedPerson.PlayerId);

            Assert.That(actualPerson.ElementAt(0), Is.EqualTo(expectedPerson));
            Assert.That(actualPerson.ElementAt(1), Is.EqualTo(secondPerson));
        }

        [Test]
        public void IfGetPlayerFailsToFindEntryItThrowsNotFoundException()
        {
            string badId = "badId";
            _battingService.Setup(mockPlayerService => mockPlayerService.GetBattingStats(badId)).Returns((IEnumerable<Batting>)null);

            HttpResponseException exception = Assert.Throws<HttpResponseException>(() => _controller.GetBattingStats(badId));

            Assert.That(exception.Status, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }

}