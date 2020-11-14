using ProjBiblioteca.Domain.Interfaces;
using ProjBiblioteca.Infrastructure.Data.Context;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace ProjBiblioteca.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected BibliotecaDbContext _context;

        public Repository(BibliotecaDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}