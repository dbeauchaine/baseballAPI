using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Moq;
using NUnit.Framework;
using System;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class BattingStatsMapperTests
    {
        private BattingStatsMapper _mapper;
        private Mock<StatsCalculator> _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Mock<StatsCalculator>();
            _mapper = new BattingStatsMapper(_calculator.Object);
        }

        [Test]
        public void MapCopiesDataFromBattingToBattingStats()
        {
            Batting batting = GenerateBattingWithoutNullValues();
            BattingStats battingStats = _mapper.Map(batting);

            AssertThatEachElementIsEqual(batting, battingStats);

            Batting battingWithNull = GenerateBattingWithNullValues();
            BattingStats battingStatsWithNull = _mapper.Map(battingWithNull);

            AssertThatEachElementIsEqual(battingWithNull, battingStatsWithNull);
        }

        [Test]
        public void MapYearCopiesDataFromBattingAndPlayerToBattingLeagueStats()
        {
            Batting batting = GenerateBattingWithPlayer();
            BattingStats battingStats = _mapper.Map(batting);

            AssertThatEachElementIsEqualWithPlayerValues(batting, battingStats);
        }

        [Test]
        public void MapCopiesDataFromBattingPostToBattingPostStats()
        {
            BattingPost battingPost = GenerateBattingPostWithoutNullValues();
            BattingPostStats battingPostStats = _mapper.Map(battingPost);

            AssertThatEachElementIsEqualPost(battingPost, battingPostStats);

            BattingPost battingWithNull = GenerateBattingPostWithNullValues();
            BattingPostStats battingStatsWithNull = _mapper.Map(battingWithNull);

            AssertThatEachElementIsEqualPost(battingWithNull, battingStatsWithNull);
        }



        private void AssertThatEachElementIsEqual(Batting batting, BattingStats battingStats)
        {
            Assert.That(battingStats.PlayerId, Is.EqualTo(batting.PlayerId));
            Assert.That(battingStats.YearId, Is.EqualTo(batting.YearId));
            Assert.That(battingStats.Stint, Is.EqualTo(batting.Stint));
            Assert.That(battingStats.TeamId, Is.EqualTo(batting.TeamId));
            Assert.That(battingStats.LgId, Is.EqualTo(batting.LgId));
            Assert.That(battingStats.G, Is.EqualTo(batting.G));
            Assert.That(battingStats.GBatting, Is.EqualTo(batting.GBatting));
            Assert.That(battingStats.Ab, Is.EqualTo(batting.Ab));
            Assert.That(battingStats.R, Is.EqualTo(batting.R));
            Assert.That(battingStats.H, Is.EqualTo(batting.H));
            Assert.That(battingStats.X2b, Is.EqualTo(batting.X2b));
            Assert.That(battingStats.X3b, Is.EqualTo(batting.X3b));
            Assert.That(battingStats.Hr, Is.EqualTo(batting.Hr));
            Assert.That(battingStats.Rbi, Is.EqualTo(batting.Rbi));
            Assert.That(battingStats.Sb, Is.EqualTo(batting.Sb));
            Assert.That(battingStats.Cs, Is.EqualTo(batting.Cs));
            Assert.That(battingStats.Bb, Is.EqualTo(batting.Bb));
            Assert.That(battingStats.So, Is.EqualTo(batting.So));
            Assert.That(battingStats.Ibb, Is.EqualTo(batting.Ibb));
            Assert.That(battingStats.Hbp, Is.EqualTo(batting.Hbp));
            Assert.That(battingStats.Sh, Is.EqualTo(batting.Sh));
            Assert.That(battingStats.Sf, Is.EqualTo(batting.Sf));
            Assert.That(battingStats.Gidp, Is.EqualTo(batting.Gidp));
        }


        private void AssertThatEachElementIsEqualWithPlayerValues(Batting batting, BattingStats battingStats)
        {
            Assert.That(battingStats.NameFirst, Is.EqualTo(batting.Player.NameFirst));
            Assert.That(battingStats.NameGiven, Is.EqualTo(batting.Player.NameGiven));
            Assert.That(battingStats.NameLast, Is.EqualTo(batting.Player.NameLast));
            Assert.That(battingStats.PlayerId, Is.EqualTo(batting.PlayerId));
            Assert.That(battingStats.YearId, Is.EqualTo(batting.YearId));
            Assert.That(battingStats.Stint, Is.EqualTo(batting.Stint));
            Assert.That(battingStats.TeamId, Is.EqualTo(batting.TeamId));
            Assert.That(battingStats.LgId, Is.EqualTo(batting.LgId));
            Assert.That(battingStats.G, Is.EqualTo(batting.G));
            Assert.That(battingStats.GBatting, Is.EqualTo(batting.GBatting));
            Assert.That(battingStats.Ab, Is.EqualTo(batting.Ab));
            Assert.That(battingStats.R, Is.EqualTo(batting.R));
            Assert.That(battingStats.H, Is.EqualTo(batting.H));
            Assert.That(battingStats.X2b, Is.EqualTo(batting.X2b));
            Assert.That(battingStats.X3b, Is.EqualTo(batting.X3b));
            Assert.That(battingStats.Hr, Is.EqualTo(batting.Hr));
            Assert.That(battingStats.Rbi, Is.EqualTo(batting.Rbi));
            Assert.That(battingStats.Sb, Is.EqualTo(batting.Sb));
            Assert.That(battingStats.Cs, Is.EqualTo(batting.Cs));
            Assert.That(battingStats.Bb, Is.EqualTo(batting.Bb));
            Assert.That(battingStats.So, Is.EqualTo(batting.So));
            Assert.That(battingStats.Ibb, Is.EqualTo(batting.Ibb));
            Assert.That(battingStats.Hbp, Is.EqualTo(batting.Hbp));
            Assert.That(battingStats.Sh, Is.EqualTo(batting.Sh));
            Assert.That(battingStats.Sf, Is.EqualTo(batting.Sf));
            Assert.That(battingStats.Gidp, Is.EqualTo(batting.Gidp));
        }
        private void AssertThatEachElementIsEqualPost(BattingPost battingPost, BattingPostStats battingPostStats)
        {
            Assert.That(battingPostStats.PlayerId, Is.EqualTo(battingPost.PlayerId));
            Assert.That(battingPostStats.YearId, Is.EqualTo(battingPost.YearId));
            Assert.That(battingPostStats.Round, Is.EqualTo(battingPost.Round));
            Assert.That(battingPostStats.TeamId, Is.EqualTo(battingPost.TeamId));
            Assert.That(battingPostStats.LgId, Is.EqualTo(battingPost.LgId));
            Assert.That(battingPostStats.G, Is.EqualTo(battingPost.G));
            Assert.That(battingPostStats.Ab, Is.EqualTo(battingPost.Ab));
            Assert.That(battingPostStats.R, Is.EqualTo(battingPost.R));
            Assert.That(battingPostStats.H, Is.EqualTo(battingPost.H));
            Assert.That(battingPostStats.X2b, Is.EqualTo(battingPost.X2b));
            Assert.That(battingPostStats.X3b, Is.EqualTo(battingPost.X3b));
            Assert.That(battingPostStats.Hr, Is.EqualTo(battingPost.Hr));
            Assert.That(battingPostStats.Rbi, Is.EqualTo(battingPost.Rbi));
            Assert.That(battingPostStats.Sb, Is.EqualTo(battingPost.Sb));
            Assert.That(battingPostStats.Cs, Is.EqualTo(battingPost.Cs));
            Assert.That(battingPostStats.Bb, Is.EqualTo(battingPost.Bb));
            Assert.That(battingPostStats.So, Is.EqualTo(battingPost.So));
            Assert.That(battingPostStats.Ibb, Is.EqualTo(battingPost.Ibb));
            Assert.That(battingPostStats.Hbp, Is.EqualTo(battingPost.Hbp));
            Assert.That(battingPostStats.Sh, Is.EqualTo(battingPost.Sh));
            Assert.That(battingPostStats.Sf, Is.EqualTo(battingPost.Sf));
            Assert.That(battingPostStats.Gidp, Is.EqualTo(battingPost.Gidp));
        }

        private Batting GenerateBattingWithoutNullValues()
        {
            return new Batting()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                G = 1,
                GBatting = 1,
                Ab = 4,
                R = 1,
                H = 2,
                X2b = 1,
                X3b = 0,
                Hr = 1,
                Rbi = 2,
                Sb = 1,
                Cs = 1,
                Bb = 1,
                So = 2,
                Ibb = 1,
                Hbp = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1
            };
        }

        private Batting GenerateBattingWithNullValues()
        {
            return new Batting()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                G = null,
                GBatting = null,
                Ab = null,
                R = null,
                H = null,
                X2b = null,
                X3b = null,
                Hr = null,
                Rbi = null,
                Sb = null,
                Cs = null,
                Bb = null,
                So = null,
                Ibb = null,
                Hbp = null,
                Sh = null,
                Sf = null,
                Gidp = null
            };
        }

        private Batting GenerateBattingWithPlayer()
        {
            return new Batting()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                G = 1,
                GBatting = 1,
                Ab = 4,
                R = 1,
                H = 2,
                X2b = 1,
                X3b = 0,
                Hr = 1,
                Rbi = 2,
                Sb = 1,
                Cs = 1,
                Bb = 1,
                So = 2,
                Ibb = 1,
                Hbp = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1,
                Player = new People()
                {
                    PlayerId = "id",
                    NameFirst = "first",
                    NameGiven = "first middle",
                    NameLast = "last"

                }
            };
        }
        private BattingPost GenerateBattingPostWithoutNullValues()
        {
            return new BattingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WS",
                TeamId = "team",
                LgId = "league",
                G = 1,
                Ab = 4,
                R = 1,
                H = 2,
                X2b = 1,
                X3b = 0,
                Hr = 1,
                Rbi = 2,
                Sb = 1,
                Cs = 1,
                Bb = 1,
                So = 2,
                Ibb = 1,
                Hbp = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1
            };
        }
        private BattingPost GenerateBattingPostWithNullValues()
        {
            return new BattingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
                TeamId = "team",
                LgId = "league",
                G = null,
                Ab = null,
                R = null,
                H = null,
                X2b = null,
                X3b = null,
                Hr = null,
                Rbi = null,
                Sb = null,
                Cs = null,
                Bb = null,
                So = null,
                Ibb = null,
                Hbp = null,
                Sh = null,
                Sf = null,
                Gidp = null
            };
        }
    }

}