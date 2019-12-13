using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
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
        private Batting _duplicatePerson;
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

            var expectedPersonStats = new BattingStats();
        }

        [Test]
        public void GetBattingStatsReturnsStats()
        {
            AssertGetBattingStatsReturnsStats(_firstPerson);
            AssertGetBattingStatsReturnsStats(_secondPerson);
            AssertGetBattingStatsReturnsStatsWithDuplicateId(_firstPerson, _duplicatePerson);
        }

        [Test]
        public void GetBattingStatsByYearReturnsStats()
        {
            AssertGetBattingStatsByYearReturnsStats(_duplicatePerson);
            AssertGetBattingStatsByYearReturnsStatsWIthDuplicateYear(_firstPerson, _secondPerson);
        }

        private void AssertGetBattingStatsByYearReturnsStatsWIthDuplicateYear(Batting firstEntry, Batting secondEntry)
        {
            var firstEntryStats = new BattingStats();
            var secondEntryStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualPeople = _service.GetBattingStatsByYear(firstEntry.YearId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        private void AssertGetBattingStatsByYearReturnsStats(Batting expectedPerson)
        {
            var expectedPersonStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedPerson)).Returns(expectedPersonStats);

            var actualBatting = _service.GetBattingStatsByYear(expectedPerson.YearId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(expectedPersonStats));
        }

        public void AssertGetBattingStatsReturnsStats(Batting expectedPerson)
        {
            var expectedPersonStats = new BattingStats();

            _mockMapper.Setup(mockBattingMapper => mockBattingMapper.Map(expectedPerson)).Returns(expectedPersonStats);

            var actualBatting = _service.GetBattingStats(expectedPerson.PlayerId);

            Assert.That(actualBatting.ElementAt(0), Is.EqualTo(expectedPersonStats));
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

            _duplicatePerson = new Batting()
            {
                YearId = 1999,
                Hr = 18,
                Ab = 99,
                PlayerId = "id"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.Add(_duplicatePerson);
            _database.SaveChanges();
        }
    }
}