using System;
using System.Collections.Generic;

namespace BaseballAPI.Models
{
    public partial class HomeGames
    {
        public int? Yearkey { get; set; }
        public string Leaguekey { get; set; }
        public string Teamkey { get; set; }
        public string Parkkey { get; set; }
        public string Spanfirst { get; set; }
        public string Spanlast { get; set; }
        public int? Games { get; set; }
        public int? Openings { get; set; }
        public int? Attendance { get; set; }
    }
}
