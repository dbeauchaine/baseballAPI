﻿using BaseballAPI.ApiModels;
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
    public class PitchingControllerTests
    {
        private Mock<IPitchingService> _service;
        private PitchingController _controller;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IPitchingService>();
            _controller = new PitchingController(_service.Object);
        }

        [Test]
        public void GetPitchingStatsReturnsEnumerablePitchingRecords()
        {
            var firstPerson = new PitchingStats
            {
                PlayerId = "personId"
            };

            var secondPerson = new PitchingStats
            {
                PlayerId = "personId"
            };

            var expectedPeople = new List<PitchingStats>()
            {
                firstPerson,
                secondPerson
            };

            _service.Setup(mockPitchingService => mockPitchingService.GetPitchingStats(firstPerson.PlayerId)).Returns(expectedPeople);

            var actualReturn = _controller.GetPitchingStats(firstPerson.PlayerId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }


        [Test]
        public void IfGetPitchingFailsToFindEntryItThrowsNotFoundException()
        {
            string badId = "badId";
            var emptyList = new List<PitchingStats>();
            
            _service.Setup(mockPitchingService => mockPitchingService.GetPitchingStats(badId)).Returns(emptyList);

            var badReturn = _controller.GetPitchingStats(badId);

            Assert.That(!badReturn.Any());
        }

        [Test]
        public void GetPitchingStatsByYearReturnsEnumerableLeaguePitchingStats()
        {
            var firstPerson = new PitchingStats
            {
                PlayerId = "personId",
                NameLast = "last",
                YearId = 2000
            };

            var secondPerson = new PitchingStats
            {
                PlayerId = "secondPersonId",
                NameLast = "secondLast",
                YearId = 2000
            };

            var expectedRecord = new List<PitchingStats>()
            {
                firstPerson,
                secondPerson
            };

            _service.Setup(mockPlayerService => mockPlayerService.GetPitchingStatsByYear(firstPerson.YearId)).Returns(expectedRecord);

            var actualReturn = _controller.GetPitchingStatsByYear(firstPerson.YearId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }

        [Test]
        public void IfGetPitchingByYearFailsToFindEntryItThrowsNotFoundException()
        {
            int badId = 1;
            var emptyList = new List<PitchingStats>();

            _service.Setup(mockPitchingService => mockPitchingService.GetPitchingStatsByYear(badId)).Returns(emptyList);

            var badReturn = _controller.GetPitchingStatsByYear(badId);

            Assert.That(!badReturn.Any());

        }

        [Test]
        public void GetPitchingPostSeasonStatsReturnsEnumerablePitchingRecords()
        {
            var firstPerson = new PitchingPostStats
            {
                PlayerId = "personId",
                YearId = 2000
            };

            var secondPerson = new PitchingPostStats
            {
                PlayerId = "personId",
                YearId = 2000
            };

            var expectedPeople = new List<PitchingPostStats>()
            {
                firstPerson,
                secondPerson
            };

            _service.Setup(mockPitchingService => mockPitchingService.GetPitchingPostStatsByYear(firstPerson.YearId)).Returns(expectedPeople);

            var actualReturn = _controller.GetPitchingPostStatsByYear(firstPerson.YearId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }

        [Test]
        public void GetPitchingPostStatsReturnsEnumerablePitchingRecords()
        {
            var firstPerson = new PitchingPostStats
            {
                PlayerId = "personId"
            };

            var secondPerson = new PitchingPostStats
            {
                PlayerId = "personId"
            };

            var expectedPeople = new List<PitchingPostStats>()
            {
                firstPerson,
                secondPerson
            };

            _service.Setup(mockPitchingService => mockPitchingService.GetPitchingPostStats(firstPerson.PlayerId)).Returns(expectedPeople);

            var actualReturn = _controller.GetPitchingPostStats(firstPerson.PlayerId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstPerson));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondPerson));
        }
    }

}