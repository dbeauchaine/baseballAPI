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

        public FieldingPostStats Map(FieldingPost fieldingPost)
        {
            var fieldingStats = new FieldingPostStats()
            {
                PlayerId = fieldingPost.PlayerId,
                YearId = fieldingPost.YearId,
                Round = fieldingPost.Round,
                TeamId = fieldingPost.TeamId,
                LgId = fieldingPost.LgId,
                Pos = fieldingPost.Pos
            };

            ConvertOptionalParamsToNonNullable(fieldingPost, fieldingStats);

            return fieldingStats;
        }

        private void ConvertOptionalParamsToNonNullable(Fielding fielding, FieldingStats fieldingStats)
        { 
                fieldingStats.G = fielding.G;
                fieldingStats.Gs = fielding.Gs;
                fieldingStats.InnOuts = fielding.InnOuts;
                fieldingStats.Po = fielding.Po;        
                fieldingStats.A = fielding.A;
                fieldingStats.E = fielding.E;
                fieldingStats.Dp = fielding.Dp;
                fieldingStats.Pb = fielding.Pb;
                fieldingStats.Wp = fielding.Wp;
                fieldingStats.Sb = fielding.Sb;
                fieldingStats.Cs = fielding.Cs;
                fieldingStats.Zr = fielding.Zr;
        }

        private void ConvertOptionalParamsToNonNullable(FieldingPost fielding, FieldingPostStats fieldingStats)
        {
                fieldingStats.G = fielding.G;
                fieldingStats.Gs = fielding.Gs;
                fieldingStats.InnOuts = fielding.InnOuts;
                fieldingStats.Po = fielding.Po;
                fieldingStats.A = fielding.A;
                fieldingStats.E = fielding.E;
                fieldingStats.Dp = fielding.Dp;
                fieldingStats.Tp = fielding.Tp;
                fieldingStats.Pb = fielding.Pb;
                fieldingStats.Sb = fielding.Sb;
                fieldingStats.Cs = fielding.Cs;
        }
    }
}
