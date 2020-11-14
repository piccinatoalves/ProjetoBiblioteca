using System.Collections.Generic;
using ProjBiblioteca.Domain.Entities;

namespace ProjBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        IEnumerable<Livro> GetLivrosSemEstoque();
        IEnumerable<Livro> GetLivrosContemTitulo(string titulo);
        IEnumerable<Livro> GetLivrosPorAutor(int autorID);
    }
}