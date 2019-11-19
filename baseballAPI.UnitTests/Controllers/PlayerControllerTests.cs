using BaseballAPI.Controllers;
using BaseballAPI.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void ReturnsPlayerID()
        {
            var firstName = "first";
            var lastName = "last";

            const string expectedPlayerId = "something";

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayerId(firstName, lastName)).Returns(expectedPlayerId);

            var playerId = _controller.GetPlayerId(firstName, lastName);

            Assert.That(playerId, Is.EqualTo(expectedPlayerId));
        }
    }

}