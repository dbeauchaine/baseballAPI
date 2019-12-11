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
    public class FieldingServiceTests
    {
        private BaseballDBContext _database;
        private FieldingService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private Fielding _firstPerson;
        private Fielding _secondPerson;
        private Fielding _duplicatePerson;
        private Mock<IFieldingStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "FieldingServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IFieldingStatsMapper>();

            _service = new FieldingService(_database, _mockMapper.Object);

            CreateFakeData(_database);
        }

        [Test]
        public void GetFieldingStatsReturnsStats()
        {
            AssertGetFieldingStatsReturnsStats(_firstPerson);
            AssertGetFieldingStatsReturnsStats(_secondPerson);
            AssertGetFieldingStatsReturnsStatsWithDuplicateId(_firstPerson, _duplicatePerson);
        }

        public void AssertGetFieldingStatsReturnsStats(Fielding expectedPerson)
        {
            var expectedPersonStats = new FieldingStats();

            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(expectedPerson)).Returns(expectedPersonStats);

            var actualFielding = _service.GetFieldingStats(expectedPerson.PlayerId);

            Assert.That(actualFielding.ElementAt(0), Is.EqualTo(expectedPersonStats));
        }

        public void AssertGetFieldingStatsReturnsStatsWithDuplicateId(Fielding firstEntry, Fielding secondEntry)
        {
            var firstEntryStats = new FieldingStats();
            var secondEntryStats = new FieldingStats();

            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockFieldingMapper => mockFieldingMapper.Map(secondEntry)).Returns(secondEntryStats);
            var actualPeople = _service.GetFieldingStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntryStats));
        }
        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new Fielding()
            {
                Pos = "2B",
                YearId = 2000,
                A = 20,
                E = 100,
                PlayerId = "id"
            };

            _secondPerson = new Fielding()
            {
                Pos = "P",
                YearId = 2001,
                A = 10,
                E = 200,
                PlayerId = "anotherId"
            };

            _duplicatePerson = new Fielding()
            {
                Pos = "C",
                YearId = 1999,
                A = 18,
                E = 99,
                PlayerId = "id"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.Add(_duplicatePerson);
            _database.SaveChanges();
        }
    }
}