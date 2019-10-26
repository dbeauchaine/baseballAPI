using baseballAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace baseballAPI
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
            _services.AddControllers();
            _services.AddTransient<IPlayerService, PlayerService>();
        }
    }
}
