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

        public MovimentacaoResponse Iniciar(MovimentacaoInicioRequest request)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();
            MovimentacaoModel newModel = null;

            MovimentacaoModel movimentacaoModel = new MovimentacaoModel(request.Numero, request.Tipo);

            // Verifica se Conteiner existe
            ConteinerModel conteinerModel = _conteinerRepository.ObterPorNumero(request.Numero);

            if (conteinerModel == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            // Verifica se Conteiner já está em movimentação
            MovimentacaoModel emMov = this._movimentacaoRepository.ObterEmMovimentoPorNumero(request.Numero);

            if (emMov != null) {
                response.SetValid(false);
                response.SetMessage("Contêiner já está em movimentação");
                response.SetItem(emMov);

                return response;
            }

            // Preenche com os dados atuais do contêiner
            movimentacaoModel = new MovimentacaoModel(request.Numero, request.Tipo, conteinerModel.Tipo,
                    conteinerModel.Status, conteinerModel.Categoria);

            long newId = this._movimentacaoRepository.Iniciar(movimentacaoModel);

            if (newId > 0) {
                newModel = this._movimentacaoRepository.Obter(newId);
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

        public MovimentacaoResponse Finalizar(long id, MovimentacaoFimRequest request)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();
            MovimentacaoModel newModel = null;

            MovimentacaoModel model = new MovimentacaoModel(id, request.Numero);

            // Verifica se Conteiner existe
            ConteinerModel conteiner = _conteinerRepository.ObterPorNumero(request.Numero);

            if (conteiner == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            int qtd = this._movimentacaoRepository.Finalizar(model);

            if (qtd > 0) {
                newModel = this._movimentacaoRepository.Obter(model.Id);
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

        public MovimentacaoResponse FinalizarPorNumero(string numero)
        {
            MovimentacaoResponse response = new MovimentacaoResponse();

            // Verifica se Conteiner existe
            ConteinerModel conteiner = _conteinerRepository.ObterPorNumero(numero);

            if (conteiner == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não existe");

                return response;
            }

            MovimentacaoModel emMov = this._movimentacaoRepository.ObterEmMovimentoPorNumero(numero);

            if (emMov == null) {
                response.SetValid(false);
                response.SetMessage("Contêiner não está em Movimentação");

                return response;
            }

            int qtd = this._movimentacaoRepository.FinalizarPorNumero(numero);

            emMov = this._movimentacaoRepository.Obter(emMov.Id);

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

        public MovimentacaoResponse Obter(long id)
        {
            MovimentacaoModel model = this._movimentacaoRepository.Obter(id);

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

        public MovimentacaoResponse ObterEmMovimentoPorNumero(string numero)
        {
            MovimentacaoModel model = this._movimentacaoRepository.ObterEmMovimentoPorNumero(numero);

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

        public MovimentacaoResponse Listar()
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.Listar();

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

        public MovimentacaoResponse ListarEmMovimento()
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.ListarEmMovimento();

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

        public MovimentacaoResponse ListarPorNumero(string numero)
        {
            List<MovimentacaoModel> list = this._movimentacaoRepository.ListarPorNumero(numero);

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

        public MovimentacaoResponse Filtrar(MovimentacaoFiltroRequest request)
        {
            MovimentacaoEntity entity = new MovimentacaoEntity(request.Numero, request.Tipo, request.Pendente);

            List<MovimentacaoEntity> list = this._movimentacaoRepository.Filtrar(entity);

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
