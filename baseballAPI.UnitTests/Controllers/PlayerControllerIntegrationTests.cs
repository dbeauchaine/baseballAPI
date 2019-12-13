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
        public async Task GetPlayerIdByFirstAndLastName()
        {
            var firstPerson = GeneratePeople("first", "last", "something");
            var secondPerson = GeneratePeople("Sammy", "Sosa", "Ssosa");
            var url = "/player";

            //await AssertThatClientResponseEqualsExpectedResponse(url, firstPerson);
            //await AssertThatClientResponseEqualsExpectedResponse(url, secondPerson);
        }


        [Test]
        public async Task GetPlayerById()
        {
            var expectedPerson = new People
            {
                PlayerId = "id"
            };

            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(expectedPerson.PlayerId)).Returns(expectedPerson);

            var url = $"/player/{expectedPerson.PlayerId}";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualPerson = JsonConvert.DeserializeObject<People>(content);

            Assert.That(actualPerson.PlayerId, Is.EqualTo(expectedPerson.PlayerId));
        }

        [Test]
        public async Task IfGetPlayerByIdDoesNotFindAPlayerReturnsA404Response()
        {
            string badId = "badId";
            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayer(badId)).Returns((People)null);

            var url = $"/player/{badId}";

            var response = await _client.GetAsync(url);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        private People GeneratePeople(string firstName, string lastName, string playerId)
        {
            return new People()
            {
                NameFirst = firstName,
                NameLast = lastName,
                PlayerId = playerId
            };
        }

        public async Task AssertThatClientResponseEqualsExpectedResponse(string url, People person)
        {
            _playerService.Setup(mockPlayerService => mockPlayerService.GetPlayerId(person.NameFirst, person.NameLast)).Returns(new List<People>() { person });

            var uri = QueryHelpers.AddQueryString(url, new Dictionary<string, string> {
                {"firstName", person.NameFirst},
                {"lastName", person.NameLast}
            });

            var response = await _client.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo(person));
        }
    }
}
