using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Moq;
using NUnit.Framework;
using System;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class TeamStatsMapperTests
    {
        private TeamStatsMapper _mapper;
        private Mock<StatsCalculator> _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Mock<StatsCalculator>();
            _mapper = new TeamStatsMapper(_calculator.Object);
        }

        [Test]
        public void MapCopiesDataFromTeamsToTeamStats()
        {
            Teams teams = GenerateTeamsWithoutNullValues();
            TeamStats teamStats = _mapper.Map(teams);

            AssertThatEachElementIsEqualWithoutNullValues(teams, teamStats);

            Teams teamsWithNull = GenerateTeamsWithNullValues();
            TeamStats teamsStatsWithNull = _mapper.Map(teamsWithNull);

            AssertThatEachElementIsEqualWithNullValues(teamsWithNull, teamsStatsWithNull);
        }

        private void AssertThatEachElementIsEqualWithoutNullValues(Teams teams, TeamStats teamStats)
        {
            Assert.That(teamStats.YearId, Is.EqualTo(teams.YearId));
            Assert.That(teamStats.LgId, Is.EqualTo(teams.LgId));
            Assert.That(teamStats.TeamId, Is.EqualTo(teams.TeamId));
            Assert.That(teamStats.FranchId, Is.EqualTo(teams.FranchId));
            Assert.That(teamStats.DivId, Is.EqualTo(teams.DivId));
            Assert.That(teamStats.Rank, Is.EqualTo(teams.Rank));
            Assert.That(teamStats.G, Is.EqualTo(teams.G));
            Assert.That(teamStats.Ghome, Is.EqualTo(teams.Ghome));
            Assert.That(teamStats.W, Is.EqualTo(teams.W));
            Assert.That(teamStats.L, Is.EqualTo(teams.L));
            Assert.That(teamStats.DivWin, Is.EqualTo(teams.DivWin));
            Assert.That(teamStats.Wcwin, Is.EqualTo(teams.Wcwin));
            Assert.That(teamStats.LgWin, Is.EqualTo(teams.LgWin));
            Assert.That(teamStats.Wswin, Is.EqualTo(teams.Wswin));
            Assert.That(teamStats.R, Is.EqualTo(teams.R));
            Assert.That(teamStats.Ab, Is.EqualTo(teams.Ab));
            Assert.That(teamStats.H, Is.EqualTo(teams.H));
            Assert.That(teamStats.X2b, Is.EqualTo(teams.X2b));
            Assert.That(teamStats.X3b, Is.EqualTo(teams.X3b));
            Assert.That(teamStats.Hr, Is.EqualTo(teams.Hr));
            Assert.That(teamStats.Bb, Is.EqualTo(teams.Bb));
            Assert.That(teamStats.So, Is.EqualTo(teams.So));
            Assert.That(teamStats.Sb, Is.EqualTo(teams.Sb));
            Assert.That(teamStats.Cs, Is.EqualTo(teams.Cs));
            Assert.That(teamStats.Hbp, Is.EqualTo(teams.Hbp));
            Assert.That(teamStats.Sf, Is.EqualTo(teams.Sf));
            Assert.That(teamStats.Ra, Is.EqualTo(teams.Ra));
            Assert.That(teamStats.Er, Is.EqualTo(teams.Er));
            Assert.That(teamStats.Era, Is.EqualTo(Math.Round((double)teams.Era/100,3)));
            Assert.That(teamStats.Cg, Is.EqualTo(teams.Cg));
            Assert.That(teamStats.Sho, Is.EqualTo(teams.Sho));
            Assert.That(teamStats.Sv, Is.EqualTo(teams.Sv));
            Assert.That(teamStats.Ipouts, Is.EqualTo(teams.Ipouts));
            Assert.That(teamStats.Ha, Is.EqualTo(teams.Ha));
            Assert.That(teamStats.Hra, Is.EqualTo(teams.Hra));
            Assert.That(teamStats.Bba, Is.EqualTo(teams.Bba));
            Assert.That(teamStats.Soa, Is.EqualTo(teams.Soa));
            Assert.That(teamStats.E, Is.EqualTo(teams.E));
            Assert.That(teamStats.Dp, Is.EqualTo(teams.Dp));
            Assert.That(teamStats.Fp, Is.EqualTo(teams.Fp));
            Assert.That(teamStats.Name, Is.EqualTo(teams.Name));
            Assert.That(teamStats.Park, Is.EqualTo(teams.Park));
            Assert.That(teamStats.Attendance, Is.EqualTo(teams.Attendance));
            Assert.That(teamStats.Bpf, Is.EqualTo(teams.Bpf));
            Assert.That(teamStats.Ppf, Is.EqualTo(teams.Ppf));
            Assert.That(teamStats.TeamIdbr, Is.EqualTo(teams.TeamIdbr));
            Assert.That(teamStats.TeamIdlahman45, Is.EqualTo(teams.TeamIdlahman45));
            Assert.That(teamStats.TeamIdretro, Is.EqualTo(teams.TeamIdretro));
        }

        private void AssertThatEachElementIsEqualWithNullValues(Teams teams, TeamStats teamStats)
        {
            Assert.That(teamStats.YearId, Is.EqualTo(teams.YearId));
            Assert.That(teamStats.LgId, Is.EqualTo(teams.LgId));
            Assert.That(teamStats.TeamId, Is.EqualTo(teams.TeamId));
            Assert.That(teamStats.FranchId, Is.EqualTo(teams.FranchId));
            Assert.That(teamStats.DivId, Is.EqualTo(teams.DivId));
            Assert.That(teamStats.Rank, Is.EqualTo(0));
            Assert.That(teamStats.G, Is.EqualTo(0));
            Assert.That(teamStats.Ghome, Is.EqualTo(0));
            Assert.That(teamStats.W, Is.EqualTo(0));
            Assert.That(teamStats.L, Is.EqualTo(0));
            Assert.That(teamStats.DivWin, Is.EqualTo(teams.DivWin));
            Assert.That(teamStats.Wcwin, Is.EqualTo(teams.Wcwin));
            Assert.That(teamStats.LgWin, Is.EqualTo(teams.LgWin));
            Assert.That(teamStats.Wswin, Is.EqualTo(teams.Wswin));
            Assert.That(teamStats.R, Is.EqualTo(0));
            Assert.That(teamStats.Ab, Is.EqualTo(0));
            Assert.That(teamStats.H, Is.EqualTo(0));
            Assert.That(teamStats.X2b, Is.EqualTo(0));
            Assert.That(teamStats.X3b, Is.EqualTo(0));
            Assert.That(teamStats.Hr, Is.EqualTo(0));
            Assert.That(teamStats.Bb, Is.EqualTo(0));
            Assert.That(teamStats.So, Is.EqualTo(0));
            Assert.That(teamStats.Sb, Is.EqualTo(0));
            Assert.That(teamStats.Cs, Is.EqualTo(0));
            Assert.That(teamStats.Hbp, Is.EqualTo(0));
            Assert.That(teamStats.Sf, Is.EqualTo(0));
            Assert.That(teamStats.Ra, Is.EqualTo(0));
            Assert.That(teamStats.Er, Is.EqualTo(0));
            Assert.That(teamStats.Era, Is.EqualTo(0));
            Assert.That(teamStats.Cg, Is.EqualTo(0));
            Assert.That(teamStats.Sho, Is.EqualTo(0));
            Assert.That(teamStats.Sv, Is.EqualTo(0));
            Assert.That(teamStats.Ipouts, Is.EqualTo(0));
            Assert.That(teamStats.Ha, Is.EqualTo(0));
            Assert.That(teamStats.Hra, Is.EqualTo(0));
            Assert.That(teamStats.Bba, Is.EqualTo(0));
            Assert.That(teamStats.Soa, Is.EqualTo(0));
            Assert.That(teamStats.E, Is.EqualTo(0));
            Assert.That(teamStats.Dp, Is.EqualTo(0));
            Assert.That(teamStats.Fp, Is.EqualTo(0));
            Assert.That(teamStats.Name, Is.EqualTo(teams.Name));
            Assert.That(teamStats.Park, Is.EqualTo(teams.Park));
            Assert.That(teamStats.Attendance, Is.EqualTo(0));
            Assert.That(teamStats.Bpf, Is.EqualTo(0));
            Assert.That(teamStats.Ppf, Is.EqualTo(0));
            Assert.That(teamStats.TeamIdbr, Is.EqualTo(teams.TeamIdbr));
            Assert.That(teamStats.TeamIdlahman45, Is.EqualTo(teams.TeamIdlahman45));
            Assert.That(teamStats.TeamIdretro, Is.EqualTo(teams.TeamIdretro));
        }

        private Teams GenerateTeamsWithoutNullValues()
        {
            return new Teams()
            {
                YearId = 2000,
                LgId = "league",
                TeamId = "id",
                FranchId = "francId",
                DivId = "divId",
                Rank = 1,
                G = 2,
                Ghome = 1,
                W = 1,
                L = 1,
                DivWin = "N",
                Wcwin = "N",
                LgWin = "N",
                Wswin = "N",
                R = 1,
                Ab = 4,
                H = 2,
                X2b = 1,
                X3b = 0,
                Hr = 1,
                Bb = 1,
                So = 2,
                Sb = 1,
                Cs = 1,
                Hbp = 1,
                Sf = 1,
                Ra = 1,
                Er = 1,
                Era = 9.0,
                Cg = 1,
                Sho = 1,
                Sv = 1,
                Ipouts = 3,
                Ha = 1,
                Hra = 1,
                Bba = 1,
                Soa = 1,
                E = 3,
                Dp = 2,
                Fp = 1,
                Name = "name",
                Park = "park",
                Attendance = 10000,
                Bpf = 1,
                Ppf = 1,
                TeamIdbr = "idBR",
                TeamIdlahman45 = "idLah",
                TeamIdretro = "idRetro"
            };
        }

        private Teams GenerateTeamsWithNullValues()
        {
            return new Teams()
            {
                YearId = 2000,
                LgId = "league",
                TeamId = "id",
                FranchId = "francId",
                DivId = "divId",
                Rank = null,
                G = null,
                Ghome = null,
                W = null,
                L = null,
                DivWin = "N",
                Wcwin = "N",
                LgWin = "N",
                Wswin = "N",
                R = null,
                Ab = null,
                H = null,
                X2b = null,
                X3b = null,
                Hr = null,
                Hra = null,
                Bb = null,
                So = null,
                Sb = null,
                Cs = null,
                Hbp = null,
                Sf = null,
                Ra = null,
                Er = null,
                Era = null,
                Cg = null,
                Sho = null,
                Sv = null,
                Ipouts = null,
                Ha = null,
                Bba = null,
                Soa = null,
                E = null,
                Dp = null,
                Fp = null,
                Name = "name",
                Park = "park",
                Attendance = null,
                Bpf = null,
                Ppf = null,
                TeamIdbr = "idBR",
                TeamIdlahman45 = "idLah",
                TeamIdretro = "idRetro"
            };
        }
    }

}