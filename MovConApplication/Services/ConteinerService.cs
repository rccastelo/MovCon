using MovConApplication.Interfaces;
using MovConApplication.Transports;
using MovConDomain.Models;
using MovConRepository.Interfaces;
using System.Collections.Generic;

namespace MovConApplication.Services
{
    public class ConteinerService : IConteinerService
    {
        private readonly IConteinerRepository _conteinerRepository;

        public ConteinerService(IConteinerRepository conteinerRepository)
        {
            this._conteinerRepository = conteinerRepository;
        }

        public ConteinerResponse Insert(ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();

            ConteinerModel modelExist = this._conteinerRepository.GetByNumero(request.Numero);

            // Verifica se Numero de Conteiner já está cadastrado
            if (modelExist != null) {
                response.SetStatus(false);
                response.SetMessage("Número de Contêiner já existe");

                return response;
            }

            ConteinerModel model = new ConteinerModel(request.Cliente, request.Numero, request.Tipo, request.Status, request.Categoria);

            long newId = this._conteinerRepository.Insert(model);

            if (newId <= 0) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não incluído");

                return response;
            }

            response.SetStatus(true);
            response.SetMessage("Contêiner incluído");
            model.Id = newId;
            response.SetItem(model);

            return response;
        }

        public ConteinerResponse Update(long id, ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();

            ConteinerModel modelExist = this._conteinerRepository.Get(id);

            // Verifica se Conteiner existe
            if (modelExist == null) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");

                return response;
            }

            ConteinerModel numeroExist = this._conteinerRepository.GetByNumero(request.Numero);

            ConteinerModel model = new ConteinerModel(id, request.Cliente, request.Numero, request.Tipo, request.Status, request.Categoria);

            // Verifica se Numero de Conteiner é de outro Conteiner
            if ((numeroExist != null) && (numeroExist.Id != model.Id)) {
                response.SetStatus(false);
                response.SetMessage("Número de Contêiner já existe");

                return response;
            }

            int qtd = this._conteinerRepository.Update(model);

            if (qtd <= 0) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não alterado");

                return response;
            }

            response.SetStatus(true);
            response.SetMessage("Contêiner alterado");
            response.SetItem(model);

            return response;
        }

        public ConteinerResponse UpdateByNumero(string numero, ConteinerRequest request)
        {
            ConteinerResponse response = new ConteinerResponse();

            ConteinerModel modelExist = this._conteinerRepository.GetByNumero(numero);

            // Verifica se Numero de Conteiner está cadastrado
            if (modelExist == null) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");

                return response;
            }

            return Update(modelExist.Id, request);
        }

        public ConteinerResponse Delete(long id)
        {
            ConteinerResponse response = new ConteinerResponse();

            ConteinerModel modelExist = this._conteinerRepository.Get(id);

            // Verifica se Conteiner está cadastrado
            if (modelExist == null) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");

                return response;
            }

            int qtd = this._conteinerRepository.Delete(id);

            if (qtd <= 0) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não excluído");

                return response;
            }

            response.SetStatus(true);
            response.SetMessage("Contêiner excluído");
            response.SetItem(modelExist);

            return response;
        }

        public ConteinerResponse DeleteByNumero(string numero)
        {
            ConteinerResponse response = new ConteinerResponse();

            ConteinerModel modelExist = this._conteinerRepository.GetByNumero(numero);

            // Verifica se Conteiner está cadastrado
            if (modelExist == null) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");

                return response;
            }

            int qtd = this._conteinerRepository.DeleteByNumero(numero);

            if (qtd <= 0) {
                response.SetStatus(false);
                response.SetMessage("Contêiner não excluído");

                return response;
            }

            response.SetStatus(true);
            response.SetMessage("Contêiner excluído");
            response.SetItem(modelExist);

            return response;
        }

        public ConteinerResponse Get(long id)
        {
            ConteinerModel model = this._conteinerRepository.Get(id);

            ConteinerResponse response = new ConteinerResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetStatus(true);
                response.SetItem(model);
            } else {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");
            }

            return response;
        }

        public ConteinerResponse GetByNumero(string numero)
        {
            ConteinerModel model = this._conteinerRepository.GetByNumero(numero);

            ConteinerResponse response = new ConteinerResponse();

            if ((model != null) && (model.Id > 0)) {
                response.SetStatus(true);
                response.SetItem(model);
            } else {
                response.SetStatus(false);
                response.SetMessage("Contêiner não encontrado");
            }

            return response;
        }

        public ConteinerResponse List()
        {
            List<ConteinerModel> list = this._conteinerRepository.List();

            ConteinerResponse response = new ConteinerResponse();

            if ((list != null) && (list.Count > 0)) {
                response.SetStatus(true);
                response.SetList(list);
            } else {
                response.SetStatus(false);
                response.SetMessage("Nenhum Contêiner encontrado");
            }

            return response;
        }
    }
}
