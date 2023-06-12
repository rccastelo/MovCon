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

        public async Task<ConteinerViewModel> Search(ConteinerViewModel transport)
        {
            ConteinerViewModel newTransport;

            newTransport = await this._conteinerExtern.Filter(transport);

            if (newTransport != null) {
                if ((newTransport.List != null) && (newTransport.List.Count > 0)) {
                    if (!string.IsNullOrWhiteSpace(transport.SortSelected)) {

                        if (transport.SortField == transport.SortSelected) {
                            if (transport.SortDirection == "desc") {
                                newTransport.SortDirection = "asc";
                            } else {
                                newTransport.SortDirection = "desc";
                            }
                        }
                        newTransport.SortField = transport.SortSelected;

                        List<ConteinerEntity> list;

                        switch (newTransport.SortField) {
                            case "cliente":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Cliente).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Cliente).ToList();
                                break;
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
                            case "status":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Status).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Status).ToList();
                                break;
                            case "categoria":
                                if (newTransport.SortDirection == "desc")
                                    list = newTransport.List.OrderByDescending(i => i.Categoria).ToList();
                                else
                                    list = newTransport.List.OrderBy(i => i.Categoria).ToList();
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

        public async Task<ConteinerViewModel> Get(Int64 id)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Get(id);

            return ret;
        }

        public async Task<ConteinerViewModel> List()
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.List();

            return ret;
        }

        public async Task<ConteinerViewModel> Insert(ConteinerViewModel transport)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Insert(transport);

            return ret;
        }

        public async Task<ConteinerViewModel> Update(ConteinerViewModel transport)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Update(transport);

            return ret;
        }

        public async Task<ConteinerViewModel> Delete(Int64 id)
        {
            ConteinerViewModel ret;

            ret = await this._conteinerExtern.Delete(id);

            return ret;
        }
    }
}
