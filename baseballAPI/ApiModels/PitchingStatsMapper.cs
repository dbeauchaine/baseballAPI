using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class PitchingStatsMapper : IPitchingStatsMapper
    {
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

            ConvertOptionalParamsToNonNullable(pitching, pitchingStats);

            return pitchingStats;
        }

        public PitchingLeaderBoardStats MapYear(Pitching pitching)
        {
            var pitchingLeaderBoardStats = new PitchingLeaderBoardStats()
            {
                NameFirst = pitching.Player.NameFirst,
                NameLast = pitching.Player.NameLast,
                NameGiven = pitching.Player.NameGiven,
                PlayerId = pitching.PlayerId,
                YearId = pitching.YearId,
                Stint = pitching.Stint,
                TeamId = pitching.TeamId,
                LgId = pitching.LgId,
            };

            ConvertOptionalLeaderboardParamsToNonNullable(pitching, pitchingLeaderBoardStats);

            return pitchingLeaderBoardStats;
        }

        private void ConvertOptionalParamsToNonNullable(Pitching pitching, PitchingStats pitchingStats)
        {
            if (pitching.W != null)
                pitchingStats.W = (short)pitching.W;
            else
                pitchingStats.W = 0;

            if (pitching.L != null)
                pitchingStats.L = (short)pitching.L;
            else
                pitchingStats.L = 0;

            if (pitching.G != null)
                pitchingStats.G = (short)pitching.G;
            else
                pitchingStats.G = 0;

            if (pitching.Gs != null)
                pitchingStats.Gs = (short)pitching.Gs;
            else
                pitchingStats.Gs = 0;

            if (pitching.Cg != null)
                pitchingStats.Cg = (short)pitching.Cg;
            else
                pitchingStats.Cg = 0;

            if (pitching.Sho != null)
                pitchingStats.Sho = (short)pitching.Sho;
            else
                pitchingStats.Sho = 0;

            if (pitching.Sv != null)
                pitchingStats.Sv = (short)pitching.Sv;
            else
                pitchingStats.Sv = 0;

            if (pitching.Ipouts != null)
                pitchingStats.Ipouts = (short)pitching.Ipouts;
            else
                pitchingStats.Ipouts = 0;

            if (pitching.H != null)
                pitchingStats.H = (short)pitching.H;
            else
                pitchingStats.H = 0;

            if (pitching.Er != null)
                pitchingStats.Er = (short)pitching.Er;
            else
                pitchingStats.Er = 0;

            if (pitching.Hr != null)
                pitchingStats.Hr = (short)pitching.Hr;
            else
                pitchingStats.Hr = 0;

            if (pitching.Bb != null)
                pitchingStats.Bb = (short)pitching.Bb;
            else
                pitchingStats.Bb = 0;

            if (pitching.So != null)
                pitchingStats.So = (short)pitching.So;
            else
                pitchingStats.So = 0;

            if (pitching.Baopp != null)
                pitchingStats.Baopp = (short)pitching.Baopp;
            else
                pitchingStats.Baopp = 0;

            if (pitching.Era != null)
                pitchingStats.Era = (short)pitching.Era;
            else
                pitchingStats.Era = 0;

            if (pitching.Ibb != null)
                pitchingStats.Ibb = (short)pitching.Ibb;
            else
                pitchingStats.Ibb = 0;

            if (pitching.Wp != null)
                pitchingStats.Wp = (short)pitching.Wp;
            else
                pitchingStats.Wp = 0;

            if (pitching.Hbp != null)
                pitchingStats.Hbp = (short)pitching.Hbp;
            else
                pitchingStats.Hbp = 0;

            if (pitching.Bk != null)
                pitchingStats.Bk = (short)pitching.Bk;
            else
                pitchingStats.Bk = 0;

            if (pitching.Bfp != null)
                pitchingStats.Bfp = (short)pitching.Bfp;
            else
                pitchingStats.Bfp = 0;

            if (pitching.Gf != null)
                pitchingStats.Gf = (short)pitching.Gf;
            else
                pitchingStats.Gf = 0;

            if (pitching.R != null)
                pitchingStats.R = (short)pitching.R;
            else
                pitchingStats.R = 0;

            if (pitching.Sh != null)
                pitchingStats.Sh = (short)pitching.Sh;
            else
                pitchingStats.Sh = 0;

            if (pitching.Sf != null)
                pitchingStats.Sf = (short)pitching.Sf;
            else
                pitchingStats.Sf = 0;

            if (pitching.Gidp != null)
                pitchingStats.Gidp = (short)pitching.Gidp;
            else
                pitchingStats.Gidp = 0;
        }

        private void ConvertOptionalLeaderboardParamsToNonNullable(Pitching pitching, PitchingLeaderBoardStats pitchingStats)
        {
            if (pitching.W != null)
                pitchingStats.W = (short)pitching.W;
            else
                pitchingStats.W = 0;

            if (pitching.L != null)
                pitchingStats.L = (short)pitching.L;
            else
                pitchingStats.L = 0;

            if (pitching.G != null)
                pitchingStats.G = (short)pitching.G;
            else
                pitchingStats.G = 0;

            if (pitching.Gs != null)
                pitchingStats.Gs = (short)pitching.Gs;
            else
                pitchingStats.Gs = 0;

            if (pitching.Cg != null)
                pitchingStats.Cg = (short)pitching.Cg;
            else
                pitchingStats.Cg = 0;

            if (pitching.Sho != null)
                pitchingStats.Sho = (short)pitching.Sho;
            else
                pitchingStats.Sho = 0;

            if (pitching.Sv != null)
                pitchingStats.Sv = (short)pitching.Sv;
            else
                pitchingStats.Sv = 0;

            if (pitching.Ipouts != null)
                pitchingStats.Ipouts = (short)pitching.Ipouts;
            else
                pitchingStats.Ipouts = 0;

            if (pitching.H != null)
                pitchingStats.H = (short)pitching.H;
            else
                pitchingStats.H = 0;

            if (pitching.Er != null)
                pitchingStats.Er = (short)pitching.Er;
            else
                pitchingStats.Er = 0;

            if (pitching.Hr != null)
                pitchingStats.Hr = (short)pitching.Hr;
            else
                pitchingStats.Hr = 0;

            if (pitching.Bb != null)
                pitchingStats.Bb = (short)pitching.Bb;
            else
                pitchingStats.Bb = 0;

            if (pitching.So != null)
                pitchingStats.So = (short)pitching.So;
            else
                pitchingStats.So = 0;

            if (pitching.Baopp != null)
                pitchingStats.Baopp = (short)pitching.Baopp;
            else
                pitchingStats.Baopp = 0;

            if (pitching.Era != null)
                pitchingStats.Era = (short)pitching.Era;
            else
                pitchingStats.Era = 0;

            if (pitching.Ibb != null)
                pitchingStats.Ibb = (short)pitching.Ibb;
            else
                pitchingStats.Ibb = 0;

            if (pitching.Wp != null)
                pitchingStats.Wp = (short)pitching.Wp;
            else
                pitchingStats.Wp = 0;

            if (pitching.Hbp != null)
                pitchingStats.Hbp = (short)pitching.Hbp;
            else
                pitchingStats.Hbp = 0;

            if (pitching.Bk != null)
                pitchingStats.Bk = (short)pitching.Bk;
            else
                pitchingStats.Bk = 0;

            if (pitching.Bfp != null)
                pitchingStats.Bfp = (short)pitching.Bfp;
            else
                pitchingStats.Bfp = 0;

            if (pitching.Gf != null)
                pitchingStats.Gf = (short)pitching.Gf;
            else
                pitchingStats.Gf = 0;

            if (pitching.R != null)
                pitchingStats.R = (short)pitching.R;
            else
                pitchingStats.R = 0;

            if (pitching.Sh != null)
                pitchingStats.Sh = (short)pitching.Sh;
            else
                pitchingStats.Sh = 0;

            if (pitching.Sf != null)
                pitchingStats.Sf = (short)pitching.Sf;
            else
                pitchingStats.Sf = 0;

            if (pitching.Gidp != null)
                pitchingStats.Gidp = (short)pitching.Gidp;
            else
                pitchingStats.Gidp = 0;
        }
    }
}

