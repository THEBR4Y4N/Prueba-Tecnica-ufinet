using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Restaurante> Restaurante { get; set;}

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Hotel>()
        //        .HasOne(h => h.Pais)
        //        .WithMany()
        //        .HasForeignKey(h => h.PaisId);

        //    modelBuilder.Entity<Restaurante>()
        //        .HasOne(i => i.Pais)
        //        .WithMany()
        //        .HasForeignKey(i => i.PaisId);
        //}


    }


}
