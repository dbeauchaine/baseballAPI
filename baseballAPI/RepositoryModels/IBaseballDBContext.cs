using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.RepositoryModels
{
    public interface IBaseballDBContext
    {
        public  DbSet<People> People { get; set; }
        public DbSet<Batting> Batting { get; set; }
    }
}
