using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class TeamServiceTests
    {
        private BaseballDBContext _database;
        private TeamService _service;
        private DbContextOptions<BaseballDBContext> _options;
        private Teams _firstTeam;
        private Teams _secondTeam;
        private Teams _thirdTeam;
        private Mock<ITeamStatsMapper> _mockMapper;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<BaseballDBContext>()
                .UseInMemoryDatabase(databaseName: "TeamsServiceTests")
                .Options;
            _database = new BaseballDBContext(_options);
            _database.Database.EnsureDeleted();
            _mockMapper = new Mock<ITeamStatsMapper>();

            _service = new TeamService(_database, _mockMapper.Object);

            CreateFakeData();
        }

        [Test]
        public void GetTeamStatsReturnsStats()
        {
            AssertGetTeamsStatsReturnsStats(_firstTeam);
            AssertGetTeamsStatsReturnsStats(_secondTeam);
            AssertGetTeamsStatsReturnsStatsWithDuplicateId(_firstTeam, _thirdTeam);
        }

        [Test]
        public void GetTeamStatsByYearReturnsStats()
        {
            AssertGetTeamsStatsByYearReturnsStats(_firstTeam, _secondTeam);
        }

        [Test]
        public void GetTeamStatsByTeamReturnsStats()
        {
            AssertGetTeamStatsByTeamReturnsStats(_firstTeam, _thirdTeam);
        }

        private void AssertGetTeamStatsByTeamReturnsStats(Teams firstEntry, Teams secondEntry)
        {
            var firstEntryStats = new TeamStats();
            var secondEntryStats = new TeamStats();

            _mockMapper.Setup(mockTeamMapper => mockTeamMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockTeamMapper => mockTeamMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualTeams = _service.GetTeamStats(firstEntry.TeamId);

            Assert.That(actualTeams.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualTeams.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        private void AssertGetTeamsStatsByYearReturnsStats(Teams firstEntry, Teams secondEntry)
        {
            var firstEntryByYear = new TeamStats();
            var secondEntryByYear = new TeamStats();

            _mockMapper.Setup(mockTeamsMapper => mockTeamsMapper.Map(firstEntry)).Returns(firstEntryByYear);
            _mockMapper.Setup(mockTeamsMapper => mockTeamsMapper.Map(secondEntry)).Returns(secondEntryByYear);

            var actualTeams = _service.GetTeamStatsByYear(firstEntry.YearId);

            Assert.That(actualTeams.ElementAt(0), Is.EqualTo(firstEntryByYear));
            Assert.That(actualTeams.ElementAt(1), Is.EqualTo(secondEntryByYear));
        }

        private void AssertGetTeamsStatsReturnsStatsWithDuplicateId(Teams firstEntry, Teams secondEntry)
        {
            var firstEntryStats = new TeamStats();
            var secondEntryStats = new TeamStats();

            _mockMapper.Setup(mockTeamsMapper => mockTeamsMapper.Map(firstEntry)).Returns(firstEntryStats);
            _mockMapper.Setup(mockTeamsMapper => mockTeamsMapper.Map(secondEntry)).Returns(secondEntryStats);

            var actualTeams = _service.GetTeamStats(firstEntry.TeamId);

            Assert.That(actualTeams.ElementAt(0), Is.EqualTo(firstEntryStats));
            Assert.That(actualTeams.ElementAt(1), Is.EqualTo(secondEntryStats));
        }

        private void AssertGetTeamsStatsReturnsStats(Teams expectedTeam)
        {
            var expectedTeamStats = new TeamStats();

            _mockMapper.Setup(mockTeamsMapper => mockTeamsMapper.Map(expectedTeam)).Returns(expectedTeamStats);

            var actualTeams = _service.GetTeamStats(expectedTeam.TeamId);

            Assert.That(actualTeams.ElementAt(0), Is.EqualTo(expectedTeamStats));
        }

        public void CreateFakeData()
        {
            _firstTeam = new Teams()
            {
                YearId = 2000,
                Hr = 20,
                Ab = 100,
                TeamId = "SE1",
                FranchId ="SEA",
                LgId = "AL"
            };

            _secondTeam = new Teams()
            {
                YearId = 2000,
                Hr = 10,
                Ab = 200,
                TeamId = "AT1",
                FranchId="ATL",
                LgId ="NL"
            };

            _thirdTeam = new Teams()
            {
                YearId = 1999,
                Hr = 18,
                Ab = 99,
                TeamId = "SE1",
                FranchId = "SEA",
                LgId = "AL"
            };

            _database.Add(_firstTeam);
            _database.Add(_secondTeam);
            _database.Add(_thirdTeam);
            _database.SaveChanges();
        }
    }
}