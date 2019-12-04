using BaseballAPI.Models;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "BattingServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _service = new BattingService(_database);

            CreateFakeData(_database);
        }

        [Test]
        public void GetBattingStatsReturnsStats()
        {
            AssertGetBattingStatsReturnsStats(_firstPerson);
            AssertGetBattingStatsReturnsStats(_secondPerson);
            AssertGetBattingStatsReturnsStatsWithDuplicateId(_firstPerson, _duplicatePerson);
        }

        public void AssertGetBattingStatsReturnsStats(Batting expectedPerson)
        {
            var actualPerson = _service.GetBattingStats(expectedPerson.PlayerId);

            Assert.That(actualPerson.ElementAt(0), Is.EqualTo(expectedPerson));
        }

        public void AssertGetBattingStatsReturnsStatsWithDuplicateId(Batting firstEntry, Batting secondEntry)
        {
            var actualPeople = _service.GetBattingStats(firstEntry.PlayerId);

            Assert.That(actualPeople.ElementAt(0), Is.EqualTo(firstEntry));
            Assert.That(actualPeople.ElementAt(1), Is.EqualTo(secondEntry));
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
                YearId = 2001,
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