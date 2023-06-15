using Microsoft.AspNetCore.Mvc;
using MovConApplication.Interfaces;
using MovConApplication.Transports;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace MovConApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConteineresController : ControllerBase
    {
        private readonly IConteinerService _conteinerService;

        public ConteineresController(IConteinerService conteinerService)
        {
            this._conteinerService = conteinerService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Inclusão de Contêiner",
            Description = "Inclusão de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Incluir(ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.Incluir(request);

                if (response.IsValid)
                    return Ok(response);
                else
                    return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Alteração de Contêiner",
            Description = "Alteração de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(long id, ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.Alterar(id, request);

                if (response.IsValid)
                    return Ok(response);
                else
                    return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpPut("numero/{numero}")]
        [SwaggerOperation(
            Summary = "Alteração de Contêiner pelo Número",
            Description = "Alteração de Contêiner pelo Número.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult AlterarPorNumero(string numero, ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.AlterarPorNumero(numero, request);

                if (response.IsValid)
                    return Ok(response);
                else
                    return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Exclusão de Contêiner",
            Description = "Exclusão de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Excluir(long id)
        {
            try {
                ConteinerResponse response = this._conteinerService.Excluir(id);

                if (response.IsValid)
                    return Ok(response);
                else
                    return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpDelete("numero/{numero}")]
        [SwaggerOperation(
            Summary = "Exclusão de Contêiner pelo Número",
            Description = "Exclusão de Contêiner pelo Número.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult ExcluirPorNumero(string numero)
        {
            try {
                ConteinerResponse response = this._conteinerService.ExcluirPorNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                ConteinerResponse response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpGet("numero/{numero}")]
        [SwaggerOperation(
            Summary = "Consulta de Contêiner pelo Número",
            Description = "Consulta de Contêiner pelo Número.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult ObterPorNumero(string numero)
        {
            try {
                ConteinerResponse response = this._conteinerService.ObterPorNumero(numero);

                return Ok(response);
            } catch (ArgumentException aex) {
                ConteinerResponse response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consulta de Contêiner",
            Description = "Consulta de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Obter(long id)
        {
            try {
                ConteinerResponse response = this._conteinerService.Obter(id);

                return Ok(response);
            } catch (ArgumentException aex) {
                ConteinerResponse response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de Conteineres",
            Description = "Lista de Conteineres.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            try {
                ConteinerResponse response = this._conteinerService.Listar();

                return Ok(response);
            } catch (ArgumentException aex) {
                ConteinerResponse response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }

        [HttpPost("filtrar")]
        [SwaggerOperation(
            Summary = "Lista filtrada de Conteineres",
            Description = "Lista filtrada de Conteineres.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Filtrar(ConteinerRequest request)
        {
            try
            {
                ConteinerResponse response = this._conteinerService.Filtrar(request);

                return Ok(response);
            }
            catch (ArgumentException aex)
            {
                ConteinerResponse response = new ConteinerResponse();
                response.SetValid(false);
                response.SetMessage(aex.Message);

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                ConteinerResponse response = new ConteinerResponse();
                response.SetError("Erro");

                return BadRequest(response);
            }
        }
    }
}
