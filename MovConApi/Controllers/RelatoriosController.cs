using Microsoft.AspNetCore.Mvc;
using MovConApplication.Interfaces;
using MovConApplication.Transports;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace MovConApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            this._relatorioService = relatorioService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Pesquisa informações para relatório",
            Description = "Pesquisa informações para relatório.",
            Tags = new[] { "Relatorios" }
        )]
        [ProducesResponseType(typeof(RelatorioResponse), 200)]
        [ProducesResponseType(typeof(RelatorioResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Pesquisar(RelatorioRequest request)
        {
            try {
                RelatorioResponse response = this._relatorioService.Pesquisar(request);

                return Ok(response);
            } catch (ArgumentException aex) {
                RelatorioResponse response = new RelatorioResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                RelatorioResponse response = new RelatorioResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }
    }
}
