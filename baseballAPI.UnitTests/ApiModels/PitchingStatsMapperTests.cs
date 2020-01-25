using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Moq;
using NUnit.Framework;
using System;

namespace BaseballAPI.UnitTests.Controllers
{
    [TestFixture]
    [Category("Unit")]
    public class PitchingStatsMapperTests
    {
        private PitchingStatsMapper _mapper;
        private Mock<StatsCalculator> _calculator;
        [SetUp]
        public void SetUp()
        {
            _calculator = new Mock<StatsCalculator>();
            _mapper = new PitchingStatsMapper(_calculator.Object);
        }

        [Test]
        public void MapCopiesDataFromPitchingToPitchingStats()
        {
            Pitching pitching = GeneratePitchingWithoutNullValues();
            PitchingStats pitchingStats = _mapper.Map(pitching);

            AssertThatEachElementIsEqual(pitching, pitchingStats);

            Pitching pitchingWithNull = GeneratePitchingWithNullValues();
            PitchingStats pitchingStatsWithNull = _mapper.Map(pitchingWithNull);

            AssertThatEachElementIsEqual(pitchingWithNull, pitchingStatsWithNull);
        }

        [Test]
        public void MapYearCopiesDataFromPitchingAndPlayerToPitchingStats()
        {
            Pitching pitching = GeneratePitchingWithPlayer();
            PitchingStats pitchingLeaderBoardStats = _mapper.Map(pitching);

            AssertThatEachElementIsEqualWithPlayerValues(pitching, pitchingLeaderBoardStats);
        }

        [Test]
        public void MapCopiesDataFromPitchingPostToPitchingPostStats()
        {
            PitchingPost pitchingPost = GeneratePitchingPostWithoutNullValues();
            PitchingPostStats pitchingPostStats = _mapper.Map(pitchingPost);

            AssertThatEachElementIsEqual(pitchingPost, pitchingPostStats);

            PitchingPost pitchingWithNull = GeneratePitchingPostWithNullValues();
            PitchingPostStats pitchingStatsWithNull = _mapper.Map(pitchingWithNull);

            AssertThatEachElementIsEqual(pitchingWithNull, pitchingStatsWithNull);
        }

        [Test]
        public void MapYearCopiesDataFromPitchingPostAndPlayerToPitchingPostStats()
        {
            PitchingPost pitching = GeneratePitchingPostWithPlayer();
            PitchingPostStats pitchingLeaderBoardStats = _mapper.Map(pitching);

            AssertThatEachElementIsEqualWithPlayerValues(pitching, pitchingLeaderBoardStats);
        }

        private void AssertThatEachElementIsEqual(Pitching pitching, PitchingStats pitchingStats)
        {
            Assert.That(pitchingStats.PlayerId, Is.EqualTo(pitching.PlayerId));
            Assert.That(pitchingStats.YearId, Is.EqualTo(pitching.YearId));
            Assert.That(pitchingStats.Stint, Is.EqualTo(pitching.Stint));
            Assert.That(pitchingStats.TeamId, Is.EqualTo(pitching.TeamId));
            Assert.That(pitchingStats.LgId, Is.EqualTo(pitching.LgId));
            Assert.That(pitchingStats.W, Is.EqualTo(pitching.W));
            Assert.That(pitchingStats.L, Is.EqualTo(pitching.L));
            Assert.That(pitchingStats.G, Is.EqualTo(pitching.G));
            Assert.That(pitchingStats.Gs, Is.EqualTo(pitching.Gs));
            Assert.That(pitchingStats.Cg, Is.EqualTo(pitching.Cg));
            Assert.That(pitchingStats.Sho, Is.EqualTo(pitching.Sho));
            Assert.That(pitchingStats.Sv, Is.EqualTo(pitching.Sv));
            Assert.That(pitchingStats.Ipouts, Is.EqualTo(pitching.Ipouts));
            Assert.That(pitchingStats.H, Is.EqualTo(pitching.H));
            Assert.That(pitchingStats.Er, Is.EqualTo(pitching.Er));
            Assert.That(pitchingStats.Hr, Is.EqualTo(pitching.Hr));
            Assert.That(pitchingStats.Bb, Is.EqualTo(pitching.Bb));
            Assert.That(pitchingStats.So, Is.EqualTo(pitching.So));
            Assert.That(pitchingStats.Baopp, Is.EqualTo(pitching.Baopp));
            var localEra = pitching.Era / 100 ?? 0;
            Assert.That(pitchingStats.Era, Is.EqualTo(Math.Round(localEra,2)));
            Assert.That(pitchingStats.Ibb, Is.EqualTo(pitching.Ibb));
            Assert.That(pitchingStats.Wp, Is.EqualTo(pitching.Wp));
            Assert.That(pitchingStats.Hbp, Is.EqualTo(pitching.Hbp));
            Assert.That(pitchingStats.Bk, Is.EqualTo(pitching.Bk));
            Assert.That(pitchingStats.Bfp, Is.EqualTo(pitching.Bfp));
            Assert.That(pitchingStats.Gf, Is.EqualTo(pitching.Gf));
            Assert.That(pitchingStats.R, Is.EqualTo(pitching.R));
            Assert.That(pitchingStats.Sh, Is.EqualTo(pitching.Sh));
            Assert.That(pitchingStats.Sf, Is.EqualTo(pitching.Sf));
            Assert.That(pitchingStats.Gidp, Is.EqualTo(pitching.Gidp));
        }

        private void AssertThatEachElementIsEqualWithPlayerValues(Pitching pitching, PitchingStats pitchingStats)
        {
            Assert.That(pitchingStats.NameFirst, Is.EqualTo(pitching.Player.NameFirst));
            Assert.That(pitchingStats.NameGiven, Is.EqualTo(pitching.Player.NameGiven));
            Assert.That(pitchingStats.NameLast, Is.EqualTo(pitching.Player.NameLast));
            Assert.That(pitchingStats.PlayerId, Is.EqualTo(pitching.PlayerId));
            Assert.That(pitchingStats.YearId, Is.EqualTo(pitching.YearId));
            Assert.That(pitchingStats.Stint, Is.EqualTo(pitching.Stint));
            Assert.That(pitchingStats.TeamId, Is.EqualTo(pitching.TeamId));
            Assert.That(pitchingStats.LgId, Is.EqualTo(pitching.LgId));
            Assert.That(pitchingStats.W, Is.EqualTo(pitching.W));
            Assert.That(pitchingStats.L, Is.EqualTo(pitching.L));
            Assert.That(pitchingStats.G, Is.EqualTo(pitching.G));
            Assert.That(pitchingStats.Gs, Is.EqualTo(pitching.Gs));
            Assert.That(pitchingStats.Cg, Is.EqualTo(pitching.Cg));
            Assert.That(pitchingStats.Sho, Is.EqualTo(pitching.Sho));
            Assert.That(pitchingStats.Sv, Is.EqualTo(pitching.Sv));
            Assert.That(pitchingStats.Ipouts, Is.EqualTo(pitching.Ipouts));
            Assert.That(pitchingStats.H, Is.EqualTo(pitching.H));
            Assert.That(pitchingStats.Er, Is.EqualTo(pitching.Er));
            Assert.That(pitchingStats.Hr, Is.EqualTo(pitching.Hr));
            Assert.That(pitchingStats.Bb, Is.EqualTo(pitching.Bb));
            Assert.That(pitchingStats.So, Is.EqualTo(pitching.So));
            Assert.That(pitchingStats.Baopp, Is.EqualTo(pitching.Baopp));
            var localEra = pitching.Era / 100 ?? 0;
            Assert.That(pitchingStats.Era, Is.EqualTo(Math.Round(localEra, 2)));
            Assert.That(pitchingStats.Ibb, Is.EqualTo(pitching.Ibb));
            Assert.That(pitchingStats.Wp, Is.EqualTo(pitching.Wp));
            Assert.That(pitchingStats.Hbp, Is.EqualTo(pitching.Hbp));
            Assert.That(pitchingStats.Bk, Is.EqualTo(pitching.Bk));
            Assert.That(pitchingStats.Bfp, Is.EqualTo(pitching.Bfp));
            Assert.That(pitchingStats.Gf, Is.EqualTo(pitching.Gf));
            Assert.That(pitchingStats.R, Is.EqualTo(pitching.R));
            Assert.That(pitchingStats.Sh, Is.EqualTo(pitching.Sh));
            Assert.That(pitchingStats.Sf, Is.EqualTo(pitching.Sf));
            Assert.That(pitchingStats.Gidp, Is.EqualTo(pitching.Gidp));
        }

        private void AssertThatEachElementIsEqual(PitchingPost pitching, PitchingPostStats pitchingStats)
        {
            Assert.That(pitchingStats.PlayerId, Is.EqualTo(pitching.PlayerId));
            Assert.That(pitchingStats.YearId, Is.EqualTo(pitching.YearId));
            Assert.That(pitchingStats.Round, Is.EqualTo(pitching.Round));
            Assert.That(pitchingStats.TeamId, Is.EqualTo(pitching.TeamId));
            Assert.That(pitchingStats.LgId, Is.EqualTo(pitching.LgId));
            Assert.That(pitchingStats.W, Is.EqualTo(pitching.W));
            Assert.That(pitchingStats.L, Is.EqualTo(pitching.L));
            Assert.That(pitchingStats.G, Is.EqualTo(pitching.G));
            Assert.That(pitchingStats.Gs, Is.EqualTo(pitching.Gs));
            Assert.That(pitchingStats.Cg, Is.EqualTo(pitching.Cg));
            Assert.That(pitchingStats.Sho, Is.EqualTo(pitching.Sho));
            Assert.That(pitchingStats.Sv, Is.EqualTo(pitching.Sv));
            Assert.That(pitchingStats.Ipouts, Is.EqualTo(pitching.Ipouts));
            Assert.That(pitchingStats.H, Is.EqualTo(pitching.H));
            Assert.That(pitchingStats.Er, Is.EqualTo(pitching.Er));
            Assert.That(pitchingStats.Hr, Is.EqualTo(pitching.Hr));
            Assert.That(pitchingStats.Bb, Is.EqualTo(pitching.Bb));
            Assert.That(pitchingStats.So, Is.EqualTo(pitching.So));
            Assert.That(pitchingStats.Baopp, Is.EqualTo(pitching.Baopp));
            var localEra = pitching.Era / 100 ?? 0;
            Assert.That(pitchingStats.Era, Is.EqualTo(Math.Round(localEra, 2)));
            Assert.That(pitchingStats.Ibb, Is.EqualTo(pitching.Ibb));
            Assert.That(pitchingStats.Wp, Is.EqualTo(pitching.Wp));
            Assert.That(pitchingStats.Hbp, Is.EqualTo(pitching.Hbp));
            Assert.That(pitchingStats.Bk, Is.EqualTo(pitching.Bk));
            Assert.That(pitchingStats.Bfp, Is.EqualTo(pitching.Bfp));
            Assert.That(pitchingStats.Gf, Is.EqualTo(pitching.Gf));
            Assert.That(pitchingStats.R, Is.EqualTo(pitching.R));
            Assert.That(pitchingStats.Sh, Is.EqualTo(pitching.Sh));
            Assert.That(pitchingStats.Sf, Is.EqualTo(pitching.Sf));
            Assert.That(pitchingStats.Gidp, Is.EqualTo(pitching.Gidp));
        }

        private void AssertThatEachElementIsEqualWithPlayerValues(PitchingPost pitching, PitchingPostStats pitchingStats)
        {
            Assert.That(pitchingStats.NameFirst, Is.EqualTo(pitching.Player.NameFirst));
            Assert.That(pitchingStats.NameGiven, Is.EqualTo(pitching.Player.NameGiven));
            Assert.That(pitchingStats.NameLast, Is.EqualTo(pitching.Player.NameLast));
            Assert.That(pitchingStats.PlayerId, Is.EqualTo(pitching.PlayerId));
            Assert.That(pitchingStats.YearId, Is.EqualTo(pitching.YearId));
            Assert.That(pitchingStats.Round, Is.EqualTo(pitching.Round));
            Assert.That(pitchingStats.TeamId, Is.EqualTo(pitching.TeamId));
            Assert.That(pitchingStats.LgId, Is.EqualTo(pitching.LgId));
            Assert.That(pitchingStats.W, Is.EqualTo(pitching.W));
            Assert.That(pitchingStats.L, Is.EqualTo(pitching.L));
            Assert.That(pitchingStats.G, Is.EqualTo(pitching.G));
            Assert.That(pitchingStats.Gs, Is.EqualTo(pitching.Gs));
            Assert.That(pitchingStats.Cg, Is.EqualTo(pitching.Cg));
            Assert.That(pitchingStats.Sho, Is.EqualTo(pitching.Sho));
            Assert.That(pitchingStats.Sv, Is.EqualTo(pitching.Sv));
            Assert.That(pitchingStats.Ipouts, Is.EqualTo(pitching.Ipouts));
            Assert.That(pitchingStats.H, Is.EqualTo(pitching.H));
            Assert.That(pitchingStats.Er, Is.EqualTo(pitching.Er));
            Assert.That(pitchingStats.Hr, Is.EqualTo(pitching.Hr));
            Assert.That(pitchingStats.Bb, Is.EqualTo(pitching.Bb));
            Assert.That(pitchingStats.So, Is.EqualTo(pitching.So));
            Assert.That(pitchingStats.Baopp, Is.EqualTo(pitching.Baopp));
            var localEra = pitching.Era / 100 ?? 0;
            Assert.That(pitchingStats.Era, Is.EqualTo(Math.Round(localEra, 2)));
            Assert.That(pitchingStats.Ibb, Is.EqualTo(pitching.Ibb));
            Assert.That(pitchingStats.Wp, Is.EqualTo(pitching.Wp));
            Assert.That(pitchingStats.Hbp, Is.EqualTo(pitching.Hbp));
            Assert.That(pitchingStats.Bk, Is.EqualTo(pitching.Bk));
            Assert.That(pitchingStats.Bfp, Is.EqualTo(pitching.Bfp));
            Assert.That(pitchingStats.Gf, Is.EqualTo(pitching.Gf));
            Assert.That(pitchingStats.R, Is.EqualTo(pitching.R));
            Assert.That(pitchingStats.Sh, Is.EqualTo(pitching.Sh));
            Assert.That(pitchingStats.Sf, Is.EqualTo(pitching.Sf));
            Assert.That(pitchingStats.Gidp, Is.EqualTo(pitching.Gidp));
        }

        private Pitching GeneratePitchingWithoutNullValues()
        {
            return new Pitching()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                W =1,
                L = 1,
                G = 1,
                Gs = 1,
                Cg = 1,
                Sho = 4,
                Sv = 2,
                Ipouts = 1,
                H = 2,
                Er =1,
                Hr = 1,
                Bb = 1,
                So = 2,
                Baopp = 1,
                Era = 1,
                Ibb = 1,
                Wp = 1,
                Hbp = 1,
                Bk = 1,
                Bfp =1,
                Gf = 1,
                R = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1,
            };
        }

        private Pitching GeneratePitchingWithNullValues()
        {
            return new Pitching()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                W = null,
                L = null,
                G = null,
                Gs = null,
                Cg = null,
                Sho = null,
                Sv = null,
                Ipouts = null,
                H = null,
                Er = null,
                Hr = null,
                Bb = null,
                So = null,
                Baopp = null,
                Era = null,
                Ibb = null,
                Wp = null,
                Hbp = null,
                Bk = null,
                Bfp = null,
                Gf = null,
                R = null,
                Sh = null,
                Sf = null,
                Gidp = null,
            };
        }

        private Pitching GeneratePitchingWithPlayer()
        {
            return new Pitching()
            {
                PlayerId = "id",
                YearId = 2000,
                Stint = 2,
                TeamId = "team",
                LgId = "league",
                W = 1,
                L = 1,
                G = 1,
                Gs = 1,
                Cg = 1,
                Sho = 4,
                Sv = 2,
                Ipouts = 1,
                H = 2,
                Er = 1,
                Hr = 1,
                Bb = 1,
                So = 2,
                Baopp = 1,
                Era = 1,
                Ibb = 1,
                Wp = 1,
                Hbp = 1,
                Bk = 1,
                Bfp = 1,
                Gf = 1,
                R = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1,
                Player = new People() { 
                    PlayerId = "id",
                    NameFirst = "first",
                    NameGiven = "first middle",
                    NameLast = "last"
                
                }
            };
        }
        private PitchingPost GeneratePitchingPostWithoutNullValues()
        {
            return new PitchingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
                TeamId = "team",
                LgId = "league",
                W = 1,
                L = 1,
                G = 1,
                Gs = 1,
                Cg = 1,
                Sho = 4,
                Sv = 2,
                Ipouts = 1,
                H = 2,
                Er = 1,
                Hr = 1,
                Bb = 1,
                So = 2,
                Baopp = 1,
                Era = 1,
                Ibb = 1,
                Wp = 1,
                Hbp = 1,
                Bk = 1,
                Bfp = 1,
                Gf = 1,
                R = 1,
                Sh = 1,
                Sf = 1,
                Gidp = 1,
            };
        }

        private PitchingPost GeneratePitchingPostWithNullValues()
        {
            return new PitchingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
                TeamId = "team",
                LgId = "league",
                W = null,
                L = null,
                G = null,
                Gs = null,
                Cg = null,
                Sho = null,
                Sv = null,
                Ipouts = null,
                H = null,
                Er = null,
                Hr = null,
                Bb = null,
                So = null,
                Baopp = null,
                Era = null,
                Ibb = null,
                Wp = null,
                Hbp = null,
                Bk = null,
                Bfp = null,
                Gf = null,
                R = null,
                Sh = null,
                Sf = null,
                Gidp = null,
            };
        }

        private PitchingPost GeneratePitchingPostWithPlayer()
        {
            return new PitchingPost()
            {
                PlayerId = "id",
                YearId = 2000,
                Round = "WC",
                TeamId = "team",
                LgId = "league",
                W = 1,
                L = 1,
                G = 1,
                Gs = 1,
                Cg = 1,
                Sho = 4,
                Sv = 2,
                Ipouts = 1,
                H = 2,
                Er = 1,
                Hr = 1,
                Bb = 1,
                So = 2,
                Baopp = 1,
                Era = 1,
                Ibb = 1,
                Wp = 1,
                Hbp = 1,
                Bk = 1,
                Bfp = 1,
                Gf = 1,
                R = 1,
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
    }

}