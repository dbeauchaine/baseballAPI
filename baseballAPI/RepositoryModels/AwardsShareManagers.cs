using System;
using System.Collections.Generic;

namespace BaseballAPI.RepositoryModels
{
    public partial class AwardsShareManagers
    {
        public string AwardId { get; set; }
        public short YearId { get; set; }
        public string LgId { get; set; }
        public string PlayerId { get; set; }
        public short? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public short? VotesFirst { get; set; }
    }
}
