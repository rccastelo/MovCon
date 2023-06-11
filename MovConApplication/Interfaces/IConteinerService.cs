using MovConApplication.Transports;

namespace MovConApplication.Interfaces
{
    public interface IConteinerService
    {
        ConteinerResponse Insert(ConteinerRequest request);
        ConteinerResponse Update(long id, ConteinerRequest request);
        ConteinerResponse UpdateByNumero(string numero, ConteinerRequest request);
        ConteinerResponse Delete(long id);
        ConteinerResponse DeleteByNumero(string numero);
        ConteinerResponse Get(long id);
        ConteinerResponse GetByNumero(string numero);
        ConteinerResponse List();
    }
}
