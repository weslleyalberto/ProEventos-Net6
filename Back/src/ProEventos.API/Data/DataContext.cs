using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = 1,
                DataEvento = "03/10/1987",
                ImageURL = "foto.png",
                Local = "Brasilia",
                Lote = "1",
                QtdPessoas = 50,
                Tema = "Asp net core"
            },
            new Evento
            {
                EventoId= 2,
                DataEvento = "18/10/1954",
                ImageURL = "foto2.png",
                Tema = "Angular",
                QtdPessoas = 150,
                Lote = "2",
                Local = "Goiânia"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
