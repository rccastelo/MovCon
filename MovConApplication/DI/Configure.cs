using Microsoft.Extensions.DependencyInjection;
using MovConApplication.Interfaces;
using MovConApplication.Services;

namespace MovConApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConteinerService, ConteinerService>();
            services.AddScoped<IMovimentacaoService, MovimentacaoService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
        }
    }
}
