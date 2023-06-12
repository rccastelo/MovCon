using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Filter(ConteinerViewModel model)
        {
            return View(model);
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Search(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Listar Contêineres");
            }

            return View("List", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Int64 id)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Get(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Consultar Contêiner");
            }

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.List();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Listar Contêineres");
            }

            return View("List", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Insert(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Incluir Contêiner");
            }

            return View("Form", ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ConteinerViewModel model)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Update(model);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Alterar Contêiner");
            }

            return View("Form", ret);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            ConteinerViewModel ret;

            try {
                ret = await this._conteinerService.Delete(id);

                if (ret.IsValid && !ret.IsError) ret.Item = null;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ret = new ConteinerViewModel();
                ret.SetError("Erro ao Excluir Contêiner");
            }

            return View("Form", ret);
        }

    }
}
