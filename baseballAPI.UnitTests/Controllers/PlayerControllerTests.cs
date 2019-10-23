using baseballAPI.Controllers;
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
        [Test]
        public void PlayerControllerExists() 
        {
            var test = new PlayerController();
        }

        [Test]
        public void ReturnsPlayerID()
        {
            var firstname = "first";
            var lastname = "last";
            var controller = new PlayerController();
            var playerID = controller.GetPlayerID(firstname, lastname);
        }
    }
}
