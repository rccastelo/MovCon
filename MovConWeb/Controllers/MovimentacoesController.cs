using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovConWeb.Interfaces;
using MovConWeb.Models;
using System;
using System.Collections.Generic;
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

        public IActionResult Filter(MovimentacaoViewModel model)
        {
            MontarDdlTipo(model?.Filter?.Tipo);

            return View(model);
        }

        public IActionResult Form()
        {
            MontarDdlTipo(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;
            string ddlTipo = null;

            try {
                ddlTipo = Request.Form["DdlTipo"].ToString();

                if ((model != null) && (model.Filter != null)) model.Filter.Tipo = ddlTipo;
                
                ret = await this._movimentacaoService.Search(model);

                if (ret != null) {
                    ret.Filter = new MovimentacaoEntity() { Tipo = ddlTipo };
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Listar Movimentações");
            }

            ViewData["DdlTipo"] = ddlTipo;

            return View("List", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Int64 id)
        {
            MovimentacaoViewModel ret;

            try {
                ret = await this._movimentacaoService.Get(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Consultar Movimentação");
            }

            MontarDdlTipo(ret?.Item?.Tipo);

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            MovimentacaoViewModel ret;

            try {
                ret = await this._movimentacaoService.List();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Listar Movimentações");
            }

            return View("List", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();

                if ((model != null) && (model.Item != null)) model.Item.Tipo = ddlTipo;

                ret = await this._movimentacaoService.Insert(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Incluir Movimentação");
            }

            MontarDdlTipo(ret?.Item?.Tipo);

            return View("Form", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MovimentacaoViewModel model)
        {
            MovimentacaoViewModel ret;

            try {
                string ddlTipo = Request.Form["DdlTipo"].ToString();

                if ((model != null) && (model.Item != null)) model.Item.Tipo = ddlTipo;

                ret = await this._movimentacaoService.Update(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new MovimentacaoViewModel();
                ret.SetError("Erro ao Alterar Movimentação");
            }

            MontarDdlTipo(ret?.Item?.Tipo);

            return View("Form", ret);
        }

        private void MontarDdlTipo(string tipo)
        {
            // Simulando retorno dos dados do domínio Tipo de Movimentação

            List<SelectListItem> items = new List<SelectListItem>() {
                new SelectListItem() { Value = "", Text = "" },
                new SelectListItem() { Value = "Embarque", Text = "Embarque" },
                new SelectListItem() { Value = "Descarga", Text = "Descarga" },
                new SelectListItem() { Value = "GateIn", Text = "Gate In" },
                new SelectListItem() { Value = "GateOut", Text = "Gate Out" },
                new SelectListItem() { Value = "Reposicionamento", Text = "Reposicionamento" },
                new SelectListItem() { Value = "Pesagem", Text = "Pesagem" },
                new SelectListItem() { Value = "Scanner", Text = "Scanner" }
            };

            ViewData["DdlTipo"] = new SelectList(items, "Value", "Text", tipo);
        }
    }
}
