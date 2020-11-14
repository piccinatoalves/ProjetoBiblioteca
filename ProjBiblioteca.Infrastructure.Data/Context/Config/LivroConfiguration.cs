using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblioteca.Domain.Entities;

namespace ProjBiblioteca.Infrastructure.Data.Context.Config
{
    public class LivroConfiguration: IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(t=>t.Titulo)
                .IsRequired();
            }
    }
}