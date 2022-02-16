using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{

    // CONTEXTO DO BANCO
    // AQUI FICA AS CLASSES QUE REPRESENTAM TABELAS
    // O CONTEXT É CRIADO QUANDO A CLASSE ERDA DBCONTEXT DO ENTITY FRAMEWORKCORE
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){ }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSocias { get; set; }


    // METODO UTILIZADO PARA INDICAR PARA O ENTITY QUE É UMA TABELA COM PK COMPOSTA
    // QUANDO TEM RELAÇÃO MUITOS PARA MUITOS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoId,PE.PalestranteId});
        }
    }
}