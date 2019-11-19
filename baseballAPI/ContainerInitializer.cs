using BaseballAPI.Models;
using BaseballAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseballAPI
{
    public class ContainerInitializer
    {
        IServiceCollection _services;
        public ContainerInitializer(IServiceCollection services)
        {
            _services = services;
        }

        public void Execute()
        {
            _services.AddDbContext<IBaseballDBContext, BaseballDBContext>();
            _services.AddControllers();
            _services.AddTransient<IPlayerService, PlayerService>();
        }
    }
}
