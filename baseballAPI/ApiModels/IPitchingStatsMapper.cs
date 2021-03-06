﻿using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public interface IPitchingStatsMapper
    {
        public PitchingStats Map(Pitching pitching);
        public PitchingPostStats Map(PitchingPost pitching);
    }
}
