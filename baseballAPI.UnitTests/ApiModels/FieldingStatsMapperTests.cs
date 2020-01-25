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
        public void MapCopiesDataFromFieldingToFieldingStats()
        {
            Fielding fielding = GenerateFieldingWithoutNullValues();
            FieldingStats fieldingStats = _mapper.Map(fielding);

            AssertThatEachElementIsEqual(fielding, fieldingStats);

            Fielding fieldingWithNull = GenerateFieldingWithNullValues();
            FieldingStats fieldingStatsWithNull = _mapper.Map(fieldingWithNull);

            AssertThatEachElementIsEqual(fieldingWithNull, fieldingStatsWithNull);
        }

        [Test]
        public void MapCopiesDataFromFieldingPostToFieldingPostStats()
        {
            FieldingPost fielding = GenerateFieldingPostWithoutNullValues();
            FieldingPostStats fieldingStats = _mapper.Map(fielding);

            AssertThatEachElementIsEqual(fielding, fieldingStats);

            FieldingPost fieldingPostWithNull = GenerateFieldingPostWithNullValues();
            FieldingPostStats fieldingPostStatsWithNull = _mapper.Map(fieldingPostWithNull);

            AssertThatEachElementIsEqual(fieldingPostWithNull, fieldingPostStatsWithNull);
        }

        private void AssertThatEachElementIsEqual(Fielding fielding, FieldingStats fieldingStats)
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

        private void AssertThatEachElementIsEqual(FieldingPost fieldingPost, FieldingPostStats fieldingPostStats)
        {
            Assert.That(fieldingPostStats.PlayerId, Is.EqualTo(fieldingPost.PlayerId));
            Assert.That(fieldingPostStats.YearId, Is.EqualTo(fieldingPost.YearId));
            Assert.That(fieldingPostStats.Round, Is.EqualTo(fieldingPost.Round));
            Assert.That(fieldingPostStats.TeamId, Is.EqualTo(fieldingPost.TeamId));
            Assert.That(fieldingPostStats.LgId, Is.EqualTo(fieldingPost.LgId));
            Assert.That(fieldingPostStats.G, Is.EqualTo(fieldingPost.G));
            Assert.That(fieldingPostStats.Pos, Is.EqualTo(fieldingPost.Pos));
            Assert.That(fieldingPostStats.Gs, Is.EqualTo(fieldingPost.Gs));
            Assert.That(fieldingPostStats.InnOuts, Is.EqualTo(fieldingPost.InnOuts));
            Assert.That(fieldingPostStats.Po, Is.EqualTo(fieldingPost.Po));
            Assert.That(fieldingPostStats.A, Is.EqualTo(fieldingPost.A));
            Assert.That(fieldingPostStats.E, Is.EqualTo(fieldingPost.E));
            Assert.That(fieldingPostStats.Dp, Is.EqualTo(fieldingPost.Dp));
            Assert.That(fieldingPostStats.Pb, Is.EqualTo(fieldingPost.Pb));
            Assert.That(fieldingPostStats.Sb, Is.EqualTo(fieldingPost.Sb));
            Assert.That(fieldingPostStats.Cs, Is.EqualTo(fieldingPost.Cs));
            Assert.That(fieldingPostStats.Tp, Is.EqualTo(fieldingPost.Tp));
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

        private FieldingPost GenerateFieldingPostWithoutNullValues()
        {
            return new FieldingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
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
                Tp = 1,
                Sb = 1,
                Cs = 1
            };
        }

        private FieldingPost GenerateFieldingPostWithNullValues()
        {
            return new FieldingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
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
                Tp = null,
                Sb = null,
                Cs = null
            };
        }
    }

}