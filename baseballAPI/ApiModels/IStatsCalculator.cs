﻿using BaseballAPI.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.ApiModels
{
    public interface IStatsCalculator
    {
        public void CalculateStats(BattingStats batting);
        public void CalculateStats(BattingPostStats batting);
        public void CalculateStats(TeamStats teamStats);
        public void CalculateStats(PitchingStats pitchingStats);
        public void CalculateStats(PitchingPostStats pitchingPostStats);
    }
}
