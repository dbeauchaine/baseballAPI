using BaseballAPI.ApiModels;
using BaseballAPI.Controllers;
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
    public class TeamControllerTests
    {
        private Mock<ITeamService> _teamsService;
        private TeamController _controller;

        [SetUp]
        public void SetUp()
        {
            _teamsService = new Mock<ITeamService>();
            _controller = new TeamController(_teamsService.Object);
        }

        [Test]
        public void GetTeamsStatsReturnsEnumerableBattingRecords()
        {
            var firstTeam = new TeamStats
            {
                TeamId = "SEA",
                YearId = 2000
            };

            var secondTeam = new TeamStats
            {
                TeamId = "SEA",
                YearId = 1999
            };

            var expectedTeams = new List<TeamStats>()
            {
                firstTeam,
                secondTeam
            };

            _teamsService.Setup(mockTeamsService => mockTeamsService.GetTeamStats(firstTeam.TeamId)).Returns(expectedTeams);

            var actualReturn = _controller.GetTeamStats(firstTeam.TeamId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstTeam));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondTeam));
        }


        [Test]
        public void IfGetTeamsByIdFailsToFindEntryItReturnsEmptyList()
        {
            string badId = "badId";

            var emptyList = new List<TeamStats>();

            _teamsService.Setup(mockTeamsService => mockTeamsService.GetTeamStats(badId)).Returns(emptyList);

            var badReturn = _controller.GetTeamStats(badId);

            Assert.That(!badReturn.Any());
        }

        [Test]
        public void GetTeamsStatsByYearReturnsEnumerableTeamsStats()
        {
            var firstTeam = new TeamStats
            {
                TeamId = "SEA",
                YearId = 2000
            };

            var secondTeam = new TeamStats
            {
                TeamId = "NYY",
                YearId = 2000
            };

            var expectedRecord = new List<TeamStats>()
            {
                firstTeam,
                secondTeam
            };

            _teamsService.Setup(mockTeamsService => mockTeamsService.GetTeamStatsByYear(firstTeam.YearId)).Returns(expectedRecord);

            var actualReturn = _controller.GetTeamStatsByYear(firstTeam.YearId);

            Assert.That(actualReturn.ElementAt(0), Is.EqualTo(firstTeam));
            Assert.That(actualReturn.ElementAt(1), Is.EqualTo(secondTeam));
        }

        [Test]
        public void IfGetBattingByYearFailsToFindEntryItReturnsEmptyList()
        {
            int badId = 1;

            var emptyList = new List<TeamStats>();
            _teamsService.Setup(mockTeamsService => mockTeamsService.GetTeamStatsByYear(badId)).Returns(emptyList);

            var actualReturn = _controller.GetTeamStatsByYear(badId);

            Assert.That(!actualReturn.Any());

        }
    }

}