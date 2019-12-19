using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BaseballAPI.Services;
using Moq;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http;
using BaseballAPI.RepositoryModels;
using Newtonsoft.Json;
using System.Net;
using BaseballAPI.ApiModels;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Integration")]

    class PlayerControllerIntegrationTests
    {
        private WebApplicationFactory<Program> _factory;
        private Mock<IPlayerService> _playerService;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
            _playerService = new Mock<IPlayerService>();


            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<IPlayerService, IPlayerService>(provider =>
                    {
                        return _playerService.Object;
                    });
                });
            }).CreateClient();
        }

        [Test]
        public async Task GetPlayerById()
        {
            var expectedPlayer = new Player
            {
                PlayerId = "id"
            };

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(expectedPlayer.PlayerId)).Returns(expectedPlayer);

            var url = $"/player/{expectedPlayer.PlayerId}";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualPlayer = JsonConvert.DeserializeObject<Player>(content);

            Assert.That(actualPlayer.PlayerId, Is.EqualTo(expectedPlayer.PlayerId));
        }

        [Test]
        public async Task IfGetPlayerByIdDoesNotFindAPlayerReturnsSuccess()
        {
            string badId = "badId";

            var emptyList = new Player();

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(badId)).Returns(emptyList);

            var url = $"/player/{badId}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public async Task AssertThatClientResponseEqualsExpectedResponse(string url, Player player)
        {
            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayerId(player.NameFirst, player.NameLast)).Returns(new List<Player>() { player });

            var uri = QueryHelpers.AddQueryString(url, new Dictionary<string, string> {
                {"firstName", player.NameFirst},
                {"lastName", player.NameLast}
            });

            var response = await _client.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo(player));
        }
    }
}
