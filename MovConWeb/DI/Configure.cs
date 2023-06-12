using Microsoft.Extensions.DependencyInjection;
using MovConWeb.Externs;
using MovConWeb.Interfaces;
using MovConWeb.Services;

namespace MovConWeb.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConteinerService, ConteinerService>();
            services.AddScoped<IConteinerExtern, ConteinerExtern>();
            services.AddScoped<IMovimentacaoService, MovimentacaoService>();
            services.AddScoped<IMovimentacaoExtern, MovimentacaoExtern>();
        }
    }
}
