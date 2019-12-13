using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PlayerServiceTests
    {
        private BaseballDBContext _database;
        private PlayerService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private People _firstPerson;
        private People _secondPerson;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "PlayerServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _service = new PlayerService(_database);

            CreateFakeData(_database);
        }

        [Test]
        public void GetPlayerIdReturnsId()
        {
            AssertGetPlayerIdReturnsId(_firstPerson);
            AssertGetPlayerIdReturnsId(_secondPerson);
        }

        [Test]
        public void GetPlayerReturnsPlayers()
        {
            AssertGetPlayerReturnsPlayer(_firstPerson);
            AssertGetPlayerReturnsPlayer(_secondPerson);
        }

        public void AssertGetPlayerIdReturnsId(People person)
        {
            var playerId = _service.GetPlayerId(person.NameFirst, person.NameLast);

            Assert.That(playerId.ElementAt(0).PlayerId, Is.EqualTo(person.PlayerId));
        }

        public void AssertGetPlayerReturnsPlayer(People expectedPerson)
        {
            var actualPerson = _service.GetPlayer(expectedPerson.PlayerId);

            Assert.That(actualPerson, Is.EqualTo(expectedPerson));
        }
        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new People()
            {
                NameFirst = "first",
                NameLast = "last",
                PlayerId = "id"
            };

            _secondPerson = new People()
            {
                NameFirst = "anotherFirst",
                NameLast = "antherLast",
                PlayerId = "anotherId"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.SaveChanges();
        }

    }
}