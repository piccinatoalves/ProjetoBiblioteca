using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjBiblioteca.Application.Interfaces;
using ProjBiblioteca.Application.Services;
using ProjBiblioteca.Domain.Interfaces;
using ProjBiblioteca.Infrastructure.Data.Context;
using ProjBiblioteca.Infrastructure.Data.Repositories;


namespace ProjBiblioteca.Infrastructure.IoC
{
    public class DependecyContainer
    {
        public static void RegisterServices(IServiceCollection services)
    {
        //Projeto de Aplicaçãos 
        services.AddScoped<IAutorService, AutorService>();
        services.AddScoped<ILivroService, LivroService>();
        //ProjetoDomínio|ProjetoData
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Se não usar o UoF, precisaríamos adicionar cada Repositório://
        services.AddScoped<IAutorRepository, AutorRepository>();
    }
        public static void RegisterContexts(IServiceCollection services, string conn)
    {
        services.AddDbContext<BibliotecaDbContext>(options => options.UseNpgsql(conn));
    }

        public static void RegisterMappers(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.ViewModels.Mapping.MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
    
}