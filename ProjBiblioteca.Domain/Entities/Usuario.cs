using System.Collections.Generic;

namespace ProjBiblioteca.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }

    }
}