﻿using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class BattingServiceTests
    {
        private BaseballDBContext _database;
        private BattingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private Batting _firstPerson;
        private Batting _secondPerson;
        private Batting _thirdPerson;
        private Batting _fourthPerson;
        private Batting _fifthPerson;

        private Mock<IBattingStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "BattingServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IBattingStatsMapper>();

            _service = new BattingService(_database, _mockMapper.Object);

            CreateFakeData();
        }

        [Test]
        public void GetBattingStatsReturnsStats()
        {
            AssertGetBattingStatsReturnsStats(_firstPerson);
            AssertGetBattingStatsReturnsStats(_secondPerson);
            AssertGetBattingStatsReturnsStatsWithDuplicateId(_firstPerson, _thirdPerson);
        }

        [Test]
        public void GetBattingStatsByYearReturnsStats()
        {
            AssertGetBattingStatsByYearReturnsStats(_fourthPerson);
            AssertGetBattingLeaderboardStatsByYearWithBadIdReturnsEmptyIEnumerable();
        }

        [Test]
        public void GetBattingStatsByTeamReturnsStats()
        {
            AssertGetBattingStatsByTeamReturnsStats(_fourthPerson, _fifthPerson);
        }

        private void AssertGetBattingStatsByTeamReturnsStats(Batting firstPerson, Batting secondPerson)
        {
            var firstBattingStats = new BattingStats();
            var secondBattingStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstPerson)).Returns(firstBattingStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondPerson)).Returns(secondBattingStats);

            var actualBattingStats = _service.GetBattingStatsByTeam(firstPerson.TeamId, firstPerson.YearId);

            Assert.That(actualBattingStats.ElementAt(0), Is.EqualTo(firstBattingStats));
            //Assert.That(actualBattingStats.ElementAt(1), Is.EqualTo(secondBattingStats));
        }

        private void AssertGetBattingLeaderboardStatsByYearWithBadIdReturnsEmptyIEnumerable()
        {
            var badYear = 1;
            var badReturn = _service.GetBattingStatsByYear(badYear);

            Assert.That(!badReturn.Any());
        }

        private void AssertGetBattingStatsByYearReturnsStats(Batting expectedBatting)
        {
            var expectedBattingStatsByYear = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedBatting)).Returns(expectedBattingStatsByYear);

            var actualBattingLeaderboardStats = _service.GetBattingStatsByYear(expectedBatting.YearId);

            Assert.That(actualBattingLeaderboardStats.ElementAt(0), Is.EqualTo(expectedBattingStatsByYear));
        }

        public void AssertGetBattingStatsReturnsStats(Batting expectedBatting)
        {
            var expectedBattingStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedBatting)).Returns(expectedBattingStats);

            var actualBatting = _service.GetBattingStats(expectedBatting.PlayerId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(expectedBattingStats));
        }

        public void AssertGetBattingStatsReturnsStatsWithDuplicateId(Batting firstEntry, Batting secondEntry)
        {
            var firstEntryStats = new BattingStats();
            var secondEntryStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualBatting = _service.GetBattingStats(firstEntry.PlayerId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualBatting.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        public void CreateFakeData()
        {
            _firstPerson = new Batting()
            {
                YearId = 2000,
                Hr = 20,
                Ab = 100,
                PlayerId = "id",
                TeamId = "SEA"
            };

            _secondPerson = new Batting()
            {
                YearId = 2000,
                Hr = 10,
                Ab = 200,
                PlayerId = "anotherId",
                TeamId = "SEA"
            };

            _thirdPerson = new Batting()
            {
                YearId = 1999,
                Hr = 18,
                Ab = 99,
                PlayerId = "id",
                TeamId = "SEA"
            };

            _fourthPerson = new Batting
            {
                YearId = 1998,
                Hr = 18,
                Ab = 101,
                PlayerId = "fourthId",
                Player = new People()
                {
                    PlayerId = "fourthId",
                    NameFirst = "first",
                    NameGiven = "first middle",
                    NameLast = "last"
                },
                TeamId = "NYA"
            };

            _fifthPerson = new Batting
            {
                YearId = 1998,
                Hr = 18,
                Ab = 101,
                PlayerId = "fifthId",
                Player = new People()
                {
                    PlayerId = "fifthId",
                    NameFirst = "fifth",
                    NameGiven = "fifth middle",
                    NameLast = "last"
                },
                TeamId = "NYA"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.Add(_thirdPerson);
            _database.Add(_fourthPerson);
            _database.SaveChanges();
        }
    }
}