namespace ProjBiblioteca.Domain.Entities
{
    public class LivroAutor
    {
        public int LivroID { get; set; }
        public Livro Livros { get; set; }
        public int AutorID { get; set; }
        public Autor Autores { get; set; }

        
    }
}