using baseballAPI.Controllers;
using baseballAPI.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PlayerControllerTests
    {
        private FakePlayerService _playerService;
        private PlayerController _controller;

        [SetUp]
        public void SetUp()
        {
            _playerService = new FakePlayerService();
            _controller = new PlayerController(_playerService);
        }

        [Test]
        public void ReturnsPlayerID()
        {
            var firstname = "first";
            var lastname = "last";
 
            const string expectedPlayerId = "something";

            _playerService.AssumeReturnsPlayerId(expectedPlayerId);

            var playerID = _controller.GetPlayerId(firstname, lastname);

            Assert.That(playerID, Is.EqualTo(expectedPlayerId));
        }
    }

    public class FakePlayerService : IPlayerService
    {
        private string _expectedPlayerId;

        public void AssumeReturnsPlayerId(string expectedPlayerId)
        {
            _expectedPlayerId = expectedPlayerId;
        }

        public string GetPlayerId()
        {
            return _expectedPlayerId;
        }
    }
}