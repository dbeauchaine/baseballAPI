using BaseballAPI.ApiModels;
using BaseballAPI.RepositoryModels;
using BaseballAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseballAPI
{
    public class ContainerInitializer
    {
        IServiceCollection _services;
        IConfiguration _configuration;
        public ContainerInitializer(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Execute()
        {
            string connectionString = _configuration.GetValue<string>("ConnectionString");
            _services.AddDbContext<IBaseballDBContext, BaseballDBContext>(options => options.UseSqlServer(connectionString));
            _services.AddControllers();
            _services.AddTransient<IPlayerService, PlayerService>();
            _services.AddTransient<IBattingService, BattingService>();
            _services.AddTransient<IBattingStatsMapper, BattingStatsMapper>();
            _services.AddTransient<IFieldingStatsMapper, FieldingStatsMapper>();
            _services.AddTransient<IFieldingService, FieldingService>();
            _services.AddTransient<IPitchingService, PitchingService>();
            _services.AddTransient<IPitchingStatsMapper, PitchingStatsMapper>();
            _services.AddTransient<IPlayerMapper, PlayerMapper>();
            _services.AddTransient<IStatsCalculator, StatsCalculator>();
            _services.AddTransient<ITeamService, TeamService>();
            _services.AddTransient<ITeamStatsMapper, TeamStatsMapper>();
        }
    }
}
