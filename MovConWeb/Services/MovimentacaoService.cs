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

        public async Task<MovimentacaoViewModel> Search(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel newTransport;

            newTransport = await this._movimentacaoExtern.Filter(model);

            if (newTransport != null) {
                if ((newTransport.List != null) && (newTransport.List.Count > 0)) {
                    if (!string.IsNullOrWhiteSpace(model.SortSelected)) {

                        if (model.SortField == model.SortSelected) {
                            if (model.SortDirection == "desc") {
                                newTransport.SortDirection = "asc";
                            } else {
                                newTransport.SortDirection = "desc";
                            }
                        }
                        newTransport.SortField = model.SortSelected;

                        List<MovimentacaoEntity> list;

                        switch (newTransport.SortField) {
                            case "numero":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Numero).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Numero).ToList();
                                break;
                            case "tipo":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Tipo).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Tipo).ToList();
                                break;
                            case "inicio":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.DataHoraInicio).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.DataHoraInicio).ToList();
                                break;
                            case "fim":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.DataHoraFim).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.DataHoraFim).ToList();
                                break;
                            case "id":
                            default:
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Id).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Id).ToList();
                                break;
                        }

                        newTransport.List = list;
                    }
                }
            }

            return newTransport;
        }

        public async Task<MovimentacaoViewModel> Get(Int64 id)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Get(id);

            return ret;
        }

        public async Task<MovimentacaoViewModel> List()
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.List();

            return ret;
        }

        public async Task<MovimentacaoViewModel> Insert(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Insert(model);

            return ret;
        }

        public async Task<MovimentacaoViewModel> Update(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Update(model);

            return ret;
        }

        public async Task<MovimentacaoViewModel> Delete(Int64 id)
        {
            MovimentacaoViewModel ret;

            ret = await this._movimentacaoExtern.Delete(id);

            return ret;
        }
    }
}
