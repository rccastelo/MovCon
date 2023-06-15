using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IConteinerRepository
    {
        long Incluir(ConteinerModel model);
        int Alterar(ConteinerModel model);
        int AlterarPorNumero(ConteinerModel model);
        int Excluir(long id);
        int ExcluirPorNumero(string numero);
        ConteinerModel Obter(long id);
        ConteinerModel ObterPorNumero(string numero);
        List<ConteinerModel> Listar();
        List<ConteinerEntity> Filtrar(ConteinerEntity entity);
    }
}
