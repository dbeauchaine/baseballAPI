using System;
using System.Collections.Generic;

namespace BaseballAPI.Models
{
    public partial class AwardsManagers
    {
        public string PlayerId { get; set; }
        public string AwardId { get; set; }
        public short YearId { get; set; }
        public string LgId { get; set; }
        public string Tie { get; set; }
        public string Notes { get; set; }
    }
}
