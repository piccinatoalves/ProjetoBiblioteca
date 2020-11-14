using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblioteca.Domain.Entities;

namespace ProjBiblioteca.Infrastructure.Data.Context.Config
{
    public class LivroAutorConfiguration : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.HasKey(bc => new {bc.LivroID, bc.AutorID});

            builder.HasOne(bc => bc.Livros)
                   .WithMany(b => b.LivAutor)
                   .HasForeignKey(bc => bc.LivroID);

            builder.HasOne(bc => bc.Autores)
                   .WithMany(c => c.LivAutor)
                   .HasForeignKey(bc => bc.AutorID);
        }
    }
}