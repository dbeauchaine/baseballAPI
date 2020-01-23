using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class FieldingServicePostTests
    {
        private BaseballDBContext _database;
        private FieldingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private FieldingPost _firstPerson;
        private FieldingPost _secondPerson;
        private FieldingPost _duplicatePerson;
        private Mock<IFieldingStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "FieldingServicePostTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IFieldingStatsMapper>();

            _service = new FieldingService(_database, _mockMapper.Object);

            CreateFakeData();
        }

        [Test]
        public void GetFieldingPostStatsReturnsStats()
        {
            AssertGetFieldingStatsReturnsStats(_firstPerson);
            AssertGetFieldingStatsReturnsStats(_secondPerson);
            AssertGetFieldingStatsReturnsStatsWithDuplicateId(_firstPerson, _duplicatePerson);
        }

        public void AssertGetFieldingStatsReturnsStats(FieldingPost expectedPerson)
        {
            var expectedPersonStats = new FieldingPostStats();

            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(expectedPerson)).Returns(expectedPersonStats);

            var actualFielding = _service.GetFieldingPostStats(expectedPerson.PlayerId);

            Assert.That(actualFielding.ElementAt(0), Is.EqualTo(expectedPersonStats));
        }

        public void AssertGetFieldingStatsReturnsStatsWithDuplicateId(FieldingPost firstEntry, FieldingPost secondEntry)
        {
            var firstEntryStats = new FieldingPostStats();
            var secondEntryStats = new FieldingPostStats();

            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(secondEntry)).Returns(secondEntryStats);
            var actualPeople = _service.GetFieldingPostStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }
        public void CreateFakeData()
        {
            _firstPerson = new FieldingPost()
            {
                Pos = "2B",
                YearId = 2000,
                A = 20,
                E = 100,
                PlayerId = "id",
                Round = "WC"
            };

            _secondPerson = new FieldingPost()
            {
                Pos = "P",
                YearId = 2001,
                A = 10,
                E = 200,
                PlayerId = "anotherId",
                Round = "WS"
            };

            _duplicatePerson = new FieldingPost()
            {
                Pos = "C",
                YearId = 1999,
                A = 18,
                E = 99,
                PlayerId = "id",
                Round = "WS"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.Add(_duplicatePerson);
            _database.SaveChanges();
        }
    }
}