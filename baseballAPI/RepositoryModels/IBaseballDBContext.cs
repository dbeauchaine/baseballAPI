using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.RepositoryModels
{
    public interface IBaseballDBContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Batting> Batting { get; set; }
        public DbSet<Fielding> Fielding { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Pitching> Pitching { get; set; }
        public DbSet<BattingPost> BattingPost { get; set; }
        public DbSet<FieldingPost> FieldingPost { get; set; }
        public DbSet<PitchingPost> PitchingPost { get; set; }
    }
}
