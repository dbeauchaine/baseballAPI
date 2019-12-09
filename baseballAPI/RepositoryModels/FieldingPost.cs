using System;
using System.Collections.Generic;

namespace BaseballAPI.RepositoryModels
{
    public partial class FieldingPost
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LgId { get; set; }
        public string Round { get; set; }
        public string Pos { get; set; }
        public short? G { get; set; }
        public short? Gs { get; set; }
        public short? InnOuts { get; set; }
        public short? Po { get; set; }
        public short? A { get; set; }
        public short? E { get; set; }
        public short? Dp { get; set; }
        public short? Tp { get; set; }
        public short? Pb { get; set; }
        public short? Sb { get; set; }
        public short? Cs { get; set; }
    }
}
