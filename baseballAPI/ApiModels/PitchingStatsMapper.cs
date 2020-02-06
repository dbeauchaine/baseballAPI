using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class PitchingStatsMapper : IPitchingStatsMapper
    {
        private IStatsCalculator _calculator;
        public PitchingStatsMapper(IStatsCalculator statsCalculator)
        {
            _calculator = statsCalculator;
        }

        public PitchingStats Map(Pitching pitching)
        {
            var pitchingStats = new PitchingStats()
            {
                PlayerId = pitching.PlayerId,
                YearId = pitching.YearId,
                Stint = pitching.Stint,
                TeamId = pitching.TeamId,
                LgId = pitching.LgId,
            };

            CopyPlayerDataIfPlayerExists(pitching, pitchingStats);

            CopyNullableStats(pitching, pitchingStats);

            _calculator.CalculateStats(pitchingStats);

            return pitchingStats;
        }


        public PitchingPostStats Map(PitchingPost pitching)
        {
            var pitchingPostStats = new PitchingPostStats()
            {
                PlayerId = pitching.PlayerId,
                YearId = pitching.YearId,
                Round = pitching.Round,
                TeamId = pitching.TeamId,
                LgId = pitching.LgId,
            };

            CopyPlayerDataIfPlayerExists(pitching, pitchingPostStats);

            CopyNullableStats(pitching, pitchingPostStats);

            _calculator.CalculateStats(pitchingPostStats);

            return pitchingPostStats;
        }
        private void CopyPlayerDataIfPlayerExists(Pitching pitching, PitchingStats pitchingStats)
        {
            if (pitching.Player != null)
            {
                pitchingStats.NameFirst = pitching.Player.NameFirst;
                pitchingStats.NameLast = pitching.Player.NameLast;
                pitchingStats.NameGiven = pitching.Player.NameGiven;
            }
        }

        private void CopyPlayerDataIfPlayerExists(PitchingPost pitching, PitchingPostStats pitchingStats)
        {
            if (pitching.Player != null)
            {
                pitchingStats.NameFirst = pitching.Player.NameFirst;
                pitchingStats.NameLast = pitching.Player.NameLast;
                pitchingStats.NameGiven = pitching.Player.NameGiven;
            }
        }

        private void CopyNullableStats(Pitching pitching, PitchingStats pitchingStats)
        {
            pitchingStats.W = pitching.W;

            pitchingStats.L = pitching.L;

            pitchingStats.G = pitching.G;

            pitchingStats.Gs = pitching.Gs;

            pitchingStats.Cg = pitching.Cg;

            pitchingStats.Sho = pitching.Sho;


            pitchingStats.Sv = pitching.Sv;

            pitchingStats.Ipouts = pitching.Ipouts;

            pitchingStats.H = pitching.H;

            pitchingStats.Er = pitching.Er;

            pitchingStats.Hr = pitching.Hr;

            pitchingStats.Bb = pitching.Bb;

            pitchingStats.So = pitching.So;

            pitchingStats.Baopp = pitching.Baopp;

            pitchingStats.Era = pitching.Era;

            pitchingStats.Ibb = pitching.Ibb;

            pitchingStats.Wp = pitching.Wp;

            pitchingStats.Hbp = pitching.Hbp;

            pitchingStats.Bk = pitching.Bk;

            pitchingStats.Bfp = pitching.Bfp;

            pitchingStats.Gf = pitching.Gf;

            pitchingStats.R = pitching.R;

            pitchingStats.Sh = pitching.Sh;

            pitchingStats.Sf = pitching.Sf;

            pitchingStats.Gidp = pitching.Gidp;
        }

        private void CopyNullableStats(PitchingPost pitching, PitchingPostStats pitchingStats)
        {
            pitchingStats.W = pitching.W;

            pitchingStats.L = pitching.L;

            pitchingStats.G = pitching.G;

            pitchingStats.Gs = pitching.Gs;

            pitchingStats.Cg = pitching.Cg;

            pitchingStats.Sho = pitching.Sho;


            pitchingStats.Sv = pitching.Sv;

            pitchingStats.Ipouts = pitching.Ipouts;

            pitchingStats.H = pitching.H;

            pitchingStats.Er = pitching.Er;

            pitchingStats.Hr = pitching.Hr;

            pitchingStats.Bb = pitching.Bb;

            pitchingStats.So = pitching.So;

            pitchingStats.Baopp = pitching.Baopp;

            pitchingStats.Era = pitching.Era;

            pitchingStats.Ibb = pitching.Ibb;

            pitchingStats.Wp = pitching.Wp;

            pitchingStats.Hbp = pitching.Hbp;

            pitchingStats.Bk = pitching.Bk;

            pitchingStats.Bfp = pitching.Bfp;

            pitchingStats.Gf = pitching.Gf;

            pitchingStats.R = pitching.R;

            pitchingStats.Sh = pitching.Sh;

            pitchingStats.Sf = pitching.Sf;

            pitchingStats.Gidp = pitching.Gidp;
        }
    }
}

