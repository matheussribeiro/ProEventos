﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
    public IEnumerable<Evento> _evento = new Evento[] {
                 new Evento(){
                 EventoId = 1,
                 Tema = "Angular 11 e .Net 5 ",
                 Local = "Belo Horizonte",
                 Lote = "1º Lote",
                 QtdPessoas = 250,
                 DataEvento = DateTime.Now.AddDays(2).ToString(),
                 ImageURL = "Foto.jpeg"
                 },
                 new Evento(){
                 EventoId = 2,
                 Tema = "Bora de Full Stack OAB ",
                 Local = "Brasília",
                 Lote = "2º Lote",
                 QtdPessoas = 350,
                 DataEvento = DateTime.Now.AddDays(3).ToString(),
                 ImageURL = "Foto.png"
                 }
    };
        public EventoController()
        {
          
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
             return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
            
        {
             return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Teste Post";
        }

        [HttpPut("{id}")]
        public string Post(int id)
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
