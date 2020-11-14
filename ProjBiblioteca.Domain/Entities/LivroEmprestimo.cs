using System.Collections.Generic;

namespace ProjBiblioteca.Domain.Entities
{
    public class LivroEmprestimo
    {
        public int EmprestimoID { get; set; }
        public Emprestimo Emprestimos { get; set; }
        public int LivroID { get; set; }
        public Livro Livros { get; set; }

    }
}