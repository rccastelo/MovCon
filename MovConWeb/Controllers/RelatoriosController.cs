using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MovConWeb.Helpers;
using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            this._relatorioService = relatorioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            RelatorioViewModel ret;

            try {
                RelatorioViewModel model = new RelatorioViewModel();
                model.Filter = new RelatorioEntity();

                ret = await this._relatorioService.Pesquisar(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new RelatorioViewModel();
                ret.SetError("Erro ao Gerar Relatório");
            }

            return View("Relatorio", ret);
        }

        public IActionResult Filtrar(RelatorioViewModel model)
        {
            ViewData["DdlTipoMovimentacao"] = DomainsHelper.MontarDdlTipoMovimentacao(model?.Filter?.TipoMovimentacao, false, true, false);
            ViewData["DdlTipoConteiner"] = DomainsHelper.MontarDdlTipoConteiner(model?.Filter?.TipoConteiner, false, true, false);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(model?.Filter?.Status, false, true, false);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(model?.Filter?.Categoria, false, true, false);

            return View("Filtro", model);
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisar(RelatorioViewModel model)
        {
            RelatorioViewModel ret;
            StringValues ddlTipoMovimentacao;
            string ddlTipoConteiner = null;
            string ddlStatus = null;
            string ddlCategoria = null;
            string rdbPendente = null;

            try {
                ddlTipoMovimentacao = Request.Form["ddlTipoMovimentacao"].ToString();
                ddlTipoConteiner = Request.Form["DdlTipoConteiner"].ToString();
                ddlStatus = Request.Form["ddlStatus"].ToString();
                ddlCategoria = Request.Form["ddlCategoria"].ToString();
                rdbPendente = Request.Form["rdbPendente"].ToString();

                if (model.Filter == null) model.Filter = new RelatorioEntity();

                model.Filter.TipoMovimentacao = ddlTipoMovimentacao;
                model.Filter.TipoConteiner = ddlTipoConteiner;
                model.Filter.Status = ddlStatus;
                model.Filter.Categoria = ddlCategoria;
                model.Filter.Pendente = (rdbPendente == "S") ? true : false;

                ret = await this._relatorioService.Pesquisar(model);

                if (ret != null) {
                    ret.Filter = new RelatorioEntity() {
                        TipoMovimentacao = ddlTipoMovimentacao,
                        TipoConteiner = ddlTipoConteiner,
                        Status = ddlStatus,
                        Categoria = ddlCategoria
                    };
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new RelatorioViewModel();
                ret.SetError("Erro ao Gerar Relatório");
            }

            ViewData["DdlTipoMovimentacao"] = ddlTipoMovimentacao;
            ViewData["DdlTipoConteiner"] = ddlTipoConteiner;
            ViewData["DdlStatus"] = ddlStatus;
            ViewData["DdlCategoria"] = ddlCategoria;
            ViewData["rdbPendente"] = rdbPendente;

            return View("Relatorio", ret);
        }
    }
}
