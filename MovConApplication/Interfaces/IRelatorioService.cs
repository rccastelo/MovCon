using MovConApplication.Transports;

namespace MovConApplication.Interfaces
{
    public interface IRelatorioService
    {
        RelatorioResponse Pesquisar(RelatorioRequest request);
    }
}
