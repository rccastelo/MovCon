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
        public IActionResult Insert(ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.Insert(request);

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
            Summary = "Alteração de Contêiner",
            Description = "Alteração de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(long id, ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.Update(id, request);

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
            Summary = "Alteração de Contêiner pelo Número",
            Description = "Alteração de Contêiner pelo Número.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateByNumero(string numero, ConteinerRequest request)
        {
            try {
                ConteinerResponse response = this._conteinerService.UpdateByNumero(numero, request);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
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
        public IActionResult Delete(long id)
        {
            try {
                ConteinerResponse response = this._conteinerService.Delete(id);

                return Ok(response);
            } catch (ArgumentException aex) {
                return BadRequest(aex.Message);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro");
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
        public IActionResult DeleteByNumero(string numero)
        {
            try {
                ConteinerResponse response = this._conteinerService.DeleteByNumero(numero);

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
            Summary = "Consulta de Contêiner pelo Número",
            Description = "Consulta de Contêiner pelo Número.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult GetByNumero(string numero)
        {
            try {
                ConteinerResponse response = this._conteinerService.GetByNumero(numero);

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
            Summary = "Consulta de Contêiner",
            Description = "Consulta de Contêiner.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(long id)
        {
            try {
                ConteinerResponse response = this._conteinerService.Get(id);

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
            Summary = "Lista de Conteineres",
            Description = "Lista de Conteineres.",
            Tags = new[] { "Conteineres" }
        )]
        [ProducesResponseType(typeof(ConteinerResponse), 200)]
        [ProducesResponseType(typeof(ConteinerResponse), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            try {
                ConteinerResponse response = this._conteinerService.List();

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
