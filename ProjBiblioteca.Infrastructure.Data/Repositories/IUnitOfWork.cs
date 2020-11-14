using ProjBiblioteca.Domain.Interfaces;
using ProjBiblioteca.Infrastructure.Data.Context;


namespace ProjBiblioteca.Infrastructure.Data.Repositories
{
public class UnitOfWork : IUnitOfWork
    {
        private AutorRepository _autorRepo; 
        private LivroRepository _livroRepo; 

        private BibliotecaDbContext _context;

        public IAutorRepository AutorRepository
        {
            get { 
                return _autorRepo = _autorRepo ?? new AutorRepository(_context);
            }
        }
        public ILivroRepository LivroRepository
        {
            get { 
                return _livroRepo = _livroRepo ?? new LivroRepository(_context);
            }
        }

        

        public UnitOfWork(BibliotecaDbContext contexto)
        {
            _context = contexto;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}