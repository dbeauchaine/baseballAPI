﻿using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class PitchingService : IPitchingService
    {
        private IBaseballDBContext _database;
        private IPitchingStatsMapper _mapper;

        public PitchingService(IBaseballDBContext database, IPitchingStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<PitchingStats> GetPitchingStats(string id)
        {
            var stats = _database.Pitching
                .Where(s => s.PlayerId == id)
                .ToList()
                .Select<Pitching,PitchingStats>(s => 
                {
                    return _mapper.Map(s);
                });

            return stats;
        }

        public IEnumerable<PitchingLeaderBoardStats> GetPitchingStatsByYear(int year)
        {
            var query = _database.Pitching
                .Include(p => p.Player)
                .Where(p => p.YearId == year)
                .OrderBy(p => p.Player.NameLast)
                .ToList()
                .Select<Pitching, PitchingLeaderBoardStats>(p =>
                {
                    return _mapper.MapYear(p);
                });

            return query;
        }

    }
}