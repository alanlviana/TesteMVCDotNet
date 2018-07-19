using Microsoft.EntityFrameworkCore;
using TesteMVC.Models;

namespace TesteMVC.Repositories.EF{
    public class ApplicationContext: DbContext{

        public ApplicationContext(DbContextOptions options): base(options){
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Analista>().HasKey(p => p.Id);
            modelBuilder.Entity<Analista>()
                            .Property(t => t.Nome)
                            .IsRequired()
                            .HasMaxLength(50);
        }
    }
}