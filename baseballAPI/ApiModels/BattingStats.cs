using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public class BattingStats
    {
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameGiven { get; set; }
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public short Stint { get; set; }
        public string TeamId { get; set; }
        public string LgId { get; set; }
        public short G { get; set; }
        public short GBatting { get; set; }
        public short Ab { get; set; }
        public short R { get; set; }
        public short H { get; set; }
        public short X2b { get; set; }
        public short X3b { get; set; }
        public short Hr { get; set; }
        public short Rbi { get; set; }
        public short Sb { get; set; }
        public short Cs { get; set; }
        public short Bb { get; set; }
        public short So { get; set; }
        public short Ibb { get; set; }
        public short Hbp { get; set; }
        public short Sh { get; set; }
        public short Sf { get; set; }
        public short Gidp { get; set; }
        public int Singles { get; set; }
        public double Avg { get; set; }
        public double Obp { get; set; }
        public double Slg { get; set; }
        public double Ops { get; set; }
        public int Pa { get; set; }
        public double BbRate { get; set; }
        public double KRate { get; set; }
        public double Iso { get; set; }
        public double Babip { get; set; }
    }
}
