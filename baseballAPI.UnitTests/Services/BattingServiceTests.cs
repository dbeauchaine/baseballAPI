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
    public class BattingServiceTests
    {
        private BaseballDBContext _database;
        private BattingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private Batting _firstPerson;
        private Batting _secondPerson;
        private Batting _thirdPerson;
        private Batting _fourthPerson;
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

            CreateFakeData(_database);
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

            var actualPeople = _service.GetBattingStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new Batting()
            {
                YearId = 2000,
                Hr = 20,
                Ab = 100,
                PlayerId = "id"
            };

            _secondPerson = new Batting()
            {
                YearId = 2000,
                Hr = 10,
                Ab = 200,
                PlayerId = "anotherId"
            };

            _thirdPerson = new Batting()
            {
                YearId = 1999,
                Hr = 18,
                Ab = 99,
                PlayerId = "id"
            };

            _fourthPerson = new Batting
            {
                YearId = 1998,
                Hr = 18,
                Ab = 20,
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