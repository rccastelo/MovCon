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

        public long Iniciar(MovimentacaoModel model)
        {
            long newId;

            using (TransactionScope ts = new TransactionScope()) {
                newId = this._movimentacaoData.Iniciar(model);

                ts.Complete();
            }

            return newId;
        }

        public int Finalizar(MovimentacaoModel model)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._movimentacaoData.Finalizar(model);

                ts.Complete();
            }

            return qtd;
        }

        public int FinalizarPorNumero(string numero)
        {
            int qtd;

            using (TransactionScope ts = new TransactionScope()) {
                qtd = this._movimentacaoData.FinalizarPorNumero(numero);

                ts.Complete();
            }

            return qtd;
        }

        public MovimentacaoModel Obter(long id)
        {
            return this._movimentacaoData.Obter(id);
        }

        public MovimentacaoModel ObterEmMovimentoPorNumero(string numero)
        {
            return this._movimentacaoData.ObterEmMovimentoPorNumero(numero);
        }

        public List<MovimentacaoModel> Listar()
        {
            return this._movimentacaoData.Listar();
        }

        public List<MovimentacaoModel> ListarEmMovimento()
        {
            return this._movimentacaoData.ListarEmMovimento();
        }

        public List<MovimentacaoModel> ListarPorNumero(string numero)
        {
            return this._movimentacaoData.ListarPorNumero(numero);
        }

        public List<MovimentacaoEntity> Filtrar(MovimentacaoEntity entity)
        {
            return this._movimentacaoData.Filtrar(entity);
        }
    }
}
