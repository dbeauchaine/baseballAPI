using BaseballAPI.RepositoryModels;

namespace BaseballAPI.ApiModels
{
    public interface ITeamStatsMapper
    {
        public TeamStats Map(Teams teamsStats);
    }
}
