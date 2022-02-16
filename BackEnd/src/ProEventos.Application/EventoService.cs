using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence geral;
        private readonly IEventoPersistence evento;
        public EventoService(IGeralPersistence geral, IEventoPersistence evento)
        {
            this.evento = evento;
            this.geral = geral;

        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                geral.Add<Evento>(model);
                if (await geral.SaveChangesAsync())
                {
                    return await evento.GetEventoByIdAsync(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

        }

        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var eventoupdt = await evento.GetEventoByIdAsync(eventoId,false);
                if(eventoupdt == null) return null;

                model.Id = eventoupdt.Id;

                geral.Update(model);
                if (await geral.SaveChangesAsync())
                {
                    return await evento.GetEventoByIdAsync(model.Id,false);
                }
                return null;
            }


            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEventos(int eventoId)
        {
             try
            {
                var eventoupdt = await evento.GetEventoByIdAsync(eventoId,false);
                if(eventoupdt == null) throw new Exception("Evento para Delete não encontrado");

                geral.Delete<Evento>(eventoupdt);
                return await geral.SaveChangesAsync();
            }


            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await evento.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await evento.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null) return null;
                
                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventobyid = await evento.GetEventoByIdAsync(eventoId,includePalestrantes);
                if (eventobyid == null) return null;
                
                return eventobyid;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}