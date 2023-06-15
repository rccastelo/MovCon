using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;
using System.Transactions;

namespace MovConRepository.Repositories
{
    public class ConteinerRepository : IConteinerRepository
    {
        private readonly IConteinerData _conteinerData;

        public ConteinerRepository(IConteinerData conteinerData)
        {
            this._conteinerData = conteinerData;
        }

        public long Incluir(ConteinerModel model)
        {
            long newId;

            using (TransactionScope ts = new TransactionScope()) {
                newId = this._conteinerData.Incluir(model);

                ts.Complete();
            }

            return newId;
        }

        public int Alterar(ConteinerModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.Alterar(model);

                ts.Complete();
            }

            return qtd;
        }

        public int AlterarPorNumero(ConteinerModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.AlterarPorNumero(model);

                ts.Complete();
            }

            return qtd;
        }

        public int Excluir(long id)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.Excluir(id);

                ts.Complete();
            }

            return qtd;
        }

        public int ExcluirPorNumero(string numero)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope())
            {
                qtd = this._conteinerData.ExcluirPorNumero(numero);

                ts.Complete();
            }

            return qtd;
        }

        public ConteinerModel Obter(long id)
        {
            return this._conteinerData.Obter(id);
        }

        public ConteinerModel ObterPorNumero(string numero)
        {
            return this._conteinerData.ObterPorNumero(numero);
        }

        public List<ConteinerModel> Listar()
        {
            return this._conteinerData.Listar();
        }

        public List<ConteinerEntity> Filtrar(ConteinerEntity entity)
        {
            return this._conteinerData.Filtrar(entity);
        }
    }
}
