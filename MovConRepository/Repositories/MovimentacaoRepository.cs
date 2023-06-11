using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;
using System.Transactions;

namespace MovConRepository.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly IMovimentacaoData _movimentacaoData;

        public MovimentacaoRepository(IMovimentacaoData movimentacaoData)
        {
            this._movimentacaoData = movimentacaoData;
        }

        public long Insert(MovimentacaoModel model)
        {
            long newId;

            using (TransactionScope ts = new TransactionScope()) {
                newId = this._movimentacaoData.Insert(model);

                ts.Complete();
            }

            return newId;
        }

        public int Update(MovimentacaoModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._movimentacaoData.Update(model);

                ts.Complete();
            }

            return qtd;
        }

        public int UpdateFimMovimentoByNumero(string numero)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._movimentacaoData.UpdateFimMovimentoByNumero(numero);

                ts.Complete();
            }

            return qtd;
        }

        public MovimentacaoModel Get(long id)
        {
            return this._movimentacaoData.Get(id);
        }

        public MovimentacaoModel GetEmMovimentoByNumero(string numero)
        {
            return this._movimentacaoData.GetEmMovimentoByNumero(numero);
        }

        public List<MovimentacaoModel> List()
        {
            return this._movimentacaoData.List();
        }

        public List<MovimentacaoModel> ListEmMovimento()
        {
            return this._movimentacaoData.ListEmMovimento();
        }

        public List<MovimentacaoModel> ListByNumero(string numero)
        {
            return this._movimentacaoData.ListByNumero(numero);
        }
    }
}
