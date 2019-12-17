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
    public class PitchingServiceTests
    {
        private BaseballDBContext _database;
        private PitchingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private Pitching _firstPerson;
        private Pitching _secondPerson;
        private Pitching _thirdPerson;
        private Pitching _fourthPerson;
        private Mock<IPitchingStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "PitchingServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IPitchingStatsMapper>();

            _service = new PitchingService(_database, _mockMapper.Object);

            CreateFakeData(_database);
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
            AssertGetPitchingLeaderboardStatsByYearReturnsStats(_fourthPerson);
        }

        private void AssertGetPitchingLeaderboardStatsByYearReturnsStats(Pitching expectedPitching)
        {
            var expectedPitchingLeaderboardStats = new PitchingLeaderBoardStats();

            _mockMapper.Setup(mockPitchingMapper => mockPitchingMapper.MapYear(expectedPitching)).Returns(expectedPitchingLeaderboardStats);

            var actualPitchingLeaderboardStats = _service.GetPitchingStatsByYear(expectedPitching.YearId);

            Assert.That(actualPitchingLeaderboardStats.ElementAt(0), Is.EqualTo(expectedPitchingLeaderboardStats));
        }

        public void AssertGetPitchingStatsReturnsStats(Pitching expectedPitching)
        {
            var expectedPitchingStats = new PitchingStats();

            _mockMapper.Setup(mockPitchingMapper => mockPitchingMapper.Map(expectedPitching)).Returns(expectedPitchingStats);

            var actualPitching = _service.GetPitchingStats(expectedPitching.PlayerId);

            Assert.That(actualPitching.ElementAt(0), Is.EqualTo(expectedPitchingStats));
        }

        public void AssertGetPitchingStatsReturnsStatsWithDuplicateId(Pitching firstEntry, Pitching secondEntry)
        {
            var firstEntryStats = new PitchingStats();
            var secondEntryStats = new PitchingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualPeople = _service.GetPitchingStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new Pitching()
            {
                YearId = 2000,
                Hr = 20,
                W = 10,
                PlayerId = "id"
            };

            _secondPerson = new Pitching()
            {
                YearId = 2000,
                Hr = 10,
                W = 3,
                PlayerId = "anotherId"
            };

            _thirdPerson = new Pitching()
            {
                YearId = 1999,
                Hr = 18,
                W = 99,
                PlayerId = "id"
            };

            _fourthPerson = new Pitching()
            {
                YearId = 1998,
                Hr = 18,
                W = 20,
                PlayerId = "fourthId",
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