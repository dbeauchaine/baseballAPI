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
    public class PlayerServiceTests
    {
        private BaseballDBContext _database;
        private PlayerService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private People _firstPerson;
        private People _secondPerson;
        private Mock<IPlayerMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "PlayerServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<IPlayerMapper>();
            _service = new PlayerService(_database, _mockMapper.Object);

            CreateFakeData(_database);
        }

        [Test]
        public void GetPlayerIdReturnsId()
        {
            AssertGetPlayerIdReturnsIdWithFullName(_firstPerson);
            AssertGetPlayerIdReturnsIdWithFullName(_secondPerson);
            AssertGetPlayerIdReturnsIdWithPartialName(_firstPerson);
        }

        [Test]
        public void GetPlayerReturnsPlayers()
        {
            AssertGetPlayerReturnsPlayer(_firstPerson);
            AssertGetPlayerReturnsPlayer(_secondPerson);
        }

        public void AssertGetPlayerIdReturnsIdWithFullName(People person)
        {
            var expectedPlayer = new Player();

            _mockMapper.Setup(mockPlayerMapper => mockPlayerMapper.Map(person)).Returns(expectedPlayer);

            var actualPlayerId = _service.GetPlayerId(person.NameFirst);
            var idFromLastName = _service.GetPlayerId(person.NameLast);
            var idFromGivenName = _service.GetPlayerId(person.NameGiven);
            var idFromFullName = _service.GetPlayerId($"{person.NameFirst} {person.NameLast}");

            Assert.That(actualPlayerId.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
            Assert.That(idFromLastName.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
            Assert.That(idFromFullName.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
        }
        private void AssertGetPlayerIdReturnsIdWithPartialName(People person)
        {
            var expectedPlayer = new Player();
            _mockMapper.Setup(MockPlayerMapper => MockPlayerMapper.Map(person)).Returns(expectedPlayer);

            var actualPlayerId = _service.GetPlayerId("fir");
            var actualPlayerIdFromLastName = _service.GetPlayerId("las");
            var actualPlayerIdFromGivenName = _service.GetPlayerId("first mi");
            var actualPlayerIdFromFullName = _service.GetPlayerId("fir las");

            Assert.That(actualPlayerId.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
            Assert.That(actualPlayerIdFromLastName.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
            Assert.That(actualPlayerIdFromFullName.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
        }

        public void AssertGetPlayerReturnsPlayer(People expectedPerson)
        {
            var expectedPlayer = new Player();

            _mockMapper.Setup(mockPlayerMapper => mockPlayerMapper.Map(expectedPerson)).Returns(expectedPlayer);

            var actualPlayer = _service.GetPlayer(expectedPerson.PlayerId);

            Assert.That(actualPlayer, Is.EqualTo(expectedPlayer));
        }
        public void CreateFakeData(BaseballDBContext database)
        {
            _firstPerson = new People()
            {
                NameFirst = "first",
                NameLast = "last",
                PlayerId = "id",
                NameGiven = "first middle"
            };

            _secondPerson = new People()
            {
                NameFirst = "anotherFirst",
                NameLast = "antherLast",
                PlayerId = "anotherId",
                NameGiven = "anotherFirst anotherMiddle"
            };

            _database.Add(_firstPerson);
            _database.Add(_secondPerson);
            _database.SaveChanges();
        }

    }
}