using Microsoft.AspNetCore.Mvc;
using MovConWeb.Helpers;
using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IMovimentacaoService movimentacaoService)
        {
            this._movimentacaoService = movimentacaoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Filtrar(MovimentacaoViewModel model)
        {
            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoMovimentacao(model?.Filter?.Tipo, false, true, false);

            return View("Filtro", model);
        }

        public IActionResult Form()
        {
            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoMovimentacao(null, false, false, true);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pesquisar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;
            string ddlTipo = null;
            string rdbPendente = null;

            try {
                ddlTipo = Request.Form["DdlTipo"].ToString();
                rdbPendente = Request.Form["rdbPendente"].ToString();

                if ((model != null) && (model.Filter != null)) {
                    model.Filter.Tipo = ddlTipo;
                    model.Filter.Pendente = (rdbPendente == "S") ? true : false;
                    model.Filter.Numero = model.Filter.Numero.ToUpper();
                }

                ret = await this._movimentacaoService.Pesquisar(model);

                if (ret != null) {
                    ret.Filter = new MovimentacaoEntity() { Tipo = ddlTipo };
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Listar Movimentações");
            }

            ViewData["rdbPendente"] = rdbPendente;
            ViewData["DdlTipo"] = ddlTipo;

            return View("Lista", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Obter(Int64 id)
        {
            MovimentacaoViewModel ret;

            try {
                ret = await this._movimentacaoService.Obter(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Consultar Movimentação");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoMovimentacao(ret?.Item?.Tipo, false, false, true);

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            MovimentacaoViewModel ret;

            try {
                ret = await this._movimentacaoService.Listar();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Listar Movimentações");
            }

            return View("Lista", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iniciar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();

                if ((model != null) && (model.Item != null)) {
                    model.Item.Tipo = ddlTipo;
                    model.Item.Numero = model.Item.Numero.ToUpper();
                }

                ret = await this._movimentacaoService.Iniciar(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Incluir Movimentação");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoMovimentacao(ret?.Item?.Tipo, false, false, true);

            return View("Form", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();

                if ((model != null) && (model.Item != null)) {
                    model.Item.Tipo = ddlTipo;
                    model.Item.Numero = model.Item.Numero.ToUpper();
                }

                ret = await this._movimentacaoService.Finalizar(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Alterar Movimentação");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoMovimentacao(ret?.Item?.Tipo, false, false, true);

            return View("Form", ret);
        }

    }
}
