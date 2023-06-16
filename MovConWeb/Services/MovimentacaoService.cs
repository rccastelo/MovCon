using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovConWeb.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoExtern _movimentacaoExtern;

        public MovimentacaoService(IMovimentacaoExtern movimentacaoExtern)
        {
            this._movimentacaoExtern = movimentacaoExtern;
        }

        public async Task<MovimentacaoViewModel> Pesquisar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel retModel;

            retModel = await this._movimentacaoExtern.Pesquisar(model);

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

                        List<MovimentacaoEntity> list;

                        switch (retModel.SortField) {
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
                            case "tipocon":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.TipoConteiner).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.TipoConteiner).ToList();
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
                            case "inicio":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.DataHoraInicioFormatado).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.DataHoraInicioFormatado).ToList();
                                break;
                            case "fim":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.DataHoraFimFormatado).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.DataHoraFimFormatado).ToList();
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

        public async Task<MovimentacaoViewModel> Obter(Int64 id)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Obter(id);

            return ret;
        }

        public async Task<MovimentacaoViewModel> Listar()
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Listar();

            return ret;
        }

        public async Task<MovimentacaoViewModel> Iniciar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Iniciar(model);

            return ret;
        }

        public async Task<MovimentacaoViewModel> Finalizar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Finalizar(model);

            return ret;
        }
    }
}
