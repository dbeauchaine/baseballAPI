using System;
using System.Collections.Generic;

namespace BaseballAPI.Models
{
    public partial class Salaries
    {
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LgId { get; set; }
        public string PlayerId { get; set; }
        public double? Salary { get; set; }
    }
}
