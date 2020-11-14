using System.Collections.Generic;
using AutoMapper;
using ProjBiblioteca.Application.InputModels;
using ProjBiblioteca.Application.ViewModels;
using ProjBiblioteca.Domain.Entities;
using ProjBiblioteca.Domain.Interfaces;

namespace ProjBiblioteca.Application.Interfaces
{
    public interface ILivroService
    {
        LivroListViewModel Get();

        LivroViewModel Get(int id);

        LivroViewModel Post(LivroInputModel livro);

        LivroViewModel Put(int id, LivroInputModel livro);

        LivroViewModel Delete(int id);
    }
}