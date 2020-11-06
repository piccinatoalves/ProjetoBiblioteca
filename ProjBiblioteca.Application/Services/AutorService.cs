using ProjBiblioteca.Application.Interfaces;
using ProjBiblioteca.Application.ViewModels;
using ProjBiblioteca.Domain.Interfaces;

namespace ProjBiblioteca.Application.Services
{
    public class AutorService : IAutorService
    {
        private IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            this._autorRepository = autorRepository;
        }
        public AutorListViewModel Get()
        {
           return new AutorListViewModel()
           {
               Autores = this._autorRepository.Get()
           };
        }
    }
        
}