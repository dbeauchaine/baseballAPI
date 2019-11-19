using BaseballAPI.Models;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PlayerServiceTests
    {
        private BaseballDBContext _database;
        private PlayerService _service;
        private DbContextOptions<BaseballDBContext> _options;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "PlayerServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _service = new PlayerService(_database);
        }

        [Test]
        public void GetReturnsIdOneEntry()
        {
            var firstName = "first";
            var lastName = "last";
            var expectedPlayerId = "something";

            _database.Add(new People
            {
                NameFirst = firstName,
                NameLast = lastName,
                PlayerId = expectedPlayerId
            });
           
            _database.SaveChanges();

            var playerId = _service.GetPlayerId(firstName, lastName);

            Assert.That(playerId, Is.EqualTo(expectedPlayerId));
        }

        [Test]
        public void GetReturnsIdMultipleEntries()
        {
            //assumes previous add to database from GetReturnsIdOneEntry
            var firstName = "first";
            var lastName = "last";
            var expectedPlayerId = "something";
            var anotherFirstName = "anotherFirst";
            var anotherLastName = "anotherLast";
            var anotherPlayerId = "somethingElse";

            _database.Add(new People
            {
                NameFirst = anotherFirstName,
                NameLast = anotherLastName,
                PlayerId = anotherPlayerId
            });

            _database.SaveChanges();

            var playerId = _service.GetPlayerId(firstName, lastName);

            Assert.That(playerId, Is.EqualTo(expectedPlayerId));
        }
    }

}