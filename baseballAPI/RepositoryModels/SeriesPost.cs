using System;
using System.Collections.Generic;

namespace BaseballAPI.RepositoryModels
{
    public partial class SeriesPost
    {
        public short YearId { get; set; }
        public string Round { get; set; }
        public string TeamIdwinner { get; set; }
        public string LgIdwinner { get; set; }
        public string TeamIdloser { get; set; }
        public string LgIdloser { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? Ties { get; set; }
    }
}
