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
            var firstName = "first";
            var lastName = "last";
 
            const string expectedPlayerId = "something";

            _playerService.AssumeReturnsPlayerId(expectedPlayerId, firstName, lastName);

            var playerId = _controller.GetPlayerId(firstName, lastName);

            Assert.That(playerId, Is.EqualTo(expectedPlayerId));
        }
    }

    public class FakePlayerService : IPlayerService
    {
        private string _expectedPlayerId;
        private string _firstName;
        private string _lastName;

        public void AssumeReturnsPlayerId(string expectedPlayerId, string firstName, string lastName)
        {
            _expectedPlayerId = expectedPlayerId;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string GetPlayerId(string firstName, string lastName)
        {
            Assert.That(firstName, Is.EqualTo(_firstName));
            Assert.That(lastName, Is.EqualTo(_lastName));

            return _expectedPlayerId;
        }
    }
}