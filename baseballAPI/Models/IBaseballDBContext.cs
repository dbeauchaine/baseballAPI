using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.Models
{
    public interface IBaseballDBContext
    {
        public  DbSet<People> People { get; set; }
    }
}
