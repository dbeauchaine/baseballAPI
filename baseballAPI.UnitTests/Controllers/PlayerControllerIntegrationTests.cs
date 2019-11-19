using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BaseballAPI.Services;
using Moq;
using Microsoft.AspNetCore.WebUtilities;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Integration")]

    class PlayerControllerIntegrationTests
    {
        private WebApplicationFactory<Program> _factory;
        private Mock<IPlayerService> _playerService;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
            _playerService = new Mock<IPlayerService>();
        }

        [TestCase("/Player", "first", "last", "something")]
        [TestCase("/Player", "Sammy", "Sosa", "Ssosa")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url, string firstName, string lastName, string expectedPlayerId)
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<IPlayerService, IPlayerService>(provider =>
                    {
                        return _playerService.Object;
                    });
                });
            })
            .CreateClient();

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayerId(firstName, lastName)).Returns(expectedPlayerId);



            var uri = QueryHelpers.AddQueryString(url, new Dictionary<string, string> {
                {"firstName", firstName},
                {"lastName", lastName}
            });

            var response = await client.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo(expectedPlayerId));
        }
    }
}
