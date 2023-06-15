using Microsoft.AspNetCore.Mvc;
using MovConWeb.Helpers;
using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Controllers
{
    public class ConteineresController : Controller
    {
        private readonly IConteinerService _conteinerService;

        public ConteineresController(IConteinerService conteinerService)
        {
            this._conteinerService = conteinerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Filtrar(ConteinerViewModel model)
        {
            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(model?.Filter?.Tipo, false, true, false);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(model?.Filter?.Status, false, true, false);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(model?.Filter?.Categoria, false, true, false);

            return View("Filtro", model);
        }

        public IActionResult Form()
        {
            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(null, false, false, true);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(null, false, false, true);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(null, false, false, true);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pesquisar(ConteinerViewModel model)
        {
            ConteinerViewModel ret;
            string ddlTipo = null;
            string ddlStatus = null;
            string ddlCategoria = null;

            try {
                ddlTipo = Request.Form["DdlTipo"].ToString();
                ddlStatus = Request.Form["ddlStatus"].ToString();
                ddlCategoria = Request.Form["ddlCategoria"].ToString();

                if ((model != null) && (model.Filter != null)) {
                    model.Filter.Tipo = ddlTipo;
                    model.Filter.Status = ddlStatus;
                    model.Filter.Categoria = ddlCategoria;
                    model.Filter.Numero = model.Filter.Numero.ToUpper();
                }

                ret = await this._conteinerService.Pesquisar(model);

                if (ret != null) {
                    ret.Filter = new ConteinerEntity() {
                        Tipo = ddlTipo,
                        Status = ddlStatus,
                        Categoria = ddlCategoria
                    };
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Listar Contêineres");
            }

            ViewData["DdlTipo"] = ddlTipo;
            ViewData["DdlStatus"] = ddlStatus;
            ViewData["DdlCategoria"] = ddlCategoria;

            return View("Lista", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Obter(Int64 id)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Obter(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Consultar Contêiner");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(ret?.Item?.Tipo, false, false, true);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(ret?.Item?.Status, false, false, true);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(ret?.Item?.Categoria, false, false, true);

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Listar();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Listar Contêineres");
            }

            return View("Lista", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Incluir(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();
                string ddlStatus = Request.Form["ddlStatus"].ToString();
                string ddlCategoria = Request.Form["ddlCategoria"].ToString();

                if ((model != null) && (model.Item != null)) {
                    model.Item.Tipo = ddlTipo;
                    model.Item.Status = ddlStatus;
                    model.Item.Categoria = ddlCategoria;
                    model.Item.Numero = model.Item.Numero.ToUpper();
                }

                ret = await this._conteinerService.Incluir(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Incluir Contêiner");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(model?.Item?.Tipo, false, false, true);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(model?.Item?.Status, false, false, true);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(model?.Item?.Categoria, false, false, true);

            return View("Form", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();
                string ddlStatus = Request.Form["ddlStatus"].ToString();
                string ddlCategoria = Request.Form["ddlCategoria"].ToString();

                if ((model != null) && (model.Item != null)) {
                    model.Item.Tipo = ddlTipo;
                    model.Item.Status = ddlStatus;
                    model.Item.Categoria = ddlCategoria;
                    model.Item.Numero = model.Item.Numero.ToUpper();
                }

                ret = await this._conteinerService.Alterar(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Alterar Contêiner");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(ret?.Item?.Tipo, false, false, true);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(ret?.Item?.Status, false, false, true);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(ret?.Item?.Categoria, false, false, true);

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(Int64 id)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Excluir(id);

                if (ret.IsValid && !ret.IsError) ret.Item = null;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Excluir Contêiner");
            }

            ViewData["DdlTipo"] = DomainsHelper.MontarDdlTipoConteiner(ret?.Item?.Tipo, false, false, true);
            ViewData["DdlStatus"] = DomainsHelper.MontarDdlStatusConteiner(ret?.Item?.Status, false, false, true);
            ViewData["DdlCategoria"] = DomainsHelper.MontarDdlCategoriaConteiner(ret?.Item?.Categoria, false, false, true);

            return View("Form", ret);
        }

    }
}
