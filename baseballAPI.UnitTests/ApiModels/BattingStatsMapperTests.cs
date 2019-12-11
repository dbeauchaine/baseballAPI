﻿using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using NUnit.Framework;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class BattingStatsMapperTests
    {
        private BattingStatsMapper _mapper;
        [SetUp]
        public void SetUp()
        {
            _mapper = new BattingStatsMapper();
        }

        [Test]
        public void MapCopiesDataFromBattingToBattingStats()
        {
            Batting batting = GenerateBattingWithoutNullValues();
            BattingStats battingStats = _mapper.Map(batting);

            AssertThatEachElementIsEqualWithoutNullValues(batting, battingStats);

            Batting battingWithNull = GenerateBattingWithNullValues();
            BattingStats battingStatsWithNull = _mapper.Map(battingWithNull);

            AssertThatEachElementIsEqualWithNullValues(battingWithNull, battingStatsWithNull);
        }

        private void AssertThatEachElementIsEqualWithoutNullValues(Batting batting, BattingStats battingStats)
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

        private void AssertThatEachElementIsEqualWithNullValues(Batting batting, BattingStats battingStats)
        {
            Assert.That(battingStats.PlayerId, Is.EqualTo(batting.PlayerId));
            Assert.That(battingStats.YearId, Is.EqualTo(batting.YearId));
            Assert.That(battingStats.Stint, Is.EqualTo(batting.Stint));
            Assert.That(battingStats.TeamId, Is.EqualTo(batting.TeamId));
            Assert.That(battingStats.LgId, Is.EqualTo(batting.LgId));
            Assert.That(battingStats.G, Is.EqualTo(0));
            Assert.That(battingStats.GBatting, Is.EqualTo(0));
            Assert.That(battingStats.Ab, Is.EqualTo(0));
            Assert.That(battingStats.R, Is.EqualTo(0));
            Assert.That(battingStats.H, Is.EqualTo(0));
            Assert.That(battingStats.X2b, Is.EqualTo(0));
            Assert.That(battingStats.X3b, Is.EqualTo(0));
            Assert.That(battingStats.Hr, Is.EqualTo(0));
            Assert.That(battingStats.Rbi, Is.EqualTo(0));
            Assert.That(battingStats.Sb, Is.EqualTo(0));
            Assert.That(battingStats.Cs, Is.EqualTo(0));
            Assert.That(battingStats.Bb, Is.EqualTo(0));
            Assert.That(battingStats.So, Is.EqualTo(0));
            Assert.That(battingStats.Ibb, Is.EqualTo(0));
            Assert.That(battingStats.Hbp, Is.EqualTo(0));
            Assert.That(battingStats.Sh, Is.EqualTo(0));
            Assert.That(battingStats.Sf, Is.EqualTo(0));
            Assert.That(battingStats.Gidp, Is.EqualTo(0));
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
    }

}