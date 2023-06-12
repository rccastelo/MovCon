using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IMovimentacaoRepository
    {
        long Insert(MovimentacaoModel model);
        int Update(MovimentacaoModel model);
        int UpdateFimMovimentoByNumero(string numero);
        MovimentacaoModel Get(long id);
        MovimentacaoModel GetEmMovimentoByNumero(string numero);
        List<MovimentacaoModel> List();
        List<MovimentacaoModel> ListEmMovimento();
        List<MovimentacaoModel> ListByNumero(string numero);
        List<MovimentacaoEntity> Filter(MovimentacaoEntity entity);
    }
}
