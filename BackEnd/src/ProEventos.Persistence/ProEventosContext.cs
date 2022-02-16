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
            // METODO UTILIZADO PARA INDICAR PARA O ENTITY QUE É UMA TABELA COM PK COMPOSTA
            // QUANDO TEM RELAÇÃO MUITOS PARA MUITOS
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new {PE.EventoId,PE.PalestranteId});


            //METODO UTILIZADO PARA INDICAR PARA O ENTITY QUE QUANDO FOR DELETAR UM EVENTO
            //DELETAR DE MOTO CASCADA AS REDES SOCIAIS VINCULADAS A ESSE EVENTO
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
            .HasMany(e => e.RedesSociais)
            .WithOne(rs => rs.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);
        }


    }
}