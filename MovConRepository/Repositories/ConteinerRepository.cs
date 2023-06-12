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

        public long Insert(ConteinerModel model)
        {
            long newId;

            using (TransactionScope ts = new TransactionScope()) {
                newId = this._conteinerData.Insert(model);

                ts.Complete();
            }

            return newId;
        }

        public int Update(ConteinerModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.Update(model);

                ts.Complete();
            }

            return qtd;
        }

        public int UpdateByNumero(ConteinerModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.UpdateByNumero(model);

                ts.Complete();
            }

            return qtd;
        }

        public int Delete(long id)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._conteinerData.Delete(id);

                ts.Complete();
            }

            return qtd;
        }

        public int DeleteByNumero(string numero)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope())
            {
                qtd = this._conteinerData.DeleteByNumero(numero);

                ts.Complete();
            }

            return qtd;
        }

        public ConteinerModel Get(long id)
        {
            return this._conteinerData.Get(id);
        }

        public ConteinerModel GetByNumero(string numero)
        {
            return this._conteinerData.GetByNumero(numero);
        }

        public List<ConteinerModel> List()
        {
            return this._conteinerData.List();
        }

        public List<ConteinerEntity> Filter(ConteinerEntity entity)
        {
            return this._conteinerData.Filter(entity);
        }
    }
}
