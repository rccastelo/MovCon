using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IMovimentacaoData
    {
        long Iniciar(MovimentacaoModel model);
        int Finalizar(MovimentacaoModel model);
        int FinalizarPorNumero(string numero);
        MovimentacaoModel Obter(long id);
        MovimentacaoModel ObterEmMovimentoPorNumero(string numero);
        List<MovimentacaoModel> Listar();
        List<MovimentacaoModel> ListarEmMovimento();
        List<MovimentacaoModel> ListarPorNumero(string numero);
        List<MovimentacaoEntity> Filtrar(MovimentacaoEntity entity);
    }
}
