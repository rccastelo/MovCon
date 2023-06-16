using MovConApplication.Interfaces;
using MovConApplication.Transports;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System;
using System.Collections.Generic;

namespace MovConApplication.Services
{
    public class ConteinerService : IConteinerService
    {
        private readonly IConteinerRepository _conteinerRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ConteinerService(IConteinerRepository conteinerRepository,
            IMovimentacaoRepository movimentacaoRepository)
        {
            this._conteinerRepository = conteinerRepository;
            this._movimentacaoRepository = movimentacaoRepository;
        }

        public ConteinerResponse Incluir(ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();

            try {
                ConteinerModel model = new ConteinerModel(request.Cliente, request.Numero, request.Tipo, request.Status, request.Categoria);

                ConteinerModel modelExist = this._conteinerRepository.ObterPorNumero(model.Numero);

                // Verifica se Numero de Conteiner já está cadastrado
                if (modelExist != null) {
                    response.SetValid(false);
                    response.SetMessage("Número de Contêiner já existe");

                    return response;
                }

                long newId = this._conteinerRepository.Incluir(model);

                if (newId <= 0) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não incluído");

                    return response;
                }

                response.SetValid(true);
                response.SetMessage("Contêiner incluído");
                model.Id = newId;
                response.SetItem(model);

                return response;
            } catch (ArgumentException aex) {
                response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return response;
            }
        }

        public ConteinerResponse Alterar(long id, ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();
            ConteinerModel contExist = null;

            try {
                contExist = this._conteinerRepository.Obter(id);

                // Verifica se Conteiner existe
                if (contExist == null) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não encontrado");

                    return response;
                }

                ConteinerModel model = new ConteinerModel(id, request.Cliente, request.Numero, request.Tipo, request.Status, request.Categoria);

                // Verifica se Contêiner está em movimentação
                MovimentacaoModel movExist = this._movimentacaoRepository.ObterEmMovimentoPorNumero(contExist.Numero);

                if (movExist != null) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner está em Movimentação e não pode ser alterado");
                    response.SetItem(contExist);

                    return response;
                }

                ConteinerModel numeroExist = this._conteinerRepository.ObterPorNumero(model.Numero);

                // Verifica se Numero de Conteiner é de outro Conteiner
                if ((numeroExist != null) && (numeroExist.Id != model.Id)) {
                    response.SetValid(false);
                    response.SetMessage("Número de Contêiner já existe");
                    response.SetItem(model);

                    return response;
                }

                int qtd = this._conteinerRepository.Alterar(model);

                if (qtd <= 0) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não alterado");
                    response.SetItem(model);

                    return response;
                }

                response.SetValid(true);
                response.SetMessage("Contêiner alterado");
                response.SetItem(model);

                return response;

            } catch (ArgumentException aex) {
                response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);
                response.SetItem(contExist);

                return response;
            }
        }

        public ConteinerResponse AlterarPorNumero(string numero, ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();
            ConteinerModel modelExist = null;

            try {
                modelExist = this._conteinerRepository.ObterPorNumero(numero);

                // Verifica se Conteiner existe
                if (modelExist == null) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não encontrado");

                    return response;
                }

                return Alterar(modelExist.Id, request);
            } catch (ArgumentException aex) {
                response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);
                response.SetItem(modelExist);

                return response;
            }
        }

        public ConteinerResponse Excluir(long id)
        {
            ConteinerResponse response = new ConteinerResponse();
            ConteinerModel modelExist = null;

            try {
                modelExist = this._conteinerRepository.Obter(id);

                // Verifica se Conteiner está cadastrado
                if (modelExist == null) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não encontrado");

                    return response;
                }

                //Verifica se tem Movimentações cadastradas para esse Contêiner
                List<MovimentacaoModel> movExist = this._movimentacaoRepository.ListarPorNumero(modelExist.Numero);

                // Verifica se Conteiner está cadastrado
                if ((movExist != null) && (movExist.Count > 0)) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner possui Movimentações e não pode ser excluído");
                    response.SetItem(modelExist);

                    return response;
                }

                int qtd = this._conteinerRepository.Excluir(id);

                if (qtd <= 0) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não excluído");
                    response.SetItem(modelExist);

                    return response;
                }

                response.SetValid(true);
                response.SetMessage("Contêiner excluído");
                response.SetItem(modelExist);

                return response;
            } catch (ArgumentException aex) {
                response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);
                response.SetItem(modelExist);

                return response;
            }
        }

        public ConteinerResponse ExcluirPorNumero(string numero)
        {
            ConteinerResponse response = new ConteinerResponse();
            ConteinerModel modelExist = null;

            try {
                modelExist = this._conteinerRepository.ObterPorNumero(numero);

                // Verifica se Conteiner está cadastrado
                if (modelExist == null) {
                    response.SetValid(false);
                    response.SetMessage("Contêiner não encontrado");

                    return response;
                }

                return this.Excluir(modelExist.Id);
            } catch (ArgumentException aex) {
                response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);
                response.SetItem(modelExist);

                return response;
            }
        }

        public ConteinerResponse Obter(long id)
        {
            ConteinerModel model = this._conteinerRepository.Obter(id);

            ConteinerResponse response = new ConteinerResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetValid(true);
                response.SetItem(model);
            } else {
                response.SetValid(false);
                response.SetMessage("Contêiner não encontrado");
            }

            return response;
        }

        public ConteinerResponse ObterPorNumero(string numero)
        {
            ConteinerModel model = this._conteinerRepository.ObterPorNumero(numero);

            ConteinerResponse response = new ConteinerResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetValid(true);
                response.SetItem(model);
            } else {
                response.SetValid(false);
                response.SetMessage("Contêiner não encontrado");
            }

            return response;
        }

        public ConteinerResponse Listar()
        {
            List<ConteinerModel> list = this._conteinerRepository.Listar();

            ConteinerResponse response = new ConteinerResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhum Contêiner encontrado");
            }

            return response;
        }

        public ConteinerResponse Filtrar(ConteinerRequest request)
        {
            ConteinerEntity entity = new ConteinerEntity(
                request.Id, request.Cliente, request.Numero,
                request.Tipo, request.Status, request.Categoria);

            List<ConteinerEntity> list = this._conteinerRepository.Filtrar(entity);

            ConteinerResponse response = new ConteinerResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetValid(true);
                response.SetList(list);
            } else {
                response.SetValid(false);
                response.SetMessage("Nenhum Contêiner encontrado");
            }

            return response;
        }
    }
}
