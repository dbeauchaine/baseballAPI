﻿using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaseballAPI.Services
{
    public class TeamService : ITeamService
    {
        private IBaseballDBContext _database;
        private ITeamStatsMapper _mapper;

        public TeamService(IBaseballDBContext database, ITeamStatsMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IEnumerable<TeamStats> GetTeamStatsByYear(int year)
        {
            var query = _database.Teams
                .Where(e => e.YearId == year)
                .OrderByDescending(e => e.W)
                .ToList()
                .Select<Teams, TeamStats>(e =>
                {
                    return _mapper.Map(e);
                });

            return query;
        }

        public IEnumerable<TeamStats> GetTeamStats(string team)
        {
            var query = _database.Teams
                .Where(e => e.TeamId == team)
                .OrderByDescending(e => e.YearId)
                .ToList()
                .Select<Teams, TeamStats>(e =>
                {
                    return _mapper.Map(e);
                });

            return query;
        }
    }
}