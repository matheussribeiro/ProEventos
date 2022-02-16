using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService eventoService;
        public EventoController(IEventoService eventoService)
        {
            this.eventoService = eventoService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await eventoService.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Nenhum Evento Encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro : {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await eventoService.GetEventoByIdAsync(id,true);
                if(evento == null) return NotFound("Nenhum Evento por Id Encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro : {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await eventoService.GetAllEventosByTemaAsync(tema,true);
                if(eventos == null) return NotFound("Nenhum Evento por tema Encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro : {ex.Message}");
            }
        }

        [HttpPost]
        public string Post()
        {
            return "Teste Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Teste Put com id = {id} ";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Teste Delete com id = {id} ";
        }
    }

}
