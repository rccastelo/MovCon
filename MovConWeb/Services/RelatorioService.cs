using MovConWeb.Interfaces;
using MovConWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovConWeb.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioExtern _relatorioExtern;

        public RelatorioService(IRelatorioExtern relatorioExtern)
        {
            this._relatorioExtern = relatorioExtern;
        }

        public async Task<RelatorioViewModel> Pesquisar(RelatorioViewModel model)
        {
            RelatorioViewModel retModel;

            retModel = await this._relatorioExtern.Pesquisar(model);

            if (retModel != null) {
                if ((retModel.List != null) && (retModel.List.Count > 0)) {
                    if (!string.IsNullOrWhiteSpace(model.SortSelected)) {

                        if (model.SortField == model.SortSelected) {
                            if (model.SortDirection == "desc") {
                                retModel.SortDirection = "asc";
                            } else {
                                retModel.SortDirection = "desc";
                            }
                        } else {
                            retModel.SortDirection = "desc";
                        }
                        retModel.SortField = model.SortSelected;

                        List<RelatorioEntity> list;

                        switch (retModel.SortField) {
                            case "numero":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.Numero).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.Numero).ToList();
                                break;
                            case "tipocon":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.TipoConteiner).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.TipoConteiner).ToList();
                                break;
                            case "status":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.Status).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.Status).ToList();
                                break;
                            case "categoria":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.Categoria).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.Categoria).ToList();
                                break;
                            case "tipomov":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenByDescending(i => i.TipoMovimentacao).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ToList();
                                break;
                            case "inicio":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.DataHoraInicio).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.DataHoraInicio).ToList();
                                break;
                            case "fim":
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenByDescending(i => i.DataHoraFim).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ThenBy(i => i.DataHoraFim).ToList();
                                break;
                            case "cliente":
                            default:
                                if (retModel.SortDirection == "desc")
                                    list = retModel.List.OrderByDescending(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ToList();
                                else
                                    list = retModel.List.OrderBy(i => i.Cliente).ThenBy(i => i.TipoMovimentacao).ToList();
                                break;
                        }

                        retModel.List = list;
                    }
                }
            }

            return retModel;
        }
    }
}
