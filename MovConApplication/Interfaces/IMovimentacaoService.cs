using MovConApplication.Transports;

namespace MovConApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        MovimentacaoResponse Iniciar(MovimentacaoInicioRequest request);
        MovimentacaoResponse Finalizar(long id, MovimentacaoFimRequest request);
        MovimentacaoResponse FinalizarPorNumero(string numero);
        MovimentacaoResponse Obter(long id);
        MovimentacaoResponse ObterEmMovimentoPorNumero(string numero);
        MovimentacaoResponse Listar();
        MovimentacaoResponse ListarEmMovimento();
        MovimentacaoResponse ListarPorNumero(string numero);
        MovimentacaoResponse Filtrar(MovimentacaoFiltroRequest request);
    }
}
