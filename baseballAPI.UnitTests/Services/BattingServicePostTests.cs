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
    public class BattingServicePostTests
    {
        private BaseballDBContext _database;
        private BattingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private BattingPost _firstPersonPost;
        private BattingPost _secondPersonPost;
        private BattingPost _thirdPersonPost;
        private BattingPost _fourthPersonPost;

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
        public void GetBattingPostStatsReturnsStats()
        {
            AssertGetBattingPostStatsReturnsStats(_firstPersonPost);
            AssertGetBattingPostStatsReturnsStats(_secondPersonPost);
            AssertGetBattingPostStatsReturnsStatsWithDuplicateId(_firstPersonPost, _thirdPersonPost);
        }

        [Test]
        public void GetBattingPostStatsByYearReturnsStats()
        {
            AssertGetBattingPostStatsByYearReturnsStats(_fourthPersonPost);
            AssertGetBattingPostLeaderboardStatsByYearWithBadIdReturnsEmptyIEnumerable();
        }

        private void AssertGetBattingPostStatsReturnsStats(BattingPost expectedBattingPost)
        {
            var expectedBattingPostStats = new BattingPostStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedBattingPost)).Returns(expectedBattingPostStats);

            var actualBatting = _service.GetBattingPostStats(expectedBattingPost.PlayerId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(expectedBattingPostStats));
        }

        private void AssertGetBattingPostStatsReturnsStatsWithDuplicateId(BattingPost firstEntry, BattingPost secondEntry)
        {
            var firstEntryStats = new BattingPostStats();
            var secondEntryStats = new BattingPostStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualBatting = _service.GetBattingPostStats(firstEntry.PlayerId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualBatting.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        private void AssertGetBattingPostLeaderboardStatsByYearWithBadIdReturnsEmptyIEnumerable()
        {
            var badYear = 1;
            var badReturn = _service.GetBattingPostStatsByYear(badYear);

            Assert.That(!badReturn.Any());
        }

        private void AssertGetBattingPostStatsByYearReturnsStats(BattingPost expectedBattingPost)
        {
            var expectedBattingStatsByYear = new BattingPostStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedBattingPost)).Returns(expectedBattingStatsByYear);

            var actualBattingLeaderboardStats = _service.GetBattingPostStatsByYear(expectedBattingPost.YearId);

            Assert.That(actualBattingLeaderboardStats.ElementAt(0), Is.EqualTo(expectedBattingStatsByYear));
        }

        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPersonPost = new BattingPost()
            {
                YearId = 2000,
                Hr = 20,
                Ab = 100,
                PlayerId = "id",
                Round = "WC"
            };

            _secondPersonPost = new BattingPost()
            {
                YearId = 2000,
                Hr = 10,
                Ab = 200,
                PlayerId = "anotherId",
                Round = "WS"
            };

            _thirdPersonPost = new BattingPost()
            {
                YearId = 1999,
                Hr = 18,
                Ab = 99,
                PlayerId = "id",
                Round = "WC"
            };

            _fourthPersonPost = new BattingPost()
            {
                YearId = 1998,
                Hr = 18,
                Ab = 20,
                PlayerId = "fourthId",
                Round = "WS",
                Player = new People()
                {
                    PlayerId = "fourthId",
                    NameFirst = "first",
                    NameGiven = "first middle",
                    NameLast = "last"
                }
            };

            _database.Add(_firstPersonPost);
            _database.Add(_secondPersonPost);
            _database.Add(_thirdPersonPost);
            _database.Add(_fourthPersonPost);
            _database.SaveChanges();
        }
    }
}