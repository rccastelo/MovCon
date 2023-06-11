using Microsoft.AspNetCore.Mvc;
using MovConApplication.Interfaces;
using MovConApplication.Transports;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace MovConApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IMovimentacaoService movimentacaoService)
        {
            this._movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "[Inclusão] Iniciar Movimentação",
            Description = "[Inclusão] Iniciar Movimentação.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(MovimentacaoInicioRequest requestNew)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Insert(requestNew);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "[Alteração] Finalizar Movimentação",
            Description = "[Alteração] Finalizar Movimentação.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(long id, MovimentacaoFimRequest requestMod)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Update(id, requestMod);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpPut("numero/{numero}")]
        [SwaggerOperation(
            Summary = "[Alteração] Finalizar Movimentação pelo Número do Contêiner",
            Description = "[Alteração] Finalizar Movimentação pelo Número do Contêiner.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateFimMovimentoByNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.UpdateFimMovimentoByNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consulta de Movimentação",
            Description = "Consulta de Movimentação.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Get(id);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpGet("pendente/{numero}")]
        [SwaggerOperation(
            Summary = "Consulta Movimentação pendente de finalização pelo Número do Contêiner",
            Description = "Consulta Movimentação pendente de finalização pelo Número do Contêiner.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetEmMovimentoByNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.GetEmMovimentoByNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de Movimentações",
            Description = "Lista de Movimentações.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.List();

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpGet("pendente")]
        [SwaggerOperation(
            Summary = "Lista de Movimentações pendentes de finalização",
            Description = "Lista de Movimentações pendentes de finalização.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult ListEmMovimento()
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.ListEmMovimento();

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }

        [HttpGet("numero/{numero}")]
        [SwaggerOperation(
            Summary = "Lista de Movimentações pelo Número do Contêiner",
            Description = "Lista de Movimentações pelo Número do Contêiner.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult ListByNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.ListByNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
            }
        }
    }
}
