using BaseballAPI.ApiModels;
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
    public class PitchingServicePostTests
    {
        private BaseballDBContext _database;
        private PitchingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private PitchingPost _firstPerson;
        private PitchingPost _secondPerson;
        private PitchingPost _thirdPerson;
        private PitchingPost _fourthPerson;
        private Mock<IPitchingStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "PitchingPostServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IPitchingStatsMapper>();

            _service = new PitchingService(_database, _mockMapper.Object);


            CreateFakeData();
        }

        [Test]
        public void GetBattingStatsReturnsStats()
        {
            AssertGetPitchingStatsReturnsStats(_firstPerson);
            AssertGetPitchingStatsReturnsStats(_secondPerson);
            AssertGetPitchingStatsReturnsStatsWithDuplicateId(_firstPerson, _thirdPerson);
        }

        [Test]
        public void GetPitchingStatsByYearReturnsStats()
        {
            AssertGetPitchingPostStatsByYearReturnsStats(_fourthPerson);
        }

        private void AssertGetPitchingPostStatsByYearReturnsStats(PitchingPost expectedPitching)
        {
            var expectedPitchingPostStats = new PitchingPostStats();

            _mockMapper.Setup(mockPitchingMapper => mockPitchingMapper.Map(expectedPitching)).Returns(expectedPitchingPostStats);

            var actualPitchingLeaderboardStats = _service.GetPitchingPostStatsByYear(expectedPitching.YearId);

            Assert.That(actualPitchingLeaderboardStats.ElementAt(0), Is.EqualTo(expectedPitchingPostStats));

        }

        public void AssertGetPitchingStatsReturnsStats(PitchingPost expectedPitching)
        {
            var expectedPitchingStats = new PitchingPostStats();

            _mockMapper.Setup(mockPitchingMapper => mockPitchingMapper.Map(expectedPitching)).Returns(expectedPitchingStats);

            var actualPitching = _service.GetPitchingPostStats(expectedPitching.PlayerId);

            Assert.That(actualPitching.ElementAt(0), Is.EqualTo(expectedPitchingStats));
        }

        public void AssertGetPitchingStatsReturnsStatsWithDuplicateId(PitchingPost firstEntry, PitchingPost secondEntry)
        {
            var firstEntryStats = new PitchingPostStats();
            var secondEntryStats = new PitchingPostStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualPeople = _service.GetPitchingPostStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        public void CreateFakeData()
        {
            _firstPerson = new PitchingPost()
            {
                YearId = 2000,
                Hr = 20,
                W = 10,
                PlayerId = "id",
                Round = "WS"
            };

            _secondPerson = new PitchingPost()
            {
                YearId = 2000,
                Hr = 10,
                W = 3,
                PlayerId = "anotherId",
                Round = "WS"
            };

            _thirdPerson = new PitchingPost()
            {
                YearId = 1999,
                Hr = 18,
                W = 99,
                PlayerId = "id",
                Round = "WC"
            };

            _fourthPerson = new PitchingPost()
            {
                YearId = 1998,
                Hr = 18,
                W = 20,
                PlayerId = "fourthId",
                Round = "WC",

                Player = new People()
                {
                    PlayerId = "fourthId",
                    NameFirst = "first",
                    NameGiven = "first middle",
                    NameLast = "last"
                }
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.Add(_thirdPerson);
            _database.Add(_fourthPerson);
            _database.SaveChanges();
        }
    }
}