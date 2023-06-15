using MovConApplication.Transports;

namespace MovConApplication.Interfaces
{
    public interface IConteinerService
    {
        ConteinerResponse Incluir(ConteinerRequest request);
        ConteinerResponse Alterar(long id, ConteinerRequest request);
        ConteinerResponse AlterarPorNumero(string numero, ConteinerRequest request);
        ConteinerResponse Excluir(long id);
        ConteinerResponse ExcluirPorNumero(string numero);
        ConteinerResponse Obter(long id);
        ConteinerResponse ObterPorNumero(string numero);
        ConteinerResponse Listar();
        ConteinerResponse Filtrar(ConteinerRequest request);
    }
}
