using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovConWeb.Services
{
    public class ConteinerService : IConteinerService
    {
        private readonly IConteinerExtern _conteinerExtern;

        public ConteinerService(IConteinerExtern conteinerExtern)
        {
            this._conteinerExtern = conteinerExtern;
        }

        public async Task<ConteinerViewModel> Pesquisar(ConteinerViewModel model)
        {
            ConteinerViewModel retModel;

            retModel = await this._conteinerExtern.Pesquisar(model);

            if (retModel != null) {
                if ((retModel.List != null) && (retModel.List.Count > 0)) {
                    if (!string.IsNullOrWhiteSpace(model.SortSelected)) {

                        if (model.SortField == model.SortSelected) {
                            if (model.SortDirection == "desc") {
                                retModel.SortDirection = "asc";
                            } else {
                                retModel.SortDirection = "desc";
                            }
                        }
                        retModel.SortField = model.SortSelected;

                        List<ConteinerEntity> list;

                        switch (retModel.SortField) {
                            case "cliente":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Cliente).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ToList();
                                break;
                            case "numero":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Numero).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Numero).ToList();
                                break;
                            case "tipo":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Tipo).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Tipo).ToList();
                                break;
                            case "status":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Status).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Status).ToList();
                                break;
                            case "categoria":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Categoria).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Categoria).ToList();
                                break;
                            case "id":
                            default:
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Id).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Id).ToList();
                                break;
                        }

                        retModel.List = list;
                    }
                }
            }

            return retModel;
        }

        public async Task<ConteinerViewModel> Obter(Int64 id)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Obter(id);

            return ret;
        }

        public async Task<ConteinerViewModel> Listar()
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Listar();

            return ret;
        }

        public async Task<ConteinerViewModel> Incluir(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Incluir(model);

            return ret;
        }

        public async Task<ConteinerViewModel> Alterar(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Alterar(model);

            return ret;
        }

        public async Task<ConteinerViewModel> Excluir(Int64 id)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Excluir(id);

            return ret;
        }
    }
}
