using BaseballAPI.RepositoryModels;

namespace BaseballAPI.ApiModels
{
    public class FieldingStatsMapper : IFieldingStatsMapper
    {
        public FieldingStats Map(Fielding fielding)
        {
            var fieldingStats = new FieldingStats()
            {
                PlayerId = fielding.PlayerId,
                YearId = fielding.YearId,
                Stint = fielding.Stint,
                TeamId = fielding.TeamId,
                LgId = fielding.LgId,
                Pos = fielding.Pos
            };

            ConvertOptionalParamsToNonNullable(fielding, fieldingStats);

            return fieldingStats;
        }

        private void ConvertOptionalParamsToNonNullable(Fielding fielding, FieldingStats fieldingStats)
        {
            if (fielding.G != null)
                fieldingStats.G = (short)fielding.G;
            else
                fieldingStats.G = 0;

            if (fielding.Gs != null)
                fieldingStats.Gs = (short)fielding.Gs;
            else
                fieldingStats.Gs = 0;

            if (fielding.InnOuts != null)
                fieldingStats.InnOuts = (short)fielding.InnOuts;
            else
                fieldingStats.InnOuts = 0;

            if (fielding.Po != null)
                fieldingStats.Po = (short)fielding.Po;
            else
                fieldingStats.Po = 0;

            if (fielding.A != null)
                fieldingStats.A = (short)fielding.A;
            else
                fieldingStats.A = 0;

            if (fielding.E != null)
                fieldingStats.E = (short)fielding.E;
            else
                fieldingStats.E = 0;

            if (fielding.Dp != null)
                fieldingStats.Dp = (short)fielding.Dp;
            else
                fieldingStats.Dp = 0;

            if (fielding.Pb != null)
                fieldingStats.Pb = (short)fielding.Pb;
            else
                fieldingStats.Pb = 0;

            if (fielding.Wp != null)
                fieldingStats.Wp = (short)fielding.Wp;
            else
                fieldingStats.Wp = 0;

            if (fielding.Sb != null)
                fieldingStats.Sb = (short)fielding.Sb;
            else
                fieldingStats.Sb = 0;

            if (fielding.Cs != null)
                fieldingStats.Cs = (short)fielding.Cs;
            else
                fieldingStats.Cs = 0;

            if (fielding.Zr != null)
                fieldingStats.Zr = (short)fielding.Zr;
            else
                fieldingStats.Zr = 0;
        }
    }
}
