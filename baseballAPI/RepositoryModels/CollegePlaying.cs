using System;
using System.Collections.Generic;

namespace BaseballAPI.RepositoryModels
{
    public partial class CollegePlaying
    {
        public string PlayerId { get; set; }
        public string SchoolId { get; set; }
        public short? YearId { get; set; }
    }
}
