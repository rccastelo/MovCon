using MovConApplication.Interfaces;
using MovConApplication.Transports;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;

namespace MovConApplication.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IConteinerRepository _conteinerRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository,
            IConteinerRepository conteinerRepository)
        {
            this._movimentacaoRepository = movimentacaoRepository;
            this._conteinerRepository = conteinerRepository;
        }

        public MovimentacaoResponse Insert(MovimentacaoInicioRequest request)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();
            MovimentacaoModel newModel = null;

            MovimentacaoModel model = new MovimentacaoModel(request.Numero, request.Tipo);

            // Verifica se Conteiner existe
            ConteinerModel conteiner = _conteinerRepository.GetByNumero(request.Numero);

            if (conteiner == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            // Verifica se Conteiner já está em movimentação
            MovimentacaoModel emMov = this._movimentacaoRepository.GetEmMovimentoByNumero(request.Numero);

            if (emMov != null) {
                response.SetValid(false);
                response.SetMessage("Contêiner já está em movimentação");
                response.SetItem(emMov);

                return response;
            }

            long newId = this._movimentacaoRepository.Insert(model);

            if (newId > 0) {
                newModel = this._movimentacaoRepository.Get(newId);
            }

            if ((newId > 0) && (newModel != null)) {
                response.SetValid(true);
                response.SetMessage("Início de Movimentação cadastrado");
                response.SetItem(newModel);
            } else {
                response.SetValid(false);
                response.SetMessage("Início de Movimentação não cadastrado");
            }

            return response;
        }

        public MovimentacaoResponse Update(long id, MovimentacaoFimRequest request)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();
            MovimentacaoModel newModel = null;

            MovimentacaoModel model = new MovimentacaoModel(id, request.Numero);

            // Verifica se Conteiner existe
            ConteinerModel conteiner = _conteinerRepository.GetByNumero(request.Numero);

            if (conteiner == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            int qtd = this._movimentacaoRepository.Update(model);

            if (qtd > 0) {
                newModel = this._movimentacaoRepository.Get(model.Id);
            }

            if ((qtd > 0) && (newModel != null)) {
                response.SetValid(true);
                response.SetMessage("Fim de Movimentação cadastrado");
                response.SetItem(newModel);
            } else {
                response.SetValid(false);
                response.SetMessage("Fim de Movimentação não cadastrado");
            }

            return response;
        }

        public MovimentacaoResponse UpdateFimMovimentoByNumero(string numero)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();

            // Verifica se Conteiner existe
            ConteinerModel conteiner = _conteinerRepository.GetByNumero(numero);

            if (conteiner == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            MovimentacaoModel emMov = this._movimentacaoRepository.GetEmMovimentoByNumero(numero);

            if (emMov == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não está em Movimentação");

                return response;
            }

            int qtd = this._movimentacaoRepository.UpdateFimMovimentoByNumero(numero);

            emMov = this._movimentacaoRepository.Get(emMov.Id);

            if (qtd > 0) {
                response.SetValid(true);
                response.SetMessage("Fim de Movimentação cadastrado");
                response.SetItem(emMov);
            } else {
                response.SetValid(false);
                response.SetMessage("Fim de Movimentação não cadastrado");
            }

            return response;
        }

        public MovimentacaoResponse Get(long id)
        {
            MovimentacaoModel model = this._movimentacaoRepository.Get(id);

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetValid(true);
                response.SetItem(model);
            } else {
                response.SetValid(false);
                response.SetMessage("Movimentação não encontrada");
            }

            return response;
        }

        public MovimentacaoResponse GetEmMovimentoByNumero(string numero)
        {
            MovimentacaoModel model = this._movimentacaoRepository.GetEmMovimentoByNumero(numero);

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetValid(true);
                response.SetItem(model);
            } else {
                response.SetValid(false);
                response.SetMessage("Movimentação não encontrada");
            }

            return response;
        }

        public MovimentacaoResponse List()
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.List();

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhuma Movimentação encontrada");
            }

            return response;
        }

        public MovimentacaoResponse ListEmMovimento()
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.ListEmMovimento();

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhuma Movimentação encontrada");
            }

            return response;
        }

        public MovimentacaoResponse ListByNumero(string numero)
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.ListByNumero(numero);

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhuma Movimentação encontrada");
            }

            return response;
        }

        public MovimentacaoResponse Filter(MovimentacaoFiltroRequest request)
        {
            MovimentacaoEntity entity = new MovimentacaoEntity(request.Numero, request.Tipo);

            List<MovimentacaoEntity> list = this._movimentacaoRepository.Filter(entity);

            MovimentacaoResponse response = new MovimentacaoResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhuma Movimentação encontrada");
            }

            return response;
        }
    }
}
