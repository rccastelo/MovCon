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
        public IActionResult Iniciar(MovimentacaoInicioRequest requestNew)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Iniciar(requestNew);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult Finalizar(long id, MovimentacaoFimRequest requestMod)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Finalizar(id, requestMod);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult FinalizarPorNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.FinalizarPorNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult Obter(long id)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Obter(id);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult ObterEmMovimentoPorNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.ObterEmMovimentoPorNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult Listar()
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Listar();

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult ListarEmMovimento()
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.ListarEmMovimento();

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
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
        public IActionResult ListarPorNumero(string numero)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.ListarPorNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpPost("filtrar")]
        [SwaggerOperation(
            Summary = "Lista filtrada de Movimentações",
            Description = "Lista filtrada de Movimentações.",
            Tags = new[] { "Movimentacoes" }
        )]
        [ProducesResponseType(typeof(MovimentacaoResponse), 200)]
        [ProducesResponseType(typeof(MovimentacaoResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Filtrar(MovimentacaoFiltroRequest request)
        {
            try {
                MovimentacaoResponse response = this._movimentacaoService.Filtrar(request);

                return Ok(response);
            } catch (ArgumentException aex) {
                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                MovimentacaoResponse response = new MovimentacaoResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }
    }
}
