﻿using BaseballAPI.Controllers;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PlayerControllerTests
    {
        private Mock<IPlayerService> _playerService;
        private PlayerController _controller;

        [SetUp]
        public void SetUp()
        {
            _playerService = new Mock<IPlayerService>();
            _controller = new PlayerController(_playerService.Object);
        }

        [Test]
        public void ReturnsPlayerId()
        {
            var firstName = "first";
            var lastName = "last";

            const string expectedPlayerId = "something";

            People expectedPlayer = new People()
            {
                PlayerId = expectedPlayerId
            };

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayerId(firstName, lastName)).Returns(new List<People>() { expectedPlayer });

            var playerId = _controller.GetPlayerId(firstName, lastName);

            Assert.That(playerId.ElementAt(0).PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
        }

        [Test]
        public void ReturnsPlayer()
        {
            var expectedPerson = new People();
            expectedPerson.PlayerId = "personId";

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(expectedPerson.PlayerId)).Returns(expectedPerson);

            var actualPerson = _controller.GetPlayer(expectedPerson.PlayerId);

            Assert.That(actualPerson, Is.EqualTo(expectedPerson));
        }

        [Test]
        public void IfGetPlayerFailsToFindEntryItThrowsNotFoundException()
        {
            string badId = "badId";
            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(badId)).Returns((People)null);

            HttpResponseException exception = Assert.Throws<HttpResponseException>(() => _controller.GetPlayer(badId));

            Assert.That(exception.Status, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }

}