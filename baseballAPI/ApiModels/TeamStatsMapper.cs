using BaseballAPI.RepositoryModels;

namespace BaseballAPI.ApiModels
{
    public class TeamStatsMapper : ITeamStatsMapper
    {
        public TeamStatsMapper()
        {

        }

        public TeamStats Map(Teams teams)
        {
            var teamsStats = new TeamStats()
            {
                YearId = teams.YearId,
                LgId = teams.LgId,
                TeamId = teams.TeamId,
                FranchId = teams.FranchId,
                DivId = teams.DivId,
                DivWin = teams.DivWin,
                Wcwin = teams.DivWin,
                LgWin = teams.LgWin,
                Wswin = teams.Wswin,
                Name = teams.Name,
                Park = teams.Park,
                TeamIdbr = teams.TeamId,
                TeamIdlahman45 = teams.TeamIdlahman45,
                TeamIdretro = teams.TeamIdretro
            };

            ConvertOptionalParamsToNonNullable(teams, teamsStats);

            return teamsStats;
        }

        private void ConvertOptionalParamsToNonNullable(Teams teams, TeamStats teamsStats)
        {
            if (teams.Rank != null)
                teamsStats.Rank = (short)teams.Rank;
            else
                teamsStats.Rank = 0;

            if (teams.G != null)
                teamsStats.G = (short)teams.G;
            else
                teamsStats.G = 0;

            if (teams.Ghome != null)
                teamsStats.Ghome = (short)teams.Ghome;
            else
                teamsStats.Ghome = 0;
            
            if (teams.W != null)
                teamsStats.W = (short)teams.W;
            else
                teamsStats.W = 0;

            if (teams.L != null)
                teamsStats.L = (short)teams.L;
            else
                teamsStats.L = 0;

            if (teams.R != null)
                teamsStats.R = (short)teams.R;
            else
                teamsStats.R = 0;

            if (teams.Ab != null)
                teamsStats.Ab = (short)teams.Ab;
            else
                teamsStats.Ab = 0;

            if (teams.H != null)
                teamsStats.H = (short)teams.H;
            else
                teamsStats.H = 0;

            if (teams.X2b != null)
                teamsStats.X2b = (short)teams.X2b;
            else
                teamsStats.X2b = 0;

            if (teams.X3b != null)
                teamsStats.X3b = (short)teams.X3b;
            else
                teamsStats.X3b = 0;

            if (teams.Hr != null)
                teamsStats.Hr = (short)teams.Hr;
            else
                teamsStats.Hr = 0;

            if (teams.Bb != null)
                teamsStats.Bb = (short)teams.Bb;
            else
                teamsStats.Bb = 0;

            if (teams.So != null)
                teamsStats.So = (short)teams.So;
            else
                teamsStats.So = 0;

            if (teams.Sb != null)
                teamsStats.Sb = (short)teams.Sb;
            else
                teamsStats.Sb = 0;

            if (teams.Cs != null)
                teamsStats.Cs = (short)teams.Cs;
            else
                teamsStats.Cs = 0;

            if (teams.Hbp != null)
                teamsStats.Hbp = (short)teams.Hbp;
            else
                teamsStats.Hbp = 0;

            if (teams.Sf != null)
                teamsStats.Sf = (short)teams.Sf;
            else
                teamsStats.Sf = 0;

            if (teams.Ra != null)
                teamsStats.Ra = (short)teams.Ra;
            else
                teamsStats.Ra = 0;

            if (teams.Er != null)
                teamsStats.Er = (short)teams.Er;
            else
                teamsStats.Er = 0;

            if (teams.Era != null)
                teamsStats.Era = (short)teams.Era;
            else
                teamsStats.Era = 0;

            if (teams.Cg != null)
                teamsStats.Cg = (short)teams.Cg;
            else
                teamsStats.Cg = 0;

            if (teams.Sho != null)
                teamsStats.Sho = (short)teams.Sho;
            else
                teamsStats.Sho = 0;

            if (teams.Sv != null)
                teamsStats.Sv = (short)teams.Sv;
            else
                teamsStats.Sv = 0;

            if (teams.Ipouts != null)
                teamsStats.Ipouts = (short)teams.Ipouts;
            else
                teamsStats.Ipouts = 0;

            if (teams.Ha != null)
                teamsStats.Ha = (short)teams.Ha;
            else
                teamsStats.Ha = 0;

            if (teams.Hra != null)
                teamsStats.Hra = (short)teams.Hra;
            else
                teamsStats.Hra = 0;

            if (teams.Bba != null)
                teamsStats.Bba = (short)teams.Bba;
            else
                teamsStats.Bba = 0;

            if (teams.Soa != null)
                teamsStats.Soa = (short)teams.Soa;
            else
                teamsStats.Soa = 0;

            if (teams.E != null)
                teamsStats.E = (short)teams.E;
            else
                teamsStats.E = 0;

            if (teams.Dp != null)
                teamsStats.Dp = (short)teams.Dp;
            else
                teamsStats.Dp = 0;

            if (teams.Fp != null)
                teamsStats.Fp = (short)teams.Fp;
            else
                teamsStats.Fp = 0;

            if (teams.Attendance != null)
                teamsStats.Attendance = (short)teams.Attendance;
            else
                teamsStats.Attendance = 0;

            if (teams.Bpf != null)
                teamsStats.Bpf = (short)teams.Bpf;
            else
                teamsStats.Bpf = 0;

            if (teams.Ppf != null)
                teamsStats.Ppf = (short)teams.Ppf;
            else
                teamsStats.Ppf = 0;
        }

    }
}

