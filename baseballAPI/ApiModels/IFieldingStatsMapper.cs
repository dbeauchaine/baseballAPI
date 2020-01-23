using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public interface IFieldingStatsMapper
    {
        public FieldingStats Map(Fielding fielding);
        public FieldingPostStats Map(FieldingPost fieldingPost);

    }
}
