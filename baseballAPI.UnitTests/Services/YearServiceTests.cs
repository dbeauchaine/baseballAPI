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
    public class YearServiceTests
    {
        private BaseballDBContext _database;
        private YearService _service;
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

            _service = new YearService(_database, _mockMapper.Object);

            CreateFakeData(_database);
        }

        [Test]
        public void GetBattingStatsByYearReturnsStats()
        {
            AssertGetBattingStatsByYearReturnsStats(_secondPerson);
            AssertGetBattingStatsByYearReturnsStatsWIthDuplicateYear(_firstPerson, _duplicatePerson);
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

        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new Batting()
            {
                YearId = 2000,
                Hr = 20,
                Ab = 100,
                PlayerId = "id"
            };

            _duplicatePerson = new Batting()
            {
                YearId = 2000,
                Hr = 10,
                Ab = 200,
                PlayerId = "anotherId"
            };

            _secondPerson = new Batting()
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