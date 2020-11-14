using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjBiblioteca.Domain.Entities;

namespace ProjBiblioteca.Infrastructure.Data.Context
{
    public class BibliotecaDbContext : DbContext
    {
       public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options):base(options)
       {

       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);

           // Para adicionar uma configuração por vez
           //modelBuilder.ApplyConfiguration(newAutorConfiguration());
           // OU Para adicionar todas de uma vez
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

          
           
           modelBuilder.Entity<LivroEmprestimo>().HasKey(bc => new{ bc.LivroID, bc.EmprestimoID });

       }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public DbSet<LivroEmprestimo> LivroEmprestimo { get; set; }

        
    }
}