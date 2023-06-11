using Microsoft.Extensions.DependencyInjection;
using MovConRepository.Datas;
using MovConRepository.Interfaces;
using MovConRepository.Repositories;

namespace MovConRepository.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConteinerData, ConteinerData>();
            services.AddScoped<IConteinerRepository, ConteinerRepository>();
            services.AddScoped<IMovimentacaoData, MovimentacaoData>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        }
    }
}
