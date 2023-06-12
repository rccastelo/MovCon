using MovConApplication.Transports;

namespace MovConApplication.Interfaces
{
    public interface IMovimentacaoService
    {
        MovimentacaoResponse Insert(MovimentacaoInicioRequest request);
        MovimentacaoResponse Update(long id, MovimentacaoFimRequest request);
        MovimentacaoResponse UpdateFimMovimentoByNumero(string numero);
        MovimentacaoResponse Get(long id);
        MovimentacaoResponse GetEmMovimentoByNumero(string numero);
        MovimentacaoResponse List();
        MovimentacaoResponse ListEmMovimento();
        MovimentacaoResponse ListByNumero(string numero);
        MovimentacaoResponse Filter(MovimentacaoFiltroRequest request);
    }
}
