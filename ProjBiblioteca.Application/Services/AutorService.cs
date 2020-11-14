using System.Collections.Generic;
using AutoMapper;
using ProjBiblioteca.Application.InputModels;
using ProjBiblioteca.Application.Interfaces;
using ProjBiblioteca.Application.ViewModels;
using ProjBiblioteca.Domain.Entities;
using ProjBiblioteca.Domain.Interfaces;

namespace ProjBiblioteca.Application.Services
{
    public class AutorService : IAutorService
    {
        private  IUnitOfWork _uow;
         public IMapper _mapper;

        public AutorService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public AutorListViewModel Get()
        {
            var autores = this._uow.AutorRepository.Get();
            return new AutorListViewModel()
            {
                Autores = _mapper.Map<IEnumerable<AutorViewModel>>(autores)
            };
        //return _mapper.Map<AutorListViewModel>(this._uow.AutorRepository.Get())
        }
        public AutorViewModel Get(int id)
        {
            var autor = this._uow.AutorRepository.GetById(a  => a.AutorID==id);
            if(autor==null)
            return null;
            
            
            return _mapper.Map<AutorViewModel>(autor);

            // return new AutorViewModel()
            // {
            //     Id=autor.AutorID,
            //     Nome=autor.Nome
            // };
        }

        public AutorViewModel Post(AutorInputModel autorInputModel)
        {
            var autor = _mapper.Map<Autor>(autorInputModel);

            _uow.AutorRepository.Add(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

        public AutorViewModel Put(int id, AutorInputModel autorInputModel)
        {
            var autor = _mapper.Map<Autor>(autorInputModel);

            _uow.AutorRepository.Update(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

        public AutorViewModel Delete(int id)
        {
            var autor = this._uow.AutorRepository.GetById(a => a.AutorID == id);

            if (autor == null)
            {
                return null;
            }

            _uow.AutorRepository.Delete(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

    }
        
}