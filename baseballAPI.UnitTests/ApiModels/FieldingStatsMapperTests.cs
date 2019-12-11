using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using NUnit.Framework;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class FieldingStatsMapperTests
    {
        private FieldingStatsMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new FieldingStatsMapper();
        }

        [Test]
        public void MapCopiesDataFromBattingToBattingStats()
        {
            Fielding fielding = GenerateFieldingWithoutNullValues();
            FieldingStats fieldingStats = _mapper.Map(fielding);

            AssertThatEachElementIsEqualWithoutNullValues(fielding, fieldingStats);

            Fielding fieldingWithNull = GenerateFieldingWithNullValues();
            FieldingStats fieldingStatsWithNull = _mapper.Map(fieldingWithNull);

            AssertThatEachElementIsEqualWithNullValues(fieldingWithNull, fieldingStatsWithNull);
        }

        private void AssertThatEachElementIsEqualWithoutNullValues(Fielding fielding, FieldingStats fieldingStats)
        {
            Assert.That(fieldingStats.PlayerId, Is.EqualTo(fielding.PlayerId));
            Assert.That(fieldingStats.YearId, Is.EqualTo(fielding.YearId));
            Assert.That(fieldingStats.Stint, Is.EqualTo(fielding.Stint));
            Assert.That(fieldingStats.TeamId, Is.EqualTo(fielding.TeamId));
            Assert.That(fieldingStats.LgId, Is.EqualTo(fielding.LgId));
            Assert.That(fieldingStats.G, Is.EqualTo(fielding.G));
            Assert.That(fieldingStats.Pos, Is.EqualTo(fielding.Pos));
            Assert.That(fieldingStats.Gs, Is.EqualTo(fielding.Gs));
            Assert.That(fieldingStats.InnOuts, Is.EqualTo(fielding.InnOuts));
            Assert.That(fieldingStats.Po, Is.EqualTo(fielding.Po));
            Assert.That(fieldingStats.A, Is.EqualTo(fielding.A));
            Assert.That(fieldingStats.E, Is.EqualTo(fielding.E));
            Assert.That(fieldingStats.Dp, Is.EqualTo(fielding.Dp));
            Assert.That(fieldingStats.Pb, Is.EqualTo(fielding.Pb));
            Assert.That(fieldingStats.Sb, Is.EqualTo(fielding.Sb));
            Assert.That(fieldingStats.Cs, Is.EqualTo(fielding.Cs));
            Assert.That(fieldingStats.Wp, Is.EqualTo(fielding.Wp));
            Assert.That(fieldingStats.Zr, Is.EqualTo(fielding.Zr));
        }

        private void AssertThatEachElementIsEqualWithNullValues(Fielding fielding, FieldingStats fieldingStats)
        {
            Assert.That(fieldingStats.PlayerId, Is.EqualTo(fielding.PlayerId));
            Assert.That(fieldingStats.YearId, Is.EqualTo(fielding.YearId));
            Assert.That(fieldingStats.Stint, Is.EqualTo(fielding.Stint));
            Assert.That(fieldingStats.TeamId, Is.EqualTo(fielding.TeamId));
            Assert.That(fieldingStats.LgId, Is.EqualTo(fielding.LgId));
            Assert.That(fieldingStats.Pos, Is.EqualTo(fielding.Pos));
            Assert.That(fieldingStats.G, Is.EqualTo(0));
            Assert.That(fieldingStats.Gs, Is.EqualTo(0));
            Assert.That(fieldingStats.InnOuts, Is.EqualTo(0));
            Assert.That(fieldingStats.Po, Is.EqualTo(0));
            Assert.That(fieldingStats.A, Is.EqualTo(0));
            Assert.That(fieldingStats.E, Is.EqualTo(0));
            Assert.That(fieldingStats.Dp, Is.EqualTo(0));
            Assert.That(fieldingStats.Pb, Is.EqualTo(0));
            Assert.That(fieldingStats.Sb, Is.EqualTo(0));
            Assert.That(fieldingStats.Cs, Is.EqualTo(0));
            Assert.That(fieldingStats.Wp, Is.EqualTo(0));
            Assert.That(fieldingStats.Zr, Is.EqualTo(0));
        }

        private Fielding GenerateFieldingWithoutNullValues()
        {
            return new Fielding()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                Pos = "C",
                G = 1,
                Gs = 1,
                InnOuts = 4,
                Po = 1,
                A = 2,
                E = 1,
                Dp = 0,
                Pb = 1,
                Wp = 2,
                Sb = 1,
                Cs = 1,
                Zr = 1
            };
        }

        private Fielding GenerateFieldingWithNullValues()
        {
            return new Fielding()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                Pos = "C",
                G = null,
                Gs = null,
                InnOuts = null,
                Po = null,
                A = null,
                E = null,
                Dp = null,
                Pb = null,
                Wp = null,
                Sb = null,
                Cs = null,
                Zr = null
            };
        }
    }

}